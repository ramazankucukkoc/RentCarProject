﻿using Core.DataAccess.Entityframework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCarImagesDal:EfEntityRepositoryBase<CarImage,CarContext>,ICarImageDal
    {
    }
}
