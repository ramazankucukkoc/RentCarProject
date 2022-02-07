using Business.Abstract;
using Core.Entities.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
  public  class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colors)
        {
            _colorDal = colors;
        }
        public IDataResult< List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>( _colorDal.GetAll());
        }
        public IDataResult<Color> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<Color>( _colorDal.Get(c => c.Id == colorId));
        }
    }
}
