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
            /// <param name="usuario"></param>
            /// <returns>Retorna una una instancia a ComandoAgregarUsuario</returns>
            public static Comando<Boolean> agregarUsuario( DominioTangerine.Entidad usuario )
            {
                return new Comandos.M2.ComandoAgregarUsuario( usuario );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoVerificarUsuario
            /// </summary>
            /// <param name="fichaEmpleado"></param>
            /// <returns>Retorna una una instancia a ComandoAgregarUsuario</returns>
            public static Comando<Boolean> verificarUsuario( int fichaEmpleado )
            {
                return new Comandos.M2.ComandoVerificarUsuario( fichaEmpleado );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoValidarUsuario
            /// </summary>
            /// <param name="usuario"></param>
            /// <returns>Retorna una instancia a ComandoValidarUsuario</returns>
            public static Comando<Boolean> validarUsuario( string usuario )
            {
                return new Comandos.M2.ComandoValidarUsuario( usuario );
            }
            
            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoObtenerCaracteres
            /// </summary>
            /// <param name="cadena"></param>
            /// <param name="cantidad"></param>
            /// <returns>Retorna una instancia a ComandoObtenerCaracteres</returns>
            public static Comando<String> obtenerCaracteres( String cadena , int cantidad )
            {
                return new Comandos.M2.ComandoObtenerCaracteres( cadena , cantidad );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoUsuarioDefault
            /// </summary>
            /// <param name="nombre"></param>
            /// <param name="apellido"></param>
            /// <returns>Retorna una instancia a ComandoUsuarioDefault</returns>
            public static Comando<String> crearUsuario( string nombre , string apellido )
            {
                return new Comandos.M2.ComandoCrearUsuarioDefault( nombre , apellido );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoObtenerUsuario
            /// </summary>
            /// <param name="theEmpleado"></param>
            /// <returns>Retorna una instancia a ComandoUsuarioDefault</returns>
            public static Comando<DominioTangerine.Entidad> obtenerUsuario( int theEmpleado )
            {
                return new Comandos.M2.ComandoObtenerUsuario( theEmpleado );
            }
            
            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoConsultarPorID
            /// </summary>
            /// <param name="usuario"></param>
            /// <returns>Retorna una instancia a ComandoConsultarPorID</returns>
            public static Comando<DominioTangerine.Entidad> consultarUsuarioPorID( DominioTangerine.Entidad usuario )
            {
                return new Comandos.M2.ComandosDAOUsuario.ComandoConsultarPorID( usuario );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoModificarContrasena
            /// </summary>
            /// <param name="usuario"></param>
            /// <returns>Retorna una instancia a ComandoModificarContrasena</returns>
            public static Comando<Boolean> modificarContrasenaUsuario( DominioTangerine.Entidad usuario )
            {
                return new Comandos.M2.ComandosDAOUsuario.ComandoModificarContrasena( usuario );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia del ComandoPrepararUsuario
            /// </summary>
            /// <param name="usuarioNombre"></param>
            /// <param name="contrasenaUsuario"></param>
            /// <param name="rolUsuario"></param>
            /// <param name="fichaEmpleado"></param>
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
            /// <param name="usuario"></param>
            /// <returns>Retorna una instancia a ComandoConsultarPorID</returns>
            public static Comando<DominioTangerine.Entidad> consultarUsuarioLogin(DominioTangerine.Entidad usuario)
            {
                return new Comandos.M2.ComandosDAOUsuario.ComandoConsultarDatosUsuarioLogin(usuario);
            }

            #endregion

            #region Comandos Rol

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoModificarRolUsuario
            /// </summary>
            /// <param name="theUsuario"></param>
            /// <returns>Retorna una una instancia a ComandoAgregarUsuario</returns>
            public static Comando<Boolean> obtenerComandoModificarRolUsuario( DominioTangerine.Entidad theUsuario )
            {
                return new Comandos.M2.ComandosDAORol.ComandoModificarRolUsuario( theUsuario );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoObtenerRolUsuario
            /// </summary>
            /// <param name="usuario"></param>
            /// <returns>Retorna una una instancia a ObtenerRolUsuario</returns>
            public static Comando<DominioTangerine.Entidad> obtenerComandoObtenerRolUsuario( int codigoRol )
            {
                return new Comandos.M2.ComandosDAORol.ComandoObtenerRolUsuario( codigoRol );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoObtenerOpciones
            /// </summary>
            /// <param name="nombreMenu"></param>
            /// <param name="codigoRol"></param>
            /// <returns>Retorna una una instancia a ObtenerOpciones</returns>
            public static Comando<DominioTangerine.Entidad> obtenerComandoObtenerOpciones( string nombreMenu , int codigoRol )
            {
                return new Comandos.M2.ComandosDAORol.ComandoObtenerOpciones( nombreMenu , codigoRol );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoObtenerRolUsuarioPorNombre
            /// </summary>
            /// <param name="nombreMenu"></param>
            /// <param name="codigoRol"></param>
            /// <returns>Retorna una una instancia a ObtenerRolUsuarioPorNombre</returns>
            public static Comando<DominioTangerine.Entidad> obtenerComandoObtenerRolUsuarioPorNombre(string nombreRol)
            {
                return new Comandos.M2.ComandosDAORol.ComandoObtenerRolUsuarioPorNombre( nombreRol );
            }
            
            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoModificarRol
            /// </summary>
            /// <param name="elUsuario"></param>
            /// <param name="elRol"></param>
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
            /// <param name="nombreRol"></param>
            /// <returns>Retorna una una instancia a ComandoVerificarAccesoAOpciones</returns>
            public static Comando<List<String>> obtenerComandoVerificarAccesoAOpciones( String nombreRol )
            {
                return new Comandos.M2.ComandosEspecificos.ComandoVerificarAccesoAOpciones( nombreRol );
            }

            /// <summary>
            /// Método utilizado para devolver una instancia de la clase ComandoVerificarAccesoAPagina
            /// </summary>
            /// <param name="paginaAVerificar"></param>
            /// <param name="nombreRol"></param>
            /// <returns>Retorna una una instancia a ComandoVerificarAccesoAPagina</returns>
            public static Comando<Boolean> obtenerComandoVerificarAccesoAPagina( String paginaAVerificar , String nombreRol)
            {
                return new Comandos.M2.ComandosEspecificos.ComandoVerificarAccesoAPagina( paginaAVerificar, nombreRol );
            }

            #endregion
        
        #endregion

        #region Modulo 3
        public static Comando<List<Entidad>> ObtenerComandoConsultarTodosClientePotencial()
        {
            return new ComandoListarTodosClientesPotenciales();
        }

        public static Comando<Entidad> ObtenerComandoConsultarClientePotencial(Entidad cliente)
        {
            return new ComandoConsultarClientePotencial(cliente);
        }

        public static Comando<bool> ObtenerComandoModificarClientePotencial(Entidad cliente)
        {
            return new ComandoModificarClientePotencial(cliente);
        }

        public static Comando<bool> ObtenerComandoDesactivarClientePotencial(Entidad cliente)
        {
            return new ComandoDesactivarClientePotencial(cliente);
        }

        public static Comando<bool> ObtenerComandoActivarClientePotencial(Entidad cliente)
        {
            return new ComandoActivarClientePotencial(cliente);
        }

        public static Comando<bool> ObtenerComandoPromoverClientePotencial(Entidad cliente)
        {
            return new ComandoPromoverClientePotencial(cliente);
        }

        public static Comando<bool> ObtenerComandoAgregarClientePotencial(Entidad cliente)
        {
            return new ComandoAgregarClientePotencial(cliente);
        }

        public static Comando<bool> ObtenerComandoEliminarClientePotencial(Entidad cliente)
        {
            return new ComandoEliminarClientePotencial(cliente);
        }

        public static Comando<int> ObtenerComandoUltimoIdClientePotencial()
        {
            return new ComandoUltimoIdClientePotencial();
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
        #endregion

        #region Modulo 8

        /// <summary>
        /// metodo para crear comando que permite agregar una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearAgregarFactura(Entidad factura)
        {
            return new ComandoAgregarFactura(factura);
        }

        /// <summary>
        /// metodo para crear comando que permite anular una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearAnularFactura(Entidad factura)
        {
            return new ComandoAnularFactura(factura);
        }

        /// <summary>
        /// metodo para crear comando que permite consultar monto restante de una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<double> CrearBuscarMontoRestanteFactura(Entidad factura)
        {
            return new ComandoBuscarMontoRestanteFactura(factura);
        }

        /// <summary>
        /// metodo para crear comando que permite consultar todas las facturas de una compania
        /// </summary>
        /// <param name="compania">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearConsultarFacturasCompania(Entidad compania)
        {
            return new ComandoConsultarFacturasCompania(compania);
        }

        /// <summary>
        /// metodo para crear comando que permite consultar todas las facturas pagadas de una compania
        /// </summary>
        /// <param name="compania">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearConsultarFacturasPagadasCompania(Entidad compania)
        {
            return new ComandoConsultarFacturasPagadasCompania(compania);
        }

        /// <summary>
        /// metodo para crear comando que permite consultar todas las facturas
        /// </summary>
        /// <returns></returns>
        public static Comando<List<Entidad>> CrearConsultarTodosFactura()
        {
            return new ComandoConsultarTodosFactura();
        }

        /// <summary>
        /// metodo para crear comando que permite consultar los datos de una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<Entidad> CrearConsultarXIdFactura(Entidad factura)
        {
            return new ComandoConsultarXIdFactura(factura);
        }

        /// <summary>
        /// metodo para crear comando que permite eliminar una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearEliminarFactura(Entidad factura)
        {
            return new ComandoEliminarFactura(factura);
        }

        /// <summary>
        /// metodo para crear comando que permite modificar una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearModificarFactura(Entidad factura)
        {
            return new ComandoModificarFactura(factura);
        }

        /// <summary>
        /// metodo para crear comando que permite verificar si existe una factura
        /// </summary>
        /// <param name="factura">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<bool> CrearSearchExistingBill(Entidad factura)
        {
            return new ComandoSearchExistingBill(factura);
        }

        #endregion

        #region Modulo 9

        public static Comandos.M9.ComandoAgregarPago cargarPago(Entidad entidad)
        {
            return new Comandos.M9.ComandoAgregarPago(entidad);
        }
        /// <summary>
        /// metodo para crear comando que permite consultar todos los pagos de una compania
        /// </summary>
        /// <param name="compania">entidad sobre la cual se va a trabajar el comando</param>
        /// <returns></returns>
        public static Comando<List<Entidad>> ConsultarPagosCompania(Entidad compania)
        {
            return new ComandoConsultarPagos(compania);
        }

        #endregion

        #region Modulo 10
        public static Comando<List<Entidad>> ConsultarEmpleados()
        {
            return new ComandoConsultarEmpleado();
        }


        public static Comando<Entidad> ConsultarIdEmpleado(Entidad empleado)
        {
            return new ComandoConsultarPorId(empleado);
        }

        public static Comando<List<Entidad>> ObtenerFabricaPaises()
        {
            return new ComandoObtenerPais();
        }
        public static Comando<List<Entidad>> ObtenerFabricaCargo()
        {
            return new ComandoObtenerCargo();
        }
        public static Comando<List<Entidad>> ObtenerFabricaEstado(Entidad Pais)
        {
            return new ComandoObtenerEstado(Pais);
        }

        public static Comando<bool> HabilitarEmpleado(Entidad estatus)
        {
            return new LogicaTangerine.Comandos.M10.ComandoHabilitarEmpleado(estatus);
        }

        #endregion
    }
}
