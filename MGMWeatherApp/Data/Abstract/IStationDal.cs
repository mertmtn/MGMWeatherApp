using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace Data.Abstract
{
    public interface IStationDal : IEntityRepository<Station>
    {
        List<StationListDTO> GetStationListByCityId(int cityId);
    }
}
