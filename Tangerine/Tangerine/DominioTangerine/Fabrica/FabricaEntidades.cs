using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DominioTangerine.Entidades.M2;
using DominioTangerine.Entidades.M4;
using DominioTangerine.Entidades.M5;
using DominioTangerine.Entidades.M10;
using DominioTangerine.Entidades.M8;


namespace DominioTangerine.Fabrica
{
    public class FabricaEntidades
    {
        #region Modulo 1
       
        public Entidad ObtenerCuenta()
        {
            return new Entidades.M1.Cuenta();
        }
        public Entidad ObtenerCuenta_M1(String elNombreUsuario, String laContrasena,
            List<Entidades.M2.RolM2> listaRoles)
        {
            return new Entidades.M1.Cuenta(elNombreUsuario, laContrasena, listaRoles);
        }
        #endregion

        #region Modulo 2

            #region Métodos para instancias de UsuarioM2

            /// <summary>
            /// Se crea la instancia sin atributos
            /// </summary>
            /// <returns>Retorna una instancia de UsuarioM2 sin atributos</returns>
            static public Entidad crearUsuarioVacio()
            {
                return new UsuarioM2();
            }

            /// <summary>
            /// Se crea la instancia con usuario y contraseña
            /// </summary>
            /// <param name="usuario"></param>
            /// <param name="contrasena"></param>
            /// <returns>Retorna una instancia de Usuario con usuario y contraseña</returns>
            static public Entidad crearUsuarioConUsuarioYContrasena( string usuario , string contrasena )
            {
                return new UsuarioM2( usuario , contrasena );
            }

            /// <summary>
            /// Se crea la instancia con usuario y rol
            /// </summary>
            /// <param name="usuario"></param>
            /// <param name="rol"></param>
            /// <returns>Retorna una instancia de Usuario con usuario y rol</returns>
            static public Entidad crearUsuarioConUsuarioRol( string usuario , RolM2 rol )
            {
                return new UsuarioM2( usuario , rol );
            }

            /// <summary>
            /// Se crea la instancia con usuario, contrasena y activo
            /// </summary>
            /// <param name="usuario"></param>
            /// <param name="contrasena"></param>
            /// <param name="activo"></param>
            /// <returns>Retorna una instancia de Usuario con usuario, contraseña y activo</returns>
            static public Entidad crearUsuarioConUsuarioContrasenaActivo( string usuario , string contrasena , string activo )
            {
                return new UsuarioM2( usuario , contrasena , activo );
            }

            /// <summary>
            /// Se crea la instancia con usuario, contrasena, activo y Rol
            /// </summary>
            /// <param name="usuario"></param>
            /// <param name="contrasena"></param>
            /// <param name="activo"></param>
            /// <param name="rol"></param>
            /// <returns>Retorna una instancia de Usuario con usuario, contraseña, activo y rol</returns>
            static public Entidad crearUsuarioConUsuarioContrasenaActivoRol( string usuario , string contrasena , string activo ,
                                                                             RolM2 rol )
            {
                return new UsuarioM2( usuario , contrasena , activo , rol );
            }

            /// <summary>
            /// Se crea la instancia del usuario con todos sus atributos
            /// </summary>
            /// <param name="inputUsuario"></param>
            /// <param name="inputContrasena"></param>
            /// <param name="inputFechaCreacion"></param>
            /// <param name="inputActivo"></param>
            /// <param name="inputRol"></param>
            /// <param name="inputfFichaEmpleado"></param>
            /// <returns>Retorna una instancia de Usuario con todos los atributos</returns>
            static public Entidad crearUsuarioCompleto( string inputUsuario , string inputContrasena , DateTime inputFechaCreacion , 
                                                        string inputActivo , RolM2 inputRol , int inputfFichaEmpleado )
            {
                return new UsuarioM2( inputUsuario , inputContrasena , inputFechaCreacion , inputActivo , inputRol ,
                                      inputfFichaEmpleado );
            }

            /// <summary>
            /// Se crea la instancia del usuario con todos sus atributos y el id
            /// </summary>
            /// <param name="inputID"></param>
            /// <param name="inputUsuario"></param>
            /// <param name="inputContrasena"></param>
            /// <param name="inputFechaCreacion"></param>
            /// <param name="inputActivo"></param>
            /// <param name="inputRol"></param>
            /// <param name="inputfFichaEmpleado"></param>
            /// <returns>Retorna una instancia de Usuario con todos los atributos y el id</returns>
            static public Entidad crearUsuarioCompletoConID( int inputID , string inputUsuario , string inputContrasena , 
                                                             DateTime inputFechaCreacion , string inputActivo , RolM2 inputRol , 
                                                             int inputfFichaEmpleado )
            {
                return new UsuarioM2( inputID , inputUsuario , inputContrasena , inputFechaCreacion , inputActivo , 
                                      inputRol , inputfFichaEmpleado );
            }
               
