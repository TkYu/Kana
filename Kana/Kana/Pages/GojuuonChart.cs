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
    public class GojuuonChart : ContentPage
    {
        private AbsoluteLayout absoluteLayout;
        private readonly int matrixWidth;
        private readonly int matrixHeight;
        

        public GojuuonChart(KanaChar[,] matrix)
        {
            matrixWidth = matrix.GetLength(1);
            matrixHeight = matrix.GetLength(0);
            absoluteLayout = new AbsoluteLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var squares = matrix.ToKanaSquares();
            foreach (var square in squares)
            {
                if (!string.IsNullOrEmpty(square.KanaChar.PhoneticSymbol))
                {
                    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer
                    {
                        Command = new Command(OnSquareTapped),
                        CommandParameter = square
                    };
                    square.GestureRecognizers.Add(tapGestureRecognizer);
                }
                absoluteLayout.Children.Add(square);
            }
            absoluteLayout.SizeChanged += AbsoluteLayout_SizeChanged;
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            
            Content = absoluteLayout;
        }

        public double FontFactor { get; set; } = 0.4;
        private void AbsoluteLayout_SizeChanged(object sender, EventArgs e)
        {
            double width = absoluteLayout.Width;
            double height = absoluteLayout.Height;

            if (width <= 0 || height <= 0)
                return;
            var squareW = matrixWidth > 4 ? width / matrixWidth : width * 0.85 / matrixWidth;
            var squareH = height / matrixHeight;
            var gold = squareW * 0.618;
            if (squareH > gold) squareH = gold;
            absoluteLayout.WidthRequest = matrixWidth * squareW;
            absoluteLayout.HeightRequest = matrixHeight * squareH;
            var shift = matrixWidth > 4 ? 0 : (width - squareW * matrixWidth)/2;
            foreach (var view in absoluteLayout.Children)
            {
                var square = (KanaSquare)view;
                square.SetLabelFont(FontFactor * squareH, FontAttributes.Bold);
                AbsoluteLayout.SetLayoutBounds(square, new Rectangle(square.Col * squareW + shift, square.Row * squareH, squareW, squareH));
            }
        }

        async void OnSquareTapped(object parameter)
        {
            var tappedSquare = (KanaSquare)parameter;
            await tappedSquare.AnimateWinAsync();
        }
    }
}
