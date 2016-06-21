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

        /// <summary>
        /// Metodo para eliminar los empleados asociados a un proyecto en la base de datos.
        /// </summary>
        ///  <param name="parametro">objeto de tipo proyecto con el ID para buscar en BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>true si se ejecuto exitosamente</returns>
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
                List<Resultado> results = EjecutarStoredProcedure(Resource_M7.DeleteProyectoEmpleado, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Metodo para consultar todos los empleados de tipo programador en la base de datos.
        /// </summary>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>lista de Empleados existentes en la base de datos</returns>
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

        /// <summary>
        /// Metodo para consultar todos los empleados asociados a un proyecto en la base de datos.
        /// </summary>
        ///  <param name="parametro">objeto de tipo proyecto con el ID para buscar en BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>Lista de Empleados asociados al proyecto</returns>
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

        /// <summary>
        /// Metodo para agregar un empleados asociado a un proyecto en la base de datos.
        /// </summary>
        ///  <param name="proyecto">objeto de tipo proyecto con el ID para agregar en BD</param>
        ///  <param name="empleado">objeto de tipo empleado con el ID para agregar en BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>true si se ejecuto exitosamente</returns>
        public bool AgregarProyectoEmpleados(Entidad proyecto, Entidad empleado)
        {
            {
                try
                {
                    List<Parametro> parameters = new List<Parametro>();
                    //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                    //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)

                    Parametro theParam = new Parametro(Resource_M7.ParamId_Proyecto, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id.ToString(), false);
                    parameters.Add(theParam);

                    theParam = new Parametro(Resource_M7.ParamPEIdEmpleado, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Empleado)empleado).Id.ToString(), false);
                    parameters.Add(theParam);

                    //Se manda a ejecutar en BDConexion el stored procedure M7_AgregarProyecto y todos los parametros que recibe
                    List<Resultado> results = EjecutarStoredProcedure(Resource_M7.AddProyectoEmpleado, parameters);

                }
                catch (Exception ex)
                {
                    throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                    return false;
                }

            }
            return true;
        }
        #endregion

        #region DAO
        public bool Agregar(Entidad entProyecto)
        {
            {
                List<Parametro> parameters;
                Parametro theParam = new Parametro();
                DominioTangerine.Entidades.M7.Proyecto elProyecto = (DominioTangerine.Entidades.M7.Proyecto)entProyecto;

                foreach (Entidad entidad in elProyecto.get_empleados())
                    {
                        DominioTangerine.Entidades.M10.EmpleadoM10 empleado = (DominioTangerine.Entidades.M10.EmpleadoM10)entidad;
                        
            
                        try
                        {
                            parameters = new List<Parametro>();
                            //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                            //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)



                            theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, elProyecto.Id.ToString(), false);
                            parameters.Add(theParam);

                            theParam = new Parametro(ResourceProyecto.ParamPEIdEmpleado, SqlDbType.Int, empleado.emp_id.ToString(), false);
                            parameters.Add(theParam);



                            //Se manda a ejecutar en BDConexion el stored procedure M7_AgregarProyecto y todos los parametros que recibe
                            List<Resultado> results = EjecutarStoredProcedure(ResourceProyecto.AddProyectoEmpleado, parameters);

                        }
                        catch (Exception ex)
                        {
                            throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                            return false;
                        }

                    }
                return true;
            }
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
        /// Metodo para consultar todos los empleados en la base de datos.
        /// </summary>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>Lista de entidad empleados</returns>
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
