using Spikes.ViewModel;
using Xamarin.Forms;

namespace Spikes {

    public class BaseView : ContentPage {

        public BaseView() {
            BackgroundColor = Color.White;
            SetBinding (Page.TitleProperty, new Binding(BaseViewModel.TitlePropertyName));
            SetBinding (Page.IconProperty, new Binding(BaseViewModel.IconPropertyName));
        }        

    }

}