            #endregion

            #region Métodos para instancias de RolM2

            /// <summary>
            /// Se crea la instancia sin atributos de RolM2
            /// </summary>
            /// <returns>Devuelve la instancia de la clase RolM2 sin atributos</returns>
            static public Entidad crearRolVacio()
            {
                return new RolM2();
            }

            static public Entidad crearRolConID( int ID )
            {
                return new RolM2( ID );
            }

            /// <summary>
            /// Se crea la instancia de RolM2 con nombre
            /// </summary>
            /// <param name="nombre"></param>
            /// <returns>Devuelve la instancia de la clase RolM2 con el nombre</returns>
            static public Entidad crearRolNombre( string nombre )
            {
                return new RolM2( nombre );
            }

            /// <summary>
            /// Se crea la instancia de RolM2 con todos sus atributos
            /// </summary>
            /// <param name="nombre"></param>
            /// <param name="menu"></param>
            /// <returns>Devuelve la instancia de la clase RolM2 con el nombre y el menu</returns>
            static public Entidad crearRolCompleto( string nombre , ListaGenericaM2<MenuM2> menu )
            {
                return new RolM2( nombre , menu );
            }

            #endregion

            #region Métodos para instancias de OpcionM2
            
            /// <summary>
            /// Se crea la instancia sin atributos de OpcionM2
            /// </summary>
            /// <returns>Devuelve la instancia de la clase OpcionM2 sin atributos</returns>
            static public Entidad crearOpcionVacia()
            {
                return new OpcionM2();
            }
            
            /// <summary>
            /// Se crea la instancia de OpcionM2 con todos sus atributos
            /// </summary>
            /// <param name="nombre"></param>
            /// <param name="url"></param>
            /// <returns>Devuelve la instancia de la clase OpcionM2 con el nombre y el url</returns>
            static public Entidad crearOpcionCompleta( string nombre , string url )
            {
                return new OpcionM2( nombre , url );
            }

            #endregion

            #region Métodos para instancias de MenuM2
            
            /// <summary>
            /// Se crea la instancia sin atributos de MenuM2
            /// </summary>
            /// <returns>Devuelve la instancia de la clase MenuM2 sin atributos</returns>
            static public Entidad crearMenuVacio()
            {
                return new MenuM2();
            }
            
            /// <summary>
            /// Se crea la instancia de MenuM2 con nombre
            /// </summary>
            /// <param name="nombre"></param>
            /// <returns>Devuelve la instancia de la clase MenuM2 con el nombre</returns>
            static public Entidad crearMenuNombre( string nombre )
            {
                return new MenuM2( nombre );
            }
            
            /// <summary>
            /// Se crea la instancia de MenuM2 con todos sus atributos
            /// </summary>
            /// <param name="nombre"></param>
            /// <param name="opciones"></param>
            /// <returns>Devuelve la instancia de la clase MenuM2 con el nombre y las opciones</returns>
            static public Entidad crearMenuCompleto( string nombre , ListaGenericaM2<OpcionM2> opciones )
            {
                return new MenuM2( nombre , opciones );
            }

            #endregion

            #region Métodos para instancias de ListaGenericaM2

            /// <summary>
            /// Se crea la instancia sin atributos de ListaGenericaM2
            /// </summary>
            /// <returns>Devuelve la instancia de la clase ListaGenericaM2 sin atributos de tipo MenuM2</returns>
            static public Entidad crearListaGenericaVaciaMenu()
            {
                return new ListaGenericaM2<DominioTangerine.Entidades.M2.MenuM2>();
            }

            /// <summary>
            /// Se crea la instancia sin atributos de ListaGenericaM2
            /// </summary>
            /// <returns>Devuelve la instancia de la clase ListaGenericaM2 sin atributos de tipo OpcionM2</returns>
            static public Entidad crearListaGenericaVaciaOpcion()
            {
                return new ListaGenericaM2<DominioTangerine.Entidades.M2.OpcionM2>();
            }

            /// <summary>
            /// Se crea la instancia sin atributos de ListaGenericaM2
            /// </summary>
            /// <returns>Devuelve la instancia de la clase ListaGenericaM2 sin atributos de tipo Entidad</returns>
            static public Entidad crearListaGenericaVacia()
            {
                return new ListaGenericaM2<Entidad>();
            }

            #endregion
            
        #endregion

