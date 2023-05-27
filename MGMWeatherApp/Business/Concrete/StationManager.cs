using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using Data.Abstract;
using Entities.Concrete;
using Entities.DTOs; 

namespace Business.Concrete
{
    public class StationManager : IStationService
    {
        private readonly IStationDal _stationDal;

        public StationManager(IStationDal stationDal)
        {
            _stationDal = stationDal;
        }

        public IResult Add(Station station)
        {
            _stationDal.Add(station);
            return new SuccessResult("İstasyon başarıyla eklendi.", 200);
        }


        public IDataResult<List<StationListDTO>> GetStationListByCityId(int cityId)
        {
            var result = _stationDal.GetStationListByCityId(cityId);
            return new SuccessDataResult<List<StationListDTO>>(result, 200);
        }

        public IResult Update(Station station)
        {
            _stationDal.Update(station);
            return new SuccessResult("İstasyon başarıyla güncellendi.", 200);
        }
    }
}
