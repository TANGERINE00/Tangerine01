using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M2
{
    public class ExcepcionPrivilegios : ExceptionsTangerine
    {
        public ExcepcionPrivilegios()
        {
        }

        public ExcepcionPrivilegios (string message )
            : base( message )
        {
        }

        public ExcepcionPrivilegios( string message, Exception inner )
            : base( message, inner )
        {
        }

        public ExcepcionPrivilegios( string codigo, string message, Exception inner )
            : base( codigo, message, inner )
        {
        }

        public override string ToString()
        {
            return string.Format( "[ExcepcionPrivilegios: (Mensaje = {0}) (Excepción={1})]", Mensaje, Excepcion );
        }
    }
}
