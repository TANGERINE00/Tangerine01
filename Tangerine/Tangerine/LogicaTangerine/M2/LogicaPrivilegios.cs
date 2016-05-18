using DominioTangerine;
using System;
using System.Collections.Generic;
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
        /// <returns></returns>
        public static List<string> VerificarAccesoAOpciones() 
        {
            List<string> lista = new List<string>();

            foreach ( DominioTangerine.Menu m in Util._theGlobalUser.Rol.Menus )
                {
                    foreach ( Opcion o in m.Opciones )
                    {
                        lista.Add( o.Nombre );
                    }
                }

            return lista;
        }

        /// <summary>
        /// Método que verifica que el usuario tiene la permisología para acceder a la página especificada
        /// </summary>
        /// <param name="paginaAVerificar"></param>
        /// <returns></returns>
        public static bool VerificarAccesoAPagina(string paginaAVerificar)
        {
            bool resultado = false;

            string[] paginaSeparada = paginaAVerificar.Split('/');
            int tamanioPagina = paginaSeparada.Length;

            foreach ( DominioTangerine.Menu m in Util._theGlobalUser.Rol.Menus )
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

            return resultado;
        }
    }
}
