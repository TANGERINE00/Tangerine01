using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M6;
using ExcepcionesTangerine;

namespace LogicaTangerine.M6
{
    public class LogicaPropuesta
    {


        /// <summary>
        /// Metodo para agregar una nueva propuesta.
        /// </summary>
        /// <param name="propuesta">objeto de tipo Propuesta para agregar</param>
        /// <returns>true si fue agregado</returns>
        public bool agregar(Propuesta propuesta)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicaRecursos.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                return BDPropuesta.agregarPropuesta(propuesta);
            }
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            catch (System.Data.SqlClient.SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaRecursos.Codigo,
                    LogicaRecursos.Mensaje, ex);
            }
            
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaRecursos.Mensaje_Generico_Error, ex);
            }
        }

        public Propuesta TraerPropuesta(String id) 
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicaRecursos.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                return BDPropuesta.ConsultarPropuestaporNombre(id);
            }
            

            catch (System.Data.SqlClient.SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaRecursos.Codigo,
                    LogicaRecursos.Mensaje, ex);
            }

            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaRecursos.Mensaje_Generico_Error, ex);
            }
            
        }

        public Boolean BorrarPropuesta(String id)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicaRecursos.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
            return BDPropuesta.BorrarPropuesta(id);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaRecursos.Codigo,
                    LogicaRecursos.Mensaje, ex);
            }

            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaRecursos.Mensaje_Generico_Error, ex);
            }

        }


        
        /// <summary>
        /// Metodo para consultar todas laspropuestas
        /// </summary>
        /// <param name="propuesta">objeto de tipo Propuesta para agregar</param>
        /// <returns>true si fue agregado</returns>
        public List<Propuesta> ConsultarTodasPropuestas()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicaRecursos.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                return BDPropuesta.ListarLasPropuestas();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaRecursos.Codigo,
                    LogicaRecursos.Mensaje, ex);
            }

            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaRecursos.Mensaje_Generico_Error, ex);
            }
        }


        /// <summary>
        /// Metodo para modificar las propuestas en la BD
        /// </summary>
        /// <param name="laPropuesta"></param>
        /// <returns></returns>

        public Boolean ModificarPropuesta(Propuesta laPropuesta)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            LogicaRecursos.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                return BDPropuesta.Modificar_Propuesta(laPropuesta);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicaRecursos.Codigo,
                    LogicaRecursos.Mensaje, ex);
            }

            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(LogicaRecursos.Mensaje_Generico_Error, ex);
            }

        }



        
       

       
    }
}
