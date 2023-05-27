using Entities.Abstract;

namespace Entities.Concrete
{
    public class WeatherType : IEntity
    { 
        public int Id { get; set; }

        public string Type { get; set; } 

        public string Description { get; set; }

        public virtual StadiumMeasuring StadiumMeasure { get; set; }

        public virtual CityDistrictMeasuring CityDistrictMeasuring { get; set; }
    }
}
