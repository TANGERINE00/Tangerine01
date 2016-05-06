using System;
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

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
