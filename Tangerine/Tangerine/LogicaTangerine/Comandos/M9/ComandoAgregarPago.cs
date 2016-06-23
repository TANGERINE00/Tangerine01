using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO.M9;
using DatosTangerine.InterfazDAO.M9;
using DatosTangerine.Fabrica;
using DominioTangerine;
using ExcepcionesTangerine;

namespace LogicaTangerine.Comandos.M9
{
    public class ComandoAgregarPago : Comando<Boolean>
    {


        public ComandoAgregarPago (Entidad entidad)
        {
            this._laEntidad = entidad;
        }
        /// <summary>
        /// Método para crear la instancia de la clase DaoPago y agregar el pago
        /// </summary>
        /// <returns></returns>
        public override Boolean Ejecutar()
        {
            IDAOPago Pago = FabricaDAOSqlServer.CrearDAOPago();


            try
            {
                Pago.Agregar(this._laEntidad);

                return Pago.Agregar(this._laEntidad);
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
