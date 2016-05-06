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
    class BDUsuario
    {
        BDConexion laConexion;
        List<Parametro> parametros;
        Parametro elParametro;

        /// <summary>
        /// Método que arma la lista de los parametros del Stored Procedure para agregar un usuario nuevo y llama 
        /// al metodo que ejecuta el Stored Procedure.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>true se es exitoso y false si es fallido</returns>
        public bool AgregarUsuario( Usuario usuario )
        {
            parametros = new List<Parametro>();
            laConexion = new BDConexion();

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
        public bool ModificarRolUsuario( Usuario usuario ) 
        {
            parametros = new List<Parametro>();
            laConexion = new BDConexion();

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
        public bool ModificarContraseniaUsuario( Usuario usuario )
        {
            parametros = new List<Parametro>();
            laConexion = new BDConexion();

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

        public bool ObtenerDatoUsuario( Usuario usuario ) 
        {
            laConexion = new BDConexion();
            SqlDataReader resultadoConsulta;

            try 
            {
                resultadoConsulta = laConexion.EjecutarQuery( "" );

                while ( resultadoConsulta.Read() )
                {

                }
            }
            catch ( Exception ex )
            {

            }

            return false;
        }
    }
}