        #region Modulo 3
            #region Metodo para instanciar Cliente Potencial
            public static Entidad ObtenerClientePotencial()
            {
                return new DominioTangerine.Entidades.M3.ClientePotencial();
            }
            #endregion
            #region instancia de cliente potencial sin estatus
            public static Entidad CrearClientePotencial(int idCliente, string nombre, string rif, 
                                                        string email, float presupuesto,
                                                        int llamadas, int visitas)
            {
                return new DominioTangerine.Entidades.M3.ClientePotencial(idCliente, nombre,rif, email,
                                                                          presupuesto, llamadas, visitas);
            }
            #endregion 

            #region metodo para instaciar cliente potencial si llamadas, visitas ni id
            public static Entidad CrearClientePotencial(string nombre, string rif, string email, float presupuesto, int status)
            {
                return new DominioTangerine.Entidades.M3.ClientePotencial(nombre, rif, email, presupuesto, status);
            }
            #endregion

            #region Metodo para instaciar llamadas
            public static Entidad CrearSeguimientoXLlamada()
            {
                return new DominioTangerine.Entidades.M3.SeguimientoCliente();
            }
            #endregion

            #region Metodo para instaciar llamadas constructor completo
            public static Entidad CrearSeguimientoXLlamada(int id, DateTime fecha, String tipo, String motivo, int fk)
            {
                return new DominioTangerine.Entidades.M3.SeguimientoCliente(id, fecha, tipo, motivo,fk);
            }
            #endregion

            #region Metodo para instaciar visitas
            public static Entidad CrearSeguimientoXVisitas()
            {
                return new DominioTangerine.Entidades.M3.SeguimientoCliente();
            }
            #endregion

            #region Metodo para instaciar visitas constructor completo
            public static Entidad CrearSeguimientoXVisitas(int id, DateTime fecha, String tipo, String motivo, int fk)
            {
                return new DominioTangerine.Entidades.M3.SeguimientoCliente(id, fecha, tipo, motivo, fk);
            }
            #endregion

            public static Entidad CrearSeguimientoDeCliente(DateTime fecha, String tipo, String motivo, int fk)
            {
                return new DominioTangerine.Entidades.M3.SeguimientoCliente(fecha, tipo, motivo, fk);
            }
        #endregion

        #region Modulo 4

            #region instancias de la clase CompaniaM4
            /// <summary>
            /// Metodo que crea la instancia de la entidad CompaniaM4
            /// </summary>
            /// <returns>Retorna la instancia a la clase CompaniaM4</returns>
            static public Entidad CrearCompaniaVacia()
            {
                return new DominioTangerine.Entidades.M4.CompaniaM4();
            }

            /// <summary>
            /// Se crea la instancia de la CompaniaM4 con todos sus atributos
            /// </summary>
            /// <param name="inputId"></param>
            /// <param name="inputNombre"></param>
            /// <param name="inputRif"></param>
            /// <param name="inputEmail"></param>
            /// <param name="inputTelefono"></param>
            /// <param name="inputAcronimo"></param>
            /// <param name="inputFechaRegistro"></param>
            /// <param name="inputStatus"></param>
            /// <param name="inputPresupuesto"></param>
            /// <param name="inputPlazoPago"></param>
            /// <param name="inputIdLugar"></param>
            /// <returns>Retorna una instacion de CompaniaM4 con todos los atributos</returns>

            static public Entidad CrearCompaniaConId(int inputId, string inputNombre, string inputRif, string inputEmail,
                string inputTelefono,string inputAcronimo, DateTime inputFechaRegistro, int inputStatus, int inputPresupuesto,
                int inputPlazoPago, int inputIdLugar)
            {
                return new DominioTangerine.Entidades.M4.CompaniaM4( inputId, inputNombre , inputRif , inputEmail ,
                                                                   inputTelefono , inputAcronimo , inputFechaRegistro , 
                                                                   inputStatus , inputPresupuesto , inputPlazoPago ,
                                                                   inputIdLugar );
            }
        
            /// <summary>
            /// Se crea la instancia de la CompaniaM4 con todos sus atributos menos el id
            /// </summary>
            /// <param name="inputNombre"></param>
            /// <param name="inputRif"></param>
            /// <param name="inputEmail"></param>
            /// <param name="inputTelefono"></param>
            /// <param name="inputAcronimo"></param>
            /// <param name="inputFechaRegistro"></param>
            /// <param name="inputStatus"></param>
            /// <param name="inputPresupuesto"></param>
            /// <param name="inputPlazoPago"></param>
            /// <param name="inputIdLugar"></param>
            /// <returns>Retorna una instacion de CompaniaM4 con todos los atributos menos el id</returns>

