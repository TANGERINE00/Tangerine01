using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;
using DominioTangerine.Entidades.M6;
using ExcepcionesTangerine;

namespace DatosTangerine.DAO.M6
{
    public class DAOPropuesta : DAOGeneral, IDAOPropuesta
    {

        #region IDAO

        /// <summary>
        /// Método para agregar una propuesta en la base de datos.
        /// </summary>
        ///  <param name="laPropuesta">Objeto de tipo Propuesta para agregar en BD</param>
        /// <returns>Retorna true si fue agregado</returns>
        public bool Agregar( Entidad laPropuesta )
        {
            Logger.EscribirInfo ( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursoDAOPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            DominioTangerine.Entidades.M6.Propuesta propuesta = ( DominioTangerine.Entidades.M6.Propuesta ) laPropuesta;

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                parametro = new Parametro( RecursoDAOPropuesta.ParamNombreProp, SqlDbType.VarChar, propuesta.Nombre, false);
                parametros.Add( parametro );

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                parametro = new Parametro( RecursoDAOPropuesta.ParamDescriProp, SqlDbType.VarChar, propuesta.Descripcion, false);
                parametros.Add( parametro );

                parametro = new Parametro( RecursoDAOPropuesta.ParamTipoDuProp, SqlDbType.VarChar, propuesta.TipoDuracion, false);
                parametros.Add( parametro );

                parametro = new Parametro( RecursoDAOPropuesta.ParamDuracProp, SqlDbType.VarChar, propuesta.CantDuracion, false);
                parametros.Add(parametro);

                parametro = new Parametro( RecursoDAOPropuesta.ParamFechaIProp, SqlDbType.Date, propuesta.Feincio.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro( RecursoDAOPropuesta.ParamFechaFProp, SqlDbType.Date, propuesta.Fefinal.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro( RecursoDAOPropuesta.ParamEstatusProp, SqlDbType.VarChar, propuesta.Estatus, false);
                parametros.Add(parametro);

                parametro = new Parametro( RecursoDAOPropuesta.ParamMonedaProp, SqlDbType.VarChar, propuesta.Moneda, false);
                parametros.Add(parametro);

                parametro = new Parametro( RecursoDAOPropuesta.ParamAcuerdoProp, SqlDbType.VarChar, propuesta.Acuerdopago, false);
                parametros.Add(parametro);

                parametro = new Parametro( RecursoDAOPropuesta.ParamCantidaProp, SqlDbType.Int, propuesta.Entrega.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro( RecursoDAOPropuesta.ParamCostoProp, SqlDbType.Int, propuesta.Costo.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro( RecursoDAOPropuesta.ParamIdCompa, SqlDbType.Int, propuesta.IdCompañia.ToString(), false);
                parametros.Add(parametro);

                //Se manda a ejecutar en BDConexion el stored procedure M6_AgregarPropuesta y todos los parametros que recibe
                List<Resultado> resultado = EjecutarStoredProcedure( RecursoDAOPropuesta.AgregarPropuesta, parametros);
            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );

                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeSqlException, ex );
            }
            catch ( ArgumentNullException ex )
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeArgumentNullException, ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeFormatException, ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionsTangerine( RecursoDAOPropuesta.CodigoModulo, 
                RecursoGeneralBD.Mensaje_Generico_Error, ex );
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursoDAOPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name );

            return true;
        }


        /// <summary>
        /// Método que permite modificar una propuesta en la BD
        /// </summary>
        /// <param name="propuesta">Objeto de tipo propuesta a ser modificado</param>
        /// <returns>Retorna true si fue modificado</returns>
        public Boolean Modificar( Entidad laPropuesta )
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
               RecursoDAOPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            DominioTangerine.Entidades.M6.Propuesta propuesta = ( DominioTangerine.Entidades.M6.Propuesta )laPropuesta;

            List<Parametro> parameters = new List<Parametro>();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)

