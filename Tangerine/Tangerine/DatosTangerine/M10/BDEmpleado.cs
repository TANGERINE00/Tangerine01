using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;
using ExcepcionesTangerine;

namespace DatosTangerine.M10
{
    public class BDEmpleado
    {
        /// <summary>
        /// Metodo para agregar un empleado nuevo en la base de datos.
        /// </summary>
        /// <param name="theEmpleado">Objeto de tipo Empleado para agregar en la base de datos</param>
        /// <returns>true si fue agregado</returns>
        public static bool AddEmpleado(Empleado theEmpleado)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Hashtable elementos = new Hashtable();
            try
            {
                elementos = listElementos(theEmpleado);
                parameters.Add(new Parametro("@pNombre", SqlDbType.VarChar, theEmpleado.Emp_p_nombre, false));
                parameters.Add(new Parametro("@sNombre", SqlDbType.VarChar, theEmpleado.Emp_s_nombre, false));
                parameters.Add(new Parametro("@pApellido", SqlDbType.VarChar, theEmpleado.Emp_p_apellido, false));
                parameters.Add(new Parametro("@sApellido", SqlDbType.VarChar, theEmpleado.Emp_s_apellido, false));
                parameters.Add(new Parametro("@genero", SqlDbType.VarChar, theEmpleado.Emp_genero, false));
                parameters.Add(new Parametro("@cedula", SqlDbType.Int, theEmpleado.Emp_cedula.ToString(), false));
                parameters.Add(new Parametro("@fechaNacimiento", SqlDbType.DateTime, theEmpleado.Emp_fecha_nac.ToString("dd/MM/yyyy"), false));
                parameters.Add(new Parametro("@activo", SqlDbType.VarChar, theEmpleado.Emp_activo, false));
                parameters.Add(new Parametro("@nivelEstudio", SqlDbType.VarChar, theEmpleado.Emp_nivel_estudio, false));
                parameters.Add(new Parametro("@correo", SqlDbType.VarChar, theEmpleado.Emp_email, false));
                parameters.Add(new Parametro("@cargo", SqlDbType.VarChar, theEmpleado.Job.Nombre, false));
                parameters.Add(new Parametro("@fechContrato", SqlDbType.DateTime, theEmpleado.Job.FechaContratacion.ToString("dd/MM/yyyy"), false));
                parameters.Add(new Parametro("@modalidad", SqlDbType.VarChar, theEmpleado.Job.Modalidad, false));
                parameters.Add(new Parametro("@sueldo", SqlDbType.Int, theEmpleado.Job.Sueldo.ToString(), false));

                parameters.Add(new Parametro("@estado", SqlDbType.VarChar, elementos["Estado"].ToString(), false));
                parameters.Add(new Parametro("@ciudad", SqlDbType.VarChar, elementos["Ciudad"].ToString(), false));
                parameters.Add(new Parametro("@direccion", SqlDbType.VarChar, elementos["Direccion"].ToString(), false));
                
                //Se manda a ejecutar en BDConexion el stored procedure M10_AgregarEmpleado y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceEmpleado.AddNewEmpleado, parameters);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
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

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
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
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }

