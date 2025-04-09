using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kana.Pages
{
    public class PracticePage : ContentPage
    {
        #region AnswerPad

        class AnswerPad : Button
        {
            public int Row { get; }
            public int Col { get; }

            public bool AcceptEvent { get; set; } = true;
            public AnswerPad(string text, int row, int col)
            {
                Text = text;
                Row = row;
                Col = col;
                TextColor = Colors.White;
                BackgroundColor = Color.FromArgb("00A0E9");

                LineBreakMode = LineBreakMode.NoWrap;
                FontAutoScalingEnabled = true;
            }
            public void SetLabelFont(double fontSize, FontAttributes attributes)
            {
                FontSize = fontSize;
                FontAttributes = attributes;
            }
        }

        #endregion

        #region properties
        

        private bool isPlaying;

        private readonly StackLayout stackLayout;
        private readonly AbsoluteLayout absoluteLayout;

        private readonly Label lblS1;
        private readonly Label lblS2;
        private readonly Label timeLabel;
        private readonly Label scoreLabel;

        private readonly Label currentKana;
        private string currentAnswer = "";

        DateTime startTime = DateTime.Now;

        private double FontFactor { get; set; }

        private const int NUM_PADLEN = 4;
        #endregion

        public PracticePage()
        {
            var screenSize = DeviceDisplay.MainDisplayInfo;
            var screenWidth = screenSize.Width / screenSize.Density;
            var screenHeight = screenSize.Height / screenSize.Density;
            var screenSizeFactor = Math.Min(screenWidth, screenHeight) / 1000;
            FontFactor = Math.Max(0.3, Math.Min(0.35, screenSizeFactor));

            InitKanaPool();
            
            absoluteLayout = new AbsoluteLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < NUM_PADLEN; col++)
                {
                    var btn = new AnswerPad("", row, col);
                    btn.Clicked += Btn_Clicked;
                    absoluteLayout.Children.Add(btn);
                }
            }
            

            #region labels

            lblS1 = new Label
            {
                Text = "一期",
                FontFamily = Global.YSFontFamily,
                HorizontalTextAlignment = TextAlignment.End,
                // FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 2,
                FontSize = 58,
                TextColor = Color.FromArgb("#34495E")
            };
            lblS2 = new Label
            {
                Text = "一会",
                FontFamily = Global.YSFontFamily,
                HorizontalTextAlignment = TextAlignment.Start,
                // FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 2,
                FontSize = 58,
                TextColor = Color.FromArgb("#3498DB")
            };
            currentKana = new Label
            {
                Text = "あ",
                FontFamily = Global.YSFontFamily,
                // FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) * 6,
                FontSize = 100,
                //Scale = 1.5,
                // FontFamily = displayFontFamily,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            //System.Diagnostics.Debug.WriteLine($"{Device.GetNamedSize(NamedSize.Large, typeof(Label))}:{Width}");
            scoreLabel = new Label
            {
                Text = "0/0",
                // FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            timeLabel = new Label
            {
                Text = "00:00:00",
                // FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            #endregion

            #region layouts

            var headingLayout = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    lblS1,
                    lblS2
                }
            };

            var midLayout = new StackLayout
            {
                Padding = new Thickness(0, 0, 0, 20),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    scoreLabel,
                    new Label
                    {
                        Text = "|"
                    },
                    timeLabel
                }
            };

            var fm = new Frame
            {
                HasShadow = Global.ShowFrameShadow,
                // OutlineColor = Color.Accent,
                Padding = new Thickness(10,10,10,20),
                Content = currentKana
            };
            stackLayout = new StackLayout
            {
                //Padding = new Thickness(0, 40, 0, 20),
                Children =
                {
                    new StackLayout
                    {
                        VerticalOptions = LayoutOptions.End,
                        HorizontalOptions = LayoutOptions.Center,
                        Padding = new Thickness(0,10,0,40),
                        Children =
                        {
                            headingLayout,
                            midLayout,
                            fm
                        }
                    },
                    absoluteLayout
                }
            };
            
            #endregion

            stackLayout.SizeChanged += OnStackSizeChanged;

            Content = stackLayout;

            var timer = Application.Current?.Dispatcher.CreateTimer();
            if(timer==null)return;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                if (!isPlaying) return;
                var timeSpan = DateTime.Now - startTime + TimeSpan.FromSeconds(0.5);
                timeSpan = new TimeSpan(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                timeLabel.Text = timeSpan.ToString("t");
            };
            timer.Start();
        }


        private void OnStackSizeChanged(object? sender, EventArgs args)
        {
            double width = stackLayout.Width;
            double height = stackLayout.Height;

            if (width <= 0 || height <= 0)
                return;

            stackLayout.Orientation = width < height ? StackOrientation.Vertical : StackOrientation.Horizontal;

            var squareSize = Math.Min(width, height) / (NUM_PADLEN + Global.OnPlatform(1, 0.5, 0.5));
            absoluteLayout.WidthRequest = NUM_PADLEN * squareSize;
            absoluteLayout.HeightRequest = NUM_PADLEN * squareSize;
            var padding = Global.OnPlatform(10.0, 2.0, 10.0);
            foreach (var view in absoluteLayout.Children)
            {
                var btn = (AnswerPad)view;
                btn.SetLabelFont(0.3 * squareSize, FontAttributes.None);
                AbsoluteLayout.SetLayoutBounds(btn, new Rect(btn.Col * squareSize + padding/2, btn.Row * squareSize, squareSize - padding, squareSize - padding));
                //AbsoluteLayout.SetLayoutBounds(btn, new Rectangle(btn.Col * squareSize, btn.Row * squareSize, squareSize, squareSize));
            }
        }

        private readonly List<string> learnedList = new List<string>();
        private async void Btn_Clicked(object sender, EventArgs e)
        {
            if (sender == null) return;
            var btn = (AnswerPad)sender;
            if (btn.AcceptEvent)
            {
                if (!isPlaying)
                {
                    startTime = DateTime.Now;
                    isPlaying = true;
                }
                if (currentAnswer == btn.Text)
                {
                    if(learnedList.Count > 60)
                        learnedList.Clear();
                    learnedList.Add(currentAnswer);
                    await ResetQuestion();
                }
                else
                {
                    await btn.ScaleTo(1.1, 50, Easing.SpringIn);
                    btn.BackgroundColor = Color.FromArgb("EB3C00");
                    await btn.ScaleTo(1, 50, Easing.SpringOut);
                    btn.AcceptEvent = false;
                }
            }
        }

        private Stack<KanaChar> KanaPool;
        private void InitKanaPool()
        {
            var lst = KanaChars.Seion.Cast<KanaChar>().Where(kana => kana is { OldCharObsoleted: false }).ToList();
            lst.AddRange(KanaChars.Dakuon.Cast<KanaChar>());
            KanaPool = lst.CreateShuffledDeck();
        }

        private KanaChar[] TakeSome(int len)
        {
            var result = new KanaChar[len];
            if (KanaPool.Count < len) 
                InitKanaPool();
            for (var i = 0; i < len; i++)
            {
                result[i] = KanaPool.Pop();
            }
            return result;
        }

        private int total;
        private int okay;

        private async Task ResetQuestion()
        {
            total++;
            bool haveBad = false;
            var rd = new Random();
            currentAnswer = null;

            List<Task> tsk = new List<Task>();
            uint inc = 70;

            foreach (var view in absoluteLayout.Children)
            {
                var btn = (AnswerPad)view;

                if (!btn.AcceptEvent) haveBad = true;

                btn.TextColor = Colors.White;
                btn.BackgroundColor = Color.FromArgb("00A0E9");
                btn.AcceptEvent = true;

                
                tsk.Add(btn.RotateXTo(180, inc));
                btn.Text = "";

                inc += 60;
            }

            if (!haveBad) okay++;
            if (total % 10 == 0)
            {
                var cy = KanaChars.Yojijukugo[rd.Next(0, KanaChars.Yojijukugo.Length - 1)];
                lblS1.Text = cy.Substring(0, 2);
                lblS2.Text = cy.Substring(2, 2);
            }
            if (isPlaying) scoreLabel.Text = $"{okay}/{total}";
            tsk.Add(currentKana.ScaleTo(0));
            await Task.WhenAll(tsk);

            tsk.Clear();

            var take = TakeSome(absoluteLayout.Children.Count);
            var selectIndex = -1;
            var randomIndex = rd.Next(0, take.Length - 1);
            while (selectIndex < 0)
            {
                if (!learnedList.Contains(take[randomIndex].Romaji))
                {
                    selectIndex = randomIndex;
                    break;
                }
                selectIndex -= 1;
                randomIndex = rd.Next(0, take.Length - 1);
                if (selectIndex <= -absoluteLayout.Children.Count - 1)
                    take = TakeSome(absoluteLayout.Children.Count);
            }

            for (int i = 0; i < absoluteLayout.Children.Count; i++)
            {
                inc -= 60;

                var btn = (AnswerPad)absoluteLayout.Children[i];
                
                var cc = take[i];
                if (i == selectIndex && currentAnswer == null)
                {
                    currentKana.Text = rd.Next(0, 100) < 50 ? cc.Hiragana : cc.Katakana;
                    currentAnswer = cc.Romaji;
                }

                
                tsk.Add(btn.RotateXTo(0, inc));

                btn.Text = cc.Romaji;
            }

            tsk.Add(currentKana.ScaleTo(1));
            await Task.WhenAll(tsk);
        }

        

        protected override async void OnAppearing()
        {
            isPlaying = false;
            timeLabel.Text = "00:00:00";
            await ResetQuestion();
            okay = total = 0;
            scoreLabel.Text = $"{okay}/{total}";
        }
    }
}
