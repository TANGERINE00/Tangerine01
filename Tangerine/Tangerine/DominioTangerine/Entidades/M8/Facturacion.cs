using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M8
{
    public class Facturacion : Entidad
    {
        #region Atributos

        private int _idNumeroFactura;
        private DateTime _fecha;
        private DateTime _fechaUltimoPago;
        private int _idCompania;
        private int _idProyecto;
        private String _descripcion;
        private int _estatus;
        private double _monto;
        private double _montoRestante;
        private String _tipoMoneda;

        #endregion

        #region Get´s Set´s

        /// <summary>
        /// Metodo para setear y obtener el ID de la factura
        /// </summary>
        /// <returns>Retorna el id de la factura</returns>
        public int idFactura
        {
            get { return _idNumeroFactura; }
            set { _idNumeroFactura = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener la fecha de la factura
        /// </summary>
        /// <returns>Retorna la fecha de la factura</returns>
        public DateTime fechaFactura
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener la fecha de ultimo pago de la factura
        /// </summary>
        /// <returns>Retorna la fecha de ultimo pago de la factura</returns>
        public DateTime fechaUltimoPagoFactura
        {
            get { return _fechaUltimoPago; }
            set { _fechaUltimoPago = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener el id del compañia en la factura
        /// </summary>
        /// <returns>Retorna el id del compañia de la factura</returns>
        public int idCompaniaFactura
        {
            get { return _idCompania; }
            set { _idCompania = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener el monto de la factura
        /// </summary>
        /// <returns>Retorna el monto de la factura</returns>
        public double montoFactura
        {
            get { return _monto; }
            set { _monto = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener el monto restante de la factura
        /// </summary>
        /// <returns>Retorna el monto restante de la factura</returns>
        public double montoRestanteFactura
        {
            get { return _montoRestante; }
            set { _montoRestante = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener el tipo de moneda de la factura
        /// </summary>
        /// <returns>Retorna el tipo de moneda de la factura</returns>
        public String tipoMoneda
        {
            get { return _tipoMoneda; }
            set { _tipoMoneda = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener el id proyecto de la factura
        /// </summary>
        /// <returns>Retorna el id del proyecto de la factura</returns>
        public int idProyectoFactura
        {
            get { return _idProyecto; }
            set { _idProyecto = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener la descripcion del proyecto de la factura
        /// </summary>
        /// <returns>Retorna la descripcion del proyecto de la factura</returns>
        public String descripcionFactura
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        /// <summary>
        /// Metodo para setear y obtener el estatus de la factura
        /// </summary>
        /// <returns>Retorna el estatus de la factura</returns>
        public int estatusFactura
        {
            get { return _estatus; }
            set { _estatus = value; }
        }

        #endregion

        #region metodos

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Facturacion()
        {
            this._fecha = DateTime.Now;
            this._fechaUltimoPago = DateTime.Now;
            this._idCompania = 0;
            this._idProyecto = 0;
            this._descripcion = String.Empty;
            this._estatus = 0;
            this._monto = 0;
            this._montoRestante = 0;
            this._tipoMoneda = String.Empty;
        }



        #endregion
    }
}
