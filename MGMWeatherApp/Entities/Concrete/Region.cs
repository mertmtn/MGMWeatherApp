using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Region: IEntity
    {
        public Region()
        {
            CityDistricts = new HashSet<CityDistrict>();
        } 

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CityDistrict> CityDistricts { get; set; }
    }
}
