using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M3
{
    public class WrongFormatExceptionLeads:ExceptionsTangerine
    {
        public WrongFormatExceptionLeads() : base()
        {}

        public WrongFormatExceptionLeads(string message)
            : base(message)
        {
        }

        public WrongFormatExceptionLeads(string message, Exception inner)
            : base(message, inner)
        {
        }

        public WrongFormatExceptionLeads(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
