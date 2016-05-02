using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class ListaMenus
    {
        #region Atributos

        private List<Menu> _listaDeMenus;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de la clase 
        /// </summary>
        public ListaMenus() 
        {
            this._listaDeMenus = new List<Menu>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método para agregar un menu a la lista
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public void AgregarMenu( Menu menu )
        {
            this._listaDeMenus.Add( menu );
        }

        /// <summary>
        /// Método para eliminar un menu de la lista
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public bool EliminarMenu( Menu menu )
        {
            return this._listaDeMenus.Remove( menu );
        }

        /// <summary>
        /// Método para imprimir los datos actuales de la lista
        /// </summary>
        public void ImprimirListaDeMenus()
        {
            foreach ( Menu m in this._listaDeMenus )
            {
                System.Diagnostics.Debug.WriteLine( "Menu: " + m.Nombre );
            }
        }

        #endregion
    }
}
