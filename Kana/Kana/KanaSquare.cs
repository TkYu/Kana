﻿using System;
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
                Text = $"{kanaChar.Hiragana} {kanaChar.Katakana}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            Label tinyLabel = new Label
            {
                Margin = new Thickness(0,0,0,1),
                Text = kanaChar.Romaji,
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Center
            };

            Padding = new Thickness(3);
            var card = new Grid
            {
                Children =
                {
                    label,
                    tinyLabel
                }
            };
            if (kanaChar.OldCharObsoleted)
            {
                card.Children.Add(new Label
                {
                    Text = "*",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start
                });
            }
            Content = new Frame
            {
                HasShadow = Global.ShowFrameShadow,
                OutlineColor = Color.Accent,
                Padding = new Thickness(3, 3, 3, 0),
                Content = card
            };
            BackgroundColor = Color.Transparent;
        }

        public async Task AnimateWinAsync()
        {
            isReverse = !isReverse;

            uint length = 150;
            //await (isReverse ? this.RotateXTo(180, length) : this.RotateXTo(-180, length));
            await this.RotateXTo(180, length);
            label.Text = isReverse ? kanaChar.PhoneticSymbol : $"{kanaChar.Hiragana} {kanaChar.Katakana}";
            await this.RotateXTo(0, length);
            //await (isReverse ? this.RotateXTo(360, length) : this.RotateXTo(0, length));
            Rotation = 0;
        }

        public void SetLabelFont(double fontSize, FontAttributes attributes)
        {
            label.FontSize = fontSize;
            label.FontAttributes = attributes;
        }
    }
}
