using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using LogicaTangerine.Comandos.M7;
using LogicaTangerine.Comandos.M10;

namespace LogicaTangerine.Fabrica
{
    public class FabricaComandos
    {
        #region Modulo 1

        #endregion

        #region Modulo 2

        /// <summary>
        /// Método utilizado para devolver una instancia de la clase ComandoAgregarUsuario
        /// </summary>
        /// <returns>Retorna una instancia a ComandoAgregarUsuario</returns>
        public static Comandos.M2.ComandoAgregarUsuario agregarUsuario()
        {
            return new Comandos.M2.ComandoAgregarUsuario();
        }

        /// <summary>
        /// Método utilizado para devolver una instancia del ComandoUsuarioDefault
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <returns>Retorna una instancia a ComandoUsuarioDefault</returns>
        public static Comandos.M2.ComandoCrearUsuarioDefault crearUsuario(String nombre, String apellido)
        {
            return new Comandos.M2.ComandoCrearUsuarioDefault(nombre, apellido);
        }
        
        /// <summary>
        /// Método utilizado para devolver una instancia del ComandoValidarUsuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Retorna una instancia a ComandoValidarUsuario</returns>
        public static Comandos.M2.ComandoValidarUsuario validarUsuario(String usuario)
        {
            return new Comandos.M2.ComandoValidarUsuario(usuario);
        }

        #endregion

        #region Modulo 3

        #endregion

        #region Modulo 4

        #endregion

        #region Modulo 5

        #endregion

        #region Modulo 6

        #endregion

        #region Modulo 7
        public static Comando<List<Entidad>> ObtenerComandoConsultarTodosProyectos()
        {
            return new ComandoConsultarTodosProyectos();
        }

        public static Comando<Entidad> ObtenerComandoConsultarXIdProyecto(Entidad proyecto)
        {
            return new ComandoConsultarXIdProyecto(proyecto);
        }
        #endregion

        #region Modulo 8

        #endregion

        #region Modulo 9

        public static Comandos.M9.ComandoCargarPago cargarPago()
        {
            return new Comandos.M9.ComandoCargarPago();
        }

        #endregion

        #region Modulo 10
         public static Comandos.M10.ComandoAgregarEmpleado agregarEmpleado()
        {
            return new Comandos.M10.ComandoAgregarEmpleado();
        }
        #endregion
    }
}
