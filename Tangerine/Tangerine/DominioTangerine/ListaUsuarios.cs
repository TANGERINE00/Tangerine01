using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class ListaUsuarios
    {
        #region Atributos

        private List<Usuario> _listaDeUsuarios;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor de la lista
        /// </summary>
        public ListaUsuarios() 
        {
            this._listaDeUsuarios = new List<Usuario>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método para agregar un usuario a la lista
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public void AgregarUsuario( Usuario usuario ) 
        {
            this._listaDeUsuarios.Add( usuario );
        }

        /// <summary>
        /// Método para eliminar un usuario de la lista
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool EliminarUsuario( Usuario usuario ) 
        {
            return this._listaDeUsuarios.Remove( usuario );
        }

        /// <summary>
        /// Método para imprimir los datos actuales de la lista
        /// </summary>
        public void ImprimirListaDeUsuarios() 
        {
            foreach( Usuario u in this._listaDeUsuarios )
            {
                System.Diagnostics.Debug.Write( "Usuario: " + u.NombreUsuario );
                System.Diagnostics.Debug.Write( "Rol: " + u.Rol );
                System.Diagnostics.Debug.Write( "Fecha de creación: " + u.FechaCreacion );
                System.Diagnostics.Debug.Write( "Estatus: " + u.Activo );
            }
        }

        #endregion
    }
}
