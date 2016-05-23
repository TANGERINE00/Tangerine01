using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M6
{
    class ListaSinPropuestaException : ExceptionsTangerine
    {
          public ListaSinPropuestaException()
            : base()
        { }

        public ListaSinPropuestaException(string message)
            : base(message)
        {
        }

        public ListaSinPropuestaException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ListaSinPropuestaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
