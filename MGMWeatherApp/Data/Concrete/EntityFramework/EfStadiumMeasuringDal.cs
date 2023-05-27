
using Core.DataAccess.EntityFramework;
using Data.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFramework
{
    public class EfStadiumMeasuringDal : EfGenericRepository<StadiumMeasuring, MGMWeatherDbContext>, IStadiumMeasuringDal
    {
        public void DeleteStadiumMeasureByDayAndStadium(DateOnly measuringDay, int stadiumId)
        {
            using var context = new MGMWeatherDbContext();
            var stadiumMeasuringToRemove = context.StadiumMeasuring.Where(x => x.MeasureDate == measuringDay && x.StadiumId == stadiumId).ToList();
            context.RemoveRange(stadiumMeasuringToRemove);
            context.SaveChanges();
        }

        public List<DateOnly> GetDistinctDateByStadiumId(int stadiumId)
        {
            using var context = new MGMWeatherDbContext();
            var result = context.Database.SqlQueryRaw<DateOnly>("SELECT DISTINCT \"MeasureDate\" FROM public.\"StadiumMeasuring\" where \"StadiumId\" =" + stadiumId);
            return result.ToList();
        }

        public List<StadiumMeasuring> GetStadiumMeasureByStadium(int stadiumId)
        {
            using var context = new MGMWeatherDbContext();
            var result = context.StadiumMeasuring.FromSqlRaw("SELECT * from public.stadyum_olcumleri(" + stadiumId + ")").AsNoTracking().Include(x => x.WeatherType).OrderBy(x => x.MeasureDate);
            return result.ToList();
        } 
    }
}
