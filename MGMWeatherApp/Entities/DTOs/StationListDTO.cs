using Core.Entities;

namespace Entities.DTOs
{
    public class StationListDTO:IDTO
    {
        public int Id { get; set; }

        public string StationName { get; set; }

        public int StationNo { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }

        public int DistrictId { get; set; }
        public string DistrictName { get; set; }

        public string? ICAO { get; set; }

        public string GoogleMapLink { get; set; }

        public bool IsActive { get; set; }
    }
}
