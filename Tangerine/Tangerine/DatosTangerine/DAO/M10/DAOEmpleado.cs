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
        public bool CambiarEstatus(Entidad empleado)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
           
            try
            {

                parameters.Add(new Parametro(ResourceEmpleado.ParamFicha, SqlDbType.VarChar,
                              ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).Id.ToString(), false));

                List<Resultado> results = EjecutarStoredProcedure(ResourceEmpleado.EstatusEmpleado, parameters);

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
                
                param = new Parametro("@id", SqlDbType.Int, 
                                     ((DominioTangerine.Entidades.M10.EmpleadoM10)empleado).emp_id.ToString(), false);
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

                    Entidad cargoEmpleado = DominioTangerine.Fabrica.FabricaEntidades.ObtenerCargoXid(empCargo,
                                            empSalario, empFechaInicio, empFechaFin);

                    empleadoFinal = DominioTangerine.Fabrica.FabricaEntidades.ListarEmpleadoId(empId, empPNombre,
                                                    empSNombre, empPApellido, empSApellido,
                                                    empGenero, empCedula, empFecha, empActivo, empNivelEstudio,
                                                    empEmailEmployee, empLugId, cargoEmpleado, empSalario,
                                                    empFechaInicio, empFechaFin, empDireccion);
    
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
              
                theParam = new Parametro("@param", SqlDbType.Int, "1", false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceEmpleado.ConsultarEmpleado,
                               parameters);

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


                    //Creo un objeto de tipo Entidad con los datos de la fila

                    Entidad cargoEmpleado = DominioTangerine.Fabrica.FabricaEntidades.ObtenerCargo3(empCargo,
                        empCargoDescripcion, empContratacion);
                                            

                    Entidad empleado = DominioTangerine.Fabrica.FabricaEntidades.ConsultarEmpleados
                    (empId, empPNombre, empSNombre,
                     empPApellido, empSApellido, empCedula, empFecha, empActivo, empEmail, empGenero, empEstudio,
                     empModalidad, empSalario, cargoEmpleado);


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
        /// Metodo para consultar los Lugares de tipo Pais dentro de la base de datos
        /// </summary>
        /// <returns>Lista de objetos de tipo LugarDireccion</returns>
        public List<Entidad> ObtenerPaises()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> listPais = new List<Entidad>();

            try
            {
                List<Parametro> parameters = new List<Parametro>();
                Parametro theParam = new Parametro("@tipo", System.Data.SqlDbType.VarChar, "Pais", false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar empleados
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceComplemento.FillSelectCountry, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad pais = DominioTangerine.Fabrica.FabricaEntidades.ObtenerLugar();

                    ((DominioTangerine.Entidades.M10.LugarDireccion)pais).Id = int.Parse(row[ResourceComplemento.
                    ItemCountryValue].ToString());
                    ((DominioTangerine.Entidades.M10.LugarDireccion)pais).LugNombre = (row[ResourceComplemento.
                    ItemCountryText].ToString());

                    listPais.Add(pais);
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

            return listPais;
        }

        
        /// <summary>
        /// Metodo para consultar los Lugares de tipo Estado en la base de datos.
        /// </summary>
        /// <param name="lugarDireccion">Cadena de caracteres que representa el nombre del Pais a filtrar</param>
        /// <returns>Lista de objetos de tipo LugarDireccion</returns>
        public List<Entidad> ObtenerEstados(Entidad lugarDireccion)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> estados = new List<Entidad>();
            List<Parametro> parameters = new List<Parametro>();

            DominioTangerine.Entidades.M10.LugarDireccion param;
            param = (DominioTangerine.Entidades.M10.LugarDireccion)lugarDireccion;
            

            try
            {
                parameters.Add(new Parametro("@lugar", SqlDbType.VarChar, param.LugNombre, false));
                parameters.Add(new Parametro("@tipo", SqlDbType.VarChar, "Estado", false));

                DataTable dt = EjecutarStoredProcedureTuplas(ResourceComplemento.FillSelectState, parameters);                

                foreach (DataRow row in dt.Rows)
                {
                    Entidad Estado=DominioTangerine.Fabrica.FabricaEntidades.ObtenerLugar();

                    ((DominioTangerine.Entidades.M10.LugarDireccion)Estado).Id = int.Parse(row[ResourceComplemento.
                    ItemCountryValue].ToString());
                    ((DominioTangerine.Entidades.M10.LugarDireccion)Estado).LugNombre = (row[ResourceComplemento.
                    ItemCountryText].ToString());                   

                    estados.Add(Estado);
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
        /// Metodo para traer todos los cargos
        /// </summary>
        /// <returns>Lista de objetos de tipo LugarDireccion</returns>
        public List<Entidad> ObtenerCargos()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceEmpleado.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> listCargo = new List<Entidad>();

            try
            {
                List<Parametro> parameters = new List<Parametro>();
                Parametro theParam = new Parametro("@id", System.Data.SqlDbType.Int, "1", false);
                parameters.Add(theParam);


                //Guardo la tabla que me regresa el procedimiento de consultar cargos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceComplemento.FillSelectJobs, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    
                    Entidad cargo = DominioTangerine.Fabrica.FabricaEntidades.ObtenerCargoM10();

                    ((DominioTangerine.Entidades.M10.CargoM10)cargo).Car_id = int.Parse(row[ResourceComplemento.
                    ItemJobValue].ToString());
                    ((DominioTangerine.Entidades.M10.CargoM10)cargo).Nombre = (row[ResourceComplemento.ItemJobText].
                    ToString());

                    listCargo.Add(cargo);
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

            return listCargo;
        }
    
    }
    }

