using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M2
{
    public class OpcionM2 : Entidad
    {
        #region Atributos

        private string _nombre;
        private string _url;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto de la clase OpcionM2
        /// </summary>
        public OpcionM2()
        {
        }

        /// <summary>
        /// Constructor con todos los atributos
        /// </summary>
        /// <param name="nombre">Es el nombre de la opcion</param>
        /// <param name="url">Es el url de la opcion</param>
        public OpcionM2( string nombre , string url )
        {
            _nombre = nombre;
            _url = url;
        }

        #endregion

        #region Get's y Set's

        /// <summary>
        /// Get y Set del nombre de la opción
        /// </summary>
        /// <returns>Retorna el nombre de la opción</returns>
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Get y Set del url de la opción
        /// </summary>
        /// <returns>Retorna el url de la opción</returns>
        public string url
        {
            get { return _url; }
            set { _url = value; }
        }

        #endregion
    }
}
