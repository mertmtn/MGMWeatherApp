using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IStadiumMeasuringService
    {
        IResult Add(StadiumMeasuring stadiumMeasuring);

        IDataResult<bool> CheckStadiumMeasure(DateOnly measuringDate, int stadiumId);
        IDataResult<List<StadiumMeasuring>> GetStadiumMeasureByStadium(int stadiumId);
        IDataResult<List<StadiumMeasuring>> GetStadiumMeasureByStadium(DateOnly measuringDate, int stadiumId);
        IDataResult<List<DateOnly>> GetDistinctDateByStadiumId( int stadiumId);
        IResult DeleteStadiumMeasureByDayAndStadium(DateOnly measuringDate, int stadiumId);

        IResult UpdateStadiumMeasureByDayAndStadium(List<StadiumMeasuring> stadiumMeasuringList, DateOnly measuringDay, int stadiumId);
    }
}
