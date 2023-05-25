using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using Data.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class FihristManager : IFihristService
    {
        private readonly IFihristDal _fihristDal;

        public FihristManager(IFihristDal fihristDal)
        {
            _fihristDal = fihristDal;
        }

        public IDataResult<List<CitySelectListDTO>> GetAllCity()
        {
            return new SuccessDataResult<List<CitySelectListDTO>>(_fihristDal.GetAllCity(), 200);
        }

        public IDataResult<List<CitySelectListDTO>> GetAllCityByRegionId(int regionId)
        {
            return new SuccessDataResult<List<CitySelectListDTO>>(_fihristDal.GetAllCityByRegionId(regionId), 200);
        }

        public IDataResult<List<DistrictSelectListDTO>> GetAllDistrict(int cityId)
        {
            return new SuccessDataResult<List<DistrictSelectListDTO>>(_fihristDal.GetAllDistrict(cityId), 200);
        }

        public IDataResult<List<RegionSelectListDTO>> GetAllRegion()
        {
            return new SuccessDataResult<List<RegionSelectListDTO>>(_fihristDal.GetAllRegion(), 200);
        }

        public IDataResult<List<WeatherTypeSelectListDTO>> GetAllWeatherType()
        {
            return new SuccessDataResult<List<WeatherTypeSelectListDTO>>(_fihristDal.GetAllWeatherType(), 200);
        }
    }
}
