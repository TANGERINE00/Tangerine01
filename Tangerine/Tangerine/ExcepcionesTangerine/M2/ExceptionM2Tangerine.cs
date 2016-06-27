using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M2
{
    public class ExceptionM2Tangerine : Exception
    {
        /// <summary>
        /// Constructor de la clase de excepciones de Tangerine del Módulo 2
        /// </summary>
        /// <param name="codigo">Codigo de la excepcion</param>
        /// <param name="mjs">Mensaje de error</param>
        /// <param name="inner">Inner del mensaje</param>
        public ExceptionM2Tangerine( String codigo , String mjs , Exception inner ) 
               :base( mjs , inner ) 
        {

        }

        /// <summary>
        /// Constructor de la clase de excepciones de Tangerine del Módulo 2
        /// </summary>
        /// <param name="mjs">Mensaje de error</param>
        /// <param name="inner">Inner del mensaje</param>
        public ExceptionM2Tangerine( String mjs , Exception inner ) 
               :base( mjs , inner )
        {

        }
    }
}
