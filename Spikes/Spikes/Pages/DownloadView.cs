using System;
using System.Diagnostics;
using Spikes.Interfaces;
using Xamarin.Forms;

namespace Spikes.Pages {

    public class DownloadView : BaseView {

        private Image image;
        private ProgressBar progressBar;

        public DownloadView() {
            Title = "Download";

            var button = new Button {
                Text = "Download",
            };
            button.Clicked += button_Clicked;

            image = new Image {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            progressBar = new ProgressBar() {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var stack = new StackLayout() {
                Padding = new Thickness(10, Device.OnPlatform(20,0,0),10,0),
                Children = {
                    progressBar,
                    button,
                    image
                }
            };

            Content = stack;
        }

        async void button_Clicked(object sender, System.EventArgs e) {
            var downloadService = DependencyService.Get<IDownloadService>();
            
            var result =  await downloadService.Download("http://eoimages.gsfc.nasa.gov/images/imagerecords/74000/74393/world.topo.200407.3x5400x2700.jpg","sat.jpg",progressBar);
            image.Source = new FileImageSource {
                File = result.Path
            };
        }
    }

}