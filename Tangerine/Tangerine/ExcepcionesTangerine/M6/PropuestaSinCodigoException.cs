using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M6
{
    class PropuestaSinCodigoException : ExceptionsTangerine
    {
           public PropuestaSinCodigoException()
            : base()
        { }

        public PropuestaSinCodigoException(string message)
            : base(message)
        {
        }

        public PropuestaSinCodigoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public PropuestaSinCodigoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
