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
    public class LogicaPrivilegios
    {
        /// <summary>
        /// Método que retorna las opciones a las cuales el usuario que ha ingresado no puede acceder
        /// </summary>
        /// <param name="nombreRol"></param>
        /// <returns></returns>
        public static List<string> VerificarAccesoAOpciones( string nombreRol )
        {
            List<string> lista = new List<string>();

            try
            {
                Rol rol = BDUsuario.ObtenerRolUsuarioPorNombre( nombreRol );

                foreach ( DominioTangerine.Menu m in rol.Menus ) 
                {
                    foreach ( Opcion o in m.Opciones )
                    {
                        lista.Add( o.Nombre );
                    }
                }
            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( "TGE_00_001",
                                                                 "Error al ejecutar VerificarAccesoAOpciones()",
                                                                 ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionPrivilegios( "Error al ejecutar " +
                                                                        "VerificarAccesoAOpciones()", ex );
            }
            return lista;
        }

        /// <summary>
        /// Método que verifica que el usuario tiene la permisología para acceder a la página especificada
        /// </summary>
        /// <param name="paginaAVerificar"></param>
        /// <returns></returns>
        public static bool VerificarAccesoAPagina( string paginaAVerificar, string nombreRol )
        {
            bool resultado = false;

            string[] paginaSeparada = paginaAVerificar.Split( '/' );
            int tamanioPagina = paginaSeparada.Length;
            try
            {
                Rol rol = BDUsuario.ObtenerRolUsuarioPorNombre( nombreRol);

                foreach ( DominioTangerine.Menu m in rol.Menus )
                {
                    foreach ( Opcion o in m.Opciones )
                    {
                        string[] opcionSeparada = o.Url.Split( '/' );
                        int tamanioOpcion = opcionSeparada.Length;

                        if ( tamanioOpcion >= 2 )
                        {
                            if ( opcionSeparada[ tamanioOpcion - 1 ].Equals( paginaSeparada[ tamanioPagina - 1 ] )
                                 && opcionSeparada[ tamanioOpcion - 2 ].Equals( paginaSeparada[ tamanioPagina - 2 ] ) )
                            {
                                resultado = true;
                                return resultado;
                            }
                        }
                    }
                }
            }
            catch ( IndexOutOfRangeException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionPrivilegios( "Error al ejecutar " +
                                                                        "VerificarAccesoAPagina()" +
                                                                        " [Pagina Errónea]", ex );
            }
            catch ( SqlException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.ExceptionTGConBD( "TGE_00_001",
                                                                 "Error al ejecutar VerificarAccesoAPagina()",
                                                                 ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ExcepcionesTangerine.M2.ExcepcionPrivilegios( "Error al ejecutar " +
                                                                        "VerificarAccesoAPagina()", ex );
            }
            return resultado;
        }
    }
}
