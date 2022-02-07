using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.InMemory;
using Entities.Concrete.DTOs;
using Core.Entities.Utilities.Results;
using Business.Constants;
using Business.ValidationsRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Business.BusinessAspects.Autofac;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carsDal;
        IColorService _colorService;
        public CarManager(ICarDal cars ,IColorService colorService)
        {
            _carsDal = cars;
            _colorService = colorService;
        }
      //  [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            IResult result = BusinessRules.Run(CheckIfCarsSameNameExists(car.Description),
               CheckIfCarCountOfBrandCorrect(car.BrandId), CheckIfBrandLimitExceed());
            if (result != null)
            {
                return result;
            }
            _carsDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }

        public IResult Delete(Car car)
        {
            if (car.Description.Length < 2)
            {
                //magic strings
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carsDal.Delete(car);
            return new SuccessResult("Ürün Silindi");
        }
        [CacheAspect]
        public IDataResult< List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==11)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carsDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult< List<CarDetailDto>> GetCarDetail()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carsDal.GetCarDetails());
        }

        public IDataResult< List<Car>>GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>( _carsDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult< List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>( _carsDal.GetAll(c => c.ColorId == colorId));
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            if (car.Description.Length < 2)
            {
                //magic strings
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carsDal.Update(car);
            return new SuccessResult("Ürün Güncellendi");
        }
        private IResult CheckIfCarCountOfBrandCorrect(int BrandId)
        {
            //Select count(*) from products where categoryid=1 aşagıdaki var result bize bunu yapıyor..
            var result = _carsDal.GetAll(c => c.BrandId == BrandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountBrandError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarsSameNameExists(string description)
        {
            //Any()metodu bu şarta uyan eleman var mı diye soruyor ve bool döndürüyor..
            var result = _carsDal.GetAll(c => c.Description == description).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfBrandLimitExceed()
        {
            var result = _colorService.GetAll();
            if (result.Data.Count > 2)
            {
                return new ErrorResult(Messages.BrandErrorLimetExceed);
            }
            return new SuccessResult();
        }
    }
}
