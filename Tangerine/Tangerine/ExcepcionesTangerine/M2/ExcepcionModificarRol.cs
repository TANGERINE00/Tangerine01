using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M2
{
    public class ExcepcionModificarRol : ExceptionsTangerine
    {
        public ExcepcionModificarRol()
        {

        }
        public ExcepcionModificarRol( string message )
            : base ( message )
        {

        }

        public ExcepcionModificarRol( string message, Exception inner)
            : base( message, inner )
        {

        }
        public ExcepcionModificarRol(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {

        }
        public override string ToString()
        {
            return string.Format("[ExcepcionModificarRol: (Mensaje = {0}) (Excepción={1})]", Mensaje, Excepcion);
        }
    }
}