            static public Entidad CrearCompaniaSinId(string inputNombre, string inputRif, string inputEmail, string inputTelefono, 
                                                                                    string inputAcronimo, DateTime inputFechaRegistro, int inputStatus, 
                                                                                    int inputPresupuesto, int inputPlazoPago, int inputIdLugar)
            {
                return new DominioTangerine.Entidades.M4.CompaniaM4( inputNombre , inputRif , inputEmail , inputTelefono ,
                                                                   inputAcronimo , inputFechaRegistro , inputStatus ,
                                                                   inputPresupuesto , inputPlazoPago , inputIdLugar );
            }
            #endregion
     

            #region instancias de la clase LugarDireccionM4

            /// <summary>
            /// Metodo que crea la instancia de la entidad LugarDireccionM4
            /// </summary>
            /// <returns>Retorna la instancia a la clase LugarDireccionM4</returns>

            static public Entidad CrearLugarDireccionVacio()
            {
                return new DominioTangerine.Entidades.M4.LugarDireccionM4();
            }

            /// <summary>
            /// Se crea la instancia de LugarDireccionM4 con lugId y lugNombre
            /// </summary>
            /// <param name="lugId"></param>
            /// <param name="lugNombre"></param>
            /// <returns>Retorna una instacion de LugarDireccionM4 con lugId y lugNombre</returns>

            static public Entidad CrearLugarDireccionConLugar(int lugId, string lugNombre)
            {
                return new DominioTangerine.Entidades.M4.LugarDireccionM4( lugId , lugNombre );
            }
        
            /// <summary>
            /// Se crea la instancia de LugarDireccionM4 con lugId,lugNombre, lugTipo y fk_lugId
            /// </summary>
            /// <param name="lugId"></param>
            /// <param name="lugNombre"></param>
            /// <param name="lugTipo"></param>
            /// <param name="fk_lugId"></param>
            /// <returns>Retorna una instacion de LugarDireccionM4 con lugId,lugNombre, lugTipo y fk_lugId</returns>

            static public Entidad CrearLugarDireccionCuatroParametros(int lugId, string lugNombre, string lugTipo, int fk_lugId)
            {
                return new DominioTangerine.Entidades.M4.LugarDireccionM4( lugId , lugNombre , lugTipo , fk_lugId );
            }
    
            /// <summary>
            /// Se crea la instancia de LugarDireccionM4 completa
            /// </summary>
            /// <param name="lugId"></param>
            /// <param name="lugNombre"></param>
            /// <param name="lugTipo"></param>
            /// <param name="fk_lugId"></param>
            /// <param name="address"></param>
            /// <returns>Retorna una instacion de LugarDireccionM4 completa</returns>

            static public Entidad CrearLugarDireccionCompleto(int lugId, string lugNombre, string lugTipo, int fk_lugId,
                                                                                                   List<DominioTangerine.Entidades.M4.LugarDireccionM4> address)
            {
                return new DominioTangerine.Entidades.M4.LugarDireccionM4( lugId , lugNombre , lugTipo , fk_lugId , 
                                                                         address);
            }

            /// <summary>
            /// Se crea la instancia de LugarDireccionM4 con lugNombre y lugTipo
            /// </summary>
            /// <param name="lugNombre"></param>
            /// <param name="lugTipo"></param>
            /// <returns>Retorna una instacion de LugarDireccionM4 con lugNombre y lugTipo</returns>

            static public Entidad CrearLugarDireccionConLugarTipo(string lugNombre, string lugTipo)
            {
                return new DominioTangerine.Entidades.M4.LugarDireccionM4(lugNombre, lugTipo );
            }

            #endregion


        #endregion

        #region Modulo 5
            /// <summary>
            /// Método para instancear la clase ContactoM5 vacia
            /// </summary>
            /// <returns></returns>
            public static Entidad crearContactoVacio()
            {
                return new ContactoM5();
            }

            /// <summary>
            /// Método para instancear la clase ContactoM5 sin el id
            /// </summary>
            /// <param name="nombre"></param>
            /// <param name="apellido"></param>
            /// <param name="departamento"></param>
            /// <param name="cargo"></param>
            /// <param name="telefono"></param>
            /// <param name="correo"></param>
            /// <param name="tipoCompañia"></param>
            /// <param name="idCompañia"></param>
            /// <returns></returns>
            public static Entidad crearContactoSinId( string nombre, string apellido, string departamento,
                                                      string cargo, string telefono, string correo, int tipoCompañia,
                                                      int idCompañia )
            {
                return new ContactoM5( nombre, apellido, departamento, cargo, telefono, correo, tipoCompañia, 
                                       idCompañia );
            }
            
