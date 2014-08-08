using System.Diagnostics;
using System.Threading.Tasks;
using Spikes.Services;
using Xamarin.Forms;

namespace Spikes.Pages {

    public class JsonWebServicePage : ContentPage {

        public JsonWebServicePage() {
            Title = "JSON Webservice Spike";

            var layout = new StackLayout() {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0,Device.OnPlatform(20,0,0),0,0),
                Children = {
                    new Label() {
                        Text = "Webservice Spike",
                        HorizontalOptions = LayoutOptions.Center,
                        Font = Font.SystemFontOfSize(NamedSize.Medium)
                    }
                }
            };

            var button = new Button() {
                Text = "Get Data",
                HorizontalOptions = LayoutOptions.Center,
            };

            button.Clicked += async (sender, args) =>  {
                IJsonTestService service = new JsonTestService();
                var response = await service.GetDateTimeAsync();
                Debug.WriteLine(response);
            };

            layout.Children.Add(button);

            Content = layout;
        }

    }

}