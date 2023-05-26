using Business.Abstract;
using Data.Abstract;

namespace Business.Concrete
{
    public class CoordinateManager:ICoordinateService
    {
        private readonly ICoordinateDal _coordinateDal;

        public CoordinateManager(ICoordinateDal coordinateDal)
        {
            _coordinateDal = coordinateDal;
        }
    }
}
