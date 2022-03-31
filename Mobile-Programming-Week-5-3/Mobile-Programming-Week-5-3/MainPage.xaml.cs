using System;
using System.Reflection;
using Xamarin.Forms;

namespace Mobile_Programming_Week_5_3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            var stackLayout = new StackLayout();
            stackLayout.Orientation = StackOrientation.Vertical;

            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.GetProperty
                                                            | BindingFlags.Static;
            foreach (var info in typeof(Color).GetRuntimeFields())
            {
                if (info.FieldType == typeof(Color) && info.IsPublic)
                {
                    stackLayout.Children.Add(renkYapiGoster((Color)info.GetValue(null), info.Name));
                }

            }
            //foreach (var info in typeof(Color).GetRuntimeProperties())
            //{
            //    if (info.PropertyType == typeof(Color))
            //    {
            //        stackLayout.Children.Add(renkYapiGoster((Color)info.GetValue(null), info.Name));
            //    }

            //}


            Content = new ScrollView
            {
                Content = stackLayout
            };
        }

        private View renkYapiGoster(Color color, string name)
        {
            return new Frame
            {
                BorderColor = Color.Accent,
                Padding = new Thickness(5),
                Content = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 15,
                    Children =
                    {
                        new BoxView
                        {
                            Color = color
                        },
                        new Label
                        {
                            Text = name,
                            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                            FontAttributes = FontAttributes.Bold,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.StartAndExpand
                        },
                        new StackLayout
                        {
                            Children =
                            {
                                new Label
                                {
                                    //Text = color.ToHex(),
                                    Text = String.Format("{0:X2} - {1:X2} - {2:X2} - ",(int) (color.R * 255),(int)
                                        (color.G)*255,
                                        (int) (color.B * 255)),
                                    VerticalOptions = LayoutOptions.CenterAndExpand
                                },
                                new Label
                                {
                                    Text = String.Format("{0:F2} - {1:F2} - {2:F2} - ",(int) color.Hue,(int)color.Saturation,
                                        (int)color.Luminosity),
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
