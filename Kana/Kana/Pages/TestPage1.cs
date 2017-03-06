using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Kana.Pages
{
    public class TestPage1 : ContentPage
    {

        StackLayout layout;
        private bool inited;
        public TestPage1()
        {
            layout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 8,
                Padding = 16
            };

            var headingLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Label {
                        Text = "Xamarin",
                        HorizontalTextAlignment = TextAlignment.End,
                        FontSize = 30,
                        TextColor = Color.FromHex ("#34495E")
                    },
                    new Label {
                        Text = "Insights",
                        HorizontalTextAlignment = TextAlignment.Start,
                        FontSize = 30,
                        TextColor = Color.FromHex ("#3498DB")
                    }
                }
            };
            layout.Children.Add(headingLayout);

            var instructionsLabel = new Label()
            {
                Text = "touch a button",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center
            };
            layout.Children.Add(instructionsLabel);

            var buttonLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = 20,
                Spacing = 10
            };

            var trackButton = new Button()
            {
                Text = "tsu",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                MinimumWidthRequest = 30,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("ECECEC")
            };
            buttonLayout.Children.Add(trackButton);

            var identifyButton = new Button()
            {
                Text = "pe",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                MinimumWidthRequest = 30,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("DADFE1")
            };
            buttonLayout.Children.Add(identifyButton);

            var warningButton = new Button()
            {
                Text = "pi",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                MinimumWidthRequest = 30,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.FromHex("F4D03F")
            };
            buttonLayout.Children.Add(warningButton);

            var errorButton = new Button()
            {
                Text = "pa",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                MinimumWidthRequest = 30,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.FromHex("EF4836")
            };
            buttonLayout.Children.Add(errorButton);

            var crashButton = new Button()
            {
                Text = "mmm",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                MinimumWidthRequest = 30,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.FromHex("CF000F")
            };
            buttonLayout.Children.Add(crashButton);

            layout.Children.Add(buttonLayout);

            Padding = Device.OnPlatform<Thickness>(new Thickness(0, 20, 0, 0), 0, 0);

            foreach (var view in layout.Children)
            {
                // Hide all the children
                view.Scale = 0;
            }

            Content = new ScrollView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = layout
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (inited)
            {
                //await DisplayAlert("API Key Missing", "Update your API key in Constants.cs first, then launch the app.", "OK");
            }
            else
            {
                inited = true;
                foreach (var view in layout.Children)
                {
                    await view.ScaleTo(1.1, 50, Easing.SpringIn);
                    await view.ScaleTo(1, 50, Easing.SpringOut);
                }
            }
            
        }
    }
}
