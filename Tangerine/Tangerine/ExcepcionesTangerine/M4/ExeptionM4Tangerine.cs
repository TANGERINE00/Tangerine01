using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M4
{
    public class ExceptionM4Tangerine : Exception
    {

        /// <summary>
        /// Excepcion creada para atrapar los errores que puedan provenir al momento de realizar alguna operacion en el dao.
        /// </summary>
        /// <param name="codigo">codigo que identificara el error ocurrido.</param>
        /// <param name="mjs">mensaje para describir el error que ocurrio al realizar la operacion.</param>
        /// <param name="inner">objeto de tipo excepcion el cual tiene toda la excepcion ocurrida.</param>
        public ExceptionM4Tangerine(String codigo, String mjs, Exception inner) : base(mjs, inner) { }

       
    
    }
}
