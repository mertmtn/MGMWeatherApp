using Entities.Abstract;

namespace Entities.Concrete
{
    public class StadiumMeasuring:IEntity
    {
        public int Id { get; set; }
        public int StadiumId { get; set; }
        public DateOnly MeasureDate { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public int ExpectedWeatherTypeId { get; set; }
        public int Hour { get; set; }        
        public virtual WeatherType WeatherType { get; set; }
        public virtual Stadium Stadium { get; set; }
    }
}
