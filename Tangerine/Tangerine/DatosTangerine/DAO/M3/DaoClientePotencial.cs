using DatosTangerine.InterfazDAO.M3;
using DatosTangerine.M3;
using DominioTangerine.Entidades.M3;
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
    public class DaoClientePotencial : DAOGeneral, IDAOClientePotencial
    {
        #region IDAOClientePotencial

        public bool Activar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            DominioTangerine.Entidades.M3.ClientePotencial elCliente = (DominioTangerine.Entidades.M3.ClientePotencial)parametro;
            elCliente.IdClientePotencial = parametro.Id;
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                theParam = new Parametro(ResourceClientePotencial.AidClientePotencial,
                    SqlDbType.Int, elCliente.IdClientePotencial.ToString(), false);
                parameters.Add(theParam);

                List<Resultado> results =
                    theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_ActivarClientePotencial, parameters);

            }

            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
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
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }
        public bool Desactivar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            DominioTangerine.Entidades.M3.ClientePotencial elClientePotencial = (DominioTangerine.Entidades.M3.ClientePotencial)parametro;
            elClientePotencial.IdClientePotencial = parametro.Id;
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceClientePotencial.AidClientePotencial, SqlDbType.Int,
                elClientePotencial.IdClientePotencial.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M3_DesactivarClientePotencial y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_eliminarClientePotencial, parameters);

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

            return true;
        }
        #endregion

        #region DAO General
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            DominioTangerine.Entidades.M3.ClientePotencial elClientePotencial = (DominioTangerine.Entidades.M3.ClientePotencial)parametro;
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceClientePotencial.AidClientePotencial, SqlDbType.Int,
                elClientePotencial.IdClientePotencial.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.AnombreClientePotencial, SqlDbType.VarChar,
                elClientePotencial.NombreClientePotencial, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.ArifClientePotencial, SqlDbType.VarChar,
                elClientePotencial.RifClientePotencial, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.AemailClientePotencial, SqlDbType.VarChar,
                elClientePotencial.EmailClientePotencial, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.ApresupuestoAnualInversion, SqlDbType.Decimal,
                elClientePotencial.PresupuestoAnual_inversion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.AnumLlamadas, SqlDbType.Int,
                elClientePotencial.NumeroLlamadas.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.AnumVisitas, SqlDbType.Int,
                elClientePotencial.NumeroVisitas.ToString(), false);
                parameters.Add(theParam);


                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_modificarClientePotencial, parameters);

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

            return true;
        }

        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
            //QUITAR DOMINIOTANGERINE AQUI Y EN EL RESTO DEL CODIGO LUEGO DE BORRAR CLIENTE POTENCIAL DEL DOMINIO
            DominioTangerine.Entidades.M3.ClientePotencial cliente = (DominioTangerine.Entidades.M3.ClientePotencial)parametro;
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<DominioTangerine.Entidades.M3.ClientePotencial> listClientePotencial = new List<DominioTangerine.Entidades.M3.ClientePotencial>();
            DominioTangerine.Entidades.M3.ClientePotencial elClientePotencial = null;

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceClientePotencial.AidClientePotencial, SqlDbType.Int,
                cliente.Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceClientePotencial.SP_consultarClientePotencial, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int IdClientePotencial = int.Parse(row[ResourceClientePotencial.idClientePotencial].ToString());
                    String NombreClientePotencial = row[ResourceClientePotencial.nombreClientePotencial].ToString();
                    String RifClientePotencial = row[ResourceClientePotencial.rifClientePotencial].ToString();
                    String EmailClientePotencial = row[ResourceClientePotencial.emailClientePotencial].ToString();
                    float PresupuestoAnual_inversion = float.Parse(row[ResourceClientePotencial.presupuestoAnual_inversion].ToString());
                    //String PresupuestoAnual_inversion = row[ResourceClientePotencial.emailClientePotencial].ToString();
                    int NumeroLlamadas = int.Parse(row[ResourceClientePotencial.numeroLlamadas].ToString());
                    int NumeroVisitas = int.Parse(row[ResourceClientePotencial.numeroVisitas].ToString());
                    int Status = int.Parse(row[ResourceClientePotencial.status].ToString());
                    //  int conCompId = int.Parse(row[ResourceClientePotencial.ConIdComp].ToString());

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    elClientePotencial = new DominioTangerine.Entidades.M3.ClientePotencial(IdClientePotencial, NombreClientePotencial, RifClientePotencial,
                        EmailClientePotencial, PresupuestoAnual_inversion, NumeroLlamadas, NumeroVisitas, Status);

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

            return elClientePotencial;
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
                    Entidad clientePotencial = DominioTangerine.Fabrica.FabricaEntidades.ObtenerClientePotencial();

                    ((DominioTangerine.Entidades.M3.ClientePotencial)clientePotencial).IdClientePotencial = Int32.Parse(row[ResourceClientePotencial.idClientePotencial].ToString());
                    ((DominioTangerine.Entidades.M3.ClientePotencial)clientePotencial).NombreClientePotencial = row[ResourceClientePotencial.nombreClientePotencial].ToString();
                    //ese nombre en mayuscula es el del set y el get de la capa de dominio

                    ((DominioTangerine.Entidades.M3.ClientePotencial)clientePotencial).RifClientePotencial = row[ResourceClientePotencial.rifClientePotencial].ToString();
                    ((DominioTangerine.Entidades.M3.ClientePotencial)clientePotencial).EmailClientePotencial = row[ResourceClientePotencial.emailClientePotencial].ToString();
                    ((DominioTangerine.Entidades.M3.ClientePotencial)clientePotencial).PresupuestoAnual_inversion = float.Parse(row[ResourceClientePotencial.presupuestoAnual_inversion].ToString());
                    ((DominioTangerine.Entidades.M3.ClientePotencial)clientePotencial).Status = Int32.Parse(row[ResourceClientePotencial.status].ToString());


                    objetolistaClientePotencial.Add(clientePotencial);

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
