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
    /// Comando para modificar una factura
    /// </summary>
    public class ComandoModificarFactura : Comando<bool>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="parametro">Factura a modificar</param>
        public ComandoModificarFactura(Entidad parametro)
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
                bool respuesta = daoFactura.Modificar(this.LaEntidad);
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