                theParam = new Parametro( RecursoDAOPropuesta.ParamPropnombre, SqlDbType.VarChar, propuesta.Nombre, false);
                parameters.Add(theParam);

                theParam = new Parametro( RecursoDAOPropuesta.ParamDescriProp, SqlDbType.VarChar, propuesta.Descripcion, false);
                parameters.Add(theParam);

                theParam = new Parametro( RecursoDAOPropuesta.ParamTipoDuProp, SqlDbType.VarChar, propuesta.TipoDuracion, false);
                parameters.Add(theParam);

                theParam = new Parametro( RecursoDAOPropuesta.ParamDuracProp, SqlDbType.VarChar, propuesta.CantDuracion, false);
                parameters.Add(theParam);

                theParam = new Parametro( RecursoDAOPropuesta.ParamAcuerdoProp, SqlDbType.VarChar, propuesta.Acuerdopago, false);
                parameters.Add(theParam);

                theParam = new Parametro( RecursoDAOPropuesta.ParamEstatusProp, SqlDbType.VarChar, propuesta.Estatus, false);
                parameters.Add(theParam);

                theParam = new Parametro( RecursoDAOPropuesta.ParamMonedaProp, SqlDbType.VarChar, propuesta.Moneda, false);
                parameters.Add(theParam);

                theParam = new Parametro( RecursoDAOPropuesta.ParamFechaIProp, SqlDbType.Date, propuesta.Feincio.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro( RecursoDAOPropuesta.ParamFechaFProp, SqlDbType.Date, propuesta.Fefinal.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro( RecursoDAOPropuesta.ParamCostoProp, SqlDbType.Int, propuesta.Costo.ToString(), false);
                parameters.Add(theParam);


                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = EjecutarStoredProcedure(RecursoDAOPropuesta.Modificar_Propuesta, parameters);

            }
            catch ( SqlException ex )
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeSqlException, ex);
            }
            catch ( ArgumentNullException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeArgumentNullException, ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeFormatException, ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionsTangerine( RecursoDAOPropuesta.CodigoModulo,
                RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name );
            return true;
        }


        /// <summary>
        /// Método para consultar propuesta por id (nombre)
        /// </summary>
        /// <param name="id">Nombre de propuesta</param>
        /// <returns>Retorna objeto de tipo propuesta</returns>
        public Entidad ConsultarXId( Entidad id )
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
           
            List<Parametro> parametros = new List<Parametro>();
            
            Entidad propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta();

