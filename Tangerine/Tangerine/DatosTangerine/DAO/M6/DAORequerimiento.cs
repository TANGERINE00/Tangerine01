using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DatosTangerine.M6;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;
using DominioTangerine.Entidades.M6;
using ExcepcionesTangerine;

namespace DatosTangerine.DAO.M6
{
    public class DAORequerimiento : DAOGeneral, IDAORequerimiento
    {

        #region IDAO

        /// <summary>
        /// Metodo para agregar una requerimiento en la base de datos.
        /// </summary>
        ///  <param name="elRequerimiento">objeto de tipo Requerimiento para agregar en BD</param>
        /// <returns>true si fue agregado</returns>
        public bool Agregar(Entidad elRequerimiento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                RecursosPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            DominioTangerine.Entidades.M6.Requerimiento requerimiento = (DominioTangerine.Entidades.M6.Requerimiento)elRequerimiento;

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                parametro = new Parametro(RecursosPropuesta.ParamCodigoReq, SqlDbType.VarChar, requerimiento.CodigoRequerimiento, false);
                parametros.Add(parametro);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                parametro = new Parametro(RecursosPropuesta.ParamDescriReq, SqlDbType.VarChar, requerimiento.Descripcion, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamIdPropuestaReq, SqlDbType.VarChar, requerimiento.CodigoPropuesta, false);
                parametros.Add(parametro);

                //Se manda a ejecutar en BDConexion el stored procedure M6_AgregarRequerimiento y todos los parametros que recibe
                List<Resultado> resultado = EjecutarStoredProcedure(RecursosPropuesta.AgregarRequerimiento, parametros);

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeSqlException, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeArgumentNullException, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeFormatException, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeExceptionGenerica, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }


        /// <summary>
        /// Metodo que permite modificar un requerimiento en la BD
        /// </summary>
        /// <param name="elRequerimiento">objeto de tipo requerimiento a ser modificado</param>
        /// <returns>true si fue modificado</returns>
        public Boolean Modificar(Entidad elRequerimiento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
               RecursosPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            DominioTangerine.Entidades.M6.Requerimiento requerimiento = (DominioTangerine.Entidades.M6.Requerimiento)elRequerimiento;
            List<Parametro> parameters = new List<Parametro>();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(RecursosPropuesta.ReqDescripcion, SqlDbType.VarChar, requerimiento.Descripcion, false);
                parameters.Add(theParam);

                theParam = new Parametro(RecursosPropuesta.ReqPropNombre, SqlDbType.VarChar, requerimiento.CodigoRequerimiento, false);
                parameters.Add(theParam);

                List<Resultado> results = EjecutarStoredProcedure(RecursosPropuesta.Modificar_Requerimiento, parameters);

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeSqlException, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeArgumentNullException, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeFormatException, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeExceptionGenerica, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }


        /// <summary>
        /// Metodo para consultar un requerimiento por id (nombre)
        /// </summary>
        /// <param name="id">nombre de requerimiento</param>
        /// <returns>Objeto requerimiento</returns>
        public Entidad ConsultarXId(Entidad id)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAORequerimiento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parametros = new List<Parametro>();

            Entidad requerimiento = DominioTangerine.Fabrica.FabricaEntidades.ObtenerRequerimiento();

            try
            {
                Parametro parametro = new Parametro(RecursoDAORequerimiento.ReqNombre, SqlDbType.VarChar,
                    ((DominioTangerine.Entidades.M6.Requerimiento)id).CodigoRequerimiento, false);
                parametros.Add(parametro);

                DataTable dataTableRequerimientos = EjecutarStoredProcedureTuplas(RecursoDAORequerimiento.ConsultarRequerimientoNombre,
                    parametros);

                DataRow fila = dataTableRequerimientos.Rows[0];

                requerimiento = DominioTangerine.Fabrica.FabricaEntidades.ObtenerRequerimiento(
                    ((DominioTangerine.Entidades.M6.Requerimiento)id).CodigoRequerimiento,
                    fila[RecursoDAORequerimiento.ReqDescripcion].ToString(),
                    fila[RecursoDAORequerimiento.ReqNombrePropuesta].ToString());
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeSqlException, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeArgumentNullException, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeFormatException, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeExceptionGenerica, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);      
            return requerimiento;
        }


