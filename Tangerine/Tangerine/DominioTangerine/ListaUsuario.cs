using System;
using System.Collections.Generic;

namespace DominioTangerine 
{
    public class ListaUsuario
    {
        private SortedSet<Usuario> _listaDeUsuarios;
        private ComparadorUsuario _comparador;

        /// <summary>
        /// Constructor de la lista
        /// </summary>
        public ListaUsuario() 
        {
            this._comparador = new ComparadorUsuario();
            this._listaDeUsuarios = new SortedSet<Usuario>( _comparador );
        }

        /// <summary>
        /// Método para agregar un usuario a la lista
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool agregarUsuario( Usuario usuario ) 
        {
            return this._listaDeUsuarios.Add( usuario );
        }

        /// <summary>
        /// Método para eliminar un usuario de la lista
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool eliminarUsuario( Usuario usuario ) 
        {
            return this._listaDeUsuarios.Remove( usuario );
        }

        /// <summary>
        /// Método para imprimir los datos actuales de la lista
        /// </summary>
        public void imprimirListaDeUsuarios() 
        {
            foreach( Usuario u in this._listaDeUsuarios )
            {
                System.Diagnostics.Debug.Write( "Usuario: " + u.getUsuario() );
                System.Diagnostics.Debug.Write( "Rol: " + u.getRol() );
                System.Diagnostics.Debug.Write( "Fecha de creación: " + u.getFechaCreacion() );
                System.Diagnostics.Debug.Write( "Estatus: " + u.getActivo() );
            }
        }
    }
}