            /// <summary>
            /// Método para instancear la clase ContactoM5 con todos sus atributos
            /// </summary>
            /// <param name="idContacto"></param>
            /// <param name="nombre"></param>
            /// <param name="apellido"></param>
            /// <param name="departamento"></param>
            /// <param name="cargo"></param>
            /// <param name="telefono"></param>
            /// <param name="correo"></param>
            /// <param name="tipoCompañia"></param>
            /// <param name="idCompañia"></param>
            /// <returns></returns>
            public static Entidad crearContactoConId( int idContacto, string nombre, string apellido, 
                                                      string departamento, string cargo, string telefono, 
                                                      string correo, int tipoCompañia, int idCompañia ) 
            {
                return new ContactoM5( idContacto, nombre, apellido, departamento, cargo, telefono, correo, 
                                       tipoCompañia, idCompañia );
            }
        #endregion

        #region Modulo 6

            #region Instancia Propuesta
            /// <summary>
            /// Se crea la instancia sin atributos
            /// </summary>
            /// <returns>Retorna una instancia de Propuesta sin atributos</returns>
            static public Entidad ObtenerPropuestaVacia()
            {
                return new DominioTangerine.Entidades.M6.Propuesta();
            }

            /// <summary>
            /// Se crea la instancia con atributos
            /// </summary>
            /// <returns>Retorna una instancia de Propuesta con atributos(sin codigo)</returns>
            static public Entidad ObtenerPropuesta( string nombre, string descripcion, string _tipoDu, string duracion, 
                string acuerdopago, string estatus, string moneda, int entrega, DateTime feincio, DateTime fefinal, 
                int costo, string compañia )
            {
                return new DominioTangerine.Entidades.M6.Propuesta( nombre, descripcion, _tipoDu, duracion, acuerdopago, 
                       estatus, moneda, entrega, feincio, fefinal, costo, compañia );
            }

            /// <summary>
            /// Se crea la instancia con atributos
            /// </summary>
            /// <returns>Retorna una instancia de Propuesta con atributos</returns>
            static public Entidad ObtenerPropuesta( string codigo, string nombre, string descripcion, string _tipoDu, 
                string duracion, string acuerdopago, string estatus, string moneda, int entrega, DateTime feincio, 
                DateTime fefinal, int costo, string compañia )
            {
                return new DominioTangerine.Entidades.M6.Propuesta(codigo, nombre, descripcion, _tipoDu, duracion, 
                    acuerdopago, estatus, moneda, entrega, feincio, fefinal, costo, compañia);
            }

            /// <summary>
            /// Se crea la instancia con atributos
            /// </summary>
            /// <returns>Retorna una instancia de Propuesta con lista de requerimientos vacia</returns>
            static public Entidad ObtenerPropuesta( string codigoP, 
                List<DominioTangerine.Entidades.M6.Requerimiento> listaRequerimiento )
            {
                return new DominioTangerine.Entidades.M6.Propuesta( codigoP, listaRequerimiento );
            }

            #endregion

            #region Instancia Requerimiento
            /// <summary>
            /// Se crea la instancia con atributos
            /// </summary>
            /// <returns>Retorna una instancia de requerimiento con atributos</returns>
            static public Entidad ObtenerRequerimiento( string codreq, string descripr, string codpro )
            {
                return new DominioTangerine.Entidades.M6.Requerimiento( codreq, descripr, codpro );
            }

            #endregion

        #endregion

        #region Modulo 7

            #region Metodos para instanciar Propuesta
            /// <summary>
            /// Método para instancear la clase Propuesta vacia
            /// </summary>
            /// <returns></returns>
            public static Entidad ObtenerPropuesta() 
            {
                return new DominioTangerine.Entidades.M7.Propuesta();
            }
            #endregion

            #region Metodos para instaciar Requerimiento
            /// <summary>
            /// Método para instancear la clase Requerimiento vacia
            /// </summary>
            /// <returns></returns>
            public static Entidad ObtenerRequerimiento()
            {
                return new DominioTangerine.Entidades.M7.Requerimiento();
            }
            #endregion

            #region Metodos para instanciar Cargo
            /// <summary>
            /// Método para instancear la clase Cargo vacia
            /// </summary>
            /// <returns></returns>
            public static Entidad ObtenerCargo()
            {
                return new DominioTangerine.Entidades.M7.Cargo();
            }

            public static Entidad ObtenerCargo2(string cargo, double salary, string dateIni, string dateFin)
            {
                return new DominioTangerine.Entidades.M7.Cargo(cargo, salary, dateIni, dateFin);
            }
            #endregion

