using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class CityDistrict : IEntity
    {
        public CityDistrict()
        {
            DistrictList = new HashSet<CityDistrict>();
        }        

        public int PlaceId { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public int RegionId { get; set; }

        public virtual Region Region { get; set; }

        public virtual CityDistrict City { get; set; }

        public virtual ICollection<CityDistrict> DistrictList { get; set; }
    }
}
