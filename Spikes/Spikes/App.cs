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

            return new JsonWebServicePage();

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
