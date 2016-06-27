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
using ExcepcionesTangerine.M2;

namespace DatosTangerine.DAO.M2
{
    public class DAOUsuario : DAOGeneral, IDAOUsuarios
    {
        #region IDAO

            /// <summary>
            /// Método para agregar un usuario
            /// </summary>
            /// <param name="theUsuario">Es el objeto que se va a agregar a la BD</param>
            /// <returns>Retorna true si se agrega en la BD</returns>
            public bool Agregar( Entidad theUsuario )
            {
                Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                     ResourceUser.MensajeInicioInfoLogger , System.Reflection.MethodBase.GetCurrentMethod().Name );
                Parametro theParam = new Parametro();
                try
                {
                    List<Parametro> parameters = new List<Parametro>();

                    //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                    //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                    theParam = new Parametro( ResourceUser.ParametroUsuario , SqlDbType.VarChar ,
                                            ( ( DominioTangerine.Entidades.M2.UsuarioM2 )theUsuario ).nombreUsuario , false );
                    parameters.Add( theParam );

                    theParam = new Parametro( ResourceUser.ParametroContrasenia , SqlDbType.VarChar ,
                                            ( ( DominioTangerine.Entidades.M2.UsuarioM2 )theUsuario ).contrasena , false );
                    parameters.Add( theParam );

                    theParam = new Parametro( ResourceUser.ParametroNumFicha , SqlDbType.Int ,
                                            ( ( DominioTangerine.Entidades.M2.UsuarioM2 )theUsuario ).fichaEmpleado.ToString() , false );
                    parameters.Add( theParam );

                    theParam = new Parametro( ResourceUser.ParametroFechaCreacion , SqlDbType.Date ,
                                            ( ( DominioTangerine.Entidades.M2.UsuarioM2 )theUsuario ).fechaCreacion.ToString() , false );
                    parameters.Add( theParam );

                    theParam = new Parametro( ResourceUser.ParametroRolNombre , SqlDbType.VarChar ,
                                            ( ( DominioTangerine.Entidades.M2.UsuarioM2 )theUsuario ).rol.nombre , false );
                    parameters.Add( theParam );

                    //Se manda a ejecutar en BDConexion el stored procedure
                    List<Resultado> results = EjecutarStoredProcedure( ResourceUser.AgregarUsuario , parameters );

                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                     ResourceUser.MensajeFinInfoLogger,
                                     System.Reflection.MethodBase.GetCurrentMethod().Name);

