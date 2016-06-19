using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M2;
using DominioTangerine;
using DatosTangerine.M10;
using DatosTangerine.DAO;
using ExcepcionesTangerine;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine.Entidades.M2;

namespace DatosTangerine.DAO.M2
{
    public class DAOUsuario : DAOGeneral, IDAOUsuarios
    {

        #region IDAO

            /// <summary>
            /// Método para agregar un usuario
            /// </summary>
            /// <param name="theUsuario"></param>
            /// <returns>Retorna true si se agrega en la BD</returns>
            public bool Agregar( Entidad theUsuario )
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceUser.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                Parametro theParam = new Parametro();
                try
                {
                    List<Parametro> parameters = new List<Parametro>();

                    //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                    //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                    theParam = new Parametro(ResourceUser.ParametroUsuario, SqlDbType.VarChar, ((DominioTangerine.Entidades.M2.UsuarioM2)theUsuario).nombreUsuario, false);
                    parameters.Add(theParam);

                    theParam = new Parametro(ResourceUser.ParametroContrasenia, SqlDbType.VarChar, ((DominioTangerine.Entidades.M2.UsuarioM2)theUsuario).contrasena, false);
                    parameters.Add(theParam);

                    theParam = new Parametro(ResourceUser.ParametroNumFicha, SqlDbType.Int, ((DominioTangerine.Entidades.M2.UsuarioM2)theUsuario).fichaEmpleado.ToString(), false);
                    parameters.Add(theParam);

                    theParam = new Parametro(ResourceUser.ParametroFechaCreacion, SqlDbType.Date, ((DominioTangerine.Entidades.M2.UsuarioM2)theUsuario).fechaCreacion.ToString(), false);
                    parameters.Add(theParam);

                    theParam = new Parametro(ResourceUser.ParametroRolNombre, SqlDbType.VarChar, ((DominioTangerine.Entidades.M2.UsuarioM2)theUsuario).rol.nombre, false);
                    parameters.Add(theParam);


                    //Se manda a ejecutar en BDConexion el stored procedure M4_AgregarCompania y todos los parametros que recibe
                    List<Resultado> results = EjecutarStoredProcedure(ResourceUser.AgregarUsuario, parameters);

                }
                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                }

