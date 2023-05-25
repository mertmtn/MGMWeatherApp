using Entities.DTOs;

namespace Data.Abstract
{
    public interface IFihristDal
    {
        public List<RegionSelectListDTO> GetAllRegion();

        public List<CitySelectListDTO> GetAllCity();

        public List<CitySelectListDTO> GetAllCityByRegionId(int regionId);

        public List<DistrictSelectListDTO> GetAllDistrict(int cityId);

        public List<WeatherTypeSelectListDTO> GetAllWeatherType();
    }
}
