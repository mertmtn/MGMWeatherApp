using Core.DataAccess.EntityFramework;
using Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Data.Concrete.EntityFramework
{
    public class EfCoordinateDal : EfGenericRepository<Coordinate, MGMWeatherDbContext>, ICoordinateDal
    {
        public CoordinateDTO GetCoordinateByPlaceId(int placeId)
        {
            using var context = new MGMWeatherDbContext();
            return context.Coordinates.Where(x => x.CityDistrictId == placeId).Select(x => new CoordinateDTO { Latitude = x.Langtitude, Longitude = x.Longtitude }).First();
        }
    }
}
