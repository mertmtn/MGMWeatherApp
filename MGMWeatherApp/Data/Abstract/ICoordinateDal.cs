using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace Data.Abstract
{
    public interface ICoordinateDal:IEntityRepository<Coordinate>
    {
        CoordinateDTO GetCoordinateByPlaceId(int placeId);
    }
}
