using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class Pago
    {
        #region Atributos

        private int _idPago;
        private int _montoPago;
        private string _monedaPago;
        private string _formaPago;
        private int _codPago;
        private DateTime _fechaPago;
        private int _idFactura;

        #endregion

        #region Constructores

        public Pago(int _idPago, int _montoPago, string _monedaPago, string _formaPago, int _codPago, DateTime _fechaPago, int _idFactura)
        {
            this._idPago = _idPago;
            this._montoPago = _montoPago;
            this._monedaPago = _monedaPago;
            this._formaPago = _formaPago;
            this._codPago = _codPago;
            this._fechaPago = _fechaPago;
            this._idFactura = _idFactura;
        }

        public Pago(string _monedaPago, int _montoPago, string _formaPago, int _codPago, DateTime _fechaPago, int _idFactura)
        {

            this._monedaPago = _monedaPago;
            this._montoPago = _montoPago;
            this._formaPago = _formaPago;
            this._codPago = _codPago;
            this._fechaPago = _fechaPago;
            this._idFactura = _idFactura;
        }

        #endregion

        #region Get's y Set's

        public int IdPago
        {
            get { return _idPago; }
            set { _idPago = value; }
        }

        public int montoPago
        {
            get { return _montoPago; }
            set { _montoPago = value; }
        }

        public string monedaPago
        {
            get { return _monedaPago; }
            set { _monedaPago = value; }
        }

        public string formaPago
        {
            get { return _formaPago; }
            set { _formaPago = value; }
        }

        public int codPago
        {
            get { return _codPago; }
            set { _codPago = value; }
        }

        public DateTime fechaPago
        {
            get { return _fechaPago; }
            set { _fechaPago = value; }
        }

        public int idFactura
        {
            get { return _idFactura; }
            set { _idFactura = value; }
        }

        #endregion
    }
}