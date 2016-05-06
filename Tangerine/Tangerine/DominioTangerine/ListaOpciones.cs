using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class ListaOpciones
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
            _listaDeOpciones.Add( opcion );
        }

        /// <summary>
        /// Método para eliminar una opcion de la lista
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public bool EliminarOpcion( Opcion opcion )
        {
            return _listaDeOpciones.Remove( opcion );
        }

        /// <summary>
        /// Método para imprimir los datos actuales de la lista
        /// </summary>
        public void ImprimirListaDeOpciones()
        {
            foreach ( Opcion o in _listaDeOpciones )
            {
                System.Diagnostics.Debug.WriteLine( "Opcion: " + o.Nombre );
                System.Diagnostics.Debug.WriteLine( "Url: " + o.Url );
            }
        }

        #endregion
    }
}
