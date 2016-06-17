using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M2
{
    public class MenuM2
    {
        #region Atributos

        private string _nombre;
        private ListaGenerica<Opcion> _opciones;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase Menu
        /// </summary>
        public MenuM2()
        {
        }

        /// <summary>
        /// Constructor que recibe el nombre del menu
        /// </summary>
        /// <param name="nombre"></param>
        public MenuM2( string nombre )
        {
            _nombre = nombre;
            _opciones = new ListaGenerica<Opcion>();
        }

        /// <summary>
        /// Constructor con todos los atributos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="opciones"></param>
        public MenuM2( string nombre, ListaGenerica<Opcion> opciones )
               :this ( nombre ) 
        {
            _opciones = opciones;
        }

        #endregion

        #region Get's y Set's

        /// <summary>
        /// Get y Set del nombre del menu
        /// </summary>
        /// <return>Retorna el nombre del menu</return>
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Get y Set de las opciones del menu
        /// </summary>
        /// <return>Retorna las opciones que posee el menu</return>
        public ListaGenerica<Opcion> opciones
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
