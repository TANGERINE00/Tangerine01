using DatosTangerine.M2;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.M2
{
    public class LogicaModificarRol
    {
        public static bool ModificarRol( Usuario usuario )
        {
            bool resultado = false;

            resultado = BDUsuario.ModificarRolUsuario( usuario );

            return resultado;
        }

        public static void prueba() 
        {
            Rol theRol = new Rol("Gerente");
            Usuario theUser = new Usuario( "userTest", "testapp1", "Activo", theRol, 0, DateTime.Now );

            bool resultado = BDUsuario.AgregarUsuario(theUser);

            System.Diagnostics.Debug.WriteLine( "Resultado = " + resultado.ToString() );

            theUser = BDUsuario.ObtenerDatoUsuario( theUser );

            theUser.Rol.imprimirListaDeMenus();

            foreach(Menu m in theUser.Rol.Menus)
            {
                m.imprimirListaDeOpciones();
            }

            
        }
    }
}
