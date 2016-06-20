using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DatosTangerine.M6;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;
//using DominioTangerine.DominioTangerine.Entidades.M10;
using ExcepcionesTangerine;

namespace DatosTangerine.DAO.M10
{
    public class DAOEmpleado : DAOGeneral, IDAOEmpleado
    {
        /// <summary>
        /// Metodo para agregar un empleado a la base de datos 
        /// </summary>
        /// <param name="elEmpleado"></param>
        /// <returns></returns>
        public bool AgregarEmpleado(DominioTangerine.Empleado elEmpleado)
        {
            throw new NotImplementedException();
        }

        
        public List<DominioTangerine.Empleado> ListarEmpleados()
        {

            throw new NotImplementedException();
        }

       
        public DominioTangerine.Empleado ConsultarEmpleados(int employeeId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para cambiar el estatus de un empleado
        /// </summary>
        /// <param name="empleadoId"></param>
        /// <returns></returns>

        public bool CambiarEstatus(int empleadoId)
        {
            throw new NotImplementedException();
        }

        public bool Agregar(DominioTangerine.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(DominioTangerine.Entidad parametro)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Metodo para consultar empleados por Id
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>

        public Entidad ConsultarXId(Entidad empleado)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            

            List<Parametro> parameters = new List<Parametro>();
            BDConexion Connection = new BDConexion();
            Parametro param = new Parametro();
            Entidad empleadoFinal;

            try
            {
                
                param = new Parametro("@id", SqlDbType.Int, ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).Id.ToString(), false);
                parameters.Add(param);

                DataTable dataTable = EjecutarStoredProcedureTuplas(ResourceEmpleado.DetallarEmpleado, parameters);

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

                    //Variables que son de la entidad Cargo 
                    String empCargo = row[ResourceEmpleado.EmpCargo].ToString();
                    double empSalario = double.Parse(row[ResourceEmpleado.EmpSueldo].ToString());
                    String empFechaInicio = row[ResourceEmpleado.EmpFechaInicio].ToString();
                    String empFechaFin = row[ResourceEmpleado.EmpFechaFin].ToString();
                    String empDireccion = row[ResourceEmpleado.EmpDireccion].ToString();


                    empleadoFinal = DominioTangerine.Fabrica.FabricaEntidades.ListarEmpleadoId(empId, empPNombre,
                                                    empSNombre, empPApellido, empSApellido,
                                                    empGenero, empCedula, empFecha, empActivo, empNivelEstudio,
                                                    empEmailEmployee, empLugId, empCargo, empSalario, empFechaInicio,
                                                    empFechaFin, empDireccion);
    
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

            return empleadoFinal;
           
        

    }
        /// <summary>
        /// Metodo para consultar todos los empleados
        /// </summary>
        /// <returns></returns>
        public List<DominioTangerine.Entidad> ConsultarTodos()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<DominioTangerine.Entidad> listEmpleado = new List<DominioTangerine.Entidad>();

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


                    ////Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos

                    Entidad cargoEmpleado = DominioTangerine.Fabrica.FabricaEntidades.ObtenerCargo3(empCargo, empCargoDescripcion,
                                            empContratacion);

                    Entidad empleado = DominioTangerine.Fabrica.FabricaEntidades.ConsultarEmpleados(empId, empPNombre, empSNombre,
                    empPApellido, empSApellido, empCedula, empFecha, empActivo, empEmail, empGenero, empEstudio, empModalidad,
                    empSalario,cargoEmpleado);

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

    }
}