﻿using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace Spikes {

	public class WebViewPage : ContentPage {
		public WebViewPage() {

			var assembly = typeof(WebViewPage).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("Spikes.Resources.article.html");
			string text = "";
			using (var reader = new System.IO.StreamReader (stream)) {
				text = reader.ReadToEnd ();
			}

			var webView = new WebView() {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Source = new HtmlWebViewSource() {
					Html = text
				},

			};

			var view = new ScrollView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Content = new StackLayout() {
					Children = {
						webView
					}
				}
			};

			this.Content = view;
		}
	}

	public class MvvmPage : ContentPage {
		ListView listView;
		List<Beer> beers;

		public MvvmPage() {

			beers = new BeerDataService().All();

			Title = "Mvvm Spike";

			var layout = new StackLayout() {
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			listView = new ListView() {
				RowHeight = 40,
				ItemsSource = beers
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
	}
}