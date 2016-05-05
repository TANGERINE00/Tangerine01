using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class Facturacion
    {
        #region Atributos

        private int _idNumeroFactura;
        private DateTime _fecha;
        private int _idCliente;
        private int _idProyecto;
        private String _descripcion;
        private double _monto;
        private double _montoRestante;

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
        /// Metodo para setear y obtener el id del cliente en la factura
        /// </summary>
        /// <returns>Retorna el id del cliente de la factura</returns>

        public int idClienteFactura
        {
            get { return _idCliente; }
            set { _idCliente = value; }
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


        #endregion

        #region Constructores

        /// <summary>
        /// Constructor con los atributos.
        /// </summary>
        /// <param name="idNumeroFactura"></param>
        /// <param name="fecha"></param>
        /// <param name="idCliente"></param>
        /// <param name="idProyecto"></param>
        /// <param name="descripcion"></param>
        /// <param name="monto"></param>
        /// <param name="montoRestante"></param>
        public Facturacion()
        {
            _idNumeroFactura = 0;
            _fecha = DateTime.Now;
            _idCliente = 0;
            _idProyecto = 0;
            _descripcion = String.Empty;
            _monto = 0;
            _montoRestante = 0;
        }


        /// <summary>
        /// Constructor con los atributos.
        /// </summary>
        /// <param name="idNumeroFactura"></param>
        /// <param name="fecha"></param>
        /// <param name="idCliente"></param>
        /// <param name="idProyecto"></param>
        /// <param name="descripcion"></param>
        /// <param name="monto"></param>
        /// <param name="montoRestante"></param>
        public Facturacion( int idNumeroFactura, DateTime fecha,   double monto, double montoRestante, String descripcion, int idProyecto, int idCliente )
        {
            this._idNumeroFactura = idNumeroFactura;
            this._fecha = fecha;
            this._idCliente = idCliente;
            this._idProyecto = idProyecto;
            this._descripcion = descripcion;
            this._monto = monto;
            this._montoRestante = montoRestante;
        }

        #endregion
    }
}
