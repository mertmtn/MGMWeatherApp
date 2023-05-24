namespace WEB.ViewModels
{
    public class CityDistrictViewModel
    {

    }

    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<District> Districts { get; set; }

        public City()
        {
            this.Districts = new List<District>();
        }
    }

    public class District
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
