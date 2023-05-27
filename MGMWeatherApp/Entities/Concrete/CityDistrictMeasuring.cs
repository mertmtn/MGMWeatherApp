using Entities.Abstract;

namespace Entities.Concrete
{
    public class CityDistrictMeasuring:IEntity
    {
       // public int Id { get; set; }
        public DateOnly MeasureDate { get; set; }
        public double Temperature { get; set; }
        public double FeelsTemperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public double WindSpeed { get; set; }
        public int PlaceId { get; set; }
        public virtual CityDistrict CityDistrict { get; set; } 
        public virtual WeatherType WeatherType { get; set; }
        public int WeatherTypeId { get; set; }
    }
}
