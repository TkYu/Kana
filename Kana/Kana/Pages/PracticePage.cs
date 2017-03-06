using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Kana.Models;
using Xamarin.Forms;

namespace Kana.Pages
{
    public class PracticePage : ContentPage
    {
        class AnswerPad:Button
        {
            public int Row { get; }
            public int Col { get; }

            public bool AcceptEvent { get; set; } = true;
            public AnswerPad(string text, int row, int col)
            {
                Text = text;
                Row = row;
                Col = col;
                TextColor = Color.White;
                BackgroundColor = Color.FromHex("00A0E9");
            }
            public void SetLabelFont(double fontSize, FontAttributes attributes)
            {
                FontSize = fontSize;
                FontAttributes = attributes;
            }
        }

        bool isPlaying = false;

        StackLayout stackLayout;
        AbsoluteLayout absoluteLayout;
        private readonly Label timeLabel;

        private readonly Label scoreLabel;

        private readonly Label currentKana;
        private string currentAnswer;

        DateTime startTime = DateTime.Now;
        public PracticePage()
        {
            InitKanaPool();

            absoluteLayout = new AbsoluteLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    var btn = new AnswerPad("", row, col);
                    btn.Clicked += Btn_Clicked;
                    absoluteLayout.Children.Add(btn);
                }
            }
            var headingLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Label {
                        Text = "一期",
                        HorizontalTextAlignment = TextAlignment.End,
                        FontSize = 30,
                        TextColor = Color.FromHex ("#34495E")
                    },
                    new Label {
                        Text = "一会",
                        HorizontalTextAlignment = TextAlignment.Start,
                        FontSize = 30,
                        TextColor = Color.FromHex ("#3498DB")
                    }
                }
            };
            
            currentKana = new Label
            {
                Text = "あ",
                FontSize = 72,
                Scale = 1.5,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            scoreLabel = new Label
            {
                Text = "0/0",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            timeLabel = new Label
            {
                Text = "00:00",
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            var midLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    scoreLabel,
                    timeLabel
                }
            };

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                if (isPlaying)
                {
                    TimeSpan timeSpan = DateTime.Now - startTime + TimeSpan.FromSeconds(0.5);
                    timeSpan = new TimeSpan(timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
                    timeLabel.Text = timeSpan.ToString("t");
                }
                return true;
            });
            stackLayout = new StackLayout
            {
                Children =
                {
                    new StackLayout
                    {
                        VerticalOptions = LayoutOptions.EndAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Padding = new Thickness(0,40,0,20),
                        Children =
                        {
                            headingLayout,
                            midLayout,
                            new Frame
                            {
                                OutlineColor = Color.Accent,
                                Padding = new Thickness(10),
                                Content = currentKana
                            }
                        }
                    },
                    absoluteLayout
                }
            };
            stackLayout.SizeChanged += OnStackSizeChanged;
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            Content = stackLayout;
        }


        private void OnStackSizeChanged(object sender, EventArgs args)
        {
            double width = stackLayout.Width;
            double height = stackLayout.Height;

            if (width <= 0 || height <= 0)
                return;

            // Orient StackLayout based on portrait/landscape mode.
            stackLayout.Orientation = (width < height) ? StackOrientation.Vertical : StackOrientation.Horizontal;

            // Calculate square size and position based on stack size.
            var squareSize = Math.Min(width, height) / Device.OnPlatform(iOS: 5, Android: 5, WinPhone: 5);
            absoluteLayout.WidthRequest = 5 * squareSize;
            absoluteLayout.HeightRequest = 5 * squareSize;
            var padding = Device.OnPlatform(iOS: 15.0, Android: 2.0, WinPhone: 10.0);
            foreach (View view in absoluteLayout.Children)
            {
                AnswerPad btn = (AnswerPad)view;
                btn.SetLabelFont(0.35 * squareSize, FontAttributes.None);
                AbsoluteLayout.SetLayoutBounds(btn, new Rectangle(btn.Col * squareSize + padding/2, btn.Row * squareSize, squareSize - padding, squareSize - padding));
            }
        }

        private async void Btn_Clicked(object sender, EventArgs e)
        {
            AnswerPad btn = (AnswerPad)sender;
            if (btn.AcceptEvent)
            {
                if (!isPlaying)
                {
                    startTime = DateTime.Now;
                    isPlaying = true;
                }
                if (currentAnswer == btn.Text)
                {
                    await ResetQuestion();
                }
                else
                {
                    await btn.ScaleTo(1.1, 50, Easing.SpringIn);
                    btn.BackgroundColor = Color.FromHex("EB3C00");
                    await btn.ScaleTo(1, 50, Easing.SpringOut);
                    btn.AcceptEvent = false;
                }
            }
        }

        private Stack<KanaChar> KanaPool;
        private void InitKanaPool()
        {
            List<KanaChar> lst = Kanas.Seion.Cast<KanaChar>().Where(kana => kana != null).ToList();
            lst.AddRange(Kanas.Dakuon.Cast<KanaChar>());
            KanaPool = CreateShuffledDeck(lst);
        }

        private KanaChar[] TakeSome(int len)
        {
            var result = new KanaChar[len];
            if (KanaPool.Count < len) InitKanaPool();
            for (int i = 0; i < len; i++)
            {
                result[i] = KanaPool.Pop();
            }
            return result;
        }

        private int total = 0;
        private int okay = 0;
        private async Task ResetQuestion()
        {
            total++;
            bool haveBad = false;
            var rd = new Random();
            currentAnswer = null;

            List<Task> tsk = new List<Task>();
            uint inc = 70;

            foreach (View view in absoluteLayout.Children)
            {
                AnswerPad btn = (AnswerPad)view;

                btn.TextColor = Color.White;
                btn.BackgroundColor = Color.FromHex("00A0E9");
                btn.AcceptEvent = true;

                
                tsk.Add(btn.RotateXTo(180, inc));
                btn.Text = "";

                inc += 60;
            }

            if (!haveBad) okay++;
            if (isPlaying) scoreLabel.Text = $"{okay}/{total}";
            tsk.Add(currentKana.ScaleTo(0));
            await Task.WhenAll(tsk);

            tsk.Clear();

            

            var take = TakeSome(absoluteLayout.Children.Count);
            var da = rd.Next(0, take.Length - 1);
            for (int i = 0; i < absoluteLayout.Children.Count; i++)
            {
                inc -= 60;

                AnswerPad btn = (AnswerPad)absoluteLayout.Children[i];
                if (!btn.AcceptEvent) haveBad = true;
                var cc = take[i];
                if (i == da && currentAnswer == null)
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

        private static Stack<T> CreateShuffledDeck<T>(IEnumerable<T> values)
        {
            var rand = new Random();

            var list = new List<T>(values);
            var stack = new Stack<T>();

            while (list.Count > 0)
            {
                // Get the next item at random.
                var index = rand.Next(0, list.Count);
                var item = list[index];

                // Remove the item from the list and push it to the top of the deck.
                list.RemoveAt(index);
                stack.Push(item);
            }

            return stack;
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
