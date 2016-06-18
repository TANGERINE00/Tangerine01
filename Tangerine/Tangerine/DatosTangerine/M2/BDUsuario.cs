﻿using DominioTangerine;
using ExcepcionesTangerine;
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
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine( RecursoGeneralBD.Codigo,
                                                                    RecursoGeneralBD.Mensaje, ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                return false;
            }

            return true;
        } //Listo

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
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionsTangerine( RecursoGeneralBD.Codigo,
                                                                    RecursoGeneralBD.Mensaje, ex );
            }

            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                return false;
            }

            return true;
        } //Listo

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
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionsTangerine( RecursoGeneralBD.Codigo,
                                                                    RecursoGeneralBD.Mensaje, ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                return false;
            }

            return true;
        } //Listo

        /// <summary>
        /// Método que obtiene los datos de un usuario teniendo como entrada su usuario y contraseña
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static Usuario ObtenerDatoUsuario( Usuario usuario ) 
        {
            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro();

            try 
            {
                laConexion.Conectar();

                elParametro = new Parametro( ResourceUser.ParametroUsuario, SqlDbType.VarChar, usuario.NombreUsuario,
                                             false );
                parametros.Add( elParametro );

                elParametro = new Parametro( ResourceUser.ParametroContrasenia, SqlDbType.VarChar, usuario.Contrasenia,
                                             false );
                parametros.Add( elParametro );

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas( ResourceUser.ObtenerDatoUsuario, parametros );

                //Por cada fila de la tabla voy a guardar los datos 
                foreach ( DataRow row in dt.Rows )
                {
                    DateTime usuFecha = DateTime.Parse( row[ ResourceUser.UsuFechaCreacion ].ToString() );
                    string usuAct = row[ ResourceUser.UsuActivo ].ToString();
                    int usuIdRol = int.Parse( row[ ResourceUser.UsuFKRol ].ToString() );
                    int usuEmpFicha = int.Parse( row[ ResourceUser.UsuEmpFicha ].ToString() );

                    usuario.FechaCreacion = usuFecha;
                    usuario.Activo = usuAct;
                    usuario.FichaEmpleado = usuEmpFicha;

                    Rol rol = ObtenerRolUsuario( usuIdRol );
                    usuario.Rol = rol;
                }

            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionsTangerine( RecursoGeneralBD.Codigo,
                                                                    RecursoGeneralBD.Mensaje, ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
            }

            return usuario;
        } //Listo

        /// <summary>
        /// Método que obtiene el rol y los menús que poseen opciones prohibidas para el usuario
        /// </summary>
        /// <param name="codigoRol"></param>
        /// <returns></returns>
        public static Rol ObtenerRolUsuario( int codigoRol ) 
        {
            Rol rol = new Rol();
            Menu menu;
            ListaGenerica<Menu> lista = new ListaGenerica<Menu>(); ;

            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro();

            bool esAdministrador = true;

            try
            {
                laConexion.Conectar();

                elParametro = new Parametro( ResourceUser.ParametroRolCodigo, SqlDbType.Int, codigoRol.ToString(),
                                             false );
                parametros.Add( elParametro );

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas( ResourceUser.ObtenerRolUsuario, parametros );

                bool rolAgregado = false;
                
                //Por cada fila de la tabla voy a guardar los datos 
                foreach ( DataRow row in dt.Rows )
                { 
                    string rolNombre = row[ ResourceUser.RolNombre ].ToString();
                    string menNombre = row[ ResourceUser.RolMenu ].ToString();

                    if ( rolAgregado == false )
                    {
                        rol.Nombre = rolNombre;
                        rolAgregado = true;
                    }

                    ListaGenerica<Opcion> opciones = ObtenerOpciones( menNombre, codigoRol );

                    menu = new Menu( menNombre, opciones );

                    lista.AgregarElemento( menu );

                    esAdministrador = false;
                }

                if( esAdministrador )
                {
                    rol.Nombre = "Administrador";
                }
                rol.Menus = lista;

            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
            }

            return rol;
        } //Listo

        /// <summary>
        /// Método que devuelve las opciones de un menú prohibidas para un rol
        /// </summary>
        /// <param name="nombreMenu"></param>
        /// <param name="codigoRol"></param>
        /// <returns></returns>
        public static ListaGenerica<Opcion> ObtenerOpciones( string nombreMenu, int codigoRol ) 
        {
            ListaGenerica<Opcion> lista = new ListaGenerica<Opcion>();
            Opcion opcion;

            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro();

            try
            {
                laConexion.Conectar();

                elParametro = new Parametro( ResourceUser.ParametroMenuNombre, SqlDbType.VarChar, nombreMenu,
                                             false );
                parametros.Add( elParametro );

                elParametro = new Parametro( ResourceUser.ParametroRolCodigo, SqlDbType.Int, codigoRol.ToString(),
                                             false );
                parametros.Add( elParametro );

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas( ResourceUser.ObtenerOpciones, parametros );

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    string nombreOpcion = row[ ResourceUser.OpcNombre ].ToString();
                    string url = row[ ResourceUser.OpcUrl ].ToString();

                    opcion = new Opcion( nombreOpcion, url );

                    lista.AgregarElemento( opcion );
                }
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
            }

            return lista;
        } //Listo

        /// <summary>
        /// Método que retorna el usuario y rol de un empleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public static Usuario ObtenerUsuarioDeEmpleado( int num_empleado ) 
        {
            Usuario usuario = new Usuario();

            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro();

            try
            {
                laConexion.Conectar();

                elParametro = new Parametro(ResourceUser.ParametroNumFicha, SqlDbType.Int, num_empleado.ToString(), false);
                parametros.Add( elParametro );

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas( ResourceUser.ObtenerUsuarioDeEmpleado, parametros );

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    string nombreUsuario = row[ ResourceUser.UsuNombre ].ToString();
                    string rolUsuario = row[ ResourceUser.RolNombre ].ToString();

                    Rol rol = new Rol( rolUsuario );
                    
                    usuario.NombreUsuario = nombreUsuario;
                    usuario.Rol = rol;
                }
            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionsTangerine( RecursoGeneralBD.Codigo,
                                                                    RecursoGeneralBD.Mensaje, ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
            }

            return usuario;
        } //Listo

        /// <summary>
        /// Método que retorna el rol de un usuario con sus privilegios pasando como parámetro el nombre del rol
        /// </summary>
        /// <param name="nombreRol"></param>
        /// <returns></returns>
        public static Rol ObtenerRolUsuarioPorNombre( string nombreRol ) 
        {
            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro();
            Rol rol = new Rol();

            try
            {
                laConexion.Conectar();

                elParametro = new Parametro( ResourceUser.ParametroRolNombre, SqlDbType.VarChar, nombreRol.ToString(),
                                             false );
                parametros.Add( elParametro );

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas( ResourceUser.ObtenerRolUsuarioPorNombre,
                                                                         parametros );

                foreach ( DataRow row in dt.Rows )
                {
                    int idRol = int.Parse( row[ ResourceUser.RolId ].ToString() );

                    rol = ObtenerRolUsuario( idRol );
                }
            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionsTangerine( RecursoGeneralBD.Codigo,
                                                                    RecursoGeneralBD.Mensaje, ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
            }

            return rol;
        } //Listo

        /// <summary>
        /// Método que retorna true si un usuario pertenece al empleado con el numero de ficha pasado como parametro. 
        /// Si sucede lo contrario retorna false.
        /// </summary>
        /// <param name="fichaEmpleado"></param>
        /// <returns></returns>
        public static bool VerificarUsuarioPorFichaEmpleado( int fichaEmpleado )
        {
            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro();

            bool resultado = false;

            try
            {
                laConexion.Conectar();

                elParametro = new Parametro( ResourceUser.ParametroNumFicha, SqlDbType.Int, fichaEmpleado.ToString(),
                                             false );
                parametros.Add( elParametro );

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas( ResourceUser.VerificarUsuarioPorFichaEmpleado,
                                                                         parametros );

                foreach ( DataRow row in dt.Rows )
                {
                    resultado = true;
                }
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                return false;
            }

            return resultado;
        } //Listo

        /// <summary>
        /// Método para verificar si un nombre de usuario existe
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        public static bool VerificarExistenciaDeUsuario( string nombreUsuario )
        {
            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro();

            bool resultado = false;

            try
            {
                laConexion.Conectar();

                elParametro = new Parametro( ResourceUser.ParametroUsuario, SqlDbType.VarChar, nombreUsuario,
                                             false );
                parametros.Add( elParametro );

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas( ResourceUser.VerificarExistenciaUsuario,
                                                                         parametros );

                foreach ( DataRow row in dt.Rows )
                {
                    resultado = true;
                }
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                return false;
            }

            return resultado;
        } //Listo
    }
}
