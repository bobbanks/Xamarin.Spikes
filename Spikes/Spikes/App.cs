using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spikes.Pages;
using Xamarin.Forms;

namespace Spikes
{
    public class App {

        private static Page homeView;

        public static Page GetMainPage() {
            return homeView ?? (homeView = new NavigationPage(new MainPage()));
        }
    }
}
