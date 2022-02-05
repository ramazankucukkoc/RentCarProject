using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Utilities.Results
{
    //Temel voidler için başlangıçlar
   public interface IResult
    {
        //sadece get demek okumak için kullanılıt
        //set ise yazmak için kullanılıyor
        bool Success { get; }
        string Message { get; }


    }
}
