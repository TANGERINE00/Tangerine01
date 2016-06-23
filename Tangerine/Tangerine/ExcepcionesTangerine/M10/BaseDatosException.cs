using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M10
{
    public class BaseDatosException : ExceptionsTangerine
    {
        public BaseDatosException() 
        {

        }

        public BaseDatosException( string message ) : base ( message )
        {

        }

        public BaseDatosException( string message, Exception inner ) : base( message, inner )
        {

        }

        public BaseDatosException( string codigo, string message, Exception inner )
            : base( codigo, message, inner )
        {

        }

        public override string ToString()
        {
            return string.Format("[BaseDatosException: (Mensaje = {0}) (Excepción={1})]", Mensaje,
                                  Excepcion);
        }
    }
}
