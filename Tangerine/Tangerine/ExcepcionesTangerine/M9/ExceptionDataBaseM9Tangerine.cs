using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M9
{
    public class ExceptionDataBaseM9Tangerine : ExceptionsTangerine
    {


        public ExceptionDataBaseM9Tangerine(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
