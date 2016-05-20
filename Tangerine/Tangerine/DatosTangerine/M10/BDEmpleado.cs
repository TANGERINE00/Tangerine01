using System;
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
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceEmpleado.ParamFicha, SqlDbType.VarChar, theEmpleado.emp_num_ficha.ToString(), false);
                parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceEmpleado.ParamCedula, SqlDbType.VarChar, theEmpleado.emp_cedula.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceEmpleado.ParamGenero, SqlDbType.VarChar, theEmpleado.emp_genero, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceEmpleado.ParamPNombre, SqlDbType.VarChar, theEmpleado.emp_p_nombre, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceEmpleado.ParamSNombre, SqlDbType.VarChar, theEmpleado.emp_s_nombre, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceEmpleado.ParamPApellido, SqlDbType.VarChar, theEmpleado.emp_p_apellido, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceEmpleado.ParamSApellido, SqlDbType.Int, theEmpleado.emp_s_apellido, false);
                parameters.Add(theParam);

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
                theParam = new Parametro(ResourceEmpleado.ParamCPrueba, SqlDbType.Int, "1", false);
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
                    //String empCargo = row[ResourceEmpleado.ConEmailContact].ToString();
                    DateTime empFecha = DateTime.Parse(row[ResourceEmpleado.EmpFecha].ToString());
                    String empActivo = row[ResourceEmpleado.EmpActivo].ToString();
                    int empLugId = int.Parse(row[ResourceEmpleado.EmpLugId].ToString());

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Empleado theEmpleado = new Empleado(empId, empPNombre, empSNombre, empPApellido, empSApellido,
                                                        empCedula, empFecha, empActivo, empLugId);
                    listEmpleado.Add(theEmpleado);
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
            String empNivelEstudio  = row[ResourceEmpleado.EmpEstudio].ToString();
            String empEmailEmployee = row[ResourceEmpleado.EmpEmail].ToString();

            String empCargo = row[ResourceEmpleado.EmpCargo].ToString();
            double empSalario = double.Parse(row[ResourceEmpleado.EmpSueldo].ToString());
            String empFechaInicio = row[ResourceEmpleado.EmpFechaInicio].ToString();
            String empFechaFin = row[ResourceEmpleado.EmpFechaFin].ToString();
            String empDireccion = row[ResourceEmpleado.EmpDireccion].ToString();

            Empleado employee= new Empleado(empId, empPNombre, empSNombre, empPApellido, empSApellido,
                                            empGenero, empCedula, empFecha, empActivo, empNivelEstudio,
                                            empEmailEmployee, empLugId, empCargo, empSalario, empFechaInicio,
                                            empFechaFin, empDireccion);
            return employee;
        }

        public List<LugarDireccion> GetElementsForSelectCountry()
        {
            List<LugarDireccion> direccion = new List<LugarDireccion>();
            return direccion;
        }

    }
}
