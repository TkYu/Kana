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

        private double factor = 1;

        public GojuuonChart(KanaChar[,] matrix)
        {
            matrixWidth = matrix.GetLength(1);
            matrixHeight = matrix.GetLength(0);
            absoluteLayout = new AbsoluteLayout()
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

        public double fontFactor { get; set; } = 0.4;
        private void AbsoluteLayout_SizeChanged(object sender, EventArgs e)
        {
            double width = absoluteLayout.Width;
            double height = absoluteLayout.Height;

            if (width <= 0 || height <= 0)
                return;
            // Calculate square size and position based on stack size.
            var squareW = width / matrixWidth;
            var squareH = height / matrixHeight;
            var gold = squareW * 0.618;
            if (squareH > gold) squareH = gold;
            absoluteLayout.WidthRequest = matrixWidth * squareW;
            absoluteLayout.HeightRequest = matrixHeight * squareH;

            foreach (View view in absoluteLayout.Children)
            {
                KanaSquare square = (KanaSquare)view;
                square.SetLabelFont(fontFactor * squareH, FontAttributes.Bold);

                AbsoluteLayout.SetLayoutBounds(square,
                    new Rectangle(square.Col * squareW,
                        square.Row * squareH,
                        squareW,
                        squareH));
            }
        }

        async void OnSquareTapped(object parameter)
        {
            KanaSquare tappedSquare = (KanaSquare)parameter;
            await tappedSquare.AnimateWinAsync();
        }
    }
}
