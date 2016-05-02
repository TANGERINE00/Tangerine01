using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class Opcion
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
        public Opcion( string nombre, string url )
        {
            this._nombre = nombre;
            this._url = url;
        }

        #endregion

        #region Get's y Set's

        /// <summary>
        /// Get y Set del nombre de la opción
        /// </summary>
        /// <returns></returns>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Get y Set del url de la opción
        /// </summary>
        /// <returns></returns>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        #endregion
    }
}
