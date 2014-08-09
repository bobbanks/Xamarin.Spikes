using System;
using Xamarin.Forms;
using Spikes.Pages;

namespace Spikes {
	public class MainPage : ContentPage {
		public MainPage() {
			var layout = new StackLayout() {
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			var listView = new ListView() {
				RowHeight = 40,
				ItemsSource = new string[] {
					"Json"
				}
			};

			listView.ItemTapped += HandleItemTapped;

			layout.Children.Add(listView);
			Title = "Spikes";
			Content = layout;
		}

		private void HandleItemTapped (object sender, ItemTappedEventArgs e)
		{
			var item = (string)e.Item;
			switch (item) {
				case "Json":
				 	Navigation.PushAsync(new JsonWebServicePage());
					break;
				default:
					throw new ArgumentOutOfRangeException("Unknown page");
			}
		}
			
	}
}

