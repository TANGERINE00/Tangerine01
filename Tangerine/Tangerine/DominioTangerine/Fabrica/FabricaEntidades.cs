using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DominioTangerine.Entidades.M2;
using DominioTangerine.Entidades.M4
;

namespace DominioTangerine.Fabrica
{
    public class FabricaEntidades
    {
        #region Modulo 1
       
        #endregion

        #region Modulo 2

            #region Metodos para instancias de Usuario

            /// <summary>
            /// Se crea la instancia sin atributos
            /// </summary>
            /// <returns>Retorna una instacion de Usuario sin atributos</returns>
            static public DominioTangerine.Entidades.M2.UsuarioM2 crearUsuarioVacio()
            {
                return new DominioTangerine.Entidades.M2.UsuarioM2();
            }

            /// <summary>
            /// Se crea la instancia con usuario y contraseña
            /// </summary>
            /// <returns>Retorna una instacion de Usuario con usuario y contraseña</returns>
            static public DominioTangerine.Entidades.M2.UsuarioM2 crearUsuarioConUsuarioYContrasena( string usuario, string contrasena )
            {
                return new DominioTangerine.Entidades.M2.UsuarioM2( usuario, contrasena );
            }

            /// <summary>
            /// Se crea la instancia con usuario y rol
            /// </summary>
            /// <returns>Retorna una instacion de Usuario con usuario y rol</returns>
            static public DominioTangerine.Entidades.M2.UsuarioM2 crearUsuarioConUsuarioRol( string usuario, RolM2 rol )
            {
                return new DominioTangerine.Entidades.M2.UsuarioM2( usuario, rol );
            }

            /// <summary>
            /// Se crea la instancia con usuario, contrasena y activo
            /// </summary>
            /// <returns>Retorna una instacion de Usuario con usuario, contraseña y activo</returns>
            static public DominioTangerine.Entidades.M2.UsuarioM2 crearUsuarioConUsuarioContrasenaActivo( string usuario, string contrasena, string activo )
            {
                return new DominioTangerine.Entidades.M2.UsuarioM2( usuario, contrasena, activo );
            }

