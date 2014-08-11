namespace Spikes.Model {

    public class BeerDetailModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BreweryId { get; set; }
        public string BreweryName { get; set; }
        public string BreweryLocation { get; set; }
        public string Logo { get; set; }
        public string BreweryLogo { get; set; }
        public int Rating { get; set; } 
    }

}