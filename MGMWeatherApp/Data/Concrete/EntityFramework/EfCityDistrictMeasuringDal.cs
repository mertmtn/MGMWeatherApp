using Core.DataAccess.EntityFramework;
using Data.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFramework
{
    public class EfCityDistrictMeasuringDal : EfGenericRepository<CityDistrictMeasuring, MGMWeatherDbContext>, ICityDistrictMeasuringDal
    {
        public List<CityDistrictMeasuring> GetMeasureResultByPlaceId(int placeId)
        {
            using var context = new MGMWeatherDbContext();
            var result = context.CityDistrictMeasuring.FromSqlRaw("SELECT * from public.il_ilce_havadurumu(" + placeId + ")").AsNoTracking().Include(x => x.CityDistrict).Include(x => x.WeatherType).OrderBy(x=>x.MeasureDate);
            return result.ToList();
        }
    }
}
