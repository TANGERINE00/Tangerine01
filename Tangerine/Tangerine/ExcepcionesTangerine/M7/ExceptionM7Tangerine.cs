using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M7
{
    public class ExceptionM7Tangerine : Exception
    {
        /// <summary>
        /// Constructor de la clase ExceptionM7Tangerine
        /// para el wrapping de excepciones 
        /// </summary>
        /// <param name="codigoEx">Código único para la excepción.</param>
        /// <param name="mensajeEx">Mensaje de error de la excepción.</param>
        /// <param name="innerEx">Excepción que generó el error.</param>
        public ExceptionM7Tangerine(String codigoEx, String mensajeEx, Exception innerEx) : base(mensajeEx, innerEx) { }
    }
}
