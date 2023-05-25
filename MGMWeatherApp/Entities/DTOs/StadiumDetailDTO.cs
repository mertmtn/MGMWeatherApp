using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class StadiumDetailDTO:IDTO
    {
        public string Name { get; set; }
        public string CityName { get; set; }
        public DateTime MeasureDate { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public int WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public int Hour { get; set; }
        public int ExpectedWeatherTypeId { get; set; }
        public int ProbabilityRainy { get; set; }
    }
}
