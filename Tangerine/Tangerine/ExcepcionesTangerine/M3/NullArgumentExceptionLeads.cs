using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M3
{
   public class NullArgumentExceptionLeads:ExceptionsTangerine
    {
     public NullArgumentExceptionLeads()
            : base()
        { }

        public NullArgumentExceptionLeads(string message)
            : base(message)
        {
        }

        public NullArgumentExceptionLeads(string message, Exception inner)
            : base(message, inner)
        {
        }

        public NullArgumentExceptionLeads(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        } 
   
   }
}
