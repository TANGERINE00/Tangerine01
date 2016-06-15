using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine.Entidades.M10;
using DominioTangerine;
using ExcepcionesTangerine;
using DatosTangerine.M10;
using System.Data;
using System.Data.SqlClient;

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

        /// <summary>
        /// Metodo para consultar todos los empleados
        /// </summary>
        /// <returns></returns>
        public List<DominioTangerine.Empleado> ListarEmpleados()
        {

            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para consultar empleados por Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>

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


        /// <summary>
        /// Metodo para consultar todos los empleados
        /// </summary>
        /// <returns></returns>
        public List<Entidad> ConsultarTodos()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> listEmpleado = new List<Entidad>();

            try
            {
                List<Parametro> parameters = new List<Parametro>();
                Parametro theParam = new Parametro(ResourceEmpleado.ParamCPrueba, System.Data.SqlDbType.Int, "1", false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar empleados
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceEmpleado.ConsultarEmpleados, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad empleado = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEmpleado();
                    //Entidad cargo = DominioTangerine.Fabrica.FabricaEntidades.ObtenerCargo();
                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Id = int.Parse(row[ResourceEmpleado.EmpIdEmpleado].ToString());
                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Emp_p_nombre = row[ResourceEmpleado.EmpPNombre].ToString();
                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Emp_s_nombre = row[ResourceEmpleado.EmpSNombre].ToString();
                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Emp_p_apellido = row[ResourceEmpleado.EmpPApellido].ToString();
                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Emp_s_apellido = row[ResourceEmpleado.EmpSApellido].ToString();
                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Emp_cedula = int.Parse(row[ResourceEmpleado.EmpCedula].ToString());

                    //((DominioTangerine.Entidades.M7.Empleado)empleado).Job = cargo;
                    //((DominioTangerine.Entidades.M7.Cargo)cargo).Nombre = row[ResourceEmpleado.EmpCargo].ToString();
                    //((DominioTangerine.Entidades.M7.Cargo)cargo).Sueldo = double.Parse(row[ResourceEmpleado.EmpSueldo].ToString());
                    //((DominioTangerine.Entidades.M7.Cargo)cargo).FechaContratacion = DateTime.Parse(row[ResourceEmpleado.EmpFechaInicio].ToString());
                    //((DominioTangerine.Entidades.M7.Cargo)cargo).FechaFin = row[ResourceEmpleado.EmpFechaFin].ToString();

                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Emp_activo = row[ResourceEmpleado.EmpActivo].ToString();
                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Fk_lug_dir_id = int.Parse(row[ResourceEmpleado.EmpLugId].ToString());
                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Emp_genero = row[ResourceEmpleado.EmpGenero].ToString();
                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Emp_nivel_estudio = row[ResourceEmpleado.EmpEstudio].ToString();
                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Emp_email = row[ResourceEmpleado.EmpEmail].ToString();
                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Emp_fecha_nac = DateTime.Parse(row[ResourceEmpleado.EmpFecha].ToString());
                    ((DominioTangerine.Entidades.M10.Empleado)empleado).Fk_lug_dir_id = int.Parse(row[ResourceEmpleado.EmpLugId].ToString());

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

