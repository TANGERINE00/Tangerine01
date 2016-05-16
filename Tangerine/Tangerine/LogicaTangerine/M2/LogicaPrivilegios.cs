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
    }
}
