using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    class Opcion
    {
        #region Atributos

        private string _nombre;
        private string _url;

        #endregion

        #region Cosntructores

        /// <summary>
        /// Constructorpor defecto de la clase Opcion
        /// </summary>
        public Opcion()
        {

        }

        /// <summary>
        /// Constructor con todos los atributos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="url"></param>
        public Opcion(string nombre, string url)
        {
            this._nombre = nombre;
            this._url = url;
        }

        #endregion

        #region Get's

        /// <summary>
        /// Método que devuelve el nombre de la opción
        /// </summary>
        /// <returns></returns>
        public string GetNombre()
        {
            return this._nombre;
        }

        /// <summary>
        /// Método que devuelve el url de la opción
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            return this._url;
        }

        #endregion
    }
}
