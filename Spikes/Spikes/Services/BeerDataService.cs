using System;
using System.Collections.Generic;

namespace Spikes {

	public interface IBeerDataService {
		List<Beer> All();
	}

	public class BeerDataService {

		public List<Beer> All() {
			var list = new List<Beer> { 
				new Beer {
					Name = "Dogfish 60 Minute IPA",
					Rating = 85
				},
				new Beer {
					Name = "Dogfish 75 Minute IPA",
					Rating = 90
				},
				new Beer {
					Name = "Chimay Première (Red)",
					Rating = 85
				},
				new Beer {
					Name = "Supplication",
					Rating = 95
				}
			};
			return list;
		}
	}
}