        /// <summary>
        /// Metodo que consulta todas los requerimientos
        /// </summary>
        ///
        /// <returns>Retorna la lista de propuestas</returns>
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        #endregion


        #region IDAORequerimiento

        /// <summary>
        /// Método para consultar el último id de requerimiento en la base de datos.
        /// </summary>
        /// <returns>Último id de requerimiento registrado.</returns>

        public int ConsultarIdUltimoRequerimiento()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAORequerimiento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            int mayorId = 0;
            try
            {
                List<Parametro> parameters = new List<Parametro>();

                //Guardo la tabla que me regresa el procedimiento de consultar ultimo id requerimiento
                DataTable dt = EjecutarStoredProcedureTuplas(RecursoDAORequerimiento.ConsultarIdUltimoRequerimiento, parameters);
                //Guardar los datos 
                DataRow row = dt.Rows[0];

                mayorId = int.Parse(row[RecursoDAORequerimiento.ReqProp].ToString());

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeSqlException, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeArgumentNullException, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeFormatException, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeExceptionGenerica, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return mayorId;
        }


        /// <summary>
        /// Método para consultar la cantidad de requerimientos en la base de datos.
        /// </summary>
        /// <returns>Cantidad de requerimientos</returns>

        public int ConsultarNumeroRequerimientos()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAORequerimiento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            int numero = 0;
            try
            {
                List<Parametro> parameters = new List<Parametro>();

                //Guardo la tabla que me regresa el procedimiento de consultar ultimo id de propuesta
                DataTable dt = EjecutarStoredProcedureTuplas(RecursoDAORequerimiento.ConsultarNumeroRequerimientos, parameters);
                //Guardar los datos 
                DataRow row = dt.Rows[0];

                numero = int.Parse(row[RecursoDAORequerimiento.ReqId].ToString());

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeSqlException, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeArgumentNullException, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeFormatException, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeExceptionGenerica, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return numero;
        }


        /// <summary>
        /// Método para listar los requerimientos por propuesta 
        /// </summary>
        /// <param name="id">nombre propuesta</param>
        /// <returns>Lista de requerimientos</returns>
        public List<Entidad> ConsultarRequerimientosXPropuesta(String id)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAORequerimiento.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parametros = new List<Parametro>();

            List<Entidad> listaRequerimientos = new List<Entidad>();

            Parametro parametro = new Parametro(RecursoDAORequerimiento.ReqPropNombre, SqlDbType.VarChar, id, false);
            parametros.Add(parametro);

            try
            {
                DataTable dataTableRequerimientos = EjecutarStoredProcedureTuplas(RecursoDAORequerimiento.ListarRequerimiento, parametros);

                foreach (DataRow fila in dataTableRequerimientos.Rows)
                {
                    listaRequerimientos.Add(DominioTangerine.Fabrica.FabricaEntidades.ObtenerRequerimiento(
                        fila[RecursoDAORequerimiento.ReqCodigo].ToString(),
                        fila[RecursoDAORequerimiento.ReqDescripcion].ToString(),id));
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeSqlException, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeArgumentNullException, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeFormatException, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeExceptionGenerica, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return listaRequerimientos;
        }

        /// <summary>
        /// Metodo que permite eliminar un requerimiento en la BD
        /// </summary>
        /// <param name="elRequerimiento">objeto tipo Requerimiento</param>
        /// <returns>True si fue eliminado</returns>
        public Boolean EliminarRequerimiento(Entidad elRequerimiento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
               RecursosPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            DominioTangerine.Entidades.M6.Requerimiento requerimiento = (DominioTangerine.Entidades.M6.Requerimiento)elRequerimiento;
            List<Parametro> parameters = new List<Parametro>();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(RecursoDAORequerimiento.ReqPropNombre, SqlDbType.VarChar, requerimiento.CodigoRequerimiento, false);
                parameters.Add(theParam);

                List<Resultado> results = EjecutarStoredProcedure(RecursoDAORequerimiento.EliminarRequerimiento, parameters);

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeSqlException, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeArgumentNullException, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeFormatException, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoDAORequerimiento.CodigoModulo, RecursoDAORequerimiento.MensajeExceptionGenerica, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }
        
        #endregion

    }
}
