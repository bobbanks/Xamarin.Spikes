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
			var mainNav = new NavigationPage(new MainPage());
			return mainNav;
        }
    }
}