            #region Metodos para instaciar Lugar Direccion
            /// <summary>
            /// Método para instancear la clase Lugar Direccion vacia
            /// </summary>
            /// <returns></returns>
            public static Entidad ObtenerLugarDireccion() 
            {
                return new DominioTangerine.Entidades.M7.LugarDireccion();
            }
            #endregion

            #region Metodos para instanciar ObtenerContacto
            /// <summary>
            /// Método para instancear la clase Entidad vacia
            /// </summary>
            /// <returns></returns>
            public static Entidad ObtenerContacto() 
            {
                return new DominioTangerine.Entidades.M7.Contacto();
            }
            #endregion

            #region Metodos para instanciar Obtener Empleados
            /// <summary>
            /// Método para instancear la clase Empleado vacia
            /// </summary>
            /// <returns></returns>
            public static Entidad ObtenerEmpleado()
            {
                return new DominioTangerine.Entidades.M7.Empleado();
            }
            #endregion

            #region Metodos para instanciar Proyecto
            /// <summary>
            /// Método para instancear la clase Proyecto vacia
            /// </summary>
            /// <returns></returns>
            public static Entidad ObtenerProyecto()
            {
                return new DominioTangerine.Entidades.M7.Proyecto();
            }

            public static Entidad CrearProyecto(string nombre, string codigo, DateTime fecha_inicio, 
                                  DateTime fecha_estimada_fin, double costo, string descripcion, 
                                  string realizacion, string estatus, string razon, string acuerdopago,
                                  int id_propuesta, int id_responsable, int id_gerente)
            {
                return new DominioTangerine.Entidades.M7.Proyecto(nombre, codigo, fecha_inicio,
                            fecha_estimada_fin, costo, descripcion, realizacion, estatus, razon, 
                            acuerdopago, id_propuesta, id_responsable, id_gerente);
            }

            public static Entidad CrearProyectoConListas(string nombre, string codigo, DateTime fecha_inicio, 
                                  DateTime fecha_estimada_fin, double costo, string descripcion, string realizacion, 
                                  string estatus, string razon, string acuerdopago, int id_propuesta, 
                                  int id_responsable, int id_gerente, List<Entidad> empleados, List<Entidad> contactos)
            {
                return new DominioTangerine.Entidades.M7.Proyecto(nombre, codigo, fecha_inicio, 
                           fecha_estimada_fin, costo, descripcion, realizacion, estatus, razon, acuerdopago,
                           id_propuesta, id_responsable, id_gerente, empleados, contactos);
            }
            #endregion

        #endregion

        #region Modulo 8

        /// <summary>
        /// Constructor de datos correo vacio.
        /// </summary>
        public static Entidad ObtenerFacturacion()
        {
            return new Facturacion();
        }

        /// <summary>
        /// Constructor de Facturacion sin id de Entidad.
        /// </summary>
        /// <param name="fecha">Fecha de creacion</param>
        /// <param name="fechaUltimoPago">Fecha del ultimo pago</param>
        /// <param name="monto">Monto de la factura</param>
        /// <param name="montoRestante">Monto restante por pagar</param>
        /// <param name="tipoMoneda">Moneda de la factura</param>
        /// <param name="descripcion">Descripcion de la factura</param>
        /// <param name="estatus">Estado de la factura(0 ppagar, 1 pagado, 2 anulada)</param>
        /// <param name="idProyecto">Id del proyecto de la factura</param>
        /// <param name="idCompania">Id de la compania del proyecto y factura</param>
        public static Entidad ObtenerFacturacion(DateTime fecha, DateTime fechaUltimoPago, double monto,
            double montoRestante, String tipoMoneda, String descripcion, int estatus, int idProyecto, int idCompania)
        {
            return new Facturacion(fecha, fechaUltimoPago, monto, montoRestante, tipoMoneda,
                descripcion, estatus, idProyecto, idCompania);
        }

        /// <summary>
        /// Constructor de Facturacion con todos los atributos.
        /// </summary>
        /// <param name="facturaId">Id de la entidad</param>
        /// <param name="fecha">Fecha de creacion</param>
        /// <param name="fechaUltimoPago">Fecha del ultimo pago</param>
        /// <param name="monto">Monto de la factura</param>
        /// <param name="montoRestante">Monto restante por pagar</param>
        /// <param name="tipoMoneda">Moneda de la factura</param>
        /// <param name="descripcion">Descripcion de la factura</param>
        /// <param name="estatus">Estado de la factura(0 ppagar, 1 pagado, 2 anulada)</param>
        /// <param name="idProyecto">Id del proyecto de la factura</param>
        /// <param name="idCompania">Id de la compania del proyecto y factura</param>
        public static Entidad ObtenerFacturacion(int facturaId, int idNumeroFactura, DateTime fecha,
            DateTime fechaUltimoPago, double monto, double montoRestante, String tipoMoneda, String descripcion,
            int estatus, int idProyecto, int idCompania)
        {
            return new Facturacion(facturaId, fecha, fechaUltimoPago, monto, montoRestante, tipoMoneda,
                descripcion, estatus, idProyecto, idCompania);
        }

