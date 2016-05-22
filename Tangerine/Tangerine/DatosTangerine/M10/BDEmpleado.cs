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

namespace DatosTangerine.M10
{
    public class BDEmpleado
    {
        /// <summary>
        /// Metodo para agregar un empleado nuevo en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Empleado para agregar en bd</param>
        /// <returns>true si fue agregado</returns>
        public static bool AddEmpleado(Empleado theEmpleado)
        {
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
                parameters.Add(new Parametro("@sueldo", SqlDbType.Int, "234", false));

                parameters.Add(new Parametro("@estado", SqlDbType.VarChar, elementos["Estado"].ToString(), false));
                parameters.Add(new Parametro("@ciudad", SqlDbType.VarChar, elementos["Ciudad"].ToString(), false));
                parameters.Add(new Parametro("@direccion", SqlDbType.VarChar, elementos["Direccion"].ToString(), false));
                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceEmpleado.AddNewEmpleado, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

        /// <summary>
        /// Metodo para consultar todos los Contactos que pertenecen a una Empresa.
        /// Recibe dos parametros: typeCompany que es 1 si es Compania o 2 si es Cliente Potencial (Lead)
        ///                        idCompany que es el id de la Empresa (Compania o Lead)
        /// </summary>
        /// <returns>Lista de contactos de la Empresa</returns>
        public static List<Empleado> ListarEmpleados()
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<Empleado> listEmpleado = new List<Empleado>();

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
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listEmpleado;
        }

        public static Empleado GetEmployeeById(int employeeId)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion Connection = new BDConexion();
            Parametro param = new Parametro();

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

            Empleado employee = new Empleado(empId, empPNombre, empSNombre, empPApellido, empSApellido,
                                            empGenero, empCedula, empFecha, empActivo, empNivelEstudio,
                                            empEmailEmployee, empLugId, empCargo, empSalario, empFechaInicio,
                                            empFechaFin, empDireccion);
            return employee;
        }

        public static List<LugarDireccion> GetElementsForSelectCountry()
        {
            List<Parametro> parameters = new List<Parametro>();
            List<LugarDireccion> direccion = new List<LugarDireccion>();
            BDConexion theConnection = new BDConexion();
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

            return direccion;
        }

        public static List<LugarDireccion> GetElementsForSelectState(string lugarDireccion)
        {
            List<LugarDireccion> estados = new List<LugarDireccion>();
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();

            parameters.Add(new Parametro("@lugar", SqlDbType.Text, lugarDireccion, false));
            parameters.Add(new Parametro("@tipo", SqlDbType.Text, "Estado", false));

            DataTable dateTable = theConnection.EjecutarStoredProcedureTuplas(ResourceComplemento.FillSelectState, parameters);

            foreach (DataRow row in dateTable.Rows)
            {
                int lugId = int.Parse(row[ResourceComplemento.ItemStateValue].ToString());
                String lugNombre = row[ResourceComplemento.ItemStateText].ToString();

                estados.Add(new LugarDireccion(lugId, lugNombre));
            }

            return estados;
        }

        public static List<Cargo> GetElementsForSelectJob()
        {
            List<Cargo> jobs = new List<Cargo>();
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            parameters.Add(new Parametro("@id", SqlDbType.Int, "1", false));
            DataTable dateTable = theConnection.EjecutarStoredProcedureTuplas(ResourceComplemento.FillSelectJobs, parameters);

            foreach (DataRow row in dateTable.Rows)
            {
                int jobId = int.Parse(row[ResourceComplemento.ItemJobValue].ToString());
                String jobNombre = row[ResourceComplemento.ItemJobText].ToString();
                String jobDescription = row[ResourceComplemento.JobDescription].ToString();

                jobs.Add(new Cargo(jobId, jobNombre, jobDescription));
            }

            return jobs;
        }

        public static List<Empleado> ListarGerentes()
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<Empleado> listEmpleado = new List<Empleado>();

            try
            {
                theConnection.Conectar();
                //PRUEBA
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

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Empleado theEmpleado = new Empleado(empId, empPNombre, empSNombre, empPApellido, empSApellido,
                                                        empGenero, empCedula, empFecha, empActivo, empNivelEstudio,
                                                        empEmailEmployee, empLugId, empCargo, empSlario, empFechaInicio,
                                                        empFechaFin, empDireccion);
                    listEmpleado.Add(theEmpleado);
                }

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listEmpleado;
        }


        public static List<Empleado> ListarProgramadores()
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<Empleado> listEmpleado = new List<Empleado>();

            try
            {
                theConnection.Conectar();
                //PRUEBA
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

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Empleado theEmpleado = new Empleado(empId, empPNombre, empSNombre, empPApellido, empSApellido,
                                                        empGenero, empCedula, empFecha, empActivo, empNivelEstudio,
                                                        empEmailEmployee, empLugId, empCargo, empSlario, empFechaInicio,
                                                        empFechaFin, empDireccion);
                    listEmpleado.Add(theEmpleado);
                }

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listEmpleado;
        }

        private static Hashtable listElementos(Empleado list)
        {
            Hashtable elementos = new Hashtable();
            foreach (LugarDireccion elemento in list.AddressComplete)
            {
                elementos.Add(elemento.LugTipo, elemento.LugNombre);
            }

            return elementos;
        }

        public static bool CambiarEstatus(int empleadoId)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            try
            {
                parameters.Add(new Parametro(ResourceEmpleado.ParamFicha, SqlDbType.VarChar, empleadoId.ToString(), false));
                
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceEmpleado.EstatusEmpleado, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

    }
}
