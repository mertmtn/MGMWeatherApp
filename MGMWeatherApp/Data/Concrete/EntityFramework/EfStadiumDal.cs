using Core.DataAccess.EntityFramework;
using Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Data.Concrete.EntityFramework
{
    public class EfStadiumDal : EfGenericRepository<Stadium, MGMWeatherDbContext>, IStadiumDal
    {
        public List<StadiumDetailDTO> GetAllStadium()
        {
            throw new NotImplementedException();
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
