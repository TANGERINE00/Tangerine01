using DatosTangerine.InterfazDAO.M3;
using DatosTangerine.M3;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;

namespace DatosTangerine.DAO.M3
{
    public class DaoLead : DAOGeneral, IDAOLead
    {
        #region IDAOLead
        #endregion

        #region DAO General
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarXId(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> objetolistaClientePotencial = new List<Entidad>();

            // List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<Parametro> parametros = new List<Parametro>();

            //BDConexion conexion = new BDConexion();
            DataTable data = new DataTable();
            data = theConnection.EjecutarStoredProcedureTuplas(ResourceClientePotencial.SP_listarClientePotencial, parametros);
            try
            {
                foreach (DataRow row in data.Rows)
                {

                    //Empleado empleado = new Empleado();
                    //ClientePotencial clientePotencial = new ClientePotencial();

                    Entidad lead = DominioTangerine.Fabrica.FabricaEntidades.ObtenerLead();

                    ((DominioTangerine.Entidades.M3.ClientePotencial)lead).IdClientePotencial = Int32.Parse(row[ResourceClientePotencial.idClientePotencial].ToString());
                    ((DominioTangerine.Entidades.M3.ClientePotencial)lead).NombreClientePotencial = row[ResourceClientePotencial.nombreClientePotencial].ToString();
                    //ese nombre en mayuscula es el del set y el get de la capa de dominio

                    ((DominioTangerine.Entidades.M3.ClientePotencial)lead).RifClientePotencial = row[ResourceClientePotencial.rifClientePotencial].ToString();
                    ((DominioTangerine.Entidades.M3.ClientePotencial)lead).EmailClientePotencial = row[ResourceClientePotencial.emailClientePotencial].ToString();
                    ((DominioTangerine.Entidades.M3.ClientePotencial)lead).PresupuestoAnual_inversion = float.Parse(row[ResourceClientePotencial.presupuestoAnual_inversion].ToString());
                    ((DominioTangerine.Entidades.M3.ClientePotencial)lead).Status = Int32.Parse(row[ResourceClientePotencial.status].ToString());


                    objetolistaClientePotencial.Add(lead);

                }
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }

            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(ResourceClientePotencial.Codigo_Error_Formato,
                    ResourceClientePotencial.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return objetolistaClientePotencial;
        }
        #endregion
    }
}