            try
            {
                Parametro parametro = new Parametro( RecursoDAOPropuesta.Prop_Nombre, SqlDbType.VarChar, 
                    ( ( DominioTangerine.Entidades.M6.Propuesta )id ).Nombre, false );
                parametros.Add(parametro);

                DataTable dataTablePropuestas = EjecutarStoredProcedureTuplas( RecursoDAOPropuesta.ConsultarPropuestaNombre, 
                    parametros );

                DataRow fila = dataTablePropuestas.Rows[0];

                propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta(
                    ((DominioTangerine.Entidades.M6.Propuesta)id).Nombre,
                    fila[RecursoDAOPropuesta.PropDescripcion].ToString(), 
                    fila[RecursoDAOPropuesta.PropTipoDuracion].ToString(), 
                    fila[RecursoDAOPropuesta.PropDuracion].ToString(), 
                    fila[RecursoDAOPropuesta.PropAcuerdo].ToString(), 
                    fila[RecursoDAOPropuesta.PropEstatus].ToString(), 
                    fila[RecursoDAOPropuesta.PropMoneda].ToString(), 
                    Convert.ToInt32(fila[RecursoDAOPropuesta.PropCantidad]), 
                    Convert.ToDateTime(fila[RecursoDAOPropuesta.PropFechaIni]), 
                    Convert.ToDateTime(fila[RecursoDAOPropuesta.PropFechaFin]), 
                    Convert.ToInt32(fila[RecursoDAOPropuesta.PropCosto]), 
                    fila[RecursoDAOPropuesta.PropIdCompania].ToString() );
            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );

                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeSqlException, ex );
            }
            catch ( ArgumentNullException ex )
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeArgumentNullException, ex );
            }
            catch ( FormatException ex)
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeFormatException, ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionsTangerine( RecursoDAOPropuesta.CodigoModulo,
                RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name );
            return propuesta;
        }


        /// <summary>
        /// Método que consulta todas las propuestas
        /// </summary>
        /// <returns>Retorna la lista de propuestas</returns>
        public List<Entidad>ConsultarTodos()
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parametros = new List<Parametro>();
            List<Entidad> listaPropuesta = new List<Entidad>();

            try
            {
                Conectar();

                //Guardo la tabla que me regresa el procedimiento de consultar propuestas
                DataTable dt = EjecutarStoredProcedureTuplas( RecursoDAOPropuesta.ConsultarTodasPropuestas, parametros );

                //Por cada fila de la tabla voy a guardar los datos 
                foreach ( DataRow row in dt.Rows )
                {
                    String conNombre = row[RecursoDAOPropuesta.PropNombre].ToString();
                    String conDescripcion = row[RecursoDAOPropuesta.PropDescripcion].ToString();
                    String contipoDuracion = row[RecursoDAOPropuesta.PropTipoDuracion].ToString();
                    String conDuracion = row[RecursoDAOPropuesta.PropDuracion].ToString();
                    String conAcuerdo = row[RecursoDAOPropuesta.PropAcuerdo].ToString();
                    String conEstatus = row[RecursoDAOPropuesta.PropEstatus].ToString();
                    String conMoneda = row[RecursoDAOPropuesta.PropMoneda].ToString();
                    int conEntregas = Convert.ToInt32(row[RecursoDAOPropuesta.PropCantidad]);
                    DateTime conFechaIni = Convert.ToDateTime(row[RecursoDAOPropuesta.PropFechaIni]);
                    DateTime conFechaFin = Convert.ToDateTime(row[RecursoDAOPropuesta.PropFechaFin]);
                    int conCosto = Convert.ToInt32(row[RecursoDAOPropuesta.PropCosto]);
                    String conFkComp = row[RecursoDAOPropuesta.PropIdCompania].ToString();

                    //Creo un objeto de tipo Propuesta con los datos de la fila y lo guardo en una lista de propuestas
                    Entidad propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta( conNombre, 
                        conDescripcion, contipoDuracion, conDuracion, conAcuerdo, conEstatus, conMoneda, conEntregas, 
                        conFechaIni, conFechaFin, conCosto, conFkComp );

                    listaPropuesta.Add(propuesta);
                }
            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );

                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeSqlException, ex );
            }
            catch ( ArgumentNullException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeArgumentNullException, ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeFormatException, ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoDAOPropuesta.CodigoModulo,
                RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name );

            return listaPropuesta;
        }
        
        #endregion


        #region IDAOPropuesta


        /// <summary>
        /// Método para consultar la cantidad de propuestas en la base de datos.
        /// </summary>
        /// <returns>Retorna la cantidad de propuestas de compañias activas registradas</returns>
        public int ConsultarNumeroPropuestas()
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name );
            int numero = 0;
            try
            {
                List<Parametro> parameters = new List<Parametro>();

                //Guardo la tabla que me regresa el procedimiento de consultar ultimo id de propuesta
                DataTable dt = EjecutarStoredProcedureTuplas( RecursoDAOPropuesta.ConsultarNumeroPropuestas, parameters );
                //Guardar los datos 
                DataRow row = dt.Rows[0];

                numero = int.Parse( row[RecursoDAOPropuesta.PropCodigo].ToString() );

            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeSqlException, ex );
            }
            catch ( ArgumentNullException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeArgumentNullException, ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeFormatException, ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionsTangerine( RecursoDAOPropuesta.CodigoModulo,
                RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name );
            return numero;
        }

        /// <summary>
        /// Método para eliminar una Propuesta de la base de datos.
        /// </summary>
        /// <param name="nombrePropuesta">Objeto de tipo propuesta a eliminar en bd</param>
        /// <returns>Retorna true si fue eliminado</returns>
        public Boolean BorrarPropuesta( string nombrePropuesta )
        {
           Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
               RecursoDAOPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parameters = new List<Parametro>();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro ( RecursoDAOPropuesta.Prop_Nombre, SqlDbType.VarChar, nombrePropuesta, false );
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = EjecutarStoredProcedure( RecursoDAOPropuesta.EliminarPropuesta, parameters );

            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );

                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeSqlException, ex );
            }
            catch ( ArgumentNullException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeArgumentNullException, ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeFormatException, ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionsTangerine( RecursoDAOPropuesta.CodigoModulo,
                RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name );

            return true;
        }


        /// <summary>
        /// Método diseñado para M7, que devuelve la lista de propuestas con estatus aprobado y que no están en proyecto
        /// </summary>
        /// <returns>Retorna la lista de propuestas con estatus "Aprobado" y que no se encuentran aún en Proyecto</returns>
        public List<Entidad>PropuestaProyecto()
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursoDAOPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parametros = new List<Parametro>();
            List<Entidad> listaPropuesta = new List<Entidad>();

            try
            {
                Conectar();

                //Guardo la tabla que me regresa el procedimiento de consultar propuestas
                DataTable dt = EjecutarStoredProcedureTuplas( RecursoDAOPropuesta.ConsultarPropuesta, parametros );

                //Por cada fila de la tabla voy a guardar los datos 
                foreach ( DataRow row in dt.Rows )
                {
                    String codigonumP = row[RecursoDAOPropuesta.PropCodigo].ToString();
                    String conNombre = row[RecursoDAOPropuesta.PropNombre].ToString();
                    String conDescripcion = row[RecursoDAOPropuesta.PropDescripcion].ToString();
                    String contipoDuracion = row[RecursoDAOPropuesta.PropTipoDuracion].ToString();
                    String conDuracion = row[RecursoDAOPropuesta.PropDuracion].ToString();
                    String conAcuerdo = row[RecursoDAOPropuesta.PropAcuerdo].ToString();
                    String conEstatus = row[RecursoDAOPropuesta.PropEstatus].ToString();
                    String conMoneda = row[RecursoDAOPropuesta.PropMoneda].ToString();
                    int conEntregas = Convert.ToInt32(row[RecursoDAOPropuesta.PropCantidad]);
                    DateTime conFechaIni = Convert.ToDateTime(row[RecursoDAOPropuesta.PropFechaIni]);
                    DateTime conFechaFin = Convert.ToDateTime(row[RecursoDAOPropuesta.PropFechaFin]);
                    int conCosto = Convert.ToInt32(row[RecursoDAOPropuesta.PropCosto]);
                    String conFkComp = row[RecursoDAOPropuesta.PropIdCompania].ToString();

                    //Creo un objeto de tipo Propuesta con los datos de la fila y lo guardo en una lista de propuestas
                    Entidad propuestas = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta(codigonumP, conNombre, 
                        conDescripcion, contipoDuracion, conDuracion,conAcuerdo, conEstatus, conMoneda, 
                        conEntregas, conFechaIni, conFechaFin, conCosto, conFkComp);
                    listaPropuesta.Add(propuestas);
                }
            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );

                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeSqlException, ex );
            }
            catch ( ArgumentNullException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeArgumentNullException, ex);
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD( RecursoDAOPropuesta.CodigoModulo, 
                RecursoDAOPropuesta.MensajeFormatException, ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionsTangerine( RecursoDAOPropuesta.CodigoModulo,
                RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursoDAOPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name );

            return listaPropuesta;
        }
        #endregion

    }
}