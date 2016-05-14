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
        public static void prueba() 
        {
            Rol theRol = new Rol("Gerente");
            Usuario theUser = new Usuario("userTest", "testapp1", "Activo", theRol, 0, DateTime.Now);

            bool resultado = BDUsuario.AgregarUsuario(theUser);

            System.Diagnostics.Debug.WriteLine("Resultado = " + resultado.ToString());
        }
    }
}
