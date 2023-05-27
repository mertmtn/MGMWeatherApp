using Core.DataAccess.EntityFramework;
using Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Data.Concrete.EntityFramework
{
    public class EfStationDal : EfGenericRepository<Station, MGMWeatherDbContext>, IStationDal
    {
        public List<StationListDTO> GetStationListByCityId(int cityId)
        {
            throw new NotImplementedException();
        }
    }
}
