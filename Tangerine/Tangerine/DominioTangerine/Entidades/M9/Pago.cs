using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M9
{
    /// <summary>
    /// Clase Pago, hereda de la clase Entidad
    /// </summary>
    public class Pago : Entidad
    {
        #region Atributos

        private int _idPago;
        private double _montoPago;
        private string _monedaPago;
        private string _formaPago;
        private int _codPago;
        private DateTime _fechaPago;
        private int _idFactura;
        private DateTime _fechaFactura;
        #endregion

        #region Constructores
       /// <summary>
       /// Constructor de Pago Vacio
       /// </summary>
        public Pago ()
        {
            
        }

        /// <summary>
        /// Constructor de Pago con 5 atributos
        /// </summary>
        /// <param name="_idFactura">Entero, Id de la Factura que se paga</param>
        /// <param name="_fechaPago">DateTime, Fecha que se realiza el pago</param>
        /// <param name="_montoPago">Double, Monto por el que se realiza el pago</param>
        /// <param name="_monedaPago">String, Moneda en la que se realiza el pago</param>
        /// <param name="_codPago">Entero, Codigo de 10 digitos para confirmar el pago</param>
        public Pago(int _idFactura, DateTime _fechaPago, double _montoPago, string _monedaPago, int _codPago)
        {
            this._idFactura = _idFactura;
            this._fechaPago = _fechaPago;
            this._montoPago = _montoPago;
            this._monedaPago = _monedaPago;
            this._codPago = _codPago;
     
        }

       /// <summary>
       /// Constructor de Pago con 7 atributos
       /// </summary>
       /// <param name="_idPago">Entero, Id del pago</param>
       /// <param name="_montoPago">Double, Monto por el que se realiza el pago</param>
       /// <param name="_monedaPago">String, Moneda en la que se realiza el pago</param>
       /// <param name="_formaPago">String, Forma del pago realizado</param>
       /// <param name="_codPago">Entero, Codigo de 10 digitos para confirmar el pago</param>
       /// <param name="_fechaPago">DateTime, Fecha en la que se realizo el Pago</param>
       /// <param name="_idFactura">Entero, Id de la factura que se va a pagar</param>
        public Pago(int _idPago, double _montoPago, string _monedaPago, string _formaPago, int _codPago, 
            DateTime _fechaPago, int _idFactura)
        {
            this._idPago = _idPago;
            this._montoPago = _montoPago;
            this._monedaPago = _monedaPago;
            this._formaPago = _formaPago;
            this._codPago = _codPago;
            this._fechaPago = _fechaPago;
            this._idFactura = _idFactura;
        }

        /// <summary>
        /// Constructor de Pago con 6 atributos
        /// </summary>
        /// <param name="_monedaPago">String, Moneda en la que se realiza el pago</param>
        /// <param name="_montoPago">Double, Monto por el que se realiza el pago</param>
        /// <param name="_formaPago">String, Forma en la que se realizo el pago</param>
        /// <param name="_codPago">Entero, Codigo de 10 digitos para confirmar el pago</param>
        /// <param name="_fechaPago">DateTime, Fecha en la que se realizo el pago</param>
        /// <param name="_idFactura">Entero, Id de la factura que se va a pagar</param>
        public Pago(string _monedaPago, double _montoPago, string _formaPago, int _codPago, DateTime _fechaPago, 
            int _idFactura)
        {

            this._monedaPago = _monedaPago;
            this._montoPago = _montoPago;
            this._formaPago = _formaPago;
            this._codPago = _codPago;
            this._fechaPago = _fechaPago;
            this._idFactura = _idFactura;
        }

       /// <summary>
       /// Constructor de Pago con 5 Atributos
       /// </summary>
       /// <param name="_codPago">Entero, Codigo de 10 digitos para confirmar el pago</param>
       /// <param name="_montoPago">Double, Monto por el que se realiza el pago</param>
       /// <param name="_monedaPago">String, Moneda en la que se realiza el pago</param>
       /// <param name="_formaPago">String, Forma en la que se realiza el pago</param>
       /// <param name="_idFactura">Entero, Id de la factura que se paga</param>
        public Pago(int _codPago, double _montoPago, string _monedaPago, string _formaPago, int _idFactura)
        {
            this._codPago = _codPago;
            this._montoPago = _montoPago;
            this._monedaPago = _monedaPago;
            this._formaPago = _formaPago;
            this._idFactura = _idFactura;
        }

        #endregion

        #region Get's
        public int idPago
        {
            get { return _idPago; }
        }
        public double montoPago
        {
            get { return _montoPago; }
        }
        public String monedaPago
        {
            get { return _monedaPago; }
        }
        public String formaPago
        {
            get { return _formaPago; }
        }
        public int codPago
        {
            get { return _codPago; }
        }
        public DateTime fechaPago
        {
            get { return _fechaPago; }
        }
        public int idFactura
        {
            get { return _idFactura; }
        }
        #endregion
    }
}
