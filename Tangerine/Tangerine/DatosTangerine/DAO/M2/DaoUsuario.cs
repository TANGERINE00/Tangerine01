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
              /*  Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    RecursosPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name); */

                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro;
                DominioTangerine.Entidades.M2.UsuarioM2 usuario = (DominioTangerine.Entidades.M2.UsuarioM2) theUsuario;
                try
                {

                    elParametro = new Parametro(ResourceUser.ParametroUsuario, SqlDbType.VarChar, usuario.nombreUsuario, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(ResourceUser.ParametroContrasenia, SqlDbType.VarChar, usuario.contrasena, false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(ResourceUser.ParametroNumFicha, SqlDbType.Int, usuario.fichaEmpleado.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(ResourceUser.ParametroFechaCreacion, SqlDbType.Date, usuario.fechaCreacion.ToString(), false);
                    parametros.Add(elParametro);

                    elParametro = new Parametro(ResourceUser.ParametroRolNombre, SqlDbType.VarChar, usuario.rol.nombre.ToString(), false);
                    parametros.Add(elParametro);

                    List<Resultado> results = EjecutarStoredProcedure(ResourceUser.AgregarUsuario, parametros);
                }
                catch (NullReferenceException ex)
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

                catch (ExcepcionesTangerine.ExceptionTGConBD ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw ex;
                }

                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    return false;
                }

             /*   Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                  RecursosPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name); */

                return true;
            }

            /// <summary>
            /// Método para modificar un usuario
            /// </summary>
            /// <param name="theUsuario"></param>
            /// <returns>Retorna el objeto en la base de datos</returns>
            public bool Modificar( Entidad theUsuario )
            {
                return true;
            }

            /// <summary>
            /// Método para consultar un usuario por id
            /// </summary>
            /// <param name="theUsuario"></param>
            /// <returns>Retorna la consulta</returns>
            public Entidad ConsultarXId( Entidad theUsuario )
            {
                return theUsuario;
            }

            /// <summary>
            /// Método para consultar todos los usuarios
            /// </summary>
            /// <returns>Retorna todos los usuarios</returns>
            public List<Entidad> ConsultarTodos()
            {
                List<Entidad> listaUser = new List<Entidad>();
                return listaUser; 
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
            }

            /// <summary>
            /// Método usado para devolver todos los empleados sin usuario
            /// </summary>
            /// <returns>Retorna la lista de empleados</returns>
            public List<Empleado> ConsultarListaDeEmpleados()
            {
                List<Empleado> listaDeEmpleados = new List<Empleado>();
                
                try
                {
                    //Hablar con mod10 para que cambien el metodo ListaEmpleados() de lugar.
                    listaDeEmpleados = BDEmpleado.ListarEmpleados();
                }
                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new ExcepcionesTangerine.M2.ExcepcionRegistro("Error al ejecutar " + "ConsultarListaDeEmpleados()", ex);
                }
                return listaDeEmpleados;
            } //OJOOOOOOOOOOOOO

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
            public Entidad ObtenerUsuarioDeEmpleado( Entidad theEmpleado )
            {
                DominioTangerine.Entidades.M10.Empleado empleado = (DominioTangerine.Entidades.M10.Empleado) theEmpleado;
                Entidad theUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioVacio();

                DominioTangerine.Entidades.M2.UsuarioM2 usuario = (DominioTangerine.Entidades.M2.UsuarioM2) theUsuario;

                List<Parametro> parametros = new List<Parametro>();
                Parametro elParametro = new Parametro();

                try
                {
                    Conectar();

                    elParametro = new Parametro(ResourceUser.ParametroNumFicha, SqlDbType.Int, empleado.Emp_num_ficha.ToString(), false);
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

        #endregion

    }
}
