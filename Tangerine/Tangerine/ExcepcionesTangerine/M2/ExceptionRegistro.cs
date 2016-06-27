using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M2
{
    public class ExceptionRegistro : ExceptionsTangerine
    {
        /// <summary>
        /// Contructor por defecto de la clase
        /// </summary>
        public ExceptionRegistro()
        {

        }

        /// <summary>
        /// Constructor que recibe el mensaje que se quiere mostrar
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        public ExceptionRegistro( string message )
               :base ( message )
        {

        }

        /// <summary>
        /// Constructor que recibe el mensaje y la excepcion que se produjo
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        /// <param name="inner">Inner del error</param>
        public ExceptionRegistro( string message , Exception inner )
               :base( message , inner )
        {

        }

        /// <summary>
        /// Constructor que recibe el codigo, el mensaje y la excepcion que se produjo
        /// </summary>
        /// <param name="codigo">Codigo del error</param>
        /// <param name="message">Mensaje del error</param>
        /// <param name="inner">Inner del error</param>
        public ExceptionRegistro( string codigo , string message , Exception inner )
               :base( codigo , message , inner )
        {

        }

        /// <summary>
        /// Sobrecarga del metodo ToString()
        /// </summary>
        /// <returns>Regresa el string del error</returns>
        public override string ToString()
        {
            return string.Format( "[ExcepcionRegistro: (Mensaje = {0}) (Excepción={1})]" , Mensaje , Excepcion );
        }
    }
}
