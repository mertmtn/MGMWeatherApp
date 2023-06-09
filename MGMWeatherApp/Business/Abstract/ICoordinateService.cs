﻿using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICoordinateService
    {
        IDataResult<CoordinateDTO> GetCoordinateByPlaceId(int placeId);
    }
}
