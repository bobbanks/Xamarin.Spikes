using Spikes.Model;
using Xamarin.Forms;

namespace Spikes {

    public class BeerDetailView : BasePage {
        public BeerDetailView(BeerDetailModel model) {

            Title = model.Name;

            BindingContext = model;
            var beerLabel = new Label() {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold)
            };
            beerLabel.SetBinding(Label.TextProperty, "Name");

            var breweryLabel = new Label() {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            breweryLabel.SetBinding(Label.TextProperty,"BreweryName");

            var layout = new StackLayout {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Children = {
                    beerLabel,
                    breweryLabel
                }
            };

            Content = layout;
        }
    }

}