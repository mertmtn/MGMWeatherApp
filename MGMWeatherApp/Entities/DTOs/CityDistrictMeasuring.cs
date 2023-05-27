using Core.Entities;
using Entities.Abstract;

namespace Entities.DTOs
{
    public class CityDistrictMeasuringDTO: IDTO
    { 
        public DateOnly MeasureDate { get; set; }
        public double Temperature { get; set; }
        public double FeelsTemperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public double WindSpeed { get; set; }
        public int PlaceId { get; set; } 
        public int WeatherTypeId { get; set; }
    }
}
