using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using Data.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CityDistrictMeasuringManager: ICityDistrictMeasuringService
    {
        private ICityDistrictMeasuringDal _cityDistrictMeasuringDal;

        public CityDistrictMeasuringManager(ICityDistrictMeasuringDal cityDistrictMeasuringDal)
        {
            _cityDistrictMeasuringDal = cityDistrictMeasuringDal;
        }

        public IResult AddMeasureByPlace(CityDistrictMeasuring measure)
        {
            _cityDistrictMeasuringDal.Add(measure);
            return new SuccessResult("Ölçüm eklendi");
        }
    }
}
