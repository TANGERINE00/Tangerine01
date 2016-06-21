using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M4
{
    public class ExceptionM4Tangerine : Exception
    {


        public ExceptionM4Tangerine(String codigo, String mjs, Exception inner) : base(mjs, inner) { }

       
    
    }
}
