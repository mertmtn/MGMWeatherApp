using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Coordinate : IEntity
    { 
        public int Id { get; set; }

        public int CityDistrictId { get; set; }

        public double Longtitude { get; set; }

        public double Langtitude { get; set; }

        public virtual CityDistrict CityDistrict { get; set; }
    }
}
