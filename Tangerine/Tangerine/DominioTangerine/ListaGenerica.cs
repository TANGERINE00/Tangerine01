using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class ListaGenerica<T> : IEnumerable<T>
    {
        #region Atributos
        
        private List<T> _listaGenerica;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la clase 
        /// </summary>
        public ListaGenerica() 
        {
            _listaGenerica = new List<T>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método para agregar un elemento a la lista
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public void AgregarElemento(T elemento)
        {
            _listaGenerica.Add(elemento);
        }

        /// <summary>
        /// Método para eliminar un elemento de la lista
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public bool EliminarElemento(T elemento)
        {
            return _listaGenerica.Remove(elemento);
        }

        #endregion

        /// <summary>
        /// Método para obtener el enumerador de la lista
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _listaGenerica.GetEnumerator();
        }

        /// <summary>
        /// Método que retorna el enumerador
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() 
        {
            return GetEnumerator();
        }
    }
}
