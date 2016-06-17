using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using LogicaTangerine.Comandos;
using LogicaTangerine.Comandos.M7;
using LogicaTangerine.Comandos.M4;
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

        /// <summary>
        /// metodo para crear comando que permite agregar una compania
        /// </summary>
        /// <param name="compania">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearAgregarCompania(Entidad compania) 
        {
            return new ComandoAgregarCompania(compania);
        
        }

        /// <summary>
        /// metodo para crear comando que permite consultar una compania
        /// </summary>
        /// <param name="compania">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<Entidad> CrearConsultarCompania(Entidad compania)
        {
            return new ComandoConsultarCompania(compania);

        }
        /// <summary>
        /// metodo para crear comando que permite consultar todas companias
        /// </summary>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearConsultarTodasCompania()
        {
            return new ComandoConsultarTodasCompanias();

        }

        /// <summary>
        /// metodo para crear comando que permite consultar todas las companias activas
        /// </summary>
        /// <param name="compania">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearConsultarCompaniasActivas()
        {
            return new comandoCosultarCompaniasActivas();

        }

        /// <summary>
        /// metodo para crear comando que permite Deshabilitar una compania
        /// </summary>
        /// <param name="compania"></param>
        /// <returns></returns>
        public static Comando<bool> CrearDeshabilitarCompania(Entidad compania)
        {
            return new ComandoDeshabilitarCompania(compania);

        }

        /// <summary>
        /// metodo para crear comando que permite modificar una compania
        /// </summary>
        /// <param name="compania">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearModificarCompania(Entidad compania)
        {
            return new ComandoModificarCompania(compania);

        }

        /// <summary>
        /// metodo para crear comando que permite habilitar una compania
        /// </summary>
        /// <param name="compania"></param>
        /// <returns></returns>
        public static Comando<bool> CrearHabilitarCompania(Entidad compania)
        {
            return new ComandoHabilitarCompania(compania);

        }

       /// <summary>
       /// metodo que crea comando para consultar los luegare
       /// </summary>
       /// <returns></returns>
        public static Comando<List<Entidad>> CrearConsultarLugar()
        {
            return new ComandoConsultarTodosLugares();

        }

        /// <summary>
        /// metodo que crea comando para modificar los luegare
        /// </summary>
        /// <returns></returns>
        public static Comando<bool> CrearConsultarLugar(Entidad parametro)
        {
            return new ComandoModificarLugar(parametro);

        }

        


         /// <summary>
        /// metodo que crea comando para consultar un  luegar
        /// </summary>
        /// <returns></returns>
        public static Comando<Entidad> CrearConsultarLugarXID(Entidad parametro)
        {
            return new ComandoConsultarLugarXID(parametro);

        }

        /// <summary>
        /// metodo que crea comando para consultar un  luegar
        /// </summary>
        /// <returns></returns>
        public static Comando<bool> CrearAgregarLugar(Entidad parametro)
        {
            return new ComandoAgregarLugar(parametro);

        }

        #endregion

        #region Modulo 5

        #endregion

        #region Modulo 6

        #region Instancia Propuesta
        public static Comando<bool> ComandoAgregarPropuesta(Entidad propuesta)
        {
            return new LogicaTangerine.Comandos.M6.ComandoAgregarPropuesta(propuesta);
        }


        public static Comando<bool> ComandoBorrarPropuesta(Entidad propuesta)
        {
            return new LogicaTangerine.Comandos.M6.ComandoBorrarPropuesta(propuesta);
        }


        public static Comando<List<Entidad>> ComandoConsultarPropuestaXProyecto()
        {
            return new LogicaTangerine.Comandos.M6.ComandoConsultarPropuestaXProyecto();
        }


        public static Comando<List<Entidad>> ComandoConsultarTodosPropuesta()
        {
            return new LogicaTangerine.Comandos.M6.ComandoConsultarTodosPropuesta();
        }


        public static Comando<Entidad> ComandoConsultarXIdPropuesta(Entidad propuesta)
        {
            return new LogicaTangerine.Comandos.M6.ComandoConsultarXIdPropuesta(propuesta);
        }


        public static Comando<bool> ComandoModificarPropuesta(Entidad propuesta)
        {
            return new LogicaTangerine.Comandos.M6.ComandoModificarPropuesta(propuesta);
        }
        #endregion

        #region Instancia Requerimiento
        public static Comando<bool> ComandoAgregarRequerimiento(Entidad requerimiento)
        {
            return new LogicaTangerine.Comandos.M6.ComandoAgregarRequerimiento(requerimiento);
        }


        public static Comando<List<Entidad>> ComandoConsultarRequerimientoXPropuesta(Entidad propuesta)
        {
            return new LogicaTangerine.Comandos.M6.ComandoConsultarRequerimientoXPropuesta(propuesta);
        }


        public static Comando<List<Entidad>> ComandoConsultarTodosRequerimiento()
        {
            return new LogicaTangerine.Comandos.M6.ComandoConsultarTodosRequerimiento();
        }


        public static Comando<Entidad> ComandoConsultarXIdRequerimiento(Entidad requerimiento)
        {
            return new LogicaTangerine.Comandos.M6.ComandoConsultarXIdRequerimiento(requerimiento);
        }


        public static Comando<bool> ComandoModificarRequerimiento(Entidad requerimiento)
        {
            return new LogicaTangerine.Comandos.M6.ComandoModificarRequerimiento(requerimiento);
        }
        #endregion

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

        public static Comando<List<Entidad>> ObtenerComandoConsultarContactosXIdProyecto(Entidad contacto)
        {
            return new ComandoConsultarContactosXIdProyecto(contacto);
        }

        public static Comando<List<Entidad>> ObtenerComandoConsultarTodosGerentes()
        {
            return new ComandoConsultarTodosGerentes();
        }

        public static Comando<List<Entidad>> ObtenerComandoConsultarTodosProgramadores()
        {
            return new ComandoConsultarTodosProgramadores();
        }

        public static Comando<Entidad> ObtenerComandoConsultarXIdproyecto(Entidad proyecto)
        {
            return new ComandoConsultarXIdProyecto(proyecto);
        }

        public static Comando<Entidad> ObtenerComandoConsultarXIdProyectoContacto(Entidad comando)
        {
            return new ComandoConsultarXIdProyectoContacto(comando);
        }

        public static Comando<Entidad> ObtenerComandoContactNombrePropuestaId(Entidad proyecto) 
        {
            return new ComandoConsultarContactoNombrePropuestaId(proyecto);
        }

        #endregion

        #region Modulo 8

        #endregion

        #region Modulo 9

        public static Comandos.M9.ComandoAgregarPago cargarPago(Entidad entidad)
        {
            return new Comandos.M9.ComandoAgregarPago(entidad);
        }

        #endregion

        #region Modulo 10
        public static Comando<List<Entidad>> ConsultarEmpleados(Entidad Empleado)
        {
            return new ComandoConsultarEmpleado(Empleado);
        }
        #endregion
    }
}
