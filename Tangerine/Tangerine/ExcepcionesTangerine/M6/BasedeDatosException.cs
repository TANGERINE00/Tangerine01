using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M6
{
    class BasedeDatosException:ExceptionsTangerine
    {
        /// <summary>
        /// Excepcion para problemas relacionados a la conexion y funcionamiento de la Base de Datos
        /// </summary>
         public BasedeDatosException() : base()
        {}
         /// <summary>
         /// Sobrecarga Excepcion para problemas relacionados a la conexion y funcionamiento de la Base de Datos
         /// </summary>
         /// <param name="message"></param>
        public BasedeDatosException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// Sobrecarga Excepcion para problemas relacionados a la conexion y funcionamiento de la Base de Datos
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public BasedeDatosException(string message, Exception inner)
            : base(message, inner)
        {
        }
        /// <summary>
        /// Sobrecarga Excepcion para problemas relacionados a la conexion y funcionamiento de la Base de Datos
        /// </summary>
        ///  /// <param name="codigo"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public BasedeDatosException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }
    }
}
