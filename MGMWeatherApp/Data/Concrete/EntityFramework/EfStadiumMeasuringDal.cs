
using Core.DataAccess.EntityFramework;
using Data.Abstract;
using Entities.Concrete;

namespace Data.Concrete.EntityFramework
{
    public class EfStadiumMeasuringDal: EfGenericRepository<StadiumMeasuring,MGMWeatherDbContext>,IStadiumMeasuringDal
    {
    }
}
