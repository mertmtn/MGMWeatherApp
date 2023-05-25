using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IFihristService
    {
        public IDataResult<List<RegionSelectListDTO>> GetAllRegion();

        public IDataResult<List<CitySelectListDTO>> GetAllCity();

        public IDataResult<List<CitySelectListDTO>> GetAllCityByRegionId(int regionId);

        public IDataResult<List<DistrictSelectListDTO>> GetAllDistrict(int cityId);

        public IDataResult<List<WeatherTypeSelectListDTO>> GetAllWeatherType();
    }
}
