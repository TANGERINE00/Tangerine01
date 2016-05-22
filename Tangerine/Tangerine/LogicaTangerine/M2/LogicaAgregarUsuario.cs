﻿using DatosTangerine.M10;
using DatosTangerine.M2;
using DominioTangerine;
using ExcepcionesTangerine;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.M2
{
    public class LogicaAgregarUsuario
    {
        /// <summary>
        /// Método que se comunica con la clase BDEmpleado con el fin de conseguir la lista de empleados que
        /// están registrados en la base de datos
        /// </summary>
        /// <returns></returns>
        public static List<Empleado> ConsultarListaDeEmpleados()
        {
            List<Empleado> listaDeEmpleados = new List<Empleado>();
            try
            { 
                listaDeEmpleados = BDEmpleado.ListarEmpleados();
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Error al ejecutar " +
                                                                     "ConsultarListaDeEmpleados()", ex );
            }
            return listaDeEmpleados;
        }

        /// <summary>
        /// Método para verificar si un empleado ya posee usuarios
        /// </summary>
        /// <param name="numeroFicha"></param>
        /// <returns></returns>
        public static bool VerificarUsuarioDeEmpleado( int numeroFicha )
        {
            bool resultado = false;
            try
            {
                resultado = BDUsuario.VerificarUsuarioPorFichaEmpleado( numeroFicha );

            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Parametro invalido [numeroFicha es null]", ex );
            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( "TGE_00_001",
                                                                 "Error al ejecutar VerificarUsuarioDeEmpleado()",
                                                                 ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Error al ejecutar " +
                                                                     "VerificarUsuarioDeEmpleado()", ex );
            }
            return resultado;
        }

        /// <summary>
        /// Método que se comunica con BDUsuario para agregar el usuario a la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static bool AgregarUsuario( Usuario usuario )
        {
            bool resultado = false;
            try
            {
                resultado = BDUsuario.AgregarUsuario( usuario );

            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Parametro invalido [usuario es null]", ex );
            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( "TGE_00_001",
                                                                 "Error al ejecutar AgregarUsuario()",
                                                                 ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Error al ejecutar " +
                                                                     "AgregarUsuario()", ex );
            }
            
            return resultado;
        }

        /// <summary>
        /// Método que prepara los objetos tipo Rol y Usuario para después llamar al método AgregarUsuario()
        /// </summary>
        /// <param name="usuarioNombre"></param>
        /// <param name="contraseniaUsuario"></param>
        /// <param name="rolUsuario"></param>
        /// <param name="fichaEmpleado"></param>
        /// <returns></returns>
        public static bool PrepararUsuario( string usuarioNombre, string contraseniaUsuario, string rolUsuario,
                                            int fichaEmpleado )
        {
            bool resultado = true;
            try 
            { 
                Rol rol = new Rol( rolUsuario );
                Usuario usuario = new Usuario( usuarioNombre, contraseniaUsuario, "Activo", rol, fichaEmpleado,
                                               DateTime.Now );
                usuario.Contrasenia = usuario.GetMD5( usuario.Contrasenia );
                AgregarUsuario( usuario );
            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Parametro invalido", ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Error al ejecutar " +
                                                                     "PrepararUsuario()", ex );
            }
            return resultado;
        }

        /// <summary>
        /// Método para crear el nombre de usuario (2 primeros caracteres del nombre + 4 primeros caracteres del 
        /// apellido)
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <returns></returns>
        public static string CrearUsuarioDefault( string nombre, string apellido )
        {
            string usuarioNuevo = "";
            try
            {        
                nombre = nombre.ToLower();
                apellido = apellido.ToLower();

                usuarioNuevo = ObtenerCaracteres( nombre, 2 );//Obtiene los dos primeros caracteres del nombre
                usuarioNuevo = usuarioNuevo + ObtenerCaracteres( apellido, 4 );//Obtiene los 4 primeros caracteres del 
                                                                               //apellido
            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Parametro invalido", ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Error al ejecutar " +
                                                                     "CrearUsuarioDefault()", ex );
            }
            return usuarioNuevo;
        }

        /// <summary>
        /// Método que obtiene los primeros caracteres de una cadena (retorna la cantidad de caracteres 
        /// indicados en el parametro cantidad)
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static string ObtenerCaracteres( string cadena, int cantidad )
        {
            string caracteres = "";
            try 
            { 
                char[] cadenaSeparada = new char[ cadena.Length ];

                using ( StringReader reader = new StringReader( cadena ) )
                {
                    reader.ReadAsync( cadenaSeparada, 0, cadena.Length );
                }

                for ( int i = 0; i < cadena.Length; i++ )
                {
                    caracteres = caracteres + cadenaSeparada[ i ];
                    if ( i == ( cantidad - 1 ) )
                    {
                        break;
                    }
                }
            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Parametro invalido", ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Error al ejecutar " +
                                                                     "ObtenerCaracteres()", ex );
            }

            return caracteres;
        }

        /// <summary>
        /// Método para verificar si el nombre de usuario pasado como arámetro existe en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static bool ExisteUsuario( string usuario )
        {
            bool resultado = false;
            try 
            { 
                resultado = BDUsuario.VerificarExistenciaDeUsuario( usuario );
            }
            catch( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Parametro invalido [usuario es null]", ex );
            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( "TGE_00_001",
                                                                 "Error al ejecutar ExisteUsuario()",
                                                                 ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro( "Error al ejecutar " +
                                                                     "ExisteUsuario()", ex );
            }
            return resultado;
        }
    }
}
