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
    /// Comando para consultar pagos de una compañia
    /// </summary>
    public class ComandoConsultarPagos : Comando<List<Entidad>>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="parametro">Compania a buscar pagos</param>
        public ComandoConsultarPagos(Entidad parametro)
        {
            LaEntidad = parametro;
        }

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
                return daoPago.ConsultarPagosCompania(LaEntidad);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(ResourceComandoM9.Codigo,
                    ResourceComandoM9.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceComandoM9.Codigo_Error_Formato,
                     ResourceComandoM9.Mensaje_Error_Formato, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(ResourceComandoM9.Mensaje_Generico_Error, ex);
            }
        }
    }
}
