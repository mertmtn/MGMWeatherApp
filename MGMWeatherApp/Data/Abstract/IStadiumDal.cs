using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace Data.Abstract
{
    public interface IStadiumDal : IEntityRepository<Stadium>
    { 
        StadiumDetailDTO GetStadiumDetailById(int id);
        List<StadiumDetailDTO> GetAllStadium();
    }
}
