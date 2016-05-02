using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    class ListaOpciones
    {
        #region Atributos

        private List<Opcion> _listaDeOpciones;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase 
        /// </summary>
        public ListaOpciones() 
        {
            this._listaDeOpciones = new List<Opcion>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método para agregar una opcion a la lista
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public void AgregarOpcion( Opcion opcion )
        {
            this._listaDeOpciones.Add( opcion );
        }

        /// <summary>
        /// Método para eliminar una opcion de la lista
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public bool EliminarOpcion( Opcion opcion )
        {
            return this._listaDeOpciones.Remove( opcion );
        }

        /// <summary>
        /// Método para imprimir los datos actuales de la lista
        /// </summary>
        public void ImprimirListaDeOpciones()
        {
            foreach ( Opcion o in this._listaDeOpciones )
            {
                System.Diagnostics.Debug.WriteLine( "Opcion: " + o.GetNombre() );
                System.Diagnostics.Debug.WriteLine( "Url: " + o.GetUrl() );
            }
        }

        #endregion
    }
}
