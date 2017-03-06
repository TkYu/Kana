using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kana.Models;
using Xamarin.Forms;

namespace Kana
{
    public class KanaSquare : ContentView
    {
        private readonly Label label;
        private readonly KanaChar kanaChar;
        private bool isReverse;
        public int Row { get; }
        public int Col { get; }

        public KanaChar KanaChar => kanaChar;

        public KanaSquare(KanaChar kana,int row,int col)
        {
            Row = row;
            Col = col;
            kanaChar = kana;
            label = new Label
            {
                Text = $"{kanaChar.Hiragana}、{kanaChar.Katakana}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            Label tinyLabel = new Label
            {
                Text = kanaChar.Romaji,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End
            };

            Padding = new Thickness(3);
            if (kanaChar.OldCharObsoleted)
            {
                Content = new Frame
                {
                    OutlineColor = Color.Accent,
                    Padding = new Thickness(5, 10, 5, 0),
                    Content = new Grid
                    {
                        Children =
                        {
                            new Label
                            {
                                Text = "*",
                                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                                VerticalOptions = LayoutOptions.Start,
                                HorizontalOptions = LayoutOptions.Start
                            },
                            label,
                            tinyLabel
                        }
                    }
                };
            }
            else
            {
                Content = new Frame
                {
                    OutlineColor = Color.Accent,
                    Padding = new Thickness(5, 10, 5, 0),
                    Content = new Grid
                    {
                        Children =
                        {
                            label,
                            tinyLabel
                        }
                    }
                };
            }
            BackgroundColor = Color.Transparent;
        }

        public async Task AnimateWinAsync()
        {
            isReverse = !isReverse;
            uint length = 150;
            await Task.WhenAll(this.ScaleTo(2, length), this.RotateTo(180, length));
            label.Text = isReverse ? kanaChar.PhoneticSymbol : $"{kanaChar.Hiragana}、{kanaChar.Katakana}";
            await Task.WhenAll(this.ScaleTo(1, length), this.RotateTo(360, length));
            Rotation = 0;
        }

        public void SetLabelFont(double fontSize, FontAttributes attributes)
        {
            label.FontSize = fontSize;
            label.FontAttributes = attributes;
        }
    }
}
