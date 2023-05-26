using Entities.Abstract;

namespace Entities.Concrete
{
    public class CityDistrictMeasuring:IEntity
    {
        public int Id { get; set; }
        public DateOnly MeasureDate { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }
}