        /// <summary>
        /// Metodo para consultar todos los Empleados
        /// </summary>
        /// <returns>Lista de empleados.</returns>
        public static List<Empleado> ListarEmpleados()
        {
            List<Empleado> listEmpleado = new List<Empleado>();
            
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

           

            try
            {
                theConnection.Conectar();
                //PRUEBA
                theParam = new Parametro("@param", SqlDbType.Int, "1", false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceEmpleado.ConsultarEmpleado, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    int empId = int.Parse(row[ResourceEmpleado.EmpIdEmpleado].ToString());
                    String empPNombre = row[ResourceEmpleado.EmpPNombre].ToString();
                    String empSNombre = row[ResourceEmpleado.EmpSNombre].ToString();
                    String empPApellido = row[ResourceEmpleado.EmpPApellido].ToString();
                    String empSApellido = row[ResourceEmpleado.EmpSApellido].ToString();
                    int empCedula = int.Parse(row[ResourceEmpleado.EmpCedula].ToString());
                    DateTime empFecha = DateTime.Parse(row[ResourceEmpleado.EmpFecha].ToString());
                    String empActivo = row[ResourceEmpleado.EmpActivo].ToString();
                    String empEmail = row[ResourceEmpleado.EmpEmail].ToString();
                    String empGenero = row[ResourceEmpleado.EmpGenero].ToString();
                    String empEstudio = row[ResourceEmpleado.EmpEstudio].ToString();

                    String empCargo = row[ResourceEmpleado.EmpCargo].ToString();
                    String empCargoDescripcion = row[ResourceEmpleado.EmpCargoDescripcion].ToString();
                    DateTime empContratacion = DateTime.Parse(row[ResourceEmpleado.EmpFechaInicio].ToString());
                    String empModalidad = row[ResourceEmpleado.EmpModalidad].ToString();
                    double empSalario = double.Parse(row[ResourceEmpleado.EmpSueldo].ToString());
                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos

                    Cargo cargoEmpleado = new Cargo(empCargo, empCargoDescripcion, empContratacion, empModalidad, empSalario);

                    Empleado empleado = new Empleado(empId, empPNombre, empSNombre, empPApellido, empSApellido, empGenero,
                                                empCedula, empFecha, empActivo, empEstudio, empEmail, cargoEmpleado, null);

                    listEmpleado.Add(empleado);
                }

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
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

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
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
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
            return listEmpleado;
        }

        /// <summary>
        /// Metodo para consultar un empleado especifico dentro de la base de datos
        /// </summary>
        /// <param name="employeId">Número entero que representa el numero de ficha de un empleado</param>
        /// <returns>Objeto de tipo Empleado</returns>
        public static Empleado GetEmployeeById(int employeeId)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion Connection = new BDConexion();
            Parametro param = new Parametro();
            Empleado employee;
            try
            {
                Connection.Conectar();
                param = new Parametro("@id", SqlDbType.Int, employeeId.ToString(), false);
                parameters.Add(param);

                DataTable dataTable = Connection.EjecutarStoredProcedureTuplas(ResourceEmpleado.DetallarEmpleado, parameters);

                DataRow row = dataTable.Rows[0];

                int empId = int.Parse(row[ResourceEmpleado.EmpIdEmpleado].ToString());
                String empPNombre = row[ResourceEmpleado.EmpPNombre].ToString();
                String empSNombre = row[ResourceEmpleado.EmpSNombre].ToString();
                String empPApellido = row[ResourceEmpleado.EmpPApellido].ToString();
                String empSApellido = row[ResourceEmpleado.EmpSApellido].ToString();
                String empGenero = row[ResourceEmpleado.EmpGenero].ToString();
                int empCedula = int.Parse(row[ResourceEmpleado.EmpCedula].ToString());
                DateTime empFecha = DateTime.Parse(row[ResourceEmpleado.EmpFecha].ToString());
                String empActivo = row[ResourceEmpleado.EmpActivo].ToString();
                int empLugId = int.Parse(row[ResourceEmpleado.EmpLugId].ToString());
                String empNivelEstudio = row[ResourceEmpleado.EmpEstudio].ToString();
                String empEmailEmployee = row[ResourceEmpleado.EmpEmail].ToString();

                String empCargo = row[ResourceEmpleado.EmpCargo].ToString();
                double empSalario = double.Parse(row[ResourceEmpleado.EmpSueldo].ToString());
                String empFechaInicio = row[ResourceEmpleado.EmpFechaInicio].ToString();
                String empFechaFin = row[ResourceEmpleado.EmpFechaFin].ToString();
                String empDireccion = row[ResourceEmpleado.EmpDireccion].ToString();

                employee = new Empleado();
                //employee = new Empleado(empId, empPNombre, empSNombre, empPApellido, empSApellido,
                //                                empGenero, empCedula, empFecha, empActivo, empNivelEstudio,
                //                                empEmailEmployee, empLugId, empCargo, empSalario, empFechaInicio,
                //                                empFechaFin, empDireccion);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
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

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
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
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return employee;
        }

        /// <summary>
        /// Metodo para consultar los Lugares de tipo Pais dentro de la base de datos
        /// </summary>
        /// <returns>Lista de objetos de tipo LugarDireccion</returns>
        public static List<LugarDireccion> GetElementsForSelectCountry()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            List<LugarDireccion> direccion = new List<LugarDireccion>();
            BDConexion theConnection = new BDConexion();

            try
            {
                theConnection.Conectar();
                Parametro param = new Parametro("@tipo", SqlDbType.Text, "Pais", false);
                parameters.Add(param);

                DataTable dateTable = theConnection.EjecutarStoredProcedureTuplas(ResourceComplemento.FillSelectCountry, parameters);

                foreach (DataRow row in dateTable.Rows)
                {
                    int empId = int.Parse(row[ResourceComplemento.ItemCountryValue].ToString());
                    String empPNombre = row[ResourceComplemento.ItemCountryText].ToString();

                    LugarDireccion lugar = new LugarDireccion(empId, empPNombre);
                    direccion.Add(lugar);
                }
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
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

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
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
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return direccion;
        }

        /// <summary>
        /// Metodo para consultar los Lugares de tipo Estado en la base de datos.
        /// </summary>
        /// <param name="lugarDireccion">Cadena de caracteres que representa el nombre del Pais a filtrar</param>
        /// <returns>Lista de objetos de tipo LugarDireccion</returns>
        public static List<LugarDireccion> GetElementsForSelectState(string lugarDireccion)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<LugarDireccion> estados = new List<LugarDireccion>();
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();

            try
            {
                theConnection.Conectar();

                parameters.Add(new Parametro("@lugar", SqlDbType.Text, lugarDireccion, false));
                parameters.Add(new Parametro("@tipo", SqlDbType.Text, "Estado", false));

                DataTable dateTable = theConnection.EjecutarStoredProcedureTuplas(ResourceComplemento.FillSelectState, parameters);

                foreach (DataRow row in dateTable.Rows)
                {
                    int lugId = int.Parse(row[ResourceComplemento.ItemStateValue].ToString());
                    String lugNombre = row[ResourceComplemento.ItemStateText].ToString();

                    estados.Add(new LugarDireccion(lugId, lugNombre));
                }
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
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

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
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
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return estados;
        }

        /// <summary>
        /// Metodo para consultar los Cargos dentro de la base de datos
        /// </summary>
        /// <returns>Lista de objetos de tipo Cargo</returns>
        public static List<Cargo> GetElementsForSelectJob()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Cargo> jobs = new List<Cargo>();
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();

            try
            {
                theConnection.Conectar();
                parameters.Add(new Parametro("@id", SqlDbType.Int, "1", false));
                DataTable dateTable = theConnection.EjecutarStoredProcedureTuplas(ResourceComplemento.FillSelectJobs, parameters);

                foreach (DataRow row in dateTable.Rows)
                {
                    int jobId = int.Parse(row[ResourceComplemento.ItemJobValue].ToString());
                    String jobNombre = row[ResourceComplemento.ItemJobText].ToString();
                    String jobDescription = row[ResourceComplemento.JobDescription].ToString();

                    jobs.Add(new Cargo(jobId, jobNombre, jobDescription));
                }
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
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

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
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
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return jobs;
        }

        /// <summary>
        /// Metodo para consultar los empleado con Cargo de "Gerente" dentro de la base de datos
        /// </summary>
        /// <returns>Lista de objetos de tipo Empleado</returns>
        public static List<Empleado> ListarGerentes()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<Empleado> listEmpleado = new List<Empleado>();

            try
            {
                theConnection.Conectar();
                theParam = new Parametro(ResourceEmpleado.ParamCPrueba, SqlDbType.Int, "1", false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar empleados
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceEmpleado.ConsultarGerente, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    int empId = int.Parse(row[ResourceEmpleado.EmpIdEmpleado].ToString());
                    String empPNombre = row[ResourceEmpleado.EmpPNombre].ToString();
                    String empSNombre = row[ResourceEmpleado.EmpSNombre].ToString();
                    String empPApellido = row[ResourceEmpleado.EmpPApellido].ToString();
                    String empSApellido = row[ResourceEmpleado.EmpSApellido].ToString();
                    int empCedula = int.Parse(row[ResourceEmpleado.EmpCedula].ToString());
                    String empCargo = row[ResourceEmpleado.EmpCargo].ToString();
                    DateTime empFecha = DateTime.Parse(row[ResourceEmpleado.EmpFecha].ToString());
                    String empActivo = row[ResourceEmpleado.EmpActivo].ToString();
                    int empLugId = int.Parse(row[ResourceEmpleado.EmpLugId].ToString());
                    String empGenero = row[ResourceEmpleado.EmpGenero].ToString();
                    String empNivelEstudio = row[ResourceEmpleado.EmpEstudio].ToString();
                    String empEmailEmployee = row[ResourceEmpleado.EmpEmail].ToString();
                    double empSlario = double.Parse(row[ResourceEmpleado.EmpSueldo].ToString());
                    string empFechaInicio = row[ResourceEmpleado.EmpFechaInicio].ToString();
                    string empFechaFin = row[ResourceEmpleado.EmpFechaFin].ToString();
                    string empDireccion = row[ResourceEmpleado.EmpLugId].ToString();

                    //Creo un objeto de tipo Empleado con los datos de la fila y lo guardo en una lista de empleados
                    Empleado theEmpleado = new Empleado();
                    
                    //Empleado theEmpleado = new Empleado(empId, empPNombre, empSNombre, empPApellido, empSApellido,
                    //                                    empGenero, empCedula, empFecha, empActivo, empNivelEstudio,
                    //                                    empEmailEmployee, empLugId, empCargo, empSlario, empFechaInicio,
                    //                                    empFechaFin, empDireccion);
                    listEmpleado.Add(theEmpleado);
                }

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
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

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
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
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listEmpleado;
        }

        /// <summary>
        /// Metodo para consultar los empleados con cargo de "Programador" dentro de la base de datos
        /// </summary>
        /// <returns>Lista de objetos de tipo Empleado</returns>
        public static List<Empleado> ListarProgramadores()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<Empleado> listEmpleado = new List<Empleado>();

            try
            {
                theConnection.Conectar();
                theParam = new Parametro(ResourceEmpleado.ParamCPrueba, SqlDbType.Int, "1", false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar empleados
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceEmpleado.ConsultarProgramadores, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    int empId = int.Parse(row[ResourceEmpleado.EmpIdEmpleado].ToString());
                    String empPNombre = row[ResourceEmpleado.EmpPNombre].ToString();
                    String empSNombre = row[ResourceEmpleado.EmpSNombre].ToString();
                    String empPApellido = row[ResourceEmpleado.EmpPApellido].ToString();
                    String empSApellido = row[ResourceEmpleado.EmpSApellido].ToString();
                    int empCedula = int.Parse(row[ResourceEmpleado.EmpCedula].ToString());
                    String empCargo = row[ResourceEmpleado.EmpCargo].ToString();
                    DateTime empFecha = DateTime.Parse(row[ResourceEmpleado.EmpFecha].ToString());
                    String empActivo = row[ResourceEmpleado.EmpActivo].ToString();
                    int empLugId = int.Parse(row[ResourceEmpleado.EmpLugId].ToString());
                    String empGenero = row[ResourceEmpleado.EmpGenero].ToString();
                    String empNivelEstudio = row[ResourceEmpleado.EmpEstudio].ToString();
                    String empEmailEmployee = row[ResourceEmpleado.EmpEmail].ToString();
                    double empSlario = double.Parse(row[ResourceEmpleado.EmpSueldo].ToString());
                    string empFechaInicio = row[ResourceEmpleado.EmpFechaInicio].ToString();
                    string empFechaFin = row[ResourceEmpleado.EmpFechaFin].ToString();
                    string empDireccion = row[ResourceEmpleado.EmpLugId].ToString();

                    //Creo un objeto de tipo Empleado con los datos de la fila y lo guardo en una lista de empleados

                    Empleado theEmpleado = new Empleado();
                    
                    //Empleado theEmpleado = new Empleado(empId, empPNombre, empSNombre, empPApellido, empSApellido,
                    //                                    empGenero, empCedula, empFecha, empActivo, empNivelEstudio,
                    //                                    empEmailEmployee, empLugId, empCargo, empSlario, empFechaInicio,
                    //                                    empFechaFin, empDireccion);
                    listEmpleado.Add(theEmpleado);
                }

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
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

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
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
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listEmpleado;
        }

        /// <summary>
        /// Metodo para obtener una tabla Hash con la direccion completa de un empleado 
        /// </summary>
        /// <param name="list">Objeto de tipo Empleado</param>
        /// <returns>Objeto de tipo Hashtable</returns>
        public static Hashtable listElementos(Empleado list)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            Hashtable elementos = new Hashtable();
            try
            {
                foreach (LugarDireccion elemento in list.AddressComplete)
                {
                    elementos.Add(elemento.LugTipo, elemento.LugNombre);
                }
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
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

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
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
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return elementos;
        }

        /// <summary>
        /// Metodo para cambiar el estatus de un empleado dentro de la base de datos de "Activo" a "Inactivo"
        /// o viceversa
        /// </summary>
        /// <param name="empleadoId">Número entero que representa el numero de ficha de un empleado</param>
        /// <returns>true si se modifica el empleado</returns>
        public static bool CambiarEstatus(int empleadoId)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            try
            {
                theConnection.Conectar();
                parameters.Add(new Parametro(ResourceEmpleado.ParamFicha, SqlDbType.VarChar, empleadoId.ToString(), false));
                
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceEmpleado.EstatusEmpleado, parameters);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M10.NullArgumentException(RecursoGeneralBD.Codigo,
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

                throw new ExcepcionesTangerine.M10.WrongFormatException(ResourceEmpleado.Codigo_Error_Formato,
                     ResourceEmpleado.Mensaje_Error_Formato, ex);
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
                ResourceEmpleado.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }

        /// <summary>
        /// Método que obtiene los datos de un usuario teniendo como entrada su usuario y contraseña
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static Usuario ObtenerCorreoUsuario(Usuario usuario)
        {
            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro();

            try
            {
                laConexion.Conectar();

                elParametro = new Parametro("@usuario", SqlDbType.VarChar, usuario.NombreUsuario,
                                             false);
                parametros.Add(elParametro);

                elParametro = new Parametro("@correo", SqlDbType.VarChar, usuario.Contrasenia,
                                             false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(ResourceEmpleado.ObtenerCorreoUsuario, parametros);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    string usuAct = row[ResourceEmpleado.UsuActivo].ToString();

                    usuario.Activo = usuAct;

                }

            }
            catch (NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Codigo,
                                                                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Codigo,
                                                                    RecursoGeneralBD.Mensaje, ex);
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
            }

            return usuario;
        }

    }
}
