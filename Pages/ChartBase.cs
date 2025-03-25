using System.Diagnostics;

namespace Kana.Pages
{
    public class ChartBase : ContentPage
    {
        // private readonly StackLayout stackLayout;
        // private readonly AbsoluteLayout absoluteLayout;
        private readonly int matrixWidth;
        private readonly int matrixHeight;
        
        public ChartBase(KanaChar[,] matrix)
        {
            var stackLayout = new StackLayout
            {
                Spacing = 6,
                Margin = new Thickness(5,Global.OnPlatform(5,5,15))
            };

            stackLayout.SizeChanged += Layout_SizeChanged;
            matrixWidth = matrix.GetLength(1);
            matrixHeight = matrix.GetLength(0);

            var absoluteLayout = new AbsoluteLayout
            {
                // HorizontalOptions = new LayoutOptions(LayoutAlignment.Fill, true),
                // VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true)
            };
            // absoluteLayout.SizeChanged+= Layout_SizeChanged;
            var squares = matrix.ToKanaSquares();
            foreach (var square in squares)
            {
                if (!string.IsNullOrEmpty(square.KanaChar.PhoneticSymbol))
                {
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += async (s, e) => { await (s as KanaSquare)!.AnimateWinAsync(); };
                    square.GestureRecognizers.Add(tapGestureRecognizer);
                }
                absoluteLayout.Add(square);
            }

            stackLayout.Add(absoluteLayout);
            Content = stackLayout;
        }

        private void Layout_SizeChanged(object sender, EventArgs e)
        {
            var stackLayout = Content as StackLayout;
            if (stackLayout == null) return;
            
            var width = stackLayout.Width;
            var height = stackLayout.Height;
            
            var absoluteLayout = stackLayout.Children[0] as AbsoluteLayout;
            if (absoluteLayout == null) return;

            if (width <= 0 || height <= 0)
                return;
            var squareW = matrixWidth > 4 ? width / matrixWidth : width * 0.85 / matrixWidth;
            var squareH = height / matrixHeight;
            var gold = squareW * 0.618;
            if (squareH > gold) squareH = gold;
            absoluteLayout.WidthRequest = matrixWidth * squareW;
            absoluteLayout.HeightRequest = matrixHeight * squareH;
            var shift = matrixWidth > 4 ? 0 : (width - squareW * matrixWidth)/16;
            foreach (var view in absoluteLayout)
            {
                var square = (KanaSquare)view;
                square.SetLabelFont(FontFactor * squareH, FontAttributes.Bold);
                var r = new Rect(square.Col * squareW + shift, square.Row * squareH, squareW, squareH);
                AbsoluteLayout.SetLayoutBounds(square, r);
            }
        }

        public double FontFactor { get; set; } = 0.4;
    }
}
