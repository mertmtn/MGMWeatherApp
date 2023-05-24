using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IStadiumService
    {
        IResult Add(Stadium stadium);
        IResult Delete(Stadium stadium);
        IResult Update(Stadium stadium); 
        IDataResult<Stadium> GetById(int id);
        IDataResult<StadiumDetailDTO> GetStadiumDetailById(int id);
        IDataResult<List<StadiumDetailDTO>> GetAllStadium();
    }
}
