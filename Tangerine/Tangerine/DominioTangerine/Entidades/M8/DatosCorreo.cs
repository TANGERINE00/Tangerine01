using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M8
{
    public class DatosCorreo : Entidad
    {
        #region Atributos

        private String _asunto;
        private String _destinatario;
        private String _mensaje;

        #endregion

        #region Get´s Set´s

        /// <summary>
        /// Metodo para setear y obtener el asunto del correo
        /// </summary>
        /// <returns>Retorna el tipo de moneda de la factura</returns>
        public String asunto
        {
            get { return _asunto; }
            set { _asunto = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener el destinatario del correo
        /// </summary>
        /// <returns>Retorna el tipo de moneda de la factura</returns>
        public String destinatario
        {
            get { return _destinatario; }
            set { _destinatario = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener el mensaje del correo
        /// </summary>
        /// <returns>Retorna el tipo de moneda de la factura</returns>
        public String mensjae
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        #endregion

        #region metodos

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public DatosCorreo() : base()
        {
            this._asunto = String.Empty;
            this._destinatario = String.Empty;
            this._mensaje = String.Empty;
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public DatosCorreo(string asunto,string destinatario,string mensaje)
            : base()
        {
            this._asunto = asunto;
            this._destinatario = destinatario;
            this._mensaje = mensaje;
        }

        #endregion
    }
}
