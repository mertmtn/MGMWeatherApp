using Core.DataAccess;
using Entities.Concrete;

namespace Data.Abstract
{
    public interface IStadiumMeasuringDal : IEntityRepository<StadiumMeasuring>
    {
        void DeleteStadiumMeasureByDayAndStadium(DateOnly measuringDay, int stadiumId);
        List<StadiumMeasuring> GetStadiumMeasureByStadium(int stadiumId);

        List<DateOnly> GetDistinctDateByStadiumId(int stadiumId); 
    }
}
