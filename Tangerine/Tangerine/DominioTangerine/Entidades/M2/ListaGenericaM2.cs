using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M2
{
    public class ListaGenericaM2<T> : Entidad , IEnumerable<T> 
    {
        #region Atributos

        private List<T> _listaGenerica;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase ListaGenericaM2
        /// </summary>
        public ListaGenericaM2() 
        {
            _listaGenerica = new List<T>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método para agregar un elemento a la lista
        /// </summary>
        /// <param name="elemento"></param>
        public void agregarElemento( T elemento )
        {
            _listaGenerica.Add( elemento );
        }

        /// <summary>
        /// Método para eliminar un elemento de la lista
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Retorna un valor booleano que indica si el elemento fue eliminado o no</returns>
        public bool eliminarElemento( T elemento )
        {
            return _listaGenerica.Remove( elemento );
        }

        /// <summary>
        /// Método para obtener el enumerador de la lista
        /// </summary>
        /// <returns>Retorna el enumaro de la lista</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _listaGenerica.GetEnumerator();
        }

        /// <summary>
        /// Método para obtener el enumerador de la lista
        /// </summary>
        /// <returns>Retorna el enumerador de la lista</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
