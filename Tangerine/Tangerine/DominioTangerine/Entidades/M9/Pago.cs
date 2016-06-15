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
        private int _montoPago;
        private string _monedaPago;
        private string _formaPago;
        private int _codPago;
        private DateTime _fechaPago;
        private int _idFactura;
        #endregion

        #region Constructores
        public Pago ()
        {
            
        }

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

        #region Get's
        public int idPago
        {
            get { return _idPago; }
        }
        public int montoPago
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
