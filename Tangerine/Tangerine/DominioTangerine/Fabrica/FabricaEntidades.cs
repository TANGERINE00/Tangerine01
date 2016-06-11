using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace DominioTangerine.Fabrica
{
    public class FabricaEntidades
    {
        #region Modulo 1
       
        #endregion

        #region Modulo 2

        #endregion

        #region Modulo 3

        #endregion

        #region Modulo 4

        #endregion

        #region Modulo 5

        #endregion

        #region Modulo 6

        #endregion

        #region Modulo 7

        #endregion

        #region Modulo 8

        #endregion

        #region Modulo 9
        public static Entidad ObtenerPago_M9(int idPago, int montoPago, string monedaPago, string formaPago,
           int codPago, DateTime fechaPago, int idFactura)
        {
            return new DominioTangerine.Entidades.M9.Pago(idPago, montoPago, monedaPago, formaPago, codPago, fechaPago, idFactura);
        }

        public static Entidad ObtenerPago_M9(string monedaPago, int montoPago, string formaPago, int codPago, DateTime fechaPago,
          int idFactura)
        {
            return new DominioTangerine.Entidades.M9.Pago(monedaPago, montoPago, formaPago, codPago, fechaPago, idFactura );
        }

        #endregion

        #region Modulo 10

        #endregion
    }
}
