using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spikes.Pages;
using Xamarin.Forms;

namespace Spikes
{
    public class App
    {
        public static Page GetMainPage()
        {
			var mainNav = new NavigationPage(new MainPage()) {
				Tint = Color.Red
			};
			return mainNav;

//            return new ContentPage
//            {
//                Content = new Label
//                {
//                    Text = "Hello, Forms !",
//                    VerticalOptions = LayoutOptions.CenterAndExpand,
//                    HorizontalOptions = LayoutOptions.CenterAndExpand,
//                },
//            };
        }
    }
}
