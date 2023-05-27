using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using Data.Abstract;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CoordinateManager:ICoordinateService
    {
        private readonly ICoordinateDal _coordinateDal;

        public CoordinateManager(ICoordinateDal coordinateDal)
        {
            _coordinateDal = coordinateDal;
        }

        public IDataResult<CoordinateDTO> GetCoordinateByPlaceId(int placeId)
        {
            return new SuccessDataResult<CoordinateDTO>(_coordinateDal.GetCoordinateByPlaceId(placeId)); 
        }
    }
}
