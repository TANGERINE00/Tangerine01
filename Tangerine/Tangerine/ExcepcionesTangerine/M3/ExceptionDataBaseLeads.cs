using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M3
{
    public class ExceptionDataBaseLeads:ExceptionsTangerine
    {
        public ExceptionDataBaseLeads()
            : base()
        { }

        public ExceptionDataBaseLeads(string message)
            : base(message)
        {
        }

        public ExceptionDataBaseLeads(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExceptionDataBaseLeads(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
