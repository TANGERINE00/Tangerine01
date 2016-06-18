using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DominioTangerine.Entidades.M2;
using DominioTangerine.Entidades.M4;
using DominioTangerine.Entidades.M5;
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
            /// <returns>Retorna una instacion de UsuarioM2 sin atributos</returns>
            static public Entidad crearUsuarioVacio()
            {
                return new UsuarioM2();
            }

            /// <summary>
            /// Se crea la instancia con usuario y contraseña
            /// </summary>
            /// <param name="usuario"></param>
            /// <param name="contrasena"></param>
            /// <returns>Retorna una instacion de Usuario con usuario y contraseña</returns>
            static public Entidad crearUsuarioConUsuarioYContrasena( string usuario , string contrasena )
            {
                return new UsuarioM2( usuario , contrasena );
            }

            /// <summary>
            /// Se crea la instancia con usuario y rol
            /// </summary>
            /// <param name="usuario"></param>
            /// <param name="rol"></param>
            /// <returns>Retorna una instacion de Usuario con usuario y rol</returns>
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
            /// <returns>Retorna una instacion de Usuario con usuario, contraseña y activo</returns>
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
            /// <returns>Retorna una instacion de Usuario con usuario, contraseña, activo y rol</returns>
            static public Entidad crearUsuarioConUsuarioContrasenaActivoRol( string usuario , string contrasena , string activo , RolM2 rol )
            {
                return new UsuarioM2( usuario , contrasena , activo , rol);
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
            /// <returns>Retorna una instacion de Usuario con todos los atributos</returns>
            static public Entidad crearUsuarioCompleto( string inputUsuario , string inputContrasena , DateTime inputFechaCreacion , 
                                                        string inputActivo , RolM2 inputRol , int inputfFichaEmpleado )
            {
                return new UsuarioM2( inputUsuario , inputContrasena , inputFechaCreacion , inputActivo , inputRol , inputfFichaEmpleado );
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
            static public Entidad crearRolCompleto( string nombre , ListaGenericaM2<MenuM2> menu)
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
            /// <returns>Devuelve la instancia de la clase ListaGenericaM2 sin atributos</returns>
            static public Entidad crearListaGenericaVacia()
            {
                return new ListaGenericaM2<Entidad>();
            }

            #endregion
            
        #endregion

        #region Modulo 3

        #endregion

        #region Modulo 4

            #region instancias de la clase CompaniaM4
            /// <summary>
            /// Metodo que crea la instancia de la entidad CompaniaM4
            /// </summary>
            /// <returns>Retorna la instancia a la clase CompaniaM4</returns>
            static public Entidad crearCompaniaVacia()
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

            static public Entidad crearCompaniaConId(int inputId, string inputNombre, string inputRif, string inputEmail, string inputTelefono,
                                                                                    string inputAcronimo, DateTime inputFechaRegistro, int inputStatus, int inputPresupuesto,
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

            static public Entidad crearCompaniaSinId(string inputNombre, string inputRif, string inputEmail, string inputTelefono, 
                                                                                    string inputAcronimo, DateTime inputFechaRegistro, int inputStatus, 
                                                                                    int inputPresupuesto, int inputPlazoPago, int inputIdLugar)
            {
                return new DominioTangerine.Entidades.M4.CompaniaM4( inputNombre , inputRif , inputEmail , inputTelefono ,
                                                                   inputAcronimo , inputFechaRegistro , inputStatus ,
                                                                   inputPresupuesto , inputPlazoPago , inputIdLugar );
            }
            #endregion
     
        
        
        public static Entidad CrearEntidadCompaniaM4 (){
             return new CompaniaM4 ();
        }

            #region instancias de la clase LugarDireccionM4

            /// <summary>
            /// Metodo que crea la instancia de la entidad LugarDireccionM4
            /// </summary>
            /// <returns>Retorna la instancia a la clase LugarDireccionM4</returns>

            static public Entidad crearLugarDireccionVacio()
            {
                return new DominioTangerine.Entidades.M4.LugarDireccionM4();
            }

            /// <summary>
            /// Se crea la instancia de LugarDireccionM4 con lugId y lugNombre
            /// </summary>
            /// <param name="lugId"></param>
            /// <param name="lugNombre"></param>
            /// <returns>Retorna una instacion de LugarDireccionM4 con lugId y lugNombre</returns>

            static public Entidad crearLugarDireccionConLugar(int lugId, string lugNombre)
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

            static public Entidad crearLugarDireccionCuatroParametros(int lugId, string lugNombre, string lugTipo, int fk_lugId)
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

            static public Entidad crearLugarDireccionCompleto(int lugId, string lugNombre, string lugTipo, int fk_lugId,
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

            static public Entidad crearLugarDireccionConLugarTipo(string lugNombre, string lugTipo)
            {
                return new DominioTangerine.Entidades.M4.LugarDireccionM4(lugNombre, lugTipo );
            }

            #endregion


        #endregion

        #region Modulo 5
            public static Entidad crearContactoVacio()
            {
                return new ContactoM5();
            }

            public static Entidad crearContactoSinId( string nombre, string apellido, string departamento,
                                                      string cargo, string telefono, string correo, int tipoCompañia,
                                                      int idCompañia )
            {
                return new ContactoM5( nombre, apellido, departamento, cargo, telefono, correo, tipoCompañia, 
                                       idCompañia );
            }

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

            static public Entidad ObtenerPropuesta(string nombre, string descripcion, string _tipoDu, string duracion, 
                string acuerdopago, string estatus, string moneda, int entrega, DateTime feincio, DateTime fefinal, 
                int costo, string compañia)
            {
                return new DominioTangerine.Entidades.M6.Propuesta(nombre, descripcion, _tipoDu, duracion, acuerdopago, 
                       estatus, moneda, entrega, feincio, fefinal, costo, compañia);
            }

            static public Entidad ObtenerPropuesta(string codigo, string nombre, string descripcion, string _tipoDu, 
                string duracion, string acuerdopago, string estatus, string moneda, int entrega, DateTime feincio, 
                DateTime fefinal, int costo, string compañia)
            {
                return new DominioTangerine.Entidades.M6.Propuesta(codigo, nombre, descripcion, _tipoDu, duracion, 
                    acuerdopago, estatus, moneda, entrega, feincio, fefinal, costo, compañia);
            }

            static public Entidad ObtenerPropuesta(string codigoP, 
                List<DominioTangerine.Entidades.M6.Requerimiento> listaRequerimiento)
            {
                return new DominioTangerine.Entidades.M6.Propuesta(codigoP, listaRequerimiento);
            }

            #endregion

            #region Instancia Requerimiento

            static public Entidad ObtenerRequerimiento(string codreq, string descripr, string codpro)
            {
                return new DominioTangerine.Entidades.M6.Requerimiento(codreq, descripr, codpro);
            }

            #endregion

        #endregion

        #region Modulo 7

            #region Metodos para instanciar Propuesta
            public static Entidad ObtenerPropuesta() 
            {
                return new DominioTangerine.Entidades.M7.Propuesta();
            }
            #endregion

            #region Metodos para instaciar Requerimiento
            public static Entidad ObtenerRequerimiento()
            {
                return new DominioTangerine.Entidades.M7.Requerimiento();
            }
            #endregion

            #region Metodos para instanciar Cargo
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
            public static Entidad ObtenerLugarDireccion() 
            {
                return new DominioTangerine.Entidades.M7.LugarDireccion();
            }
            #endregion

            #region Metodos para instanciar ObtenerContacto
            public static Entidad ObtenerContacto() 
            {
                return new DominioTangerine.Entidades.M7.Contacto();
            }
            #endregion

            #region Metodos para instanciar Obtener Empleados
            public static Entidad ObtenerEmpleado()
            {
                return new DominioTangerine.Entidades.M7.Empleado();
            }
            #endregion

            #region Metodos para instanciar Proyecto
            public static Entidad ObtenerProyecto()
            {
                return new DominioTangerine.Entidades.M7.Proyecto();
            }
            #endregion

        #endregion

        #region Modulo 8

        public static Entidad ObtenerFacturacion()
        {
            return new Facturacion();
        }

        public static Entidad Facturacion(DateTime fecha, DateTime fechaUltimoPago, double monto,
            double montoRestante, String tipoMoneda, String descripcion, int estatus, int idProyecto, int idCompania)
        {
            return new Facturacion(fecha, fechaUltimoPago, monto, montoRestante, tipoMoneda,
                descripcion, estatus, idProyecto, idCompania);
        }

        public static Entidad Facturacion(int id, int idNumeroFactura, DateTime fecha, DateTime fechaUltimoPago, double monto,
            double montoRestante, String tipoMoneda, String descripcion, int estatus, int idProyecto, int idCompania)
        {
            return new Facturacion(id, fecha, fechaUltimoPago, monto, montoRestante, tipoMoneda,
                descripcion, estatus, idProyecto, idCompania);
        }

        #endregion

        #region Modulo 9

        public static Entidad ObtenerPago_M9 ()
            {
                return new DominioTangerine.Entidades.M9.Pago();
            }
        public static Entidad ObtenerPago_M9(int idPago, int montoPago, string monedaPago, string formaPago,
           int codPago, DateTime fechaPago, int idFactura)
        {
            return new DominioTangerine.Entidades.M9.Pago(idPago, montoPago, monedaPago, formaPago, codPago, fechaPago, idFactura);
        }

        public static Entidad ObtenerPago_M9(string monedaPago, int montoPago, string formaPago, int codPago, DateTime fechaPago,
          int idFactura)
        {
            return new DominioTangerine.Entidades.M9.Pago(monedaPago, montoPago, formaPago, codPago, fechaPago, idFactura );
        }

        #endregion

        #region Modulo 10

        /// <summary>
        /// Metodo para instanciar empleados sin atributos
        /// </summary>
        /// <returns></returns>

        public static Entidad ConsultarEmpleados() 
        {
            return new DominioTangerine.Entidades.M10.Empleado();
        }

        //public static Entidad ObtenerCargo()
        //{
        //    return new DominioTangerine.Entidades.M10.Cargo();
        //}

      
        public static Entidad ObtenerCargo3(string empCargo, string empCargoDescripcion, DateTime empContratacion, string empModalidad, double empSalario)
        {
            return new DominioTangerine.Entidades.M10.Cargo(empCargo, empCargoDescripcion, empContratacion, empModalidad, empSalario);
        }

        #endregion

        public static Entidad ConsultarEmpleados(int empId, string empPNombre, string empSNombre, string empPApellido, string empSApellido, string empGenero,
                                                 int empCedula, DateTime empFecha, string empActivo, string empEstudio, string empEmail, Entidad cargoEmpleado)
        {
            throw new NotImplementedException();
        }
    }
}
