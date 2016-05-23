using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M6
{
    class FormatoIncorrectoException:ExceptionsTangerine
    {
       
        private FormatException ex;
        private ArgumentNullException ex1;
        
        

         public FormatoIncorrectoException() : base()
        {}

        public FormatoIncorrectoException(string message)
            : base(message)
        {
        }

        public FormatoIncorrectoException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public FormatoIncorrectoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

        public FormatoIncorrectoException(string codigo, string message, ArgumentNullException ex)
        {
            // TODO: Complete member initialization
            this.Codigo = codigo ;
            this.ex1 = ex;
        }

       

       

        

       
    }
}
