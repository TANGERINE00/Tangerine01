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
        private ListaOpciones _opciones;

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
        /// <param name="opciones"></param>
        public Menu( string nombre, ListaOpciones opciones ) : this( nombre )
        {
            this._opciones = opciones;
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

        /// <summary>
        /// Método que devuelve las opciones del menu
        /// </summary>
        /// <returns></returns>
        public ListaOpciones GetOpciones() 
        {
            return this._opciones;
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

        /// <summary>
        /// Setea las opciones del menu
        /// </summary>
        /// <param name="opciones"></param>
        public void SetOpciones( ListaOpciones opciones ) 
        {
            this._opciones = opciones;
        }

        #endregion
    }
}
