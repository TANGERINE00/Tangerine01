using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M10
{
    public class AgregarEmpleadoException : ExceptionsTangerine
    {
        public AgregarEmpleadoException ()
        {

        }

        public AgregarEmpleadoException( string message ) : base ( message )
        {

        }

        public AgregarEmpleadoException( string message, Exception inner ) : base( message, inner )
        {

        }

         public AgregarEmpleadoException( string codigo, string message, Exception inner )
            : base( codigo, message, inner )
        {

        }

         public override string ToString()
        {
            return string.Format( "[AgregarEmpleadoException: (Mensaje = {0}) (Excepción={1})]", Mensaje, 
                                  Excepcion );
        }
    }
}
