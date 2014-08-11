using Spikes.ViewModel;
using Xamarin.Forms;

namespace Spikes {

    public class BasePage : ContentPage {

        public BasePage()
        {
            SetBinding (Page.TitleProperty, new Binding(BaseViewModel.TitlePropertyName));
            SetBinding (Page.IconProperty, new Binding(BaseViewModel.IconPropertyName));
        }        

    }

}