using System.IO;
using System.Reflection;
using Xamarin.Forms;
using System.Diagnostics;

namespace Spikes
{

    public class WebViewPage : BaseView {

        public WebViewPage() {

            var assembly = typeof (WebViewPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Spikes.Resources.article.html");

            using (var reader = new System.IO.StreamReader(stream)) {
                string text = reader.ReadToEnd();
                var webView = new WebView() {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Source = new HtmlWebViewSource() {
                        Html = text
                    }
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

}