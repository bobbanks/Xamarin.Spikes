using System.Diagnostics;
using System.Threading.Tasks;
using Spikes.Services;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Spikes.Pages {

    public class JsonWebServicePage : BaseView {
		protected Label timeLabel;

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

            button.Clicked += ButtonClicked;

            layout.Children.Add(button);

			timeLabel = new Label() {
				Text = "",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			layout.Children.Add(timeLabel);

            Content = layout;
        }

        private async void ButtonClicked (object sender, System.EventArgs e)
        {
			IJsonTestService service = new JsonTestService();
			var response = await service.GetDateTimeAsync();
			timeLabel.Text = response;
        }

    }

}