using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IStadiumMeasuringService
    {
        IResult Add(StadiumMeasuring stadiumMeasuring);
    }
}
