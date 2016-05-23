using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M6
{
    class BasedeDatosException:ExceptionsTangerine
    {
         public BasedeDatosException() : base()
        {}

        public BasedeDatosException(string message)
            : base(message)
        {
        }

        public BasedeDatosException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public BasedeDatosException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
