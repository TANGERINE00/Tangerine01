using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M9
{
    public class WrongFormatException:ExceptionsTangerine
    {
        public WrongFormatException() : base()
        {}

        public WrongFormatException(string message)
            : base(message)
        {
        }

        public WrongFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public WrongFormatException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