                return true;
            } 

            /// <summary>
            /// Método para modificar un usuario
            /// </summary>
            /// <param name="theUsuario"></param>
            /// <returns>Retorna el objeto en la base de datos</returns>
            public bool Modificar( Entidad theUsuario )
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Método para consultar un usuario por id
            /// </summary>
            /// <param name="theUsuario"></param>
            /// <returns>Retorna la consulta</returns>
            public Entidad ConsultarXId( Entidad theUsuario )
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceUser.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                Entidad usuario;

                try
                {
                    List<Parametro> parameters = new List<Parametro>();

                    Parametro theParam = new Parametro(ResourceUser.ParametroID, SqlDbType.Int, ((DominioTangerine.Entidades.M2.UsuarioM2)theUsuario).Id.ToString(), false);
                    parameters.Add(theParam);

                    //Guardo la tabla que me regresa el procedimiento de ConsultarUsuario
                    DataTable dt = EjecutarStoredProcedureTuplas(ResourceUser.ConsultUser, parameters);
                    //Guardar los datos 
                    DataRow row = dt.Rows[0];

                    int usuId = int.Parse(row[ResourceUser.ComIDUser].ToString());
                    String usuUser = row[ResourceUser.UsuNombre].ToString();
                    String usuContrasena = row[ResourceUser.UsuContrasena].ToString();
                    DateTime usuFechaCreacion = DateTime.Parse(row[ResourceUser.UsuFechaCreacion].ToString());
                    String usuActivo = row[ResourceUser.UsuActivo].ToString();
                    int theRolID = int.Parse(row[ResourceUser.UsuFKRol].ToString());
                    DominioTangerine.Entidad rolID = DominioTangerine.Fabrica.FabricaEntidades.crearRolConID( theRolID );
                    DominioTangerine.Entidades.M2.RolM2 rol = (DominioTangerine.Entidades.M2.RolM2)rolID;
                    int empleadoNumFicha = int.Parse(row[ResourceUser.UsuEmpFicha].ToString());

                    //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                    usuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID( usuId, usuUser, usuContrasena,
                                                                                              usuFechaCreacion , usuActivo ,
                                                                                              rol, empleadoNumFicha);
                }
                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                }

                return usuario;
            }

            /// <summary>
            /// Método para consultar todos los usuarios
            /// </summary>
            /// <returns>Retorna todos los usuarios</returns>
            public List<Entidad> ConsultarTodos()
            {
                throw new NotImplementedException();
            }

        #endregion

        #region IDAOUsuarios

            /// <summary>
            /// Verificar si el usuario por su ficha
            /// </summary>
            /// <param name="theUsuario"></param>
            /// <returns>Si existe True, si no, False</returns>
            public bool VerificarUsuarioPorFichaEmpleado( int fichaEmpleado )
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro();

                bool resultado = false;

                try
                {
                    Conectar();

                    elParametro = new Parametro(ResourceUser.ParametroNumFicha, SqlDbType.Int, fichaEmpleado.ToString(), false);
                    parametros.Add(elParametro);

                    DataTable dt = EjecutarStoredProcedureTuplas(ResourceUser.VerificarUsuarioPorFichaEmpleado, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        resultado = true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    return false;
                }

                return resultado;
            } //DONE COMMAND

            /// <summary>
            /// Método usado para devolver todos los empleados sin usuario
            /// </summary>
            /// <returns>Retorna la lista de empleados</returns>
            public List<Entidad> ConsultarListaDeEmpleados()
            {
                List<Entidad> listaDeEmpleados = new List<Entidad>();
                //List<DominioTangerine.Entidades.M10.Empleado> listaEmpleado = (List<DominioTangerine.Entidades.M10.Empleado>)theListaDeEmpleados;

                
                try
                {
                    //Hablar con mod10 para que cambien el metodo ListaEmpleados() de lugar.
                    DatosTangerine.InterfazDAO.M10.IDAOEmpleado empleadoConexion = DatosTangerine.Fabrica.FabricaDAOSqlServer.ConsultarDAOEmpleado();
                    //listaDeEmpleados = empleadoConexion.ListarEmpleados();
                }
                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new ExcepcionesTangerine.M2.ExcepcionRegistro("Error al ejecutar " + "ConsultarListaDeEmpleados()", ex);
                }
                return listaDeEmpleados;
            } //OJOOOOOOOOOOOOO HABLAR CON M10

            /// <summary>
            /// Método usado para verificar si el usuario existe en el sistema
            /// </summary>
            /// <param name="nombreUsuario"></param>
            /// <returns>Retorna una valor booleano indicando la disponibilidad del usuario</returns>
            public bool VerificarExistenciaUsuario( string nombreUsuario )
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro();

                bool resultado = false;

                try
                {
                    Conectar(); //Conexion a la base de datos

                    elParametro = new Parametro(ResourceUser.ParametroUsuario, SqlDbType.VarChar, nombreUsuario, false);
                    parametros.Add(elParametro);

                    DataTable dt = EjecutarStoredProcedureTuplas(ResourceUser.VerificarExistenciaUsuario, parametros);

                    foreach (DataRow row in dt.Rows)
                    {
                        resultado = true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    return false;
                }

                return resultado;
            }

            /// <summary>
            /// Método que retorna el usuario y rol de un empleado
            /// </summary>
            /// <param name="empleado"></param>
            /// <returns>Retorna el usuario de un empleado</returns>
            public Entidad ObtenerUsuarioDeEmpleado( Entidad num_empleado )
            {
                DominioTangerine.Entidades.M10.EmpleadoM10 empleado = (DominioTangerine.Entidades.M10.EmpleadoM10)num_empleado;
                Entidad theUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioVacio();

                DominioTangerine.Entidades.M2.UsuarioM2 usuario = (DominioTangerine.Entidades.M2.UsuarioM2) theUsuario;

                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro();

                try
                {
                    Conectar();

                    elParametro = new Parametro(ResourceUser.ParametroNumFicha, SqlDbType.Int, num_empleado.ToString(), false);
                    parametros.Add(elParametro);

                    DataTable dt = EjecutarStoredProcedureTuplas(ResourceUser.ObtenerUsuarioDeEmpleado, parametros);

                    //Por cada fila de la tabla voy a guardar los datos 
                    foreach (DataRow row in dt.Rows)
                    {
                        string nombreUsuario = row[ResourceUser.UsuNombre].ToString();
                        string rolUsuario = row[ResourceUser.RolNombre].ToString();

                        Entidad theRol = DominioTangerine.Fabrica.FabricaEntidades.crearRolNombre( rolUsuario );
                        DominioTangerine.Entidades.M2.RolM2 rol = ( DominioTangerine.Entidades.M2.RolM2 ) theRol;

                        usuario.nombreUsuario = nombreUsuario;
                        usuario.rol = rol;
                    }
                }
                catch (NullReferenceException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Codigo,
                                                                        RecursoGeneralBD.Mensaje, ex);
                }
                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                }

                return usuario;
            }

            /// <summary>
            /// Método que obtiene los datos de un usuario teniendo como entrada su usuario y contraseña
            /// </summary>
            /// <param name="usuario"></param>
            /// <returns>Los datos del usuario</returns>
            public Entidad ObtenerDatoUsuario( Entidad theUsuario )
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro();
                DominioTangerine.Entidades.M2.UsuarioM2 usuario = (DominioTangerine.Entidades.M2.UsuarioM2)theUsuario;

                try
                {
                    Conectar(); //Conexion a la BD

                    elParametro = new Parametro(ResourceUser.ParametroUsuario, SqlDbType.VarChar, usuario.nombreUsuario, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(ResourceUser.ParametroContrasenia, SqlDbType.VarChar, usuario.contrasena, false);
                    parametros.Add(elParametro);

                    DataTable dt = EjecutarStoredProcedureTuplas(ResourceUser.ObtenerDatoUsuario, parametros);

                    //Por cada fila de la tabla voy a guardar los datos 
                    foreach (DataRow row in dt.Rows)
                    {
                        DateTime usuFecha = DateTime.Parse(row[ResourceUser.UsuFechaCreacion].ToString());
                        string usuAct = row[ResourceUser.UsuActivo].ToString();
                        int usuIdRol = int.Parse(row[ResourceUser.UsuFKRol].ToString());
                        int usuEmpFicha = int.Parse(row[ResourceUser.UsuEmpFicha].ToString());

                        usuario.fechaCreacion = usuFecha;
                        usuario.activo = usuAct;
                        usuario.fichaEmpleado = usuEmpFicha;

                        DatosTangerine.InterfazDAO.M2.IDAORol DAORol = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoRol();
                        Entidad theRol = DAORol.ObtenerRolUsuario( usuIdRol );
                        DominioTangerine.Entidades.M2.RolM2 rol = (DominioTangerine.Entidades.M2.RolM2)theRol; 
                        usuario.rol = rol;
                    }

                }
                catch (NullReferenceException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Codigo,
                                                                        RecursoGeneralBD.Mensaje, ex);
                }
                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                }

                return usuario;
            }

            /// <summary>
            /// Método que arma la lista de los parametros del Stored Procedure para modificar la contraseña 
            /// del usuario y llama al método que ejecuta el Stored Procedure (El objeto usuario debe tener 
            /// agregada la contraseña nueva).
            /// </summary>
            /// <param name="usuario"></param>
            /// <returns>true se es exitoso y false si es fallido</returns>
            public bool ModificarContraseniaUsuario(Entidad theUsuario)
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro;
                DominioTangerine.Entidades.M2.UsuarioM2 usuario = (DominioTangerine.Entidades.M2.UsuarioM2)theUsuario;

                try
                {
                    elParametro = new Parametro(ResourceUser.ParametroUsuario, SqlDbType.VarChar, usuario.nombreUsuario,false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(ResourceUser.ParametroContraseniaNueva, SqlDbType.VarChar,usuario.contrasena, false);
                    parametros.Add(elParametro);

                    List<Resultado> results = EjecutarStoredProcedure(ResourceUser.ModificarContraUsuario, parametros);
                }
                catch (NullReferenceException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Codigo,
                                                                        RecursoGeneralBD.Mensaje, ex);
                }
                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    return false;
                }

                return true;
            }

            /// <summary>
            /// Método que permite consultar el ID del ultimo usuario en la base de datos
            /// </summary>
            /// <returns>Retorne el ultimo ID</returns>
            public int ConsultLastUserID()
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceUser.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                int ultimoID = 0;
                try
                {
                    List<Parametro> parameters = new List<Parametro>();

                    //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
                    DataTable dt = EjecutarStoredProcedureTuplas(ResourceUser.ConsultLastUserID, parameters);
                    //Guardar los datos 
                    DataRow row = dt.Rows[0];

                    ultimoID = int.Parse(row[ResourceUser.ComIDUser].ToString());

                }
                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                }

                return ultimoID;
            }

        #endregion

    }
}
