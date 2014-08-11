using System;
using System.Collections.Generic;
using Spikes.Model;

namespace Spikes {

	public interface IBeerDataService {
		List<BeerDetailModel> All();
	}

	public class BeerDataService : IBeerDataService {

		public List<BeerDetailModel> All() {
		    for (int i = 0; i < 100000000; i++) {
		        
		    }
			var list = new List<BeerDetailModel> { 
				new BeerDetailModel {
					Name = "Dogfish 60 Minute IPA",
                    BreweryName = "Dogfish Head",
					Rating = 85
				},
				new BeerDetailModel {
					Name = "Dogfish 75 Minute IPA",
                    BreweryName = "Dogfish Head",
					Rating = 90
				},
				new BeerDetailModel {
					Name = "Chimay Première (Red)",
                    BreweryName = "Dogfish Head",
					Rating = 85
				},
				new BeerDetailModel {
					Name = "Supplication",
                    BreweryName = "Dogfish Head",
					Rating = 95
				}
			};
			return list;
		}
	}
}

