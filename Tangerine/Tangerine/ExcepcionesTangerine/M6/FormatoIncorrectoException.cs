using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesTangerine.M6
{
    class FormatoIncorrectoException:ExceptionsTangerine
    {
       
        private FormatException ex;
        private ArgumentNullException ex1;


        /// <summary>
        /// Excepcion para formatos Incorrectos
        /// </summary>
         public FormatoIncorrectoException() : base()
        {}
         /// <summary>
         /// Sobrecarga Excepcion para formatos Incorrectos
         /// </summary>
         ///  /// <param name="message"></param>
        public FormatoIncorrectoException(string message)
            : base(message)
        {
        }
        /// <summary>
        /// Sobrecarga Excepcion para formatos Incorrectos
        /// </summary>
        ///  /// <param name="message"></param>
        /// <param name="inner"></param>
        public FormatoIncorrectoException(string message, Exception inner)
            : base(message, inner)
        {
        }
        /// <summary>
        /// Sobrecarga Excepcion para listas de propuestas vacias
        /// </summary>
        ///  /// <param name="codigo"></param>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public FormatoIncorrectoException(string codigo, string message, Exception inner)
            : base(codigo, message, inner)
        {
        }

        public FormatoIncorrectoException(string codigo, string message, ArgumentNullException ex)
        {
            // TODO: Complete member initialization
            this.Codigo = codigo ;
            this.ex1 = ex;
        }

       

       

        

       
    }
}
