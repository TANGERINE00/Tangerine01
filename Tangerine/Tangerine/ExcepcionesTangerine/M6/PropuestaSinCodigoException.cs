using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M6
{
    class PropuestaSinCodigoException : ExceptionsTangerine
    {

        /// <summary>
        /// Excepcion para propuestas que no poseen Codigo sin parametros
        /// </summary>
        public PropuestaSinCodigoException()
            : base()
        { }

        /// <summary>
        /// Excepcion para propuestas que no poseen Codigo
        /// </summary>
        ///  /// <param name="message"></param>
        
        public PropuestaSinCodigoException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// Sobrecarga de Excepcion para propuestas que no poseen Codigo
        /// </summary>
        ///  /// <param name="message"></param>
        /// <param name="inner"></param>

        public PropuestaSinCodigoException(string message, Exception inner)
            : base(message, inner)
        {
        }
        /// <summary>
        /// Sobrecarga de Excepcion para propuestas que no poseen Codigo 
        /// </summary>
        ///  /// <param name="codigo"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public PropuestaSinCodigoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