            /// <summary>
            /// Se crea la instancia con usuario, contrasena, activo y Rol
            /// </summary>
            /// <returns>Retorna una instacion de Usuario con usuario, contraseña, activo y rol</returns>
            static public DominioTangerine.Entidades.M2.UsuarioM2 crearUsuarioConUsuarioContrasenaActivoRol( string usuario, string contrasena, string activo, RolM2 rol )
            {
                return new DominioTangerine.Entidades.M2.UsuarioM2( usuario, contrasena, activo, rol);
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

            static public DominioTangerine.Entidades.M2.UsuarioM2 crearUsuarioCompleto( string inputUsuario, string inputContrasena,
                                                                                        DateTime inputFechaCreacion, string inputActivo,
                                                                                        RolM2 inputRol, int inputfFichaEmpleado )
            {
                return new DominioTangerine.Entidades.M2.UsuarioM2( inputUsuario, inputContrasena, inputFechaCreacion,
                                                                    inputActivo, inputRol, inputfFichaEmpleado );
            }
            #endregion

            #region Metodos para instancias de Rol

            /// <summary>
            /// Se crea la instancia sin atributos de rol
            /// </summary>
            /// <returns>Devuelve la instancia de la clase Rol sin atributos</returns>
            static public DominioTangerine.Entidades.M2.RolM2 crearRolVacio()
            {
                return new DominioTangerine.Entidades.M2.RolM2();
            }

            /// <summary>
            /// Se crea la instancia de rol con nombre
            /// </summary>
            /// <returns>Devuelve la instancia de la clase Rol con el nombre</returns>
            static public DominioTangerine.Entidades.M2.RolM2 crearRolNombre( string nombre )
            {
                return new DominioTangerine.Entidades.M2.RolM2( nombre );
            }

            /// <summary>
            /// Se crea la instancia de rol con todos sus atributos
            /// </summary>
            /// <returns>Devuelve la instancia de la clase con el nombre y el menu</returns>
            static public DominioTangerine.Entidades.M2.RolM2 crearRolCompleto( string nombre, ListaGenerica<Menu> menu )
            {
                return new DominioTangerine.Entidades.M2.RolM2( nombre, menu );
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
            static public DominioTangerine.Entidades.M4.CompaniaM4 crearCompaniaVacia()
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

            static public DominioTangerine.Entidades.M4.CompaniaM4 crearCompaniaConId(int inputId, string inputNombre, string inputRif, string inputEmail, string inputTelefono,
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

            static public DominioTangerine.Entidades.M4.CompaniaM4 crearCompaniaSinId(string inputNombre, string inputRif, string inputEmail, string inputTelefono, 
                                                                                    string inputAcronimo, DateTime inputFechaRegistro, int inputStatus, 
                                                                                    int inputPresupuesto, int inputPlazoPago, int inputIdLugar)
            {
                return new DominioTangerine.Entidades.M4.CompaniaM4( inputNombre , inputRif , inputEmail , inputTelefono ,
                                                                   inputAcronimo , inputFechaRegistro , inputStatus ,
                                                                   inputPresupuesto , inputPlazoPago , inputIdLugar );
            }
            #endregion
        public static CompaniaM4 CrearEntidadCompaniaM4 (){
             return new CompaniaM4 ();
        }

            #region instancias de la clase LugarDireccionM4

            /// <summary>
            /// Metodo que crea la instancia de la entidad LugarDireccionM4
            /// </summary>
            /// <returns>Retorna la instancia a la clase LugarDireccionM4</returns>

            static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionVacio()
            {
                return new DominioTangerine.Entidades.M4.LugarDireccionM4();
            }

            /// <summary>
            /// Se crea la instancia de LugarDireccionM4 con lugId y lugNombre
            /// </summary>
            /// <param name="lugId"></param>
            /// <param name="lugNombre"></param>
            /// <returns>Retorna una instacion de LugarDireccionM4 con lugId y lugNombre</returns>

            static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionConLugar(int lugId, string lugNombre)
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

            static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionCuatroParametros(int lugId, string lugNombre, string lugTipo, int fk_lugId)
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

            static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionCompleto(int lugId, string lugNombre, string lugTipo, int fk_lugId,
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

            static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionConLugarTipo(string lugNombre, string lugTipo)
            {
                return new DominioTangerine.Entidades.M4.LugarDireccionM4(lugNombre, lugTipo );
            }

            #endregion


        #endregion

        #region Modulo 5

        #endregion

        #region Modulo 6
        static public Entidad ObtenerPropuesta(string nombre, string descripcion, string _tipoDu, string duracion, string acuerdopago, string estatus,
                         string moneda, int entrega, DateTime feincio, DateTime fefinal, int costo, string compañia)
        {
            return new DominioTangerine.Entidades.M6.Propuesta(nombre, descripcion, _tipoDu, duracion, acuerdopago, estatus,
                         moneda, entrega, feincio, fefinal, costo, compañia);
        }

        static public Entidad ObtenerPropuesta(string codigo, string nombre, string descripcion, string _tipoDu, string duracion, string acuerdopago, string estatus,
                        string moneda, int entrega, DateTime feincio, DateTime fefinal, int costo, string compañia)
        {
            return new DominioTangerine.Entidades.M6.Propuesta(codigo, nombre, descripcion, _tipoDu, duracion, acuerdopago, estatus,
                        moneda, entrega, feincio, fefinal, costo, compañia);
        }

        static public Entidad ObtenerPropuesta(string codigoP, List<DominioTangerine.Entidades.M6.Requerimiento> listaRequerimiento)
        {
            return new DominioTangerine.Entidades.M6.Propuesta(codigoP, listaRequerimiento);
        }

        static public Entidad ObtenerRequerimiento(string codreq, string descripr, string codpro)
        {
            return new DominioTangerine.Entidades.M6.Requerimiento(codreq, descripr, codpro);
        }
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

        #endregion

        #region Modulo 9
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

        public static Entidad ObtenerEmpleadoE() 
        {
            return new DominioTangerine.Entidades.M10.Empleado();
        }

        
        /// <summary>
        /// Metodo para instanciar a los empleados con todos sus atributos
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="empPNombre"></param>
        /// <param name="empSNombre"></param>
        /// <param name="empPApellido"></param>
        /// <param name="empSApellido"></param>
        /// <param name="empGenero"></param>
        /// <param name="empCedula"></param>
        /// <param name="empFecha"></param>
        /// <param name="empActivo"></param>
        /// <param name="empEstudio"></param>
        /// <param name="empEmail"></param>
        /// <param name="empLugId"></param>
        /// <returns></returns>
        public static Entidad ObtenerEmpleadoCompleto(int empId, string empPNombre, string empSNombre, string empPApellido, string empSApellido,
                       string empGenero, int empCedula, DateTime empFecha, string empActivo, string empEstudio,
                       string empEmail, int empLugId) 
        {
            return new DominioTangerine.Entidades.M10.Empleado( empId,  empPNombre,  empSNombre,  empPApellido,  empSApellido,
                        empGenero,  empCedula,  empFecha,  empActivo,  empEstudio,
                        empEmail,  empLugId);
        }


        /// <summary>
        /// Metodo para instanciar empleados con todos los atributos menos el id 
        /// </summary>
        /// <param name="pNombre"></param>
        /// <param name="sNombre"></param>
        /// <param name="pApellido"></param>
        /// <param name="sApellido"></param>
        /// <param name="email"></param>
        /// <param name="genero"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="ficha"></param>
        /// <param name="cedula"></param>
        /// <param name="nivelEstudio"></param>
        /// <param name="activo"></param>
        /// <returns></returns>
        public static Entidad ObtenerEmpleadoSinId(string pNombre, string sNombre, string pApellido, string sApellido,
                string email, string genero, DateTime fechaNacimiento, int ficha, int cedula,
                string nivelEstudio, string activo) 
        {
            return new DominioTangerine.Entidades.M10.Empleado( pNombre,  sNombre,  pApellido,  sApellido,
                 email,  genero,  fechaNacimiento,  ficha,  cedula,
                 nivelEstudio,  activo);
        }

        
       
        #endregion
    }
}
