using Core.Entities.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImagesService
    {
        IResult Add(IFormFile file, CarImages carImage);
        IResult Delete(CarImages carImage);
        IResult Update(IFormFile file, CarImages carImage);

        IDataResult<List<CarImages>> GetAll();
        IDataResult<List<CarImages>> GetByCarId(int carId);
        IDataResult<CarImages> GetByImageId(int imageId);
    }
}
