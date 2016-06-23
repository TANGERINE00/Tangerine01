using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M6
{
    class ListaSinPropuestaException : ExceptionsTangerine
    {

        /// <summary>
        /// Excepcion para listas de propuestas vacias
        /// </summary>
          public ListaSinPropuestaException()
            : base()
        { }
          /// <summary>
          /// Sobrecarga Excepcion para listas de propuestas vacias
          /// </summary>
          ///  /// <param name="codigo"></param>
        public ListaSinPropuestaException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// Sobrecarga Excepcion para listas de propuestas vacias
        /// </summary>
        ///  /// <param name="codigo"></param>
        /// <param name="message"></param>
        public ListaSinPropuestaException(string message, Exception inner)
            : base(message, inner)
        {
        }
        /// <summary>
        /// Sobrecarga Excepcion para listas de propuestas vacias
        /// </summary>
        ///  /// <param name="codigo"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public ListaSinPropuestaException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
