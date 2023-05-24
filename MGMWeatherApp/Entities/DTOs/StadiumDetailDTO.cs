using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class StadiumDetailDTO:IDTO
    {
        public string Name { get; set; }
        public string CityName { get; set; }
    }
}
