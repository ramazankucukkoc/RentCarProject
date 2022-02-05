using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Utilities.Results
{
    //DataResult<T>:Result demek dataResulta diyoruz ki sen resultu
    //tamamen içeriyorsun demektir.
    public class DataResult<T>:Result,IDataResult<T>
    {
        //base demek aşagıdaki ctorda yer alan success ve messsageı
        //Resulta al ben bir daha o kodları yazmıyacagım demmektir
        public DataResult(T data,bool success,string message):base(success,message)
        {
            Data = data;
        }
        public DataResult(T data,bool success):base(success)
        {
            Data = data;
        }
        public T Data { get; }

    }
}
