using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    class Menu
    {
        #region Atributos

        private string _nombre;
        private List<Opcion> _listaDeOpciones;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase Menu
        /// </summary>
        public Menu()
        {

        }

        /// <summary>
        /// Constructor solo con el nombre del menu
        /// </summary>
        /// <param name="nombre"></param>
        public Menu( string nombre ) 
        {
            this._nombre = nombre;
        }

        /// <summary>
        /// Constructor con todos los atributos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="listaDeOpciones"></param>
        public Menu( string nombre, List<Opcion> listaDeOpciones ) : this( nombre )
        {
            this._listaDeOpciones = listaDeOpciones;
        }

        #endregion

        #region Get's

        /// <summary>
        /// Método que devuelve el nombre del menu
        /// </summary>
        /// <returns></returns>
        public string GetNombre() 
        {
            return this._nombre;
        }

        #endregion

        #region Set's

        /// <summary>
        /// Setea el nombre del menu
        /// </summary>
        /// <param name="nombre"></param>
        public void SetNombre( string nombre ) 
        {
            this._nombre = nombre;
        }

        #endregion

        #region Otros métodos

        /// <summary>
        /// Método para agregar una opcion a la lista
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public void AgregarOpcion( Opcion opcion )
        {
            this._listaDeOpciones.Add( opcion );
        }

        /// <summary>
        /// Método para eliminar una opcion de la lista
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public bool EliminarOpcion( Opcion opcion )
        {
            return this._listaDeOpciones.Remove( opcion );
        }

        /// <summary>
        /// Método para imprimir los datos actuales de la lista
        /// </summary>
        public void ImprimirListaDeOpciones()
        {
            System.Diagnostics.Debug.WriteLine( this._nombre + ":" );

            foreach ( Opcion o in this._listaDeOpciones )
            {
                System.Diagnostics.Debug.WriteLine( "Opcion: " + o.GetNombre() );
                System.Diagnostics.Debug.WriteLine( "Url: " + o.GetUrl() );
            }
        }

        #endregion
    }
}