        /// <summary>
        /// Constructor de CorreoGmailM8.
        /// </summary>
        public static Entidad ObtenerCorreoGmailM8()
        {
            return new CorreoGmailM8();
        }

        /// <summary>
        /// Constructor de datos correo vacio.
        /// </summary>
        public static Entidad ObtenerDatosCorreo()
        {
            return new DatosCorreo();
        }

        /// <summary>
        /// Constructor de datos correo sin archivo adjunto.
        /// </summary>
        /// <param name="asunto">Asunto del mensaje</param>
        /// <param name="destinatario">Destinatarios del mensaje</param>
        /// <param name="mensaje">Contenido del mensaje</param>
        public static Entidad ObtenerDatosCorreo(string asunto, string destinatario, string mensaje)
        {
            return new DatosCorreo(asunto, destinatario, mensaje);
        }

        /// <summary>
        /// Constructor de datos correo con todos sus atributos.
        /// </summary>
        /// <param name="asunto">Asunto del mensaje</param>
        /// <param name="destinatario">Destinatarios del mensaje</param>
        /// <param name="mensaje">Contenido del mensaje</param>
        /// <param name="adjunto">Archivo adjunto del mensaje</param>
        public static Entidad ObtenerDatosCorreo(string asunto, string destinatario, string mensaje, string adjunto)
        {
            return new DatosCorreo(asunto, destinatario, mensaje, adjunto);
        }
        #endregion

        #region Modulo 9

        /// <summary>
        /// Metodo que instancia la clase Pago vacia 
        /// </summary>
        /// <returns>Objeto Pago instanciado</returns>
        public static Entidad ObtenerPago_M9 ()
            {
                return new DominioTangerine.Entidades.M9.Pago();
            }
        /// <summary>
        /// Metodo que instancia la clase Pago con 5 atributos
        /// </summary>
        /// <param name="_idFactura">Entero, Id de la factura que se va a pagar</param>
        /// <param name="_fechaPago">DateTime, Fecha en la que se realiza el pago</param>
        /// <param name="_montoPago">Double, Monto por el que se realiza el pago</param>
        /// <param name="_monedaPago">String, Moneda en la que se realiza el pago</param>
        /// <param name="_codPago">Entero, Codigo de 10 digitos para confirmar el pago</param>
        /// <returns>Objeto Pago instanciado</returns>
        public static Entidad ObtenerPago_M9(int _idFactura, DateTime _fechaPago, double _montoPago, 
            string _monedaPago, int _codPago)
        {
            return new DominioTangerine.Entidades.M9.Pago(_idFactura,_fechaPago, _montoPago, _monedaPago, _codPago);
        }

        /// <summary>
        /// Metodo para instanciar la clase pago con 6 atributos
        /// </summary>
        /// <param name="monedaPago">String, Moneda en la que se realiza el pago</param>
        /// <param name="montoPago">Double, Monto por el que se realiza el pago</param>
        /// <param name="formaPago">String, Forma en la que se realiza el pago</param>
        /// <param name="codPago">Entero, Codigo de 10 digitos para confirmar el pago</param>
        /// <param name="fechaPago">DateTime, Fecha en la que se realizo el pago</param>
        /// <param name="idFactura">Entero, Id de la factura que se va a pagar</param>
        /// <returns>Objeto Pago instanciado</returns>
        public static Entidad ObtenerPago_M9(string monedaPago, double montoPago, string formaPago, int codPago, 
            DateTime fechaPago,
          int idFactura)
        {
            return new DominioTangerine.Entidades.M9.Pago(monedaPago, montoPago, formaPago, codPago, fechaPago, 
                idFactura);
        }

       
        /// <summary>
        /// Metodo para instanciar la clase pago con 5 atributos
        /// </summary>
        /// <param name="codPago">Entero, Codigo de 10 digitos para confirmar el pago</param>
        /// <param name="montoPago">Double, Monto por el que se realiza el pago</param>
        /// <param name="monedaPago">String, Moneda en la que se realiza el pago</param>
        /// <param name="formaPago">String, Forma en la que se realiza el pago</param>
        /// <param name="idFactura">Entero, Id de la factura que se va a pagar</param>
        /// <returns>Objeto Pago instanciado</returns>
        public static Entidad ObtenerPago_M9(int codPago, double montoPago, string monedaPago, string formaPago, 
            int idFactura)
        {
            return new DominioTangerine.Entidades.M9.Pago(codPago, montoPago, monedaPago, formaPago, idFactura);
        }


