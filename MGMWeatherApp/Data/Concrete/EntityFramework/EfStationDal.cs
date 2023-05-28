using Core.DataAccess.EntityFramework;
using Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFramework
{
    public class EfStationDal : EfGenericRepository<Station, MGMWeatherDbContext>, IStationDal
    {
        public StationListDTO GetStationDetailById(int id)
        {
            using var context = new MGMWeatherDbContext();
            return context.StationListDTO.FromSqlRaw("select * from vwGetStationListDTO").Where(x => x.Id == id).First();            
        }

        public List<StationListDTO> GetStationListByCityId(int placeId)
        { 
            using var context = new MGMWeatherDbContext();
            var result = context.StationListDTO.FromSqlRaw("select * from vwGetStationListDTO WHERE \"CityId\"=" + placeId);//.Where(x => x.CityDistrict.PlaceId == placeId);
            return result.ToList();

        }
    }
}
