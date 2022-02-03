using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationsRules.FluentValidation
{
    //FluentValidation paketini yükledik ve onun sayesinde sınıflarını kullanıyoruz
    //Ve burada dogrulama yapıyoruz iş kurallarımızı yazıyoruz
    //ProductValidator:AbstractValidator<Car> bu car nesnesi için kullanılan kuralları yazacagız diyoruz
    //ayrıca Rules(kuralları) constructor da yazıyoruz
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(1000).When(c => c.BrandId == 1);
            RuleFor(c => c.Description).Must(StartWithA).WithMessage("Açıklama A harfi Başlamıyor");
           //Must metodu sayesinde kendimiz kurallar yazabiliyoruz.....
        }
        //string arg yukarıdaki Description'dır...
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
