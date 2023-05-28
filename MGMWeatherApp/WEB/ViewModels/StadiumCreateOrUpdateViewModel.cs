using Data.Concrete.EntityFramework;
using Entities.Concrete;

namespace WEB.ViewModels
{
    public class StadiumCreateOrUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public bool IsActive { get; set; }
    }

    public class StadiumCreateViewModel
    {
        public string? Name { get; set; }
        public int SelectedCityId { get; set; }
        public StadiumDetails StadiumDetails { get; set; }
        public List<WeatherType> WeatherTypes { get; set; }
        public DateTime MeasureDate { get; set; }
        public bool IsActive { get; set; }
        public StadiumCreateViewModel()
        {
            this.StadiumDetails = new StadiumDetails();
            this.WeatherTypes = new List<WeatherType>();
        }
    }

    public class StadiumDetails
    {
        public string? Name { get; set; }
        public List<HourTemp> HourTemps { get; set; }

        public StadiumDetails()
        {
            this.HourTemps = Enumerable.Repeat(new HourTemp(), 16).ToList();
        }
    }

    public class HourTemp
    {
        public int SelectedWeatherTypeId { get; set; }
        public int Hour { get; set; }
        public double Temperature { get; set; }
        public int Precipitation { get; set; }
    }
}
