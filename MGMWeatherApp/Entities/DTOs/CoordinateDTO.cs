using Core.Entities;

namespace Entities.DTOs
{
    public class CoordinateDTO:IDTO
    { 
        public double Latitude { get; set; } 
        public double Longitude { get; set; }
    }
}
