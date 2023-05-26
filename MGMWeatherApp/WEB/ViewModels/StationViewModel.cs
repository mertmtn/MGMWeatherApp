using Entities.Concrete;

namespace WEB.ViewModels
{
    public class StationViewModel
    {
        public List<StationEntity> Stations { get; set; }

        public StationViewModel()
        {
            this.Stations = new List<StationEntity>();
        }
    }

    public class StationEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int StationNumber { get; set; }
        public string? ICAO { get; set; }
        public string? District { get; set; }
        public string? GoogleMapsUrl { get; set; }
    }
}
