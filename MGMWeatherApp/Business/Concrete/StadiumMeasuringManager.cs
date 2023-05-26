using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using Data.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class StadiumMeasuringManager: IStadiumMeasuringService
    {
        private readonly IStadiumMeasuringDal _stadiumMeasuringDal;

        public StadiumMeasuringManager(IStadiumMeasuringDal stadiumMeasuringDal)
        {
            _stadiumMeasuringDal = stadiumMeasuringDal;
        }

        public IResult Add(StadiumMeasuring stadiumMeasuring)
        {
            _stadiumMeasuringDal.Add(stadiumMeasuring);
            return new SuccessResult("Ölçüm başarıyla eklendi.",200);
        }
    }
}
