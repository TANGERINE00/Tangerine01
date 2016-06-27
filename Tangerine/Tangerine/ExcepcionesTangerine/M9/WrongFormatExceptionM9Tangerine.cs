using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M9
{
    public class WrongFormatExceptionM9Tangerine:ExceptionsTangerine
    {
        /// <summary>
        /// Excepción que se arroja cuando se pase un parametro en un formato incorrecto
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public WrongFormatExceptionM9Tangerine(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
