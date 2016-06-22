using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M9
{
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
        public Pago ()
        {
            
        }

        public Pago(int _idFactura, DateTime _fechaPago, double _montoPago, string _monedaPago, int _codPago)
        {
            this._idFactura = _idFactura;
            this._fechaPago = _fechaPago;
            this._montoPago = _montoPago;
            this._monedaPago = _monedaPago;
            this._codPago = _codPago;
     
        }

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
