namespace WEB.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<City> Cities { get; set; }

        public HomeIndexViewModel()
        {
            this.Cities = new List<City>();    
        }
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
