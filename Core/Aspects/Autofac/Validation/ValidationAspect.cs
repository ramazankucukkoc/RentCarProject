using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        //Attirubetlara tipleri Type ile atarız
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //Bu if yapısını type dogrulamamız gerekiyor attirubetlarda bu kuraldır.validatorType=ProductValidator dir.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir dogrulama sınıfı degil");
            }

            _validatorType = validatorType;
        }
        //OnBefore metodunu burada eziyoruz MethodInterception sınıfında geliyor.
        protected override void OnBefore(IInvocation invocation)
        {
            //var validator = (IValidator)Activator.CreateInstance(_validatorType); bu kod ProductValidator'ın instancenı oluşturyor.

            var validator = (IValidator)Activator.CreateInstance(_validatorType);

            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //public class CarValidator : AbstractValidator<Car> bir satır yularıdaki kodun anlamı
            //_validatorType =CarValidator demektir
            //BaseType AbstractValidator dır.
            //onun GetGenericArguments()[0] 0.indeksini bulun <Car> car nesnesini buluyor.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            //bir satır yularıdaki kodun anlamı invocation(metot demek) metotun paremetrelerini bul
            // public IResult Add(Car car) CarValidator add metodu için parametreleri (Car car) budur yani bul
            //Sonra foreachle gez ValidationTool kullanarak Validate(dogrula) demektir.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
