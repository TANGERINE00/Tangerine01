using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.M2
{
    public class BDUsuario
    {

        /// <summary>
        /// Método que arma la lista de los parametros del Stored Procedure para agregar un usuario nuevo y llama 
        /// al metodo que ejecuta el Stored Procedure.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>true se es exitoso y false si es fallido</returns>
        public static bool AgregarUsuario( Usuario usuario )
        {
            List<Parametro> parametros = new List<Parametro>();
            BDConexion laConexion = new BDConexion();
            Parametro elParametro;

            try
            {
                elParametro = new Parametro( ResourceUser.ParametroUsuario, SqlDbType.VarChar, usuario.NombreUsuario,
                                             false );
                parametros.Add( elParametro );

                elParametro = new Parametro( ResourceUser.ParametroContrasenia, SqlDbType.VarChar, usuario.Contrasenia,
                                             false );
                parametros.Add( elParametro );

                elParametro = new Parametro( ResourceUser.ParametroNumFicha, SqlDbType.Int, 
                                             usuario.FichaEmpleado.ToString(), false );
                parametros.Add( elParametro );

                elParametro = new Parametro( ResourceUser.ParametroFechaCreacion, SqlDbType.Date,
                                             usuario.FechaCreacion.ToString(), false );
                parametros.Add( elParametro );

                elParametro = new Parametro( ResourceUser.ParametroRolNombre, SqlDbType.VarChar, usuario.Rol.Nombre,
                                             false );
                parametros.Add( elParametro );

                List<Resultado> results = laConexion.EjecutarStoredProcedure( ResourceUser.AgregarUsuario, 
                                                                              parametros );
            }
            catch ( Exception ex )
            {

            }

            return true;
        }

        /// <summary>
        /// Método que arma la lista de los parametros del Stored Procedure para modificar el rol del usuario 
        /// y llama al método que ejecuta el Stored Procedure (El objeto usuario debe tener agregado el rol nuevo).
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>true se es exitoso y false si es fallido</returns>
        public static bool ModificarRolUsuario( Usuario usuario ) 
        {
            List<Parametro> parametros = new List<Parametro>();
            BDConexion laConexion = new BDConexion();
            Parametro elParametro;

            try
            {
                elParametro = new Parametro( ResourceUser.ParametroUsuario, SqlDbType.VarChar, usuario.NombreUsuario,
                                             false );
                parametros.Add( elParametro );

                elParametro = new Parametro( ResourceUser.ParametroRolUsuario, SqlDbType.VarChar, usuario.Rol.Nombre,
                                             false );
                parametros.Add( elParametro );

                List<Resultado> results = laConexion.EjecutarStoredProcedure( ResourceUser.ModificarRolUsuario,
                                                                              parametros );
            }
            catch ( Exception ex )
            {

            }

            return true;
        }

        /// <summary>
        /// Método que arma la lista de los parametros del Stored Procedure para modificar la contraseña 
        /// del usuario y llama al método que ejecuta el Stored Procedure (El objeto usuario debe tener 
        /// agregada la contraseña nueva).
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>true se es exitoso y false si es fallido</returns>
        public static bool ModificarContraseniaUsuario( Usuario usuario )
        {
            List<Parametro> parametros = new List<Parametro>();
            BDConexion laConexion = new BDConexion();
            Parametro elParametro; ;

            try
            {
                elParametro = new Parametro( ResourceUser.ParametroUsuario, SqlDbType.VarChar, usuario.NombreUsuario,
                                             false );
                parametros.Add( elParametro );

                elParametro = new Parametro( ResourceUser.ParametroContraseniaNueva, SqlDbType.VarChar,
                                             usuario.Contrasenia, false );
                parametros.Add( elParametro );

                List<Resultado> results = laConexion.EjecutarStoredProcedure( ResourceUser.ModificarContraUsuario,
                                                                              parametros );
            }
            catch ( Exception ex )
            {

            }

            return true;
        }

        /// <summary>
        /// Método que obtiene los datos de un usuario teniendo como entrada su usuario y contraseña
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static Usuario ObtenerDatoUsuario( Usuario usuario ) 
        {
            BDConexion laConexion = new BDConexion();
            SqlDataReader resultadoConsulta;

            try 
            {
                resultadoConsulta = laConexion.EjecutarQuery( @"SELECT usu_fecha_creacion, usu_activo, fk_rol_id,
                                                                       fk_emp_num_ficha
                                                                FROM usuario
                                                                WHERE usu_usuario = '" + usuario.NombreUsuario +
                                                               "' and usu_contrasena = '" + usuario.Contrasenia +
                                                               "'" );

                while ( resultadoConsulta.Read() )
                {
                    usuario.FechaCreacion = resultadoConsulta.GetDateTime( 0 );
                    usuario.Activo = resultadoConsulta.GetString( 1 );
                    usuario.FichaEmpleado = resultadoConsulta.GetInt32( 3 );
                }

            }
            catch ( Exception ex )
            {

            }

            return usuario;
        }

        public static Rol ObtenerRolUsuario( int codigoRol ) 
        {
            Rol rol = new Rol();
            ListaGenerica<Menu> lista = new ListaGenerica<Menu>(); ;

            BDConexion laConexion = new BDConexion();
            SqlDataReader resultadoConsulta;

            try
            {
                resultadoConsulta = laConexion.EjecutarQuery( @"select distinct rol_nombre, m.men_nombre
                                                                from rol, rol_opcion, opcion, menu m
                                                                where rol_id = fk_rol_id and fk_opc_id = opc_id
                                                                      and fk_men_id = m.men_id 
                                                                      and rol_id = " + codigoRol.ToString() );
                bool rolAgregado = false;

                while (resultadoConsulta.Read())
                {
                    if ( rolAgregado == false )
                    {
                        rol.Nombre = resultadoConsulta.GetString(0);
                        rolAgregado = true;
                    }

                    string nombreMenu = resultadoConsulta.GetString( 1 );
                    Menu menu = new Menu( nombreMenu );
                    
                    lista.AgregarElemento( menu );
                    
                }

            }
            catch (Exception ex)
            {

            }

            return rol;
        }
    }
}
