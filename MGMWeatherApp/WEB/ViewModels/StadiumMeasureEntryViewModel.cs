using Entities.Concrete;

namespace WEB.ViewModels
{
 
    public class StadiumMeasureEntryViewModel
    {
        public List<WeatherType> WeatherTypes { get; set; }
        public List<StadiumMeasureEntryViewModel> Entities { get; set; }

        public StadiumMeasureEntryViewModel()
        {
            this.WeatherTypes = new List<WeatherType>(); this.Entities = new List<StadiumMeasureEntryViewModel>();
        }
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public DateOnly MeasureDate { get; set; }
        public int? Hour { get; set; }
        public double? Temperature { get; set; }
        public int? Precipitation { get; set; }
        public int? SelectedWeatherTypeId { get; set; }
        
    }

   
}
