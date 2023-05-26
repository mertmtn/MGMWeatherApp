namespace WEB.ViewModels
{
    public class StationCreateViewModel
    {
        public string? Name { get; set; }
        public int StationNumber { get; set; }
        public string? ICAO { get; set; }
        public int SelectedCityId { get; set; }
        public int SelectedDistrictId { get; set; }
        public string? GoogleMapsUrl { get; set; }
    }
}
