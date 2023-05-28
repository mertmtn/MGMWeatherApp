using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using Data.Abstract;
using Entities.Concrete;
using System.Net.WebSockets;

namespace Business.Concrete
{
    public class StadiumMeasuringManager : IStadiumMeasuringService
    {
        private readonly IStadiumMeasuringDal _stadiumMeasuringDal;

        public StadiumMeasuringManager(IStadiumMeasuringDal stadiumMeasuringDal)
        {
            _stadiumMeasuringDal = stadiumMeasuringDal;
        }

        public IResult Add(StadiumMeasuring stadiumMeasuring)
        {
            _stadiumMeasuringDal.Add(stadiumMeasuring);
            return new SuccessResult("Ölçüm başarıyla eklendi.", 200);
        }

        public IDataResult<bool> CheckStadiumMeasure(DateOnly measuringDate, int stadiumId)
        {
            var result = _stadiumMeasuringDal.GetAll(x => x.StadiumId == stadiumId && x.MeasureDate == measuringDate).Count > 0;
            return new SuccessDataResult<bool>(result, 200);
        }

        public IResult DeleteStadiumMeasureByDayAndStadium(DateOnly measuringDate, int stadiumId)
        {
            _stadiumMeasuringDal.DeleteStadiumMeasureByDayAndStadium(measuringDate, stadiumId);
            return new SuccessResult("Ölçümler silindi.", 200);
        }

        public IDataResult<List<DateOnly>> GetDistinctDateByStadiumId(int stadiumId)
        {
            var result = _stadiumMeasuringDal.GetDistinctDateByStadiumId(stadiumId);
            return new SuccessDataResult<List<DateOnly>>(result, 200);
        }

        public IDataResult<List<StadiumMeasuring>> GetStadiumMeasureByStadium(int stadiumId)
        {
            var result = _stadiumMeasuringDal.GetStadiumMeasureByStadium(stadiumId);
            return new SuccessDataResult<List<StadiumMeasuring>>(result, 200);
        }

        public IDataResult<List<StadiumMeasuring>> GetStadiumMeasureByStadium(DateOnly measuringDate, int stadiumId)
        {
            var result = _stadiumMeasuringDal.GetAll(x => x.StadiumId == stadiumId && x.MeasureDate == measuringDate);
            return new SuccessDataResult<List<StadiumMeasuring>>(result, 200);
        }
        public IResult UpdateStadiumMeasureByDayAndStadium(List<StadiumMeasuring> stadiumMeasuringList, DateOnly measuringDay, int stadiumId)
        {
           return _stadiumMeasuringDal.UpdateStadiumMeasureByDayAndStadium(stadiumMeasuringList, measuringDay, stadiumId);
          
        }

    }
}
