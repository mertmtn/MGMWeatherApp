using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class StadiumManager : IStadiumService
    {
        private readonly IStadiumDal _stadiumDal;

        public StadiumManager(IStadiumDal stadiumDal)
        {
            _stadiumDal = stadiumDal;
        }

        public IResult Add(Stadium stadium)
        {
            _stadiumDal.Add(stadium);
            return new SuccessResult("Stadyum başarıyla eklendi.", 200);
        }

        public IResult Delete(Stadium stadium)
        {
            _stadiumDal.Delete(stadium);
            return new SuccessResult("Stadyum başarıyla silindi.", 200);
        }

        public IDataResult<List<StadiumDetailDTO>> GetAllStadium()
        {
            return new SuccessDataResult<List<StadiumDetailDTO>>(_stadiumDal.GetAllStadium(), 200);
        }

        public IDataResult<Stadium> GetById(int id)
        {
            return new SuccessDataResult<Stadium>(_stadiumDal.Get(x => x.Id == id), 200);
        }


        public IResult Update(Stadium stadium)
        {
            _stadiumDal.Update(stadium);
            return new SuccessResult("Stadyum başarıyla güncellendi.", 200);
        } 
        public IDataResult<StadiumDetailDTO> GetStadiumDetailById(int id)
        {
            return new SuccessDataResult<StadiumDetailDTO>(_stadiumDal.GetStadiumDetailById(id), 200);
        }
    }
}
