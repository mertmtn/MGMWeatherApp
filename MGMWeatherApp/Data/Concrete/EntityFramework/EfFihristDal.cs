using Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.EntityFramework
{
    public class EfFihristDal : IFihristDal
    {
        public List<CitySelectListDTO> GetAllCity()
        {
            using var context = new MGMWeatherDbContext();
            return context.CityDistricts.AsNoTracking().Where(x => x.CityId == 0)
                .Select(x => new CitySelectListDTO { Value = x.PlaceId, Text = x.Name }).ToList();
        }

        public List<CitySelectListDTO> GetAllCityByRegionId(int regionId)
        {
            using var context = new MGMWeatherDbContext();
            return context.CityDistricts.AsNoTracking().Where(x => x.RegionId == regionId)
                        .Select(x => new CitySelectListDTO { Value = x.PlaceId, Text = x.Name }).ToList();
        }

        public List<DistrictSelectListDTO> GetAllDistrict(int cityId)
        {
            using var context = new MGMWeatherDbContext();
            return context.CityDistricts.AsNoTracking().Where(x => x.CityId == cityId)
                .Select(x => new DistrictSelectListDTO { Value = x.PlaceId, Text = x.Name }).ToList();
        }

        public CityDistrict GetPlaceInfoByDistrictId(int placeId)
        {
            using var context = new MGMWeatherDbContext();
            return context.CityDistricts.AsNoTracking().Where(x => x.PlaceId == placeId).Include(x => x.City).ThenInclude(x => x.Region).First(); 
        }

        public List<RegionSelectListDTO> GetAllRegion()
        {
            using var context = new MGMWeatherDbContext();
            return context.Regions.AsNoTracking()
                .Select(x => new RegionSelectListDTO { Value = x.Id, Text = x.Name }).ToList();
        }

        public List<WeatherTypeSelectListDTO> GetAllWeatherType()
        {
            using var context = new MGMWeatherDbContext();
            return context.WeatherTypes.AsNoTracking()
                .Select(x => new WeatherTypeSelectListDTO { Value = x.Id, Text = x.Type }).ToList();
        }
    }
}
