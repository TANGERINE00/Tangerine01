using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M10
{
    public class ExceptionDatabase : ExceptionsTangerine
    {
        public ExceptionDatabase() : base()
        { }

        public ExceptionDatabase(string message) : base(message)
        {

        }

        public ExceptionDatabase(string message, Exception inner) : base(message,inner)
        {

        }

        public ExceptionDatabase(string codigo, string message, Exception inner) : base(codigo, message, inner)
        {

        }
    }
}
