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

        private int _idFactura;
        private DateTime _fechaPago;
        private int _numeroConfirmacion;
        private string _tipoPago;

        #endregion

        #region Constructores

        public Pago (int idFactura, DateTime fechaPago, int numeroConfirmacion)
        {
            this._idFactura = idFactura;
            this._fechaPago = fechaPago;
            this._numeroConfirmacion = numeroConfirmacion;
        }

        #endregion

        #region Get's y Set's

        public int Idfactura
        {
            get { return _idFactura; }
            set { _idFactura = value; }
        }

        public DateTime Fechapago
        {
            get { return _fechaPago; }
            set { _fechaPago = value; }
        }

        public int NumeroConfirmacion
        {
            get { return _numeroConfirmacion; }
            set { _numeroConfirmacion = value; }
        }

        public string TipoPago
        {
            get { return _tipoPago; }
            set { _tipoPago = value; }
        }
        #endregion
    }
}