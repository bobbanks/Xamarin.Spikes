using System;
using Xamarin.Forms;
using Spikes.Pages;

namespace Spikes {
	public class MainPage : BaseView {

		private ListView listView;

		public MainPage() {
			var layout = new StackLayout() {
				VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };

			listView = new ListView() {
				RowHeight = 40,
				ItemsSource = new string[] {
					"Json",
					"MVVM",
					"WebView",
                    "Quiz",
                    "Download"
				}
			};

			listView.ItemTapped += HandleItemTapped;

			layout.Children.Add(listView);
			Title = "Spikes";
			Content = layout;
		}

		private void HandleItemTapped (object sender, ItemTappedEventArgs e)
		{
			listView.SelectedItem = null;
			var item = (string)e.Item;
			switch (item) {
				case "Json":
				 	Navigation.PushAsync(new JsonWebServicePage());
					break;
				case "MVVM":
					Navigation.PushAsync(new BeerListView());
					break;
				case "WebView":
					Navigation.PushAsync(new WebViewPage());
					break;
				case "Quiz":
					Navigation.PushAsync(new QuizView());
					break;
				case "Download":
					Navigation.PushAsync(new DownloadView());
					break;
				default:
					throw new ArgumentOutOfRangeException("Unknown page");
			}
		}
			
	}
}

