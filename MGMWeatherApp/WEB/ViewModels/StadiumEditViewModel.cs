using Entities.Concrete;

namespace WEB.ViewModels
{
    public class StadiumEditViewModel
    {
        public List<WeatherType> WeatherTypes { get; set; }
        public StadiumSavedDetail? StadiumSavedDetail { get; set; }

        public StadiumEditViewModel()
        {
            this.WeatherTypes = new List<WeatherType>();
        }
    }

    public class StadiumEditRequest
    {
        public int? StadiumId { get; set; }
        public DateTime? Day { get; set; }
        public List<StadiumEditEntity>? Entities { get; set; }
    }

    public class StadiumSavedDetail
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public List<StadiumEditEntity>? HourlyDetails { get; set; }
    }

    public class StadiumEditEntity
    {
        public int? Id { get; set; }
        public int? Hour { get; set; }
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public int? SelectedWeatherTypeId { get; set; }
    }
}
