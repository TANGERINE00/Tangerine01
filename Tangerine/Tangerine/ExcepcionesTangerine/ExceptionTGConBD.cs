using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine
{
    public class ExceptionTGConBD:ExceptionsTangerine
    {
        public ExceptionTGConBD(): base()
        {}
        
        public ExceptionTGConBD(string message)
            : base(message)
        {}

        public ExceptionTGConBD(string message, Exception inner)
            : base(message, inner)
        {}

        public ExceptionTGConBD(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {}
    }
}
