using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Data.Abstract
{
    public interface ICityDistrictMeasuringDal:IEntityRepository<CityDistrictMeasuring>
    {
        List<CityDistrictMeasuring> GetMeasureResultByPlaceId(int placeId);
    }
}
