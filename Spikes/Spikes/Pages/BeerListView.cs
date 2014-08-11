using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Spikes.Model;
using Spikes.ViewModel;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Spikes {

    public class BeerListView : BasePage {

        private BeerListViewModel ViewModel {
            get { return BindingContext as BeerListViewModel; }
        }

		ListView listView;

		public BeerListView() {

		    BindingContext = new BeerListViewModel();
		    var refresh = new ToolbarItem() {
		        Command = ViewModel.LoadItemsCommand,
		        Icon = "refresh.png",
		        Name = "refresh",
                Order = ToolbarItemOrder.Default
		    };

            ToolbarItems.Add(refresh);

			var layout = new StackLayout() {
				VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0,8,0,8)
			};

		    var activity = new ActivityIndicator {
		        Color = Color.Accent,
		        IsEnabled = true
		    };

            activity.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
            activity.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            layout.Children.Add(activity);

			listView = new ListView() {
				RowHeight = 40,
				ItemsSource = ViewModel.Beers
			};

		    listView.ItemTapped += (sender, args) => {
		        if (listView.SelectedItem == null) {
		            return;
		        }

		        Navigation.PushAsync(new BeerDetailView(listView.SelectedItem as BeerDetailModel));
		        listView.SelectedItem = null;
		    };

			listView.ItemTemplate = new DataTemplate( () => {
				Label nameLabel = new Label() {
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center
				};
				nameLabel.SetBinding(Label.TextProperty, "Name");

				Label ratingLabel = new Label() {
					VerticalOptions  = LayoutOptions.Center,
					HorizontalOptions = LayoutOptions.EndAndExpand,
					Font = Font.SystemFontOfSize(NamedSize.Medium),
					BackgroundColor = Color.Green,
					HeightRequest = 40,
					WidthRequest = 40,
					XAlign = TextAlignment.Center,
					YAlign = TextAlignment.Center
				};
				ratingLabel.SetBinding(Label.TextProperty, new Binding("Rating",BindingMode.OneWay,null,null, "{0}"));

				return new ViewCell {
					View = new StackLayout {
						Padding = new Thickness(5,5),
						Orientation = StackOrientation.Horizontal,
						Children = {
							nameLabel,
							ratingLabel
						}
					}
				};
			});

			layout.Children.Add(listView);

			Content = layout;
		}

        protected override void OnAppearing() {
            base.OnAppearing();

            if (ViewModel == null || !ViewModel.CanLoadMore || ViewModel.IsBusy || ViewModel.Beers.Count > 0)
                return;

            ViewModel.LoadItemsCommand.Execute(null);
        }

    }
}