using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M9
{
    public class ExceptionDataBase : ExceptionsTangerine
    {
        public ExceptionDataBase()
            : base()
        { }

        public ExceptionDataBase(string message)
            : base(message)
        {
        }

        public ExceptionDataBase(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExceptionDataBase(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