        #endregion

        #region Modulo 10
        #region Metodo para instanciar empleados sin atributos
        // <summary>
        // Metodo para instanciar empleados
        // </summary>
        /// <returns></returns>

        public static Entidad ConsultarEmpleados(int id)
        {
            return new DominioTangerine.Entidades.M10.EmpleadoM10(id);
        }


        public static Entidad ConsultarEmpleados() 
        {
            return new DominioTangerine.Entidades.M10.EmpleadoM10();
        }
        #endregion

        public static Entidad ObtenerLugar()
        {
            return new DominioTangerine.Entidades.M10.LugarDireccion();
        }
        public static Entidad ObtenerCargoM10()
        {
            return new DominioTangerine.Entidades.M10.CargoM10();
        }
        public static Entidad ObtenerEstadoM10()
        {
            return new DominioTangerine.Entidades.M10.LugarDireccion();
        }
        public static Entidad AgregarEmpledoM10()
        {
            return new DominioTangerine.Entidades.M10.EmpleadoM10();
        }

  
        public static Entidad ObtenerCargo3(string empCargo, string empCargoDescripcion, DateTime empContratacion, string empModalidad)
        {
            return new DominioTangerine.Entidades.M10.CargoM10(empCargo, empCargoDescripcion, empContratacion,empModalidad);
        }

        
        public static Entidad ObtenerCargoXid(string empCargo, double empSalario, string empFechaInicio, string empFechaFin)
        {
            return new DominioTangerine.Entidades.M10.CargoM10(empCargo, empSalario,empFechaInicio,empFechaFin);
        }

        public static Entidad ConsultarEmpleados(int empId, string empPNombre, string empSNombre, string empPApellido,
                                                 string empSApellido, int empCedula, DateTime empFecha, string empActivo,
                                                 string empEmail, string empGenero, string empEstudio, string empModalidad,
                                                 double empSalario, Entidad cargo)
        {
            return (new DominioTangerine.Entidades.M10.EmpleadoM10(empId, empPNombre, empSNombre, empPApellido,
                    empSApellido, empCedula, empFecha, empActivo, empEmail, empGenero, empEstudio, empModalidad, empSalario, cargo));

        }

        public static Entidad ListarEmpleadoId(int empId, string empPNombre, string empSNombre, string empPApellido,
                                               string empSApellido, string empGenero, int empCedula, DateTime empFecha,
                                               string empActivo, string empNivelEstudio, string empEmailEmployee,
                                               int empLugId, Entidad empCargo, double empSalario, string empFechaInicio,
                                               string empFechaFin, string empDireccion)
        {
            return (new DominioTangerine.Entidades.M10.EmpleadoM10(empId, empPNombre,  empSNombre,  empPApellido,
                                                                   empSApellido,  empGenero,  empCedula,  empFecha,
                                                                   empActivo,  empNivelEstudio,  empEmailEmployee,
                                                                   empLugId,  empCargo,  empSalario,  empFechaInicio,
                                                                   empFechaFin, empDireccion));
        }

        public static Entidad CrearEntidadEmpleado(string empPNombre, string empSNombre, string empPApellido, string empSApellido, string empGenero, int empCedula,
                     DateTime empFecha, string empActivo, string empEstudio, string empEmail,Entidad cargo, string telefono, List<DominioTangerine.Entidades.M10.LugarDireccion> ListaLugar)
        {
            return(new DominioTangerine.Entidades.M10.EmpleadoM10(empPNombre, empSNombre, empPApellido,empSApellido, empGenero,empCedula,
                     empFecha, empActivo, empEstudio, empEmail, cargo,telefono, ListaLugar));
        }

        public static Entidad CrearEntidadCargo(string name, DateTime dateJob, string jobMode, Double Salary)
        {
            return (new DominioTangerine.Entidades.M10.CargoM10(name, dateJob, jobMode, Salary));
        }

        public static Entidad CrearDireccion()
        {
            return(new DominioTangerine.Entidades.M10.LugarDireccion());
        }

        public static Entidad obtenerEntidad()
        {
            return new DominioTangerine.Entidades.M10.EmpleadoM10();
        }


        #endregion

       
    
    }
}
