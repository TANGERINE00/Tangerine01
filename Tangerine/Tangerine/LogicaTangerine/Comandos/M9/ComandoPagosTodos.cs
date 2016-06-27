using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;
using DominioTangerine;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M9;

namespace LogicaTangerine.Comandos.M9
{
    /// <summary>
    /// Comando para consultar todos los pagos
    /// </summary>
    public class ComandoPagosTodos : Comando<List<Entidad>>
    {

        /// <summary>
        /// Metodo que ejecuta el comando
        /// </summary>
        /// <returns>booleano que refleja el exito de la ejecucion del comando</returns>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name
                , ResourceComandoM9.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                IDAOPago daoPago = FabricaDAOSqlServer.CrearDAOPago();
                List<Entidad> respuesta = daoPago.ConsultarTodos();
                return respuesta;
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceComandoM9.CodigoErrorNull,
                    ResourceComandoM9.MensajeErrorNull, ex);

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceComandoM9.CodigoErrorFormato,
                     ResourceComandoM9.MensajeErrorFormato, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceComandoM9.MensajeGenerico, ex);
            }
        }


    }
}
