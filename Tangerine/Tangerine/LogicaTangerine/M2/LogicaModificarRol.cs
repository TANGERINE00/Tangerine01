using DatosTangerine.M10;
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
        public static bool ModificarRol(string elusuario, string elrol)
        {
            bool resultado = false;
            Rol rol = new Rol(elrol);
            Usuario usuario = new Usuario(elusuario, rol);

            resultado = BDUsuario.ModificarRolUsuario(usuario);

            return resultado;
        }



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
        public static Usuario ObtenerUsuario(Empleado empleado)
        {

            Usuario usuario = BDUsuario.ObtenerUsuarioDeEmpleado(empleado);

            return usuario;
        }
        public static void prueba()
        {
            Rol theRol = new Rol("Gerente");
            Usuario theUser = new Usuario("userTest", "testapp1", "Activo", theRol, 0, DateTime.Now);

            bool resultado = BDUsuario.AgregarUsuario(theUser);

            System.Diagnostics.Debug.WriteLine("Resultado = " + resultado.ToString());

            theUser = BDUsuario.ObtenerDatoUsuario(theUser);

            theUser.Rol.imprimirListaDeMenus();

            foreach (Menu m in theUser.Rol.Menus)
            {
                m.imprimirListaDeOpciones();
            }
        }
    }
}
