using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M7;


namespace DatosTangerine.DAO.M7
{
    public class DaoProyecto : DAOGeneral, IDaoProyecto
    {
        #region IDAO Proyecto

        public List<Entidad> ContactProyectoxAcuerdoPago()
        {
            List<Parametro> parameters = new List<Parametro>();
            List<Entidad> listProyecto = new List<Entidad>();

            try
            {
                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(Resource_M7.ContactProyectosxAcuerdoPago, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();

                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id =
                                        int.Parse(row[Resource_M7.ProyIdProyecto].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Nombre =
                                        row[Resource_M7.ProyNombre].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Codigo =
                                        row[Resource_M7.ProyCodigo].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechainicio =
                                        DateTime.Parse(row[Resource_M7.ProyFechaInicio].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechaestimadafin =
                                        DateTime.Parse(row[Resource_M7.ProyFechaEstFin].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Costo =
                                        double.Parse(row[Resource_M7.ProyCosto].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Descripcion =
                                        row[Resource_M7.ProyDescripcion].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion =
                                        row[Resource_M7.ProyRealizacion].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus =
                                        row[Resource_M7.ProyEstatus].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Razon =
                                        row[Resource_M7.ProyRazon].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Acuerdopago =
                                        row[Resource_M7.ProyAcuerdoPago].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idpropuesta =
                                        int.Parse(row[Resource_M7.ProyIdPropuesta].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idresponsable =
                                        int.Parse(row[Resource_M7.ProyIdCompania].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idgerente =
                                        int.Parse(row[Resource_M7.ProyIdCompania].ToString());

                    listProyecto.Add(proyecto);

                }
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }

            return listProyecto;
        }

        public Entidad ContactNombrePropuestaId(Entidad parametro)
        {
            Entidad propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta();
            try
            {
                List<Parametro> parameters = new List<Parametro>();

                Parametro theParam = new Parametro(Resource_M7.ParamIdPropuestaPrpu, SqlDbType.Int,
                                        ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
                DataTable dt = EjecutarStoredProcedureTuplas(Resource_M7.ContactNombrePropuestaID, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];
                ((DominioTangerine.Entidades.M7.Propuesta)propuesta).Nombre = row[Resource_M7.PrpuNombre].ToString();

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }

            return propuesta;
        }

        public int ContactMaxIdProyecto()
        {

            List<Parametro> parameters = new List<Parametro>();

            int proyId;

            try
            {
                //Guardo la tabla que me regresa el procedimiento de buscar el ID Max.
                DataTable dt = EjecutarStoredProcedureTuplas(Resource_M7.ContacMaxIdProyecto, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];
                proyId = int.Parse(row[Resource_M7.ProyIdProyecto].ToString());


            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }

            return proyId;
        }

        public Double CalcularPagoMensual(Entidad parametro)
        {
            try
            {
                DominioTangerine.Entidades.M7.Proyecto P = (DominioTangerine.Entidades.M7.Proyecto)parametro;

                int dias = Int32.Parse((P.Fechaestimadafin - P.Fechainicio).Days.ToString());
                if (dias > 31)
                {
                    return (P.Costo / dias) * 30;
                }
                else
                {
                    return P.Costo;
                }
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }
        }

        public String GenerarCodigoProyecto(Entidad parametro)
        {

            try
            {
                DominioTangerine.Entidades.M6.Propuesta P = (DominioTangerine.Entidades.M6.Propuesta)parametro;
                String nombre = P.Nombre;
                return "Proy-" + nombre[0] + nombre[1] + nombre[2] + nombre[3] + nombre[4] +
                    nombre[5] + P.Feincio.Day.ToString() + "-" + DateTime.Today.Year;
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }
        }

        public int ConsultarNumeroProyectos()
        {

            int numero = 0;
            try
            {
                List<Parametro> parameters = new List<Parametro>();

                //Guardo la tabla que me regresa el procedimiento de consultar ultimo id de propuesta
                DataTable dt = EjecutarStoredProcedureTuplas(Resource_M7.NumeroProyectos, parameters);
                //Guardar los datos 
                DataRow row = dt.Rows[0];

                numero = int.Parse(row[Resource_M7.ProyIdProyecto].ToString());

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }

            return numero;
        }

        public bool BorrarProyecto(int proyID)
        {

            Parametro theParam = new Parametro();
            try
            {
                List<Parametro> parameters = new List<Parametro>();

                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(Resource_M7.ProyIdProyecto, SqlDbType.Int, proyID.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M4_AgregarCompania y todos los parametros que recibe
                List<Resultado> results = EjecutarStoredProcedure(Resource_M7.BorrarProyecto, parameters);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }


            return true;
        }
        #endregion

        #region DAO

        public bool Agregar(Entidad proyecto)
        {

            DominioTangerine.Entidades.M7.Proyecto theProyecto = (DominioTangerine.Entidades.M7.Proyecto)proyecto;

            List<Parametro> parameters = new List<Parametro>();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                //theParam = new Parametro(Resource_M7.ParamId_Proyecto, SqlDbType.Int, TheProyecto.Idproyecto.ToString(), false);
                //parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(Resource_M7.ParamNombre, SqlDbType.VarChar,
                                theProyecto.Nombre.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamCodigo, SqlDbType.VarChar,
                                theProyecto.Codigo.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamFechaInicio, SqlDbType.Date,
                                theProyecto.Fechainicio.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamFechaEstFin, SqlDbType.Date,
                                theProyecto.Fechaestimadafin.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamCosto, SqlDbType.Int,
                                theProyecto.Costo.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamDescripcion, SqlDbType.VarChar,
                                theProyecto.Descripcion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamRealizacion, SqlDbType.VarChar,
                                theProyecto.Realizacion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamEstatus, SqlDbType.VarChar,
                                theProyecto.Estatus.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamRazon, SqlDbType.VarChar,
                                theProyecto.Razon.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamAcuerdoPago, SqlDbType.VarChar,
                                theProyecto.Acuerdopago.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamIdPropuesta, SqlDbType.Int,
                                theProyecto.Idpropuesta.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamIdCompania, SqlDbType.Int,
                                theProyecto.Idresponsable.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamIdGerente, SqlDbType.Int,
                                theProyecto.Idgerente.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M7_AgregarProyecto y todos los parametros que recibe
                List<Resultado> results = EjecutarStoredProcedure(Resource_M7.AddNewProyecto, parameters);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }

            return true;
        }

        /// <summary>
        /// Metodo para modificar un proyecto en la base de datos.
        /// </summary>
        ///  <param name="parametro">objeto de tipo proyecto para agregar en BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>true si fue agregado</returns>
        public bool Modificar(Entidad parametro)
        {

            List<Parametro> parameters = new List<Parametro>();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                Parametro theParam = new Parametro(Resource_M7.ParamId_Proyecto, SqlDbType.Int,
                                            ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id.ToString(), false);
                parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(Resource_M7.ParamNombre, SqlDbType.VarChar,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Nombre.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamCodigo, SqlDbType.VarChar,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Codigo.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamFechaInicio, SqlDbType.Date,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Fechainicio.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamFechaEstFin, SqlDbType.Date,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Fechaestimadafin.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamCosto, SqlDbType.Int,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Costo.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamDescripcion, SqlDbType.VarChar,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Descripcion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamRealizacion, SqlDbType.VarChar,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Realizacion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamEstatus, SqlDbType.VarChar,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Estatus.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamRazon, SqlDbType.VarChar,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Razon.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamAcuerdoPago, SqlDbType.VarChar,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Acuerdopago.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamIdPropuesta, SqlDbType.Int,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Idpropuesta.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamIdCompania, SqlDbType.Int,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Idresponsable.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamIdGerente, SqlDbType.Int,
                                ((DominioTangerine.Entidades.M7.Proyecto)parametro).Idgerente.ToString(), false);

                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M7_ModificarProyecto y todos los parametros que recibe
                List<Resultado> results = EjecutarStoredProcedure(Resource_M7.ChangeProyecto, parameters);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }

            return true;
        }

        /// <summary>
        /// Metodo para consultar un poryecto por su ID en la base de datos.
        /// </summary>
        ///  <param name="parametro">objeto de tipo proyecto obtener el ID y buscar en la BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>Entidad Proyecto con todos los atributos</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            // AQUI VA EL LOGGER!
            Entidad proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
            try
            {
                List<Parametro> parameters = new List<Parametro>();

                Parametro theParam = new Parametro(Resource_M7.ParamId_Proyecto, SqlDbType.Int,
                                            ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
                DataTable dt = EjecutarStoredProcedureTuplas(Resource_M7.ContactProyecto, parameters);
                //Guardar los datos 
                DataRow row = dt.Rows[0];
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id =
                                    int.Parse(row[Resource_M7.ProyIdProyecto].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Nombre =
                                    row[Resource_M7.ProyNombre].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Codigo =
                                    row[Resource_M7.ProyCodigo].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechainicio =
                                    DateTime.Parse(row[Resource_M7.ProyFechaInicio].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechaestimadafin =
                                    DateTime.Parse(row[Resource_M7.ProyFechaEstFin].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Costo =
                                    double.Parse(row[Resource_M7.ProyCosto].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Descripcion =
                                    row[Resource_M7.ProyDescripcion].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion =
                                    row[Resource_M7.ProyRealizacion].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus =
                                    row[Resource_M7.ProyEstatus].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Razon =
                                    row[Resource_M7.ProyRazon].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Acuerdopago =
                                    row[Resource_M7.ProyAcuerdoPago].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idpropuesta =
                                    int.Parse(row[Resource_M7.ProyIdPropuesta].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idresponsable =
                                    int.Parse(row[Resource_M7.ProyIdCompania].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idgerente =
                                    int.Parse(row[Resource_M7.ProyIdCompania].ToString());
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }

            return proyecto;
        }

        /// <summary>
        /// Metodo para consultar todos los proyectos en la base de datos.
        /// </summary>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>Lista de Proyectos</returns>
        public List<Entidad> ConsultarTodos()
        {
            List<Parametro> parameters = new List<Parametro>();
            List<Entidad> listProyecto = new List<Entidad>();

            try
            {
                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(Resource_M7.ContactProyectos, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id =
                                    int.Parse(row[Resource_M7.ProyIdProyecto].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Nombre =
                                    row[Resource_M7.ProyNombre].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Codigo =
                                    row[Resource_M7.ProyCodigo].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechainicio =
                                    DateTime.Parse(row[Resource_M7.ProyFechaInicio].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechaestimadafin =
                                    DateTime.Parse(row[Resource_M7.ProyFechaEstFin].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Costo =
                                    double.Parse(row[Resource_M7.ProyCosto].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Descripcion =
                                    row[Resource_M7.ProyDescripcion].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion =
                                    row[Resource_M7.ProyRealizacion].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus =
                                    row[Resource_M7.ProyEstatus].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Razon =
                                    row[Resource_M7.ProyRazon].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Acuerdopago =
                                    row[Resource_M7.ProyAcuerdoPago].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idpropuesta =
                                    int.Parse(row[Resource_M7.ProyIdPropuesta].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idresponsable =
                                    int.Parse(row[Resource_M7.ProyIdCompania].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idgerente =
                                    int.Parse(row[Resource_M7.ProyIdCompania].ToString());

                    listProyecto.Add(proyecto);

                }


            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }

            return listProyecto;
        }

        /// <summary>
        /// Método para consultar la cantidad de proyectos en la base de datos.
        /// </summary>
        /// <returns>Retorna la cantidad de proyectos</returns>


        #endregion
    }
}

