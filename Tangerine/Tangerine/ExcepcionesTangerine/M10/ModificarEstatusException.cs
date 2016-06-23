using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M10
{
    public class ModificarEstatusException : ExceptionsTangerine
    {
         public ModificarEstatusException()
        {

        }

        public ModificarEstatusException( string message ) : base ( message )
        {

        }

         public ModificarEstatusException( string message, Exception inner ) : base( message, inner )
        {

        }

        public ModificarEstatusException( string codigo, string message, Exception inner )
            : base( codigo, message, inner )
        {

        }

        public override string ToString()
        {
            return string.Format("[ModificarEstatusException: (Mensaje = {0}) (Excepción={1})]", Mensaje,
                                  Excepcion);
        }
    }
}