                return true;
            } 

            /// <summary>
            /// Método para modificar un usuario
            /// </summary>
            /// <param name="theUsuario">Es el objeto que se va a modificar en la BD</param>
            /// <returns>Retorna el objeto en la base de datos</returns>
            public bool Modificar( Entidad theUsuario )
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Método para consultar un usuario por id
            /// </summary>
            /// <param name="theUsuario">Es el objeto que se va a consultar en la BD</param>
            /// <returns>Retorna la consulta</returns>
            public Entidad ConsultarXId( Entidad theUsuario )
            {
                Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                     ResourceUser.MensajeInicioInfoLogger , System.Reflection.MethodBase.GetCurrentMethod().Name );
                Entidad usuario;

                try
                {
                    List<Parametro> parameters = new List<Parametro>();

                    Parametro theParam = new Parametro( ResourceUser.ParametroID , SqlDbType.Int ,
                                                       ( ( DominioTangerine.Entidades.M2.UsuarioM2 )theUsuario ).Id.ToString() , false );
                    parameters.Add( theParam );

                    //Guardo la tabla que me regresa el procedimiento de ConsultarUsuario
                    DataTable dt = EjecutarStoredProcedureTuplas( ResourceUser.ConsultUser , parameters );
                    //Guardar los datos 
                    DataRow row = dt.Rows[ 0 ];

                    int usuId = int.Parse( row[ ResourceUser.ComIDUser ].ToString() );
                    String usuUser = row[ ResourceUser.UsuNombre ].ToString();
                    String usuContrasena = row[ ResourceUser.UsuContrasena ].ToString();
                    DateTime usuFechaCreacion = DateTime.Parse( row[ ResourceUser.UsuFechaCreacion ].ToString() );
                    String usuActivo = row[ ResourceUser.UsuActivo ].ToString();
                    int theRolID = int.Parse( row[ ResourceUser.UsuFKRol ].ToString() );
                    DominioTangerine.Entidad rolID = DominioTangerine.Fabrica.FabricaEntidades.crearRolConID( theRolID );
                    DominioTangerine.Entidades.M2.RolM2 rol = ( DominioTangerine.Entidades.M2.RolM2 )rolID;
                    int empleadoNumFicha = int.Parse( row[ ResourceUser.UsuEmpFicha ].ToString() );

                    //Creo un objeto de tipo Usuario con los datos de la fila y lo guardo.
                    usuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompletoConID( usuId, usuUser, usuContrasena,
                                                                                                   usuFechaCreacion , usuActivo ,
                                                                                                   rol, empleadoNumFicha );
                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                    ResourceUser.MensajeFinInfoLogger ,
                                    System.Reflection.MethodBase.GetCurrentMethod().Name );

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
            /// <param name="fichaEmpleado">Es la ficha del empleado que se quiere verificar</param>
            /// <returns>Si existe True, si no, False</returns>
            public bool VerificarUsuarioPorFichaEmpleado( int fichaEmpleado )
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro();
                bool resultado = false;

                try
                {
                    elParametro = new Parametro( ResourceUser.ParametroNumFicha , SqlDbType.Int , fichaEmpleado.ToString() , false );
                    parametros.Add(elParametro);

                    DataTable dt = EjecutarStoredProcedureTuplas( ResourceUser.VerificarUsuarioPorFichaEmpleado , parametros );

                    foreach ( DataRow row in dt.Rows )
                    {
                        resultado = true;
                    }
                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                    ResourceUser.MensajeFinInfoLogger ,
                                    System.Reflection.MethodBase.GetCurrentMethod().Name );

                return resultado;
            }

            /// <summary>
            /// Método usado para verificar si el usuario existe en el sistema
            /// </summary>
            /// <param name="nombreUsuario">Es el nombre de usuario cuya existencia sera verificada</param>
            /// <returns>Retorna una valor booleano indicando la disponibilidad del usuario</returns>
            public bool VerificarExistenciaUsuario( string nombreUsuario )
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro();

                bool resultado = false;

                try
                {
                    elParametro = new Parametro( ResourceUser.ParametroUsuario , SqlDbType.VarChar , nombreUsuario , false );
                    parametros.Add( elParametro );

                    DataTable dt = EjecutarStoredProcedureTuplas( ResourceUser.VerificarExistenciaUsuario , parametros );

                    foreach ( DataRow row in dt.Rows )
                    {
                        resultado = true;
                    }
                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                     ResourceUser.MensajeFinInfoLogger,
                                     System.Reflection.MethodBase.GetCurrentMethod().Name);

                return resultado;
            }

            /// <summary>
            /// Método que retorna el usuario y rol de un empleado
            /// </summary>
            /// <param name="num_empleado">Es la ficha del empleado para devolver su usuario y rol</param>
            /// <returns>Retorna el usuario de un empleado</returns>
            public Entidad ObtenerUsuarioDeEmpleado( int num_empleado )
            {
                Entidad theUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioVacio();
                DominioTangerine.Entidades.M2.UsuarioM2 usuario = ( DominioTangerine.Entidades.M2.UsuarioM2 )theUsuario;

                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro();

                try
                {
                    elParametro = new Parametro( ResourceUser.ParametroNumFicha , SqlDbType.Int , num_empleado.ToString() , false );
                    parametros.Add( elParametro );

                    DataTable dt = EjecutarStoredProcedureTuplas( ResourceUser.ObtenerUsuarioDeEmpleado , parametros );

                    foreach ( DataRow row in dt.Rows )
                    {
                        string nombreUsuario = row[ ResourceUser.UsuNombre ].ToString();
                        string rolUsuario = row[ ResourceUser.RolNombre ].ToString();

                        Entidad theRol = DominioTangerine.Fabrica.FabricaEntidades.crearRolNombre( rolUsuario );
                        DominioTangerine.Entidades.M2.RolM2 rol = ( DominioTangerine.Entidades.M2.RolM2 )theRol;

                        usuario.nombreUsuario = nombreUsuario;
                        usuario.rol = rol;
                    }
                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                    ResourceUser.MensajeFinInfoLogger ,
                                    System.Reflection.MethodBase.GetCurrentMethod().Name );

                return usuario;
            }

            /// <summary>
            /// Método que obtiene los datos de un usuario teniendo como entrada su usuario y contraseña
            /// </summary>
            /// <param name="theUsuario">Es el objeto del cual que quieren obtener los datos</param>
            /// <returns>Los datos del usuario</returns>
            public Entidad ObtenerDatoUsuario( Entidad theUsuario )
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro();
                DominioTangerine.Entidades.M2.UsuarioM2 usuario = ( DominioTangerine.Entidades.M2.UsuarioM2 )theUsuario;

                try
                {
                    elParametro = new Parametro( ResourceUser.ParametroUsuario , SqlDbType.VarChar , usuario.nombreUsuario , false );
                    parametros.Add( elParametro );

                    elParametro = new Parametro( ResourceUser.ParametroContrasenia , SqlDbType.VarChar , usuario.contrasena , false );
                    parametros.Add( elParametro );

                    DataTable dt = EjecutarStoredProcedureTuplas( ResourceUser.ObtenerDatoUsuario , parametros );

                    //Por cada fila de la tabla voy a guardar los datos 
                    foreach ( DataRow row in dt.Rows )
                    {
                        DateTime usuFecha = DateTime.Parse( row [ ResourceUser.UsuFechaCreacion ].ToString() );
                        string usuAct = row[ ResourceUser.UsuActivo ].ToString();
                        int usuIdRol = int.Parse( row[ ResourceUser.UsuFKRol ].ToString() );
                        int usuEmpFicha = int.Parse (row[ ResourceUser.UsuEmpFicha ].ToString() );

                        usuario.fechaCreacion = usuFecha;
                        usuario.activo = usuAct;
                        usuario.fichaEmpleado = usuEmpFicha;

                        DatosTangerine.InterfazDAO.M2.IDAORol DAORol = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoRol();
                        Entidad theRol = DAORol.ObtenerRolUsuario( usuIdRol );
                        DominioTangerine.Entidades.M2.RolM2 rol = ( DominioTangerine.Entidades.M2.RolM2 )theRol; 
                        usuario.rol = rol;
                    }

                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine("DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine("DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                    ResourceUser.MensajeFinInfoLogger ,
                                    System.Reflection.MethodBase.GetCurrentMethod().Name );

                return usuario;
            }

            /// <summary>
            /// Método que arma la lista de los parametros del Stored Procedure para modificar la contraseña 
            /// del usuario y llama al método que ejecuta el Stored Procedure (El objeto usuario debe tener 
            /// agregada la contraseña nueva).
            /// </summary>
            /// <param name="theUsuario">Es el objeto al cual se le quiere modificar la contraseña</param>
            /// <returns>true se es exitoso y false si es fallido</returns>
            public bool ModificarContraseniaUsuario( Entidad theUsuario )
            {
                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro;
                DominioTangerine.Entidades.M2.UsuarioM2 usuario = ( DominioTangerine.Entidades.M2.UsuarioM2 )theUsuario;

                try
                {
                    elParametro = new Parametro( ResourceUser.ParametroUsuario , SqlDbType.VarChar , usuario.nombreUsuario , false );
                    parametros.Add( elParametro );

                    elParametro = new Parametro( ResourceUser.ParametroContraseniaNueva , SqlDbType.VarChar ,
                                                 usuario.contrasena , false );
                    parametros.Add( elParametro );

                    List<Resultado> results = EjecutarStoredProcedure( ResourceUser.ModificarContraUsuario , parametros );
                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                    ResourceUser.MensajeFinInfoLogger ,
                                    System.Reflection.MethodBase.GetCurrentMethod().Name );

                return true;
            }

            /// <summary>
            /// Método que permite consultar el ID del ultimo usuario en la base de datos
            /// </summary>
            /// <returns>Retorne el ultimo ID</returns>
            public int ConsultLastUserID()
            {
                Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                     ResourceUser.MensajeInicioInfoLogger , System.Reflection.MethodBase.GetCurrentMethod().Name );
                int ultimoID = 0;
                try
                {
                    List<Parametro> parameters = new List<Parametro>();

                    //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
                    DataTable dt = EjecutarStoredProcedureTuplas( ResourceUser.ConsultLastUserID , parameters );
                    //Guardar los datos 
                    DataRow row = dt.Rows[ 0 ];

                    ultimoID = int.Parse( row [ ResourceUser.ComIDUser ].ToString() );

                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                    ResourceUser.MensajeFinInfoLogger ,
                                    System.Reflection.MethodBase.GetCurrentMethod().Name );

                return ultimoID;
            }
            
            /// <summary>
            /// Método que permite consultar el ID del ultimo empleado en la base de datos
            /// </summary>
            /// <returns>Retorna el ID del ultimo empleado</returns>
            public int ConsultLastEmployeID()
            {
                Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                     ResourceUser.MensajeInicioInfoLogger , System.Reflection.MethodBase.GetCurrentMethod().Name );
                int ultimoID = 0;
                try
                {
                    List<Parametro> parameters = new List<Parametro>();

                    //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
                    DataTable dt = EjecutarStoredProcedureTuplas(ResourceUser.ConsultLastEmployeID, parameters);
                    //Guardar los datos 
                    DataRow row = dt.Rows[0];

                    ultimoID = int.Parse( row[ ResourceUser.fichaEmpleado ].ToString() );

                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                     ResourceUser.MensajeFinInfoLogger ,
                                     System.Reflection.MethodBase.GetCurrentMethod().Name );

                return ultimoID;
            }

            /// <summary>
            /// Borrar usuario por el Id de un usuario
            /// </summary>
            /// <param name="userID">Es el ID del usuario que se va a borrar de la BD</param>
            /// <returns>Retorna true si es elimanado exitosamente</returns>
            public bool BorrarUsuario( int userID )
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                    ResourceUser.MensajeInicioInfoLogger , System.Reflection.MethodBase.GetCurrentMethod().Name );
                Parametro theParam = new Parametro();
                try
                {
                    List<Parametro> parameters = new List<Parametro>();

                    //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                    //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                    theParam = new Parametro( ResourceUser.ParametroUsuID , SqlDbType.Int , userID.ToString() , false );
                    parameters.Add( theParam );

                    //Se manda a ejecutar en BDConexion el stored procedure M4_AgregarCompania y todos los parametros que recibe
                    List<Resultado> results = EjecutarStoredProcedure( ResourceUser.BorrarUsuario , parameters );

                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                    ResourceUser.MensajeFinInfoLogger ,
                                    System.Reflection.MethodBase.GetCurrentMethod().Name );

                return true;
            }
            
            /// <summary>
            /// Método para modificar el nombre de usuario de un empleado
            /// </summary>
            /// <param name="fichaEmpleado">Es la ficha del empleado que se va a buscar</param>
            /// <param name="nombreUsuario">Es el nombre del usuario que se va a modificar</param>
            /// <returns></returns>
            public bool ModificarUsuario( int fichaEmpleado , string nombreUsuario )
            {
                Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                     ResourceUser.MensajeInicioInfoLogger , System.Reflection.MethodBase.GetCurrentMethod().Name );
                Parametro theParam = new Parametro();
                try
                {
                    List<Parametro> parameters = new List<Parametro>();

                    //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                    //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                    theParam = new Parametro( ResourceUser.ParametroNumFicha , SqlDbType.Int , fichaEmpleado.ToString() , false );
                    parameters.Add(theParam);
                    
                    theParam = new Parametro( ResourceUser.ParametroUsuario , SqlDbType.VarChar, nombreUsuario , false );
                    parameters.Add(theParam);

                    //Se manda a ejecutar en BDConexion el stored procedure
                    List<Resultado> results = EjecutarStoredProcedure( ResourceUser.ModificarNombreUsuario , parameters );

                }
                catch ( ArgumentNullException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de un argumento con valor invalido" , ex );
                }
                catch ( FormatException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Ingreso de datos con un formato invalido" , ex );
                }
                catch ( ExceptionTGConBD ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error con la base de datos" , ex );
                }
                catch ( SqlException ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la conexion" , ex );
                }
                catch ( Exception ex )
                {
                    Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                    throw new ExceptionM2Tangerine( "DS-202" , "Error al momento de realizar la operacion" , ex );
                }

                Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name ,
                                     ResourceUser.MensajeFinInfoLogger ,
                                     System.Reflection.MethodBase.GetCurrentMethod().Name );

                return true;
            }

        #endregion
    }
}
