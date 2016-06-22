using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M9
{
    public class WrongFormatExceptionM9Tangerine:ExceptionsTangerine
    {

        public WrongFormatExceptionM9Tangerine(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
