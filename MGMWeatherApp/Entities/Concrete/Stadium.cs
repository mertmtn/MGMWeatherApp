using Entities.Abstract;

namespace Entities.Concrete
{
    public class Stadium:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public virtual CityDistrict CityDistrict { get; set; }
    }
}
