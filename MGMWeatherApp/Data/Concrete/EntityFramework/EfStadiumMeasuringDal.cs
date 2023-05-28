
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using Core.Utilities.Results.Error;
using Core.Utilities.Results.Success;
using Data.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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

        public IResult UpdateStadiumMeasureByDayAndStadium(List<StadiumMeasuring> stadiumMeasuringList, DateOnly measuringDay, int stadiumId)
        {
            using var context = new MGMWeatherDbContext();
            using IDbContextTransaction transaction = context.Database.BeginTransaction();
            try
            {
                if (stadiumMeasuringList != null)
                {
                    var stadiumMeasuringToRemove = context.StadiumMeasuring.Where(x => x.MeasureDate == measuringDay && x.StadiumId == stadiumId).ToList();
                    context.RemoveRange(stadiumMeasuringToRemove);
                    context.SaveChanges();

                    context.StadiumMeasuring.AddRange(stadiumMeasuringList);
                    context.SaveChanges();

                    transaction.Commit();
                   
                }
                return new SuccessResult("İşlem başarılıdır.",200);
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                return new ErrorResult(ex.InnerException.Message, 500); 
            }
        }
    }
}
