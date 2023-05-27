﻿using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICityDistrictMeasuringService
    {
        IResult AddMeasureByPlace(CityDistrictMeasuring measure);
    }
}