using System.IO;
using System.Reflection;
using Xamarin.Forms;

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

}