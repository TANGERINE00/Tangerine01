using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M10
{
    public class NullArgumentException : ExceptionsTangerine
    {
        public NullArgumentException()
            : base()
        { }

        public NullArgumentException(string message)
            : base(message)
        {
        }

        public NullArgumentException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public NullArgumentException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
