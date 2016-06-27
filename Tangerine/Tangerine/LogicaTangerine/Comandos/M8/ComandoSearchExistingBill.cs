using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;
using DominioTangerine;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M8;

namespace LogicaTangerine.Comandos.M8
{
    /// <summary>
    /// Comando para verificar si existe una factura
    /// en una fecha, compania y proyecto determinado
    /// </summary>
    public class ComandoSearchExistingBill : Comando<bool>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// DEBE CONTENER LOS SIGUIENTES DATOS
        /// <param name="parametro">Factura -> fechaFactura</param>
        public ComandoSearchExistingBill(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <returns>booleano que refleja el exito de la ejecucion del comando</returns>
        public override bool Ejecutar()
        {
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                , ResourceLogicaM8.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                IDaoFactura daoFactura = FabricaDAOSqlServer.ObtenerDAOFactura();
                bool respuesta = daoFactura.CheckExistingInvoice(this.LaEntidad);
                return respuesta;
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceLogicaM8.Codigo,
                    ResourceLogicaM8.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceLogicaM8.Codigo,
                     ResourceLogicaM8.Mensaje_Error_Formato, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw ex;
            }
        }
    }
}