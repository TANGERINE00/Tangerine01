using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M2
{
    public class RolM2 : Entidad
    {
        #region Atributos

        private string _nombre;
        private ListaGenerica<Menu> _menu;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor vacío de la clase Rol
        /// </summary>
        public RolM2()
        {
        }

        /// <summary>
        /// Constructor de la clase Rol con nombre
        /// </summary>
        /// <param name="nombre"></param>
        public RolM2( string nombre )
        {
            _nombre = nombre;
            _menu = new ListaGenerica<Menu>();
        }

        /// <summary>
        /// Constructor de la clase Rol con todos sus atributos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="menus"></param>
        public RolM2( string nombre, ListaGenerica<Menu> menu )
            :this(nombre)
        {
            _menu = menu;
        }

        #endregion

        #region Get's y Set's

        /// <summary>
        /// Get y Set del atributo _nombre
        /// </summary>
        /// <returns>Nombre del rol</returns>
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Get y Set de la lista de menu
        /// </summary>
        /// <returns>Lista de los menus que continen las opciones a las que no puede acceder el rol</returns>
        public ListaGenerica<Menu> menu
        {
            get { return _menu; }
            set { _menu = value; }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método para imprimir los datos actuales de la lista
        /// </summary>
        public void imprimirListaDeMenu()
        {
            foreach ( Menu m in _menu )
            {
                System.Diagnostics.Debug.WriteLine( "Menú: " + m.Nombre );
            }
        }

        #endregion
    }
}
