using DatosTangerine.M10;
using DatosTangerine.M2;
using DominioTangerine;
using ExcepcionesTangerine;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.M2
{
    public class LogicaModificarRol
    {
        /// <summary>
        /// Metodo que indica si se cambio o no exitosamente el rol de un usuario.
        /// </summary>
        /// <param name="elusuario"></param>
        /// <param name="elrol"></param>
        /// <returns></returns>
        public static bool ModificarRol( string elusuario, string elrol )
        {
            bool resultado = false;

            try
            {
                Rol rol = new Rol( elrol );
                Usuario usuario = new Usuario( elusuario, rol );

                resultado = BDUsuario.ModificarRolUsuario( usuario );
            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionModificarRol( "Parametro invalido [usuario es null]", ex );
            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( "TGE_00_001",
                                                                 "Error al ejecutar ConsultarListaDeEmpleados()",
                                                                 ex );
            }

            return resultado;
        }

        /// <summary>
        /// Metodo que retorna una lista de todos los usuarios que hay en el sistema
        /// </summary>
        /// <returns></returns>
        public static List<Usuario> ConsultarListaDeUsuarios()
        {
            List<Usuario> listaDeUsuarios = new List<Usuario>();

            List<Empleado> listaDeEmpleados = BDEmpleado.ListarEmpleados();

            foreach (Empleado empleado in listaDeEmpleados)
            {
                listaDeUsuarios.Add(BDUsuario.ObtenerUsuarioDeEmpleado(empleado));
            }

            return listaDeUsuarios;
        }

        /// <summary>
        /// Metodo que retorna el usuario de un empleado en particular
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public static Usuario ObtenerUsuario( Empleado empleado )
        {
            Usuario usuario;

            try
            {
                usuario = BDUsuario.ObtenerUsuarioDeEmpleado( empleado );
            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( "TGE_00_001",
                                                                 "Error al ejecutar ConsultarListaDeEmpleados()",
                                                                 ex );
            }
            return usuario;
        }
    }
}

