using Entities.Concrete;

namespace WEB.ViewModels
{
    public class StadiumEditViewModel
    {
        public List<WeatherType> WeatherTypes { get; set; }

        public StadiumEditViewModel()
        {
            this.WeatherTypes = new List<WeatherType>();
        }
    }

    public class StadiumEditRequest
    {
        public DateTime? Day { get; set; }
        public List<StadiumEditEntity> Entities { get; set; }

        public StadiumEditRequest()
        {
            this.Entities = new List<StadiumEditEntity>();
        }
    }

    public class StadiumEditEntity
    {
        public int? Hour { get; set; }
        public double? Temperature { get; set; }
        public int? Precipitation { get; set; }
        public int? SelectedWeatherTypeId { get; set; }
    }
}
