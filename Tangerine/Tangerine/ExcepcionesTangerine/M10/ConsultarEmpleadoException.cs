using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M10
{
    public class ConsultarEmpleadoException : ExceptionsTangerine
    {
        public ConsultarEmpleadoException() 
        {

        }

         public ConsultarEmpleadoException( string message ) : base ( message )
        {

        }

         public ConsultarEmpleadoException( string message, Exception inner ) : base( message, inner )
        {

        }

         public ConsultarEmpleadoException( string codigo, string message, Exception inner )
            : base( codigo, message, inner )
        {

        }

         public override string ToString()
         {
             return string.Format("[ConsultarEmpleadoException: (Mensaje = {0}) (Excepción={1})]", Mensaje,
                                   Excepcion);
         }
    }
}
