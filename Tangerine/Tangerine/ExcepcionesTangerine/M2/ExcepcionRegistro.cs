using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M2
{
    public class ExcepcionRegistro : ExceptionsTangerine
    {
        public ExcepcionRegistro()
        {

        }
        public ExcepcionRegistro( string message )
            : base ( message )
        {

        }

        public ExcepcionRegistro( string message, Exception inner)
            : base( message, inner )
        {

        }
        public ExcepcionRegistro( string codigo, string message, Exception inner )
            : base(codigo, message, inner)
        {

        }
        public override string ToString()
        {
            return string.Format("[ExcepcionDivision: (Mensaje = {0}) (Excepción={1})]", Mensaje, Excepcion);
        }
    }
}
