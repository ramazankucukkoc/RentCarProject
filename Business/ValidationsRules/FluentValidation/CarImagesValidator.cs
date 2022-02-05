using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationsRules.FluentValidation
{
   public class CarImagesValidator:AbstractValidator<CarImage>
    {
        public CarImagesValidator()
        {
            RuleFor(c => c.Date).NotEmpty();
            RuleFor(c => c.ImagePath).MinimumLength(2);
            RuleFor(c => c.ImagePath).Empty();
            //Must metodu sayesinde kendimiz kurallar yazabiliyoruz.....
        }
        //string arg yukarıdaki Description'dır...
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
