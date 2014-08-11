using System;
using Xamarin.Forms;
using Spikes.Pages;

namespace Spikes {
	public class MainPage : ContentPage {

		private ListView listView;

		public MainPage() {
			var layout = new StackLayout() {
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			listView = new ListView() {
				RowHeight = 40,
				ItemsSource = new string[] {
					"Json",
					"MVVM",
					"WebView"
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
					Navigation.PushAsync(new MvvmPage());
					break;
				case "WebView":
					Navigation.PushAsync(new WebViewPage());
					break;
				default:
					throw new ArgumentOutOfRangeException("Unknown page");
			}
		}
			
	}
}

