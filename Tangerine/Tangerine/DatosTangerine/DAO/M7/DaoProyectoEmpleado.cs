using DatosTangerine.InterfazDAO.M7;
using DatosTangerine.M10;
using DatosTangerine.M7;
using DominioTangerine;
using ExcepcionesTangerine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.DAO.M7
{
    public class DaoProyectoEmpleado : DAOGeneral, IDaoProyectoEmpleado
    {
        #region IDAO Proyecto Empleado
        public bool ContactProyectoEmpleado(Entidad proyecto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProyectoEmpleado(Entidad proyecto)
        {
            try
            {
                //Las segunda linea  tienenque repetirse tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                List<Parametro> parameters = new List<Parametro>();
                Parametro theParam = new Parametro(Resource_M7.ParamId_Proyecto, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id.ToString(), false);
                parameters.Add(theParam);

                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)

                //Se manda a ejecutar en BDConexion el stored procedure M7_EliminarProyecto y todos los parametros que recibe
                List<Resultado> results = EjecutarStoredProcedure(Resource_M7.DeleteProyectoContacto, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                return false;
            }

            return true;
        }

        public List<Entidad> ConsultarTodosProgramadores()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> listEmpleado = new List<Entidad>();

            try
            {
                List<Parametro> parameters = new List<Parametro>();
                Parametro theParam = new Parametro(ResourceEmpleado.ParamCPrueba, SqlDbType.Int, "1", false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar empleados
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceEmpleado.ConsultarProgramadores, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad empleado = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEmpleado();
                    Entidad cargo = DominioTangerine.Fabrica.FabricaEntidades.ObtenerCargo();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Id = int.Parse(row[ResourceEmpleado.EmpIdEmpleado].ToString());
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_p_nombre = row[ResourceEmpleado.EmpPNombre].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_s_nombre = row[ResourceEmpleado.EmpSNombre].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_p_apellido = row[ResourceEmpleado.EmpPApellido].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_s_apellido = row[ResourceEmpleado.EmpSApellido].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_cedula = int.Parse(row[ResourceEmpleado.EmpCedula].ToString());

                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Job = cargo;
                    ((DominioTangerine.Entidades.M7.Cargo)cargo).Nombre = row[ResourceEmpleado.EmpCargo].ToString();
                    ((DominioTangerine.Entidades.M7.Cargo)cargo).Sueldo = double.Parse(row[ResourceEmpleado.EmpSueldo].ToString());
                    ((DominioTangerine.Entidades.M7.Cargo)cargo).FechaContratacion = DateTime.Parse(row[ResourceEmpleado.EmpFechaInicio].ToString());
                    ((DominioTangerine.Entidades.M7.Cargo)cargo).FechaFin = row[ResourceEmpleado.EmpFechaFin].ToString();

                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_activo = row[ResourceEmpleado.EmpActivo].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Fk_lug_dir_id = int.Parse(row[ResourceEmpleado.EmpLugId].ToString());
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_genero = row[ResourceEmpleado.EmpGenero].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_nivel_estudio = row[ResourceEmpleado.EmpEstudio].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_email = row[ResourceEmpleado.EmpEmail].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_fecha_nac = DateTime.Parse(row[ResourceEmpleado.EmpFecha].ToString());
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Fk_lug_dir_id = int.Parse(row[ResourceEmpleado.EmpLugId].ToString());

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

        public bool ObtenerListaEmpleados(Entidad proyecto)
        {

            List<Entidad> listEmpleado = new List<Entidad>();

            try
            {
                List<Parametro> parameters = new List<Parametro>(); 

                Parametro theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, proyecto.Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceProyecto.ContactProyectoEmpleado, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad empleado = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEmpleado();

                    int PEIdEmpleado = int.Parse(row[ResourceProyecto.PEIdEmpleado].ToString());
                    //creo un objeto de tipo Contacto con los datos del id y lo guardo

                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_num_ficha = int.Parse(row[ResourceProyecto.PEIdEmpleado].ToString());
                    listEmpleado.Add(empleado);

                }
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).set_empleados(listEmpleado);
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                return false;
            }
            return true;
        }
        #endregion

        #region IDAO
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

        public List<Entidad> ConsultarTodos()
        {

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> listEmpleado = new List<Entidad>();

            try
            {
                List<Parametro> parameters = new List<Parametro>();
                Parametro theParam = new Parametro(ResourceEmpleado.ParamCPrueba, SqlDbType.Int, "1", false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar empleados
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceEmpleado.ConsultarGerente, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad empleado = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEmpleado();
                    Entidad cargo = DominioTangerine.Fabrica.FabricaEntidades.ObtenerCargo();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Id = int.Parse(row[ResourceEmpleado.EmpIdEmpleado].ToString());
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_p_nombre = row[ResourceEmpleado.EmpPNombre].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_s_nombre = row[ResourceEmpleado.EmpSNombre].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_p_apellido = row[ResourceEmpleado.EmpPApellido].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_s_apellido = row[ResourceEmpleado.EmpSApellido].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_cedula = int.Parse(row[ResourceEmpleado.EmpCedula].ToString());

                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Job = cargo;
                    ((DominioTangerine.Entidades.M7.Cargo)cargo).Nombre = row[ResourceEmpleado.EmpCargo].ToString();
                    ((DominioTangerine.Entidades.M7.Cargo)cargo).Sueldo = double.Parse(row[ResourceEmpleado.EmpSueldo].ToString());
                    ((DominioTangerine.Entidades.M7.Cargo)cargo).FechaContratacion = DateTime.Parse(row[ResourceEmpleado.EmpFechaInicio].ToString());
                    ((DominioTangerine.Entidades.M7.Cargo)cargo).FechaFin = row[ResourceEmpleado.EmpFechaFin].ToString();

                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_activo = row[ResourceEmpleado.EmpActivo].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Fk_lug_dir_id = int.Parse(row[ResourceEmpleado.EmpLugId].ToString());
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_genero = row[ResourceEmpleado.EmpGenero].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_nivel_estudio = row[ResourceEmpleado.EmpEstudio].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_email = row[ResourceEmpleado.EmpEmail].ToString();
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Emp_fecha_nac = DateTime.Parse(row[ResourceEmpleado.EmpFecha].ToString());
                    ((DominioTangerine.Entidades.M7.Empleado)empleado).Fk_lug_dir_id = int.Parse(row[ResourceEmpleado.EmpLugId].ToString());

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
        #endregion
    }
}
