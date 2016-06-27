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
using LogicaTangerine.Comandos.M8;
using LogicaTangerine.Comandos.M3;
using LogicaTangerine.Comandos.M5;
using LogicaTangerine.Comandos.M9;

namespace LogicaTangerine.Fabrica
{
    public class FabricaComandos
    {
        #region Modulo 1

        #endregion

        #region Modulo 2

            #region Comandos Usuarios

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoAgregarUsuario
            /// </summary>
            /// <param name="usuario">Es el objeto que se quiere agregar</param>
            /// <returns>Retorna una una instancia a ComandoAgregarUsuario</returns>
            public static Comando<Boolean> agregarUsuario( DominioTangerine.Entidad usuario )
            {
                return new Comandos.M2.ComandoAgregarUsuario( usuario );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoVerificarUsuario
            /// </summary>
            /// <param name="fichaEmpleado">Es la ficha del empleado</param>
            /// <returns>Retorna una una instancia a ComandoAgregarUsuario</returns>
            public static Comando<Boolean> verificarUsuario( int fichaEmpleado )
            {
                return new Comandos.M2.ComandoVerificarUsuario( fichaEmpleado );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoValidarUsuario
            /// </summary>
            /// <param name="usuario">Es el nombre del usuario</param>
            /// <returns>Retorna una instancia a ComandoValidarUsuario</returns>
            public static Comando<Boolean> validarUsuario( string usuario )
            {
                return new Comandos.M2.ComandoValidarUsuario( usuario );
            }
            
            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoObtenerCaracteres
            /// </summary>
            /// <param name="cadena">Es la cadena que se quiere obtener</param>
            /// <param name="cantidad">Es la cantidad de la cadena</param>
            /// <returns>Retorna una instancia a ComandoObtenerCaracteres</returns>
            public static Comando<String> obtenerCaracteres( String cadena , int cantidad )
            {
                return new Comandos.M2.ComandoObtenerCaracteres( cadena , cantidad );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoUsuarioDefault
            /// </summary>
            /// <param name="nombre">Es el nombre del usuario</param>
            /// <param name="apellido">Es el apellido del usuario</param>
            /// <returns>Retorna una instancia a ComandoUsuarioDefault</returns>
            public static Comando<String> crearUsuario( string nombre , string apellido )
            {
                return new Comandos.M2.ComandoCrearUsuarioDefault( nombre , apellido );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoObtenerUsuario
            /// </summary>
            /// <param name="theEmpleado">Es el numero del empleado</param>
            /// <returns>Retorna una instancia a ComandoUsuarioDefault</returns>
            public static Comando<DominioTangerine.Entidad> obtenerUsuario( int theEmpleado )
            {
                return new Comandos.M2.ComandoObtenerUsuario( theEmpleado );
            }
            
            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoConsultarPorID
            /// </summary>
            /// <param name="usuario">Es el objeto que se quiere consultar</param>
            /// <returns>Retorna una instancia a ComandoConsultarPorID</returns>
            public static Comando<DominioTangerine.Entidad> consultarUsuarioPorID( DominioTangerine.Entidad usuario )
            {
                return new Comandos.M2.ComandosDAOUsuario.ComandoConsultarPorID( usuario );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoModificarContrasena
            /// </summary>
            /// <param name="usuario">Es el objeto que se quiere modificar</param>
            /// <returns>Retorna una instancia a ComandoModificarContrasena</returns>
            public static Comando<Boolean> modificarContrasenaUsuario( DominioTangerine.Entidad usuario )
            {
                return new Comandos.M2.ComandosDAOUsuario.ComandoModificarContrasena( usuario );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoPrepararUsuario
            /// </summary>
            /// <param name="usuarioNombre">Es el nombre de usuario</param>
            /// <param name="contrasenaUsuario">Es la contraseña de usuario</param>
            /// <param name="rolUsuario">Es el rol</param>
            /// <param name="fichaEmpleado">Es la ficha del empleado</param>
            /// <returns>Retorna una instancia a ComandoPrepararUsuario</returns>
            public static Comando<Boolean> prepararUsuario( String usuarioNombre , String contrasenaUsuario , 
                                                            String rolUsuario , int fichaEmpleado)
            {
                return new Comandos.M2.ComandosDAOUsuario.ComandoPrepararUsuario( usuarioNombre , contrasenaUsuario , 
                                                                                  rolUsuario , fichaEmpleado );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoConsultaUsuarioLogin
            /// </summary>
            /// <param name="usuario">Es el objeto que se quiere consultar</param>
            /// <returns>Retorna una instancia a ComandoConsultarPorID</returns>
            public static Comando<DominioTangerine.Entidad> consultarUsuarioLogin( DominioTangerine.Entidad usuario )
            {
                return new Comandos.M2.ComandosDAOUsuario.ComandoConsultarDatosUsuarioLogin( usuario );
            }
            
            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoModificarUsuario
            /// </summary>
            /// <param name="fichaEmpleado">Es la ficha del empleado</param>
            /// <param name="nombreUsuario">Es el nombre del usuario</param>
            /// <returns>Retorna una instancia a ComandoModificarUsuario</returns>
            public static Comando<Boolean> modificarUsuario( int fichaEmpleado , string nombreUsuario )
            {
                return new Comandos.M2.ComandosDAOUsuario.ComandoModificarUsuario( fichaEmpleado , nombreUsuario );
            }
            
            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoConsultarUltimoIDEmpleado
            /// </summary>
            /// <returns>Retorna una instancia a ComandoConsultarUltimoIDEmpleado</returns>
            public static Comando<int> consultarIDUltimoEmpleado()
            {
                return new Comandos.M2.ComandosDAOUsuario.ComandoConsultarUltimoIDEmpleado();
            }

            #endregion

            #region Comandos Rol

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoModificarRolUsuario
            /// </summary>
            /// <param name="theUsuario">Es el objeto al cual se le quiere modificar el rol</param>
            /// <returns>Retorna una una instancia a ComandoAgregarUsuario</returns>
            public static Comando<Boolean> obtenerComandoModificarRolUsuario( DominioTangerine.Entidad theUsuario )
            {
                return new Comandos.M2.ComandosDAORol.ComandoModificarRolUsuario( theUsuario );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoObtenerRolUsuario
            /// </summary>
            /// <param name="codigoRol">Es el codigo del rol</param>
            /// <returns>Retorna una una instancia a ObtenerRolUsuario</returns>
            public static Comando<DominioTangerine.Entidad> obtenerComandoObtenerRolUsuario( int codigoRol )
            {
                return new Comandos.M2.ComandosDAORol.ComandoObtenerRolUsuario( codigoRol );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoObtenerOpciones
            /// </summary>
            /// <param name="nombreMenu">Es el nombre del menu</param>
            /// <param name="codigoRol">Es el codigo del rol</param>
            /// <returns>Retorna una una instancia a ObtenerOpciones</returns>
            public static Comando<DominioTangerine.Entidad> obtenerComandoObtenerOpciones( string nombreMenu , int codigoRol )
            {
                return new Comandos.M2.ComandosDAORol.ComandoObtenerOpciones( nombreMenu , codigoRol );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoObtenerRolUsuarioPorNombre
            /// </summary>
            /// <param name="nombreRol">Es el nombre del rol</param>
            /// <returns>Retorna una una instancia a ObtenerRolUsuarioPorNombre</returns>
            public static Comando<DominioTangerine.Entidad> obtenerComandoObtenerRolUsuarioPorNombre( string nombreRol )
            {
                return new Comandos.M2.ComandosDAORol.ComandoObtenerRolUsuarioPorNombre( nombreRol );
            }
            
            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoModificarRol
            /// </summary>
            /// <param name="elUsuario">Es el nombre del usuario</param>
            /// <param name="elRol">Es el nombre del rol</param>
            /// <returns>Retorna una una instancia a ComandoModificarRol</returns>
            public static Comando<Boolean> obtenerComandoModificarRol( string elUsuario , string elRol )
            {
                return new Comandos.M2.ComandosDAORol.ComandoModificarRol( elUsuario , elRol );
            }
            
            #endregion

            #region Comandos Especificos
            
            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoVerificarAccesoAOpciones
            /// </summary>
            /// <param name="nombreRol">Es el nombre del rol</param>
            /// <returns>Retorna una una instancia a ComandoVerificarAccesoAOpciones</returns>
            public static Comando<List<String>> obtenerComandoVerificarAccesoAOpciones( String nombreRol )
            {
                return new Comandos.M2.ComandosEspecificos.ComandoVerificarAccesoAOpciones( nombreRol );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoVerificarAccesoAPagina
            /// </summary>
            /// <param name="paginaAVerificar">Es la pagina a la cual se le quiere verificar el acceso</param>
            /// <param name="nombreRol">Es el nombre del rol</param>
            /// <returns>Retorna una una instancia a ComandoVerificarAccesoAPagina</returns>
            public static Comando<Boolean> obtenerComandoVerificarAccesoAPagina( String paginaAVerificar , String nombreRol)
            {
                return new Comandos.M2.ComandosEspecificos.ComandoVerificarAccesoAPagina( paginaAVerificar, nombreRol );
            }

            #endregion
        
        #endregion

        #region Modulo 3

        /// <summary>
        /// Método que crea una instancia de la clase ComandoListarTodosClientesPotenciales
        /// </summary>
        public static Comando<List<Entidad>> ObtenerComandoConsultarTodosClientePotencial()
        {
            return new ComandoListarTodosClientesPotenciales();
        }

        /// <summary>
        /// Método que crea una instancia de la clase ComandoConsultarClientePotencial
        /// </summary>
        /// <param name="cliente"></param>
        public static Comando<Entidad> ObtenerComandoConsultarClientePotencial(Entidad cliente)
        {
            return new ComandoConsultarClientePotencial(cliente);
        }

        /// <summary>
        /// Método que crea una instancia de la clase ComandoModificarClientePotencial
        /// </summary>
        /// <param name="cliente"></param>
        public static Comando<bool> ObtenerComandoModificarClientePotencial(Entidad cliente)
        {
            return new ComandoModificarClientePotencial(cliente);
        }

        /// <summary>
        /// Método que crea una instancia de la clase ComandoDesctivarClientePotencial
        /// </summary>
        /// <param name="cliente"></param>
        public static Comando<bool> ObtenerComandoDesactivarClientePotencial(Entidad cliente)
        {
            return new ComandoDesactivarClientePotencial(cliente);
        }

        /// <summary>
        /// Método que crea una instancia de la clase ComandoActivarClientePotencial
        /// </summary>
        /// <param name="cliente"></param>
        public static Comando<bool> ObtenerComandoActivarClientePotencial(Entidad cliente)
        {
            return new ComandoActivarClientePotencial(cliente);
        }

        /// <summary>
        /// Método que crea una instancia de la clase ComandoPromoverClientePotencial
        /// </summary>
        /// <param name="cliente"></param>
        public static Comando<bool> ObtenerComandoPromoverClientePotencial(Entidad cliente)
        {
            return new ComandoPromoverClientePotencial(cliente);
        }

        /// <summary>
        /// Método que crea una instancia de la clase ComandoAgregarClientePotencial
        /// </summary>
        /// <param name="cliente"></param>
        public static Comando<bool> ObtenerComandoAgregarClientePotencial(Entidad cliente)
        {
            return new ComandoAgregarClientePotencial(cliente);
        }

        /// <summary>
        /// Método que crea una instancia de la clase ComandoEliminarClientePotencial
        /// </summary>
        /// <param name="cliente"></param>
        public static Comando<bool> ObtenerComandoEliminarClientePotencial(Entidad cliente)
        {
            return new ComandoEliminarClientePotencial(cliente);
        }

        /// <summary>
        /// Método que crea una instancia de la clase ComandoConsultarUltimoIdClientePotencial
        /// </summary>
        public static Comando<int> ObtenerComandoUltimoIdClientePotencial()
        {
            return new ComandoUltimoIdClientePotencial();
        }

        /// <summary>
        /// Método que crea una instancia de la clase ComandoSeguimientoDeLlamadas
        /// </summary>
        /// <param name="cliente"></param>
        public static Comando<List<Entidad>> ObtenerComandoConsultarHistoricoLlamadas(Entidad cliente)
        {
            return new ComandoSeguimientoDeLlamadas(cliente);
        }

        /// <summary>
        /// Método que crea una instancia de la clase ComandoSeguimientoDeVisitas
        /// </summary>
        /// <param name="cliente"></param>
        public static Comando<List<Entidad>> ObtenerComandoConsultarHistoricoVisitas(Entidad cliente)
        {
            return new ComandoSeguimientoDeVisitas(cliente);
        }

        /// <summary>
        /// Método que crea una instancia de la clase ComandoAgregarSeguimiento
        /// </summary>
        /// <param name="cliente"></param>
        public static Comando<bool> ObtenerComandoAgregarSeguimiento(Entidad registroSeguimiento)
        {
            return new ComandoAgregarSeguimiento(registroSeguimiento);
        }

        /// <summary>
        /// Método que crea una instancia de la clase ComandoBuscarExistenciaDeCliente
        /// </summary>
        /// <param name="cliente"></param>
        public static Comando<Entidad> ComandoObtenerClientePorVerificar(Entidad cliente)
        {
            return new ComandoBuscarExistenciaDeCliente(cliente);
        }
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
        public static Comando<bool> CrearModificarLugar(Entidad parametro)
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

        /// <summary>
        /// metodo que crea comando para consultar los  luegares con su id y nombre
        /// </summary>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearConsultarLugarXNombreID()
        {
            return new ComandoConsultarLugarXNombreID();

        }

        #endregion

        #region Modulo 5
        /// <summary>
        /// Método para instancear el ComandoAgregarContacto
        /// </summary>
        /// <param name="contacto"></param>
        /// <returns></returns>
        public static Comando<bool> CrearComandoAgregarContacto( Entidad contacto ) 
        {
            return new ComandoAgregarContacto( contacto );
        }

        /// <summary>
        /// Método para instancear el ComandoAgregarContactoAProyecto
        /// </summary>
        /// <param name="contacto"></param>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        public static Comando<bool> CrearComandoAgregarContactoAProyecto( Entidad contacto, Entidad proyecto )
        {
            return new ComandoAgregarContactoAProyecto( contacto, proyecto );
        }

        /// <summary>
        /// Método para instancear el ComandoConsultarContacto
        /// </summary>
        /// <param name="contacto"></param>
        /// <returns></returns>
        public static Comando<Entidad> CrearComandoConsultarContacto( Entidad contacto ) 
        {
            return new ComandoConsultarContacto( contacto );
        }

        /// <summary>
        /// Método para instancear el ComandoConsultarContactosNoPertenecenAProyecto
        /// </summary>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearComandoConsultarContactosNoPertenecenAProyecto( Entidad proyecto ) 
        {
            return new ComandoConsultarContactosNoPertenecenAProyecto( proyecto );
        }

        /// <summary>
        /// Método para instancear el ComandoConsultarContactosPorCompania
        /// </summary>
        /// <param name="compania"></param>
        /// <param name="tipoCompania"></param>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearComandoConsultarContactosPorCompania( Entidad compania, int tipoCompania ) 
        {
            return new ComandoConsultarContactosPorCompania( compania, tipoCompania );
        }

        /// <summary>
        /// Método para instancear el ComandoConsultarContactosPorProyecto
        /// </summary>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearComandoConsultarContactosPorProyecto( Entidad proyecto )
        {
            return new ComandoConsultarContactosPorProyecto( proyecto );
        }

        /// <summary>
        /// Método para instancear el ComandoEliminarContacto
        /// </summary>
        /// <param name="contacto"></param>
        /// <returns></returns>
        public static Comando<bool> CrearComandoEliminarContacto( Entidad contacto ) 
        {
            return new ComandoEliminarContacto( contacto );
        }

        /// <summary>
        /// Método para instancear el ComandoEliminarContactoDeProyecto
        /// </summary>
        /// <param name="contacto"></param>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        public static Comando<bool> CrearComandoEliminarContactoDeProyecto( Entidad contacto, Entidad proyecto ) 
        {
            return new ComandoEliminarContactoDeProyecto( contacto, proyecto );
        }

        /// <summary>
        /// Método para instancear el ComandoModificarContacto
        /// </summary>
        /// <param name="contacto"></param>
        /// <returns></returns>
        public static Comando<bool> CrearComandoModificarContacto( Entidad contacto ) 
        {
            return new ComandoModificarContacto( contacto );
        }

        /// <summary>
        /// Método para instancear el ComandoConsultarTodosContactos
        /// </summary>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearComandoConsultarTodosContactos() 
        {
            return new ComandoConsultarTodosContactos();
        }
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

        public static Comando<int> ComandoConsultarNumeroPropuestas()
        {
            return new LogicaTangerine.Comandos.M6.ComandoConsultarNumeroPropuestas();
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

        public static Comando<int> ComandoConsultarNumeroRequerimientos()
        {
            return new LogicaTangerine.Comandos.M6.ComandoConsultarNumeroRequerimientos();
        }

        public static Comando<bool> ComandoEliminarRequerimiento(Entidad requerimiento)
        {
            return new LogicaTangerine.Comandos.M6.ComandoEliminarRequerimiento(requerimiento);
        }
        #endregion

        #endregion

        #region Modulo 7
        /// <summary>
        /// Método para instancear el ComandoConsultarTodosProyectos
        /// </summary>
        /// <returns>comando con un lista de entidades tipo proyecto</returns>
        public static Comando<List<Entidad>> ObtenerComandoConsultarTodosProyectos()
        {
            return new ComandoConsultarTodosProyectos();
        }

        /// <summary>
        /// Método para instancear el ComandoConsultarXIdProyecto
        /// </summary>
        /// <param name="proyecto">entidad de tipo proyecto sobre la cual se va a trabajar el comando</param>
        /// <returns>comando con una entidad tipo proyecto</returns>
        public static Comando<Entidad> ObtenerComandoConsultarXIdProyecto(Entidad proyecto)
        {
            return new ComandoConsultarXIdProyecto(proyecto);
        }

        /// <summary>
        /// Método para instancear el ComandoConsultarContactosXIdProyecto
        /// </summary>
        /// <param name="contacto">entidad de tipo contacto sobre la cual se va a trabajar el comando</param>
        /// <returns>comando con un lista de entidades tipo contacto</returns>
        public static Comando<List<Entidad>> ObtenerComandoConsultarContactosXIdProyecto(Entidad contacto)
        {
            return new ComandoConsultarContactosXIdProyecto(contacto);
        }

        /// <summary>
        /// Método para instancear el ComandoConsultarTodosGerentes
        /// </summary>
        /// <returns>comando con un lista de entidades tipo empleado</returns>
        public static Comando<List<Entidad>> ObtenerComandoConsultarTodosGerentes()
        {
            return new ComandoConsultarTodosGerentes();
        }

        /// <summary>
        /// Método para instancear el ComandoConsultarTodosProgramadores
        /// </summary>
        /// <returns>comando con un lista de entidades tipo empleado</returns>
        public static Comando<List<Entidad>> ObtenerComandoConsultarTodosProgramadores()
        {
            return new ComandoConsultarTodosProgramadores();
        }

        /// <summary>
        /// Método para instancear el ComandoConsultarXIdProyecto
        /// </summary>
        /// <param name="proyecto">entidad de tipo proyecto sobre la cual se va a trabajar el comando</param>
        /// <returns>comando con entidad tipo proyecto</returns>


        /// <summary>
        /// Método para instancear el ComandoConsultarXIdProyectoContacto
        /// </summary>
        /// <param name="proyecto">entidad de tipo proyecto sobre la cual se va a trabajar el comando</param>
        /// <returns>comando con entidad tipo proyecto</returns>
        public static Comando<Entidad> ObtenerComandoConsultarXIdProyectoContacto(Entidad comando)
        {
            return new ComandoConsultarXIdProyectoContacto(comando);
        }

        /// <summary>
        /// Método para instancear el ComandoConsultarContactoNombrePropuestaId
        /// </summary>
        /// <param name="proyecto">entidad de tipo proyecto sobre la cual se va a trabajar el comando</param>
        /// <returns>comando con entidad tipo proyecto</returns>
        public static Comando<Entidad> ObtenerComandoContactNombrePropuestaId(Entidad proyecto) 
        {
            return new ComandoConsultarContactoNombrePropuestaId(proyecto);
        }

        /// <summary>
        /// Método para crear una instancia del ComandoConsultarAcuerdoPagoMensual utilizado por M8
        /// para la generación de facturas
        /// </summary>
        /// <returns>Comando que se utiliza para consultar el acuerdo de pago de un proyecto</returns>
        public static Comando<List<Entidad>> ObtenerComandoConsultarAcuerdoPagoMensual()
        {
            return new ComandoConsultarAcuerdoPagoMensual();
        }

        /// <summary>
        /// Método para crear una instancia del ComandoCalcularPagoMensual utilizado por M8
        /// para la generación de facturas
        /// </summary>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        public static Comando<Double> ObtenerComandoCalcularPagoMesual(Entidad proyecto)
        {
            return new ComandoCalcularPagoMensual(proyecto);
        }

        /// <summary>
        /// Método para crear una instancia del ComandoGenerarCodigoProyecto
        /// </summary>
        /// <param name="propuesta">Entidad de tipo propuesta</param>
        /// <returns>Comando que se utiliza para generar el código de un proyecto</returns>
        public static Comando<String> ObtenerComandoGenerarCodigoProyecto(Entidad propuesta)
        {
            return new ComandoGenerarCodigoProyecto(propuesta);
        }

        /// <summary>
        /// Método para instancear el ComandoModificarProyecto
        /// </summary>
        /// <param name="_propuesta">lista de entidades de tipo propuesta sobre la cual se va a trabajar el comando</param>
        /// <param name="_proyecto">lista de entidades de tipo proyecto sobre la cual se va a trabajar el comando</param>
        /// <param name="_trabajadores">lista de entidades de tipo trabajadores sobre la cual se va a trabajar el comando</param>
        /// <returns>comando con bolean true o false</returns>
        public static Comando<Boolean> ObtenerComandoModificarProyecto(Entidad _propuesta, Entidad _proyecto, List<Entidad> _trabajadores)
        {
            return new ComandoModificarProyecto(_propuesta, _proyecto, _trabajadores);
        }

        /// <summary>
        /// Método para crear una instancia del ComandoAgregarProyecto
        /// </summary>
        /// <param name="proyecto">proyecto de tipo Entidad que será insertado en la base de datos</param>
        /// <returns>Comando para agregar un proyecto a la BD.</returns>
        public static Comando<bool> ObtenerComandoAgregarProyecto(Entidad proyecto)
        {
            return new ComandoAgregarProyecto(proyecto);
        }

        /// <summary>
        /// Método para crear una instancia del ComandoUltimoIdProyecto
        /// </summary>
        /// <returns>Id del último proyecto insertado en la BD.</returns>
        public static Comando<int> ObtenerComandoUltimoIdProyecto()
        {
            return new ComandoUltimoIdProyecto();
        }

        /// <summary>
        /// Método para crear una instancia del ComandoAgregarEmpleados.
        /// </summary>
        /// <param name="proyecto">Proyecto al cual se le agregaran los empleados.</param>
        /// <returns>True si ha sido exitoso el insertar.</returns>
        public static Comando<bool> ObtenerComandoAgregarEmpleados (Entidad proyecto)
        {
            return new ComandoAgregarEmpleados(proyecto);
        }

        /// <summary>
        /// Método para crear una instancia del ComandoAgregarContactos.
        /// </summary>
        /// <param name="proyecto">Proyecto al cual se le agregaran los contactos.</param>
        /// <returns>True si ha sido exitoso el insertar.</returns>
        public static Comando<bool> ObtenerComandoAgregarContactos(Entidad proyecto)
        {
            return new ComandoAgregarContactos(proyecto);
        }

        /// <summary>
        /// Método para crear una instancia del ComandoAgregarContactos.
        /// </summary>
        /// <param name="proyecto">Proyecto al cual se le agregaran los contactos.</param>
        /// <returns>True si ha sido exitoso el insertar.</returns>
        public static Comando<List<Entidad>> ObtenerComandoConsultarEmpleadosXIdProyecto(Entidad proyecto)
        {
            return new ComandoConsultarEmpleadosXIdProyecto(proyecto);
        }

        /// <summary>
        /// Método para crear una instancia del ComandoAgregarHistoricoGerente.
        /// </summary>
        /// <param name="proyecto">Proyecto al cual se le agregara el historico.</param>
        /// <returns>True si ha sido exitoso el insertar.</returns>
        public static Comando<bool> ObtenerComandoAgregarHistoricoGerente(Entidad proyecto, Entidad empleado)
        {
            return new ComandoAgregarHistoricoGerente(proyecto, empleado);
        }

        /// <summary>
        /// Método para crear una instancia del ComandoAgregarContactos.
        /// </summary>
        /// <param name="proyecto">Proyecto al cual se le agregaran los contactos.</param>
        /// <returns>True si ha sido exitoso el insertar.</returns>
        public static Comando<List<Entidad>> ObtenerComandoConsultarHistoricoGerente(Entidad proyecto)
        {
            return new ComandoConsultarHistoricoGerente(proyecto);
        }
        #endregion

        #region Modulo 8

        /// <summary>
        /// metodo para crear comando que permite agregar una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearAgregarFactura(Entidad factura)
        {
            Comando<bool> respuesta = new ComandoAgregarFactura(factura);
            return respuesta;
        }

        /// <summary>
        /// metodo para crear comando que permite anular una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearAnularFactura(Entidad factura)
        {
            Comando<bool> respuesta = new ComandoAnularFactura(factura);
            return respuesta;
        }

        /// <summary>
        /// metodo para crear comando que permite consultar monto restante de una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<double> CrearBuscarMontoRestanteFactura(Entidad factura)
        {
            Comando<double> respuesta = new ComandoBuscarMontoRestanteFactura(factura);
            return respuesta;
        }

        /// <summary>
        /// metodo para crear comando que permite consultar todas las facturas de una compania
        /// </summary>
        /// <param name="compania">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearConsultarFacturasCompania(Entidad compania)
        {
            Comando<List<Entidad>> respuesta = new ComandoConsultarFacturasCompania(compania);
            return respuesta;
        }

        /// <summary>
        /// metodo para crear comando que permite consultar todas las facturas pagadas de una compania
        /// </summary>
        /// <param name="compania">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearConsultarFacturasPagadasCompania(Entidad compania)
        {
            Comando<List<Entidad>> respuesta = new ComandoConsultarFacturasPagadasCompania(compania);
            return respuesta;
        }

        /// <summary>
        /// metodo para crear comando que permite consultar todas las facturas
        /// </summary>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearConsultarTodosFactura()
        {
            Comando<List<Entidad>> respuesta = new ComandoConsultarTodosFactura();
            return respuesta;
        }

        /// <summary>
        /// metodo para crear comando que permite consultar los datos de una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<Entidad> CrearConsultarXIdFactura(Entidad factura)
        {
            Comando<Entidad> respuesta = new ComandoConsultarXIdFactura(factura);
            return respuesta;
        }

        /// <summary>
        /// metodo para crear comando que permite eliminar una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearEliminarFactura(Entidad factura)
        {
            Comando<bool> respuesta = new ComandoEliminarFactura(factura);
            return respuesta;
        }

        /// <summary>
        /// metodo para crear comando que permite modificar una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearModificarFactura(Entidad factura)
        {
            Comando<bool> respuesta = new ComandoModificarFactura(factura);
            return respuesta;
        }

        /// <summary>
        /// metodo para crear comando que permite verificar si existe una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearSearchExistingBill(Entidad factura)
        {
            Comando<bool> respuesta = new ComandoSearchExistingBill(factura);
            return respuesta;
        }

        /// <summary>
        /// metodo para crear comando que permite mandar correos
        /// </summary>
        /// <param name="correo">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearComandoEnviarCorreoGmail(Entidad correo)
        {
            Comando<bool> respuesta = new ComandoEnviarCorreoGmail(correo);
            return respuesta;
        }

        #endregion

        #region Modulo 9

        /// <summary>
        /// Metodo para crear el comando que permite Agregar un pago
        /// </summary>
        /// <param name="entidad">Entidad con la informacion que sera agregada a la BD</param>
        /// <returns>Regresa el objeto ComandoAgregarPago para poder ejecutarlo</returns>
        public static Comandos.M9.ComandoAgregarPago cargarPago(Entidad entidad)
        {
            return new Comandos.M9.ComandoAgregarPago(entidad);
        }
        /// <summary>
        /// metodo para crear comando que permite consultar todos los pagos de una compania
        /// </summary>
        /// <param name="compania">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns>Regresa el objeto ComandoConsultarPagos para poder ejecutarlo</returns>
        public static Comando<List<Entidad>> ConsultarPagosCompania(Entidad compania)
        {
            return new ComandoConsultarPagos(compania);
        }

        /// <summary>
        /// Metodo para crear comando que permite eliminar un pago
        /// </summary>
        /// <param name="entidad">Entidad que se va a eliminar</param>
        /// <returns>Objeto ComandoEliminarPago</returns>
        public static Comando<Boolean> EliminarPago (Entidad entidad)
        {
            return new ComandoEliminarPago(entidad);
        }

        #endregion

        #region Modulo 10
        /// <summary>
        /// Metodo para instanciar el ComandoConsultarEmpleado
        /// </summary>
        /// <returns></returns>
        public static Comando<List<Entidad>> ConsultarEmpleados()
        {
            return new ComandoConsultarEmpleado();
        }

        /// <summary>
        /// Metodo para instanciar el ComandoConsultarPorId
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public static Comando<Entidad> ConsultarIdEmpleado(Entidad empleado)
        {
            return new ComandoConsultarPorId(empleado);
        }

        /// <summary>
        /// Metodo para instanciar el ComandoObtenerPais
        /// </summary>
        /// <returns></returns>
        public static Comando<List<Entidad>> ObtenerFabricaPaises()
        {
            return new ComandoObtenerPais();
        }

        /// <summary>
        /// Metodo para instanciar ComandoObtenerCargo
        /// </summary>
        /// <returns></returns>
        public static Comando<List<Entidad>> ObtenerFabricaCargo()
        {
            return new ComandoObtenerCargo();
        }

        /// <summary>
        /// Metodo para instanciar ComandoObtenerEstado
        /// </summary>
        /// <param name="Pais"></param>
        /// <returns></returns>
        public static Comando<List<Entidad>> ObtenerFabricaEstado(Entidad Pais)
        {
            return new ComandoObtenerEstado(Pais);
        }

        /// <summary>
        /// Metodo para instanciar ComandoAgregarEmpleado
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        public static Comando<bool> ComandoAgregarEmpleado(Entidad empleado)
        {
            return new LogicaTangerine.Comandos.M10.ComandoAgregarEmpleado(empleado);
        }


        public static Comando<bool> HabilitarEmpleado(Entidad estatus)
        {
            return new LogicaTangerine.Comandos.M10.ComandoHabilitarEmpleado(estatus);
        }

        public static Comando<Entidad> ConsultarUsuarioxCorreo (Entidad usuario)
        {
            return new LogicaTangerine.Comandos.M10.ComandoValidarUsuarioCorreo(usuario);
        }

        /// <summary>
        /// metodo para crear comando que envia un correo
        /// </summary>
        /// <param name="correo">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> EnviarCorreoG(Entidad correo)
        {
            return new ComandoEnviarCorreoGmail(correo);
        }

        #endregion
    }
}
