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
        static public DominioTangerine.Entidades.M4.CompaniaM4 crearCompaniaVacia()
        {
            return new DominioTangerine.Entidades.M4.CompaniaM4();
        }

        static public DominioTangerine.Entidades.M4.CompaniaM4 crearCompaniaConId(int inputId, string inputNombre, string inputRif, string inputEmail, string inputTelefono,
                                                                                string inputAcronimo, DateTime inputFechaRegistro, int inputStatus, int inputPresupuesto,
                                                                                int inputPlazoPago, int inputIdLugar)
        {
            return new DominioTangerine.Entidades.M4.CompaniaM4( inputId, inputNombre , inputRif , inputEmail ,
                                                               inputTelefono , inputAcronimo , inputFechaRegistro , 
                                                               inputStatus , inputPresupuesto , inputPlazoPago ,
                                                               inputIdLugar );
        }

        static public DominioTangerine.Entidades.M4.CompaniaM4 crearCompaniaSinId(string inputNombre, string inputRif, string inputEmail, string inputTelefono, 
                                                                                string inputAcronimo, DateTime inputFechaRegistro, int inputStatus, 
                                                                                int inputPresupuesto, int inputPlazoPago, int inputIdLugar)
        {
            return new DominioTangerine.Entidades.M4.CompaniaM4( inputNombre , inputRif , inputEmail , inputTelefono ,
                                                               inputAcronimo , inputFechaRegistro , inputStatus ,
                                                               inputPresupuesto , inputPlazoPago , inputIdLugar );
        }

        static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionVacio()
        {
            return new DominioTangerine.Entidades.M4.LugarDireccionM4();
        }

        static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionConLugar(int lugId, string lugNombre)
        {
            return new DominioTangerine.Entidades.M4.LugarDireccionM4( lugId , lugNombre );
        }

        static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionCuatroParametros(int lugId, string lugNombre, string lugTipo, int fk_lugId)
        {
            return new DominioTangerine.Entidades.M4.LugarDireccionM4( lugId , lugNombre , lugTipo , fk_lugId );
        }

        static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionCompleto(int lugId, string lugNombre, string lugTipo, int fk_lugId,
                                                                                               List<DominioTangerine.Entidades.M4.LugarDireccionM4> address)
        {
            return new DominioTangerine.Entidades.M4.LugarDireccionM4( lugId , lugNombre , lugTipo , fk_lugId , 
                                                                     address);
        }

        static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionConLugarTipo(string lugNombre, string lugTipo)
        {
            return new DominioTangerine.Entidades.M4.LugarDireccionM4(lugNombre, lugTipo );
        }




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
