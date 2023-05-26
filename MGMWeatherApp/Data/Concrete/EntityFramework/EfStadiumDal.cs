using Core.DataAccess.EntityFramework;
using Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Net.Mime;

namespace Data.Concrete.EntityFramework
{
    public class EfStadiumDal : EfGenericRepository<Stadium, MGMWeatherDbContext>, IStadiumDal
    {
        public List<StadiumDetailDTO> GetAllStadium()
        {
            using (var context = new MGMWeatherDbContext())
            {
                var result =  from stadium in context.Stadiums
                       join city in context.CityDistricts
                       on stadium.CityId equals city.PlaceId
                       select new StadiumDetailDTO
                       {
                           Id = stadium.Id,
                           CityName = city.Name,
                           Name = stadium.Name
                       };

                return result.ToList();
            }
        }

        public StadiumDetailDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public StadiumDetailDTO GetStadiumDetailById(int id)
        {
            throw new NotImplementedException();
        } 
    }
}
