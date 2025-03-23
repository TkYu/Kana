namespace Kana.Pages
{
    public class ChartBase : ContentPage
    {
        private readonly StackLayout stackLayout;
        private readonly AbsoluteLayout absoluteLayout;
        private readonly int matrixWidth;
        private readonly int matrixHeight;
        

        public ChartBase(KanaChar[,] matrix)
        {
            stackLayout = new StackLayout
            {
                Spacing = 6,
                Margin = 5
            };
            stackLayout.SizeChanged += Layout_SizeChanged;

            matrixWidth = matrix.GetLength(1);
            matrixHeight = matrix.GetLength(0);

            absoluteLayout = new AbsoluteLayout
            {
                // HorizontalOptions = new LayoutOptions(LayoutAlignment.Fill, true),
                // VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true)
            };
            var squares = matrix.ToKanaSquares();
            foreach (var square in squares)
            {
                if (!string.IsNullOrEmpty(square.KanaChar.PhoneticSymbol))
                {
                    var tapGestureRecognizer = new TapGestureRecognizer
                    {
                        Command = new Command(OnSquareTapped),
                        CommandParameter = square
                    };
                    square.GestureRecognizers.Add(tapGestureRecognizer);
                }
                absoluteLayout.Add(square);
            }
            // Padding = new Thickness(0, Global.OnPlatform(30, 0, 0), 0, 0);
            stackLayout.Add(absoluteLayout);
            Content = stackLayout;
        }

        private void Layout_SizeChanged(object sender, EventArgs e)
        {
            double width = stackLayout.Width;
            double height = stackLayout.Height;

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
                AbsoluteLayout.SetLayoutBounds(square, new Rect(square.Col * squareW + shift, square.Row * squareH, squareW, squareH));
            }
        }

        public double FontFactor { get; set; } = 0.4;
        
        async void OnSquareTapped(object parameter)
        {
            var tappedSquare = (KanaSquare)parameter;
            await tappedSquare.AnimateWinAsync();
        }
    }
}
