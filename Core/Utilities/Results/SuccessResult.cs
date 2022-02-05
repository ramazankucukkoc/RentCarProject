using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Utilities.Results
{
   public class SuccessResult:Result
    {
        //Constructor kullanarak base sınıfı Aslında Result classı 
        //demektir.
        public SuccessResult(string message) : base(true, message)
        {

        }
        public SuccessResult():base(true)
        {

        }
    }
}
