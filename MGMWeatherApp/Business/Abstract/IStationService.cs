using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IStationService
    {
        IResult Add(Station station); 
        IResult Update(Station station);
        IDataResult<List<StationListDTO>> GetStationListByCityId(int cityId);
        IDataResult<StationListDTO> GetStationDetailById(int placeId); 
    }
}
