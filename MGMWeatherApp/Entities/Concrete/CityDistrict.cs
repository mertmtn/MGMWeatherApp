using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class CityDistrict : IEntity
    {
        public CityDistrict()
        {
            Place = new HashSet<CityDistrict>();
            Stadium = new HashSet<Stadium>();
        }        

        public int PlaceId { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

        public virtual CityDistrict City { get; set; }

        public virtual ICollection<CityDistrict> Place { get; set; }

        public virtual ICollection<Stadium> Stadium { get; set; }
    }
}
