using DatosTangerine.InterfazDAO.M3;
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

        /// <summary>
        /// Metodo para activar a un cliente potencial en la base de datos
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public bool Activar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            ClientePotencial elCliente = (ClientePotencial)parametro;
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
            catch (ExceptionTGConBD ex)
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

        /// <summary>
        /// Metodo para desactivar a un cliente potencial en la base de datos
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public bool Desactivar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            ClientePotencial elClientePotencial = (ClientePotencial)parametro;

            elClientePotencial.IdClientePotencial = parametro.Id;
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                theParam = new Parametro(ResourceClientePotencial.AidClientePotencial, SqlDbType.Int,
                elClientePotencial.IdClientePotencial.ToString(), false);
                parameters.Add(theParam);

                List<Resultado> results =
                    theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_eliminarClientePotencial, parameters);

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
            catch (ExceptionTGConBD ex)
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

        /// <summary>
        /// Metodo para promover a un cliente dentro de la base de datos
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public bool Promover(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            ClientePotencial elClientePotencial = (ClientePotencial)parametro;

            elClientePotencial.IdClientePotencial = parametro.Id;
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                theParam = new Parametro(ResourceClientePotencial.AidClientePotencial, SqlDbType.Int,
                elClientePotencial.IdClientePotencial.ToString(), false);
                parameters.Add(theParam);

                List<Resultado> results =
                    theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_promoverClientePotencial, parameters);

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
            catch (ExceptionTGConBD ex)
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

        /// <summary>
        /// Metodo para consultar el ID del último cliente potencial agregado a la base de datos
        /// </summary>
        /// <returns>Un entero con el mayor ID</returns>
        public int ConsultarIdUltimoClientePotencial()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            int mayorId = 0;
            try
            {
                List<Parametro> parameters = new List<Parametro>();

                DataTable dt = EjecutarStoredProcedureTuplas(ResourceClientePotencial.ConsultarUltimoId, parameters);
                DataRow row = dt.Rows[0];

                mayorId = int.Parse(row[ResourceClientePotencial.idClientePotencial].ToString());
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
            catch (ExceptionTGConBD ex)
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

            return mayorId;
        }

        /// <summary>
        /// Metodo para eliminar a un cliente potencial dentro de la base de datos
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public bool Eliminar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            ClientePotencial elClientePot = (ClientePotencial)parametro;
            elClientePot.IdClientePotencial = parametro.Id;
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                theParam = new Parametro(ResourceClientePotencial.AidClientePotencial,
                    SqlDbType.Int, elClientePot.IdClientePotencial.ToString(), false);
                parameters.Add(theParam);

                List<Resultado> results =
                    theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_eliminarClientePotencialDef, parameters);

            }

            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExceptionTGConBD ex)
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

        /// <summary>
        /// Metodo para consultar las llamadas realizadas a un cliente potencial
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public List<Entidad> ConsultarLlamadasXId(Entidad parametro)
        {
            List<Entidad> objetoListaHistorico = new List<Entidad>();
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            theConnection.Conectar();

            try
            {
                theParam = new Parametro(ResourceClientePotencial.AidClientePotencial, SqlDbType.Int,
                parametro.Id.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.ChekTipo, SqlDbType.VarChar,
                "Llamada", false);
                parameters.Add(theParam);

                DataTable data =
                    theConnection.EjecutarStoredProcedureTuplas(ResourceClientePotencial.ConsultarSegumientoLlamadas, parameters);

                foreach (DataRow row in data.Rows)
                {
                    int idHistoria = int.Parse(row[ResourceClientePotencial.idSeguimiento].ToString());
                    String tipoHistoria = row[ResourceClientePotencial.tipoSeguimiento].ToString();
                    String motivoHistoria = row[ResourceClientePotencial.motivoRegistro].ToString();
                    DateTime fechaHistoria = DateTime.Parse(row[ResourceClientePotencial.fechaRegistro].ToString());
                    int fkLead = int.Parse(row[ResourceClientePotencial.fkCliente].ToString());

                    Entidad registroHistoria =
                        DominioTangerine.Fabrica.FabricaEntidades.CrearSeguimientoXLlamada(idHistoria, fechaHistoria,
                                                                                            tipoHistoria, motivoHistoria, fkLead);

                    objetoListaHistorico.Add(registroHistoria);

                }
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExceptionTGConBD ex)
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

            return objetoListaHistorico;
        }

        /// <summary>
        /// Metodo para consultar las visitas realizadas a un cliente potencial
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public List<Entidad> ConsultarVistaXId(Entidad parametro)
        {
            List<Entidad> objetoListaHistorico = new List<Entidad>();
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            theConnection.Conectar();

            try
            {
                theParam = new Parametro(ResourceClientePotencial.AidClientePotencial, SqlDbType.Int,
                parametro.Id.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.ChekTipo, SqlDbType.VarChar,
                "Visita", false);
                parameters.Add(theParam);

                DataTable data =
                    theConnection.EjecutarStoredProcedureTuplas(ResourceClientePotencial.ConsultarSegumientoLlamadas, parameters);

                foreach (DataRow row in data.Rows)
                {
                    int idHistoria = int.Parse(row[ResourceClientePotencial.idSeguimiento].ToString());
                    String tipoHistoria = row[ResourceClientePotencial.tipoSeguimiento].ToString();
                    String motivoHistoria = row[ResourceClientePotencial.motivoRegistro].ToString();
                    DateTime fechaHistoria = DateTime.Parse(row[ResourceClientePotencial.fechaRegistro].ToString());
                    int fkLead = int.Parse(row[ResourceClientePotencial.fkCliente].ToString());

                    Entidad registroHistoria =
                        DominioTangerine.Fabrica.FabricaEntidades.CrearSeguimientoXVisitas(idHistoria, fechaHistoria,
                                                                                           tipoHistoria, motivoHistoria,
                                                                                           fkLead);

                    objetoListaHistorico.Add(registroHistoria);

                }
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ExceptionTGConBD ex)
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

            return objetoListaHistorico;
        }

        /// <summary>
        /// Metodo para agregar a un cliente potencial a la base de datos
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public bool AgregarSeguimiento(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            SeguimientoCliente seguimiento = (SeguimientoCliente)parametro;
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                theParam = new Parametro(ResourceClientePotencial.SeguimientoFecha, SqlDbType.DateTime,
                seguimiento.FechaHistoria.ToString("dd/MM/yyyy"), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.SeguimientoTipo, SqlDbType.VarChar,
                seguimiento.TipoHistoria, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.SeguimientoMotivo, SqlDbType.VarChar,
                seguimiento.MotivoHistoria, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.SeguimientoCliente , SqlDbType.Int,
                seguimiento.FkCliente.ToString(), false);
                parameters.Add(theParam);
                
                List<Resultado> results =
                    theConnection.EjecutarStoredProcedure(ResourceClientePotencial.AgregarSeguimiento, parameters);

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
            catch (ExceptionTGConBD ex)
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

        /// <summary>
        /// Metodo para agregar a un cliente potencial a la base de datos
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public bool Agregar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            ClientePotencial elClientePotencial = (ClientePotencial)parametro;
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
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

                theParam = new Parametro(ResourceClientePotencial.Astatus, SqlDbType.Decimal,
                elClientePotencial.Status.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results =
                    theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_agregar_clientePotencial, parameters);

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
            catch (ExceptionTGConBD ex)
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

        /// <summary>
        /// Metodo para modificar a un cliente potencial dentro de la base de datos
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public bool Modificar(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            ClientePotencial elClientePotencial = (ClientePotencial)parametro;
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
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

                List<Resultado> results =
                    theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_modificarClientePotencial, parameters);

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
            catch (ExceptionTGConBD ex)
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

        /// <summary>
        /// Metodo para promover a un cliente dentro de la base de datos
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Un cliente potencial</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            ClientePotencial cliente = (ClientePotencial)parametro;
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<ClientePotencial> listClientePotencial = new List<ClientePotencial>();
            ClientePotencial elClientePotencial = null;

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceClientePotencial.AidClientePotencial, SqlDbType.Int,
                cliente.Id.ToString(), false);
                parameters.Add(theParam);

                DataTable dt =
                    theConnection.EjecutarStoredProcedureTuplas(ResourceClientePotencial.SP_consultarClientePotencial, parameters);

                foreach (DataRow row in dt.Rows)
                {

                    int IdClientePotencial = int.Parse(row[ResourceClientePotencial.idClientePotencial].ToString());
                    String NombreClientePotencial = row[ResourceClientePotencial.nombreClientePotencial].ToString();
                    String RifClientePotencial = row[ResourceClientePotencial.rifClientePotencial].ToString();
                    String EmailClientePotencial = row[ResourceClientePotencial.emailClientePotencial].ToString();
                    float PresupuestoAnual_inversion = float.Parse(row[ResourceClientePotencial.presupuestoAnual_inversion].ToString());
                    int NumeroLlamadas = int.Parse(row[ResourceClientePotencial.numeroLlamadas].ToString());
                    int NumeroVisitas = int.Parse(row[ResourceClientePotencial.numeroVisitas].ToString());
                    int Status = int.Parse(row[ResourceClientePotencial.status].ToString());

                    elClientePotencial = new ClientePotencial(IdClientePotencial, NombreClientePotencial, RifClientePotencial,
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

        /// <summary>
        /// Metodo para consultar todos los clientes potenciales
        /// </summary>
        /// <returns>Una lista que contiene clientes potenciales</returns>
        public List<Entidad> ConsultarTodos()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> objetolistaClientePotencial = new List<Entidad>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<Parametro> parametros = new List<Parametro>();

            DataTable data = new DataTable();
            data = theConnection.EjecutarStoredProcedureTuplas(ResourceClientePotencial.SP_listarClientePotencial, parametros);
            try
            {
                foreach (DataRow row in data.Rows)
                {
                    Entidad clientePotencial = DominioTangerine.Fabrica.FabricaEntidades.ObtenerClientePotencial();

                    ((ClientePotencial)clientePotencial).IdClientePotencial =
                        Int32.Parse(row[ResourceClientePotencial.idClientePotencial].ToString());

                    ((ClientePotencial)clientePotencial).NombreClientePotencial =
                        row[ResourceClientePotencial.nombreClientePotencial].ToString();

                    ((ClientePotencial)clientePotencial).RifClientePotencial =
                        row[ResourceClientePotencial.rifClientePotencial].ToString();

                    ((ClientePotencial)clientePotencial).EmailClientePotencial =
                        row[ResourceClientePotencial.emailClientePotencial].ToString();

                    ((ClientePotencial)clientePotencial).PresupuestoAnual_inversion =
                        float.Parse(row[ResourceClientePotencial.presupuestoAnual_inversion].ToString());

                    ((ClientePotencial)clientePotencial).Status = Int32.Parse(row[ResourceClientePotencial.status].ToString());

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
