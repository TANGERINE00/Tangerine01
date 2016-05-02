using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    class Rol
    {
        #region Atributos

        private string _nombre;
        private ListaMenus _menus;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase Rol
        /// </summary>
        public Rol() 
        {

        }

        /// <summary>
        /// Constructor solo con el nombre
        /// </summary>
        /// <param name="nombre"></param>
        public Rol( string nombre ) 
        {
            this._nombre = nombre;
        }

        /// <summary>
        /// Constructor con todos los atributos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="menus"></param>
        public Rol( string nombre, ListaMenus menus ) : this( nombre ) 
        {
            this._menus = menus;
        }

        #endregion

        #region Get's

        /// <summary>
        /// Método que devuelve el nombre del rol
        /// </summary>
        /// <returns></returns>
        public string GetNombre() 
        {
            return this._nombre;
        }

        /// <summary>
        /// Método que devuelve la lista de menus
        /// </summary>
        /// <returns></returns>
        public ListaMenus GetMenus() 
        {
            return this._menus;
        }

        #endregion

        #region Set's

        /// <summary>
        /// Setea el nombre del rol
        /// </summary>
        /// <param name="nombre"></param>
        public void SetNombre( string nombre ) 
        {
            this._nombre = nombre;
        }

        /// <summary>
        /// Setea la lista de menus
        /// </summary>
        /// <param name="menus"></param>
        public void SetMenus( ListaMenus menus ) 
        {
            this._menus = menus;
        }

        #endregion
    }
}