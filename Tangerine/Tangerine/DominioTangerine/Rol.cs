using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class Rol
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

        #region Get's y Set's

        /// <summary>
        /// Get y Set del nombre del rol
        /// </summary>
        /// <returns>Nombre del rol</returns>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Get y Set de la lista de menus
        /// </summary>
        /// <returns>Lista de los menus a los que puede acceder el rol</returns>
        public ListaMenus Menus
        {
            get { return _menus; }
            set { _menus = value; }
        }

        #endregion
    }
}