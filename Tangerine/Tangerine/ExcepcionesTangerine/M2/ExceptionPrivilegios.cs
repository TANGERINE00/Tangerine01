using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M2
{
    public class ExceptionPrivilegios : ExceptionsTangerine
    {
        /// <summary>
        /// Contructor por defecto de la clase
        /// </summary>
        public ExceptionPrivilegios()
        {

        }

        /// <summary>
        /// Constructor que recibe el mensaje que se quiere mostrar
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        public ExceptionPrivilegios( string message )
               :base( message )
        {

        }

        /// <summary>
        /// Constructor que recibe el mensaje y la excepcion que se produjo
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        /// <param name="inner">inner del mensaje</param>
        public ExceptionPrivilegios( string message , Exception inner )
               :base( message , inner )
        {

        }

        /// <summary>
        /// Constructor que recibe el codigo, el mensaje y la excepcion que se produjo
        /// </summary>
        /// <param name="codigo">Codigo del error</param>
        /// <param name="message">Mensaje de error</param>
        /// <param name="inner">Inner del mensaje</param>
        public ExceptionPrivilegios( string codigo , string message , Exception inner )
               :base( codigo , message , inner )
        {
        }

        /// <summary>
        /// Sobrecarga del metodo ToString()
        /// </summary>
        /// <returns>Regresa el string del error</returns>
        public override string ToString()
        {
            return string.Format( "[ExcepcionPrivilegios: (Mensaje = {0}) (Excepción={1})]" , Mensaje , Excepcion );
        }
    }
}
