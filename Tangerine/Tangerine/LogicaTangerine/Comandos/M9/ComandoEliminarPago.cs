using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M9;
using ExcepcionesTangerine;

namespace LogicaTangerine.Comandos.M9
{
    public class ComandoEliminarPago : Comando <Boolean>
    {

            /// <summary>
            /// Constructor del Comando Agregar Pago
            /// </summary>
            /// <param name="entidad">Entidad, parametro que sera asignado para utilizar su valor</param>
            public ComandoEliminarPago(Entidad entidad)
            {
                this._laEntidad = entidad;
            }
            /// <summary>
            /// Método para crear la instancia de la clase DaoPago y agregar el pago
            /// </summary>
            /// <returns>Regresa un Booleano indicando si el metodo se ejecuto exitosamente o no</returns>
            public override Boolean Ejecutar()
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                           ResourceComandoM9.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                IDAOPago Pago = FabricaDAOSqlServer.CrearDAOPago();


                try
                {
                    Pago.Agregar(this._laEntidad);
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                          ResourceComandoM9.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return Pago.EliminarPago(this._laEntidad);
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
