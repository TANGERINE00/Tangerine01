using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class Menu
    {
        #region Atributos

        private string _nombre;
        private ListaGenerica<Opcion> _opciones;

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
            _nombre = nombre;
        }

        /// <summary>
        /// Constructor con todos los atributos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="opciones"></param>
        public Menu( string nombre, ListaGenerica<Opcion> opciones ) : this( nombre )
        {
            _opciones = opciones;
        }

        #endregion

        #region Get's y Set's

        /// <summary>
        /// Get y Set del nombre del menu
        /// </summary>
        /// <returns>El nombre del menu</returns>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Get y Set de las opciones del menu
        /// </summary>
        /// <returns>Opciones que posee el menu</returns>
        public ListaGenerica<Opcion> Opciones
        {
            get { return _opciones; }
            set { _opciones = value; }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método para imprimir los datos actuales de la lista
        /// </summary>
        public void imprimirListaDeOpciones() 
        {
            foreach (Opcion o in _opciones)
            {
                System.Diagnostics.Debug.WriteLine("Opcion: " + o.Nombre);
                System.Diagnostics.Debug.WriteLine("Url: " + o.Url);
            }
        }

        #endregion
    }
}
