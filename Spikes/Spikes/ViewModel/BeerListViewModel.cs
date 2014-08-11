using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Spikes.Model;
using Xamarin.Forms;

namespace Spikes.ViewModel {

    public class BeerListViewModel : BaseViewModel {

        public BeerListViewModel() {
            Title = "Beer List";
        }

        private ObservableCollection<BeerDetailModel> beers = new ObservableCollection<BeerDetailModel>();
        public ObservableCollection<BeerDetailModel> Beers {
            get { return beers; }
            set { beers = value; OnPropertyChanged("Beers"); }
        }

        private BeerDetailModel selectedBeer;
        public BeerDetailModel SelectedBeer {
            get { return selectedBeer; }
            set { selectedBeer = value; OnPropertyChanged("SelectedBeer"); }
        }

        private Command loadItemsCommand;

        public Command LoadItemsCommand {
            get { return loadItemsCommand ?? (loadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand())); }
        }

        private async Task ExecuteLoadItemsCommand() {
            if (IsBusy)
                return;

            IsBusy = true;

            try {
                var beerDataService = new BeerDataService();
                var beerData = await Task.Run((Func<IEnumerable<BeerDetailModel>>) beerDataService.All);
                Beers.Clear();
                foreach (var beerSummaryModel in beerData) {
                    Beers.Add(beerSummaryModel);
                }
            } catch (Exception ex) {
                var page = new ContentPage();
                var result = page.DisplayAlert("Error", "Unable to load beers.", "OK", null);
            }

            IsBusy = false;
        }

    }

}