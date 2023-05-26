using Entities.Concrete;

namespace WEB.ViewModels
{
    public class StadiumDetailViewModel
    {
        public List<StadiumDetailEntry>? StadiumDetailList { get; set; }
        public List<WeatherType> WeatherTypes { get; set; }
        public StadiumDetailViewModel()
        {
            this.StadiumDetailList = new List<StadiumDetailEntry>();
            this.WeatherTypes = new List<WeatherType>();
        }
    }

    public class StadiumDetailEntry
    {
        public DateTime? Day { get; set; }
        public List<StadiumEditEntity> HourlyDetails { get; set; }

        public StadiumDetailEntry()
        {
            this.HourlyDetails = new List<StadiumEditEntity>();
        }
    }
}
