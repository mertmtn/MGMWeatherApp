using Entities.Abstract;

namespace Entities.Concrete
{
    public class Station : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int StationNo { get; set; }        

        public int CityDistrictId { get; set; }

        public string ICAO { get; set; }

        public string GoogleMapLink { get; set; }

        public bool IsActive { get; set; }

        public virtual CityDistrict CityDistrict { get; set; }
    }
}
