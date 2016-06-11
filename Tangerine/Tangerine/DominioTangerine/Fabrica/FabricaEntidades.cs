using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DominioTangerine.Entidades.M2;

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
            /// <returns></returns>
            static public DominioTangerine.Entidades.M2.UsuarioM2 crearUsuarioVacio()
            {
                return new DominioTangerine.Entidades.M2.UsuarioM2();
            }

            /// <summary>
            /// Se crea la instancia con usuario y contraseña
            /// </summary>
            /// <returns></returns>
            static public DominioTangerine.Entidades.M2.UsuarioM2 crearUsuarioConUsuarioYContrasena(string usuario, string contrasena)
            {
                return new DominioTangerine.Entidades.M2.UsuarioM2(usuario, contrasena);
            }

            /// <summary>
            /// Se crea la instancia con usuario y rol
            /// </summary>
            /// <returns></returns>
            static public DominioTangerine.Entidades.M2.UsuarioM2 crearUsuarioConUsuarioRol(string usuario, RolM2 rol)
            {
                return new DominioTangerine.Entidades.M2.UsuarioM2(usuario, rol);
            }

            /// <summary>
            /// Se crea la instancia con usuario, contrasena y activo
            /// </summary>
            /// <returns></returns>
            static public DominioTangerine.Entidades.M2.UsuarioM2 crearUsuarioConUsuarioContrasenaActivo(string usuario, string contrasena, string activo)
            {
                return new DominioTangerine.Entidades.M2.UsuarioM2(usuario, contrasena, activo);
            }

            /// <summary>
            /// Se crea la instancia con usuario, contrasena, activo y Rol
            /// </summary>
            /// <returns></returns>
            static public DominioTangerine.Entidades.M2.UsuarioM2 crearUsuarioConUsuarioContrasenaActivoRol(string usuario, string contrasena, string activo, RolM2 rol)
            {
                return new DominioTangerine.Entidades.M2.UsuarioM2(usuario, contrasena, activo, rol);
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
            /// <returns></returns>

            static public DominioTangerine.Entidades.M2.UsuarioM2 crearUsuarioCompleto(string inputUsuario, string inputContrasena,
                                                                                        DateTime inputFechaCreacion, string inputActivo, RolM2 inputRol,
                                                                                    int inputfFichaEmpleado)
            {
                return new DominioTangerine.Entidades.M2.UsuarioM2(inputUsuario, inputContrasena, inputFechaCreacion, inputActivo, inputRol,
                                                                    inputfFichaEmpleado);
            }
            #endregion

            #region Metodos para instancias de Rol

            /// <summary>
            /// Se crea la instancia sin atributos de rol
            /// </summary>
            /// <returns>Devuelve la instancia de la clase</returns>
            static public DominioTangerine.Entidades.M2.RolM2 crearRolVacio()
            {
                return new DominioTangerine.Entidades.M2.RolM2();
            }

            /// <summary>
            /// Se crea la instancia de rol con nombre
            /// </summary>
            /// <returns>Devuelve la instancia de la clase</returns>
            static public DominioTangerine.Entidades.M2.RolM2 crearRolNombre(string nombre)
            {
                return new DominioTangerine.Entidades.M2.RolM2(nombre);
            }

            /// <summary>
            /// Se crea la instancia de rol con todos sus atributos
            /// </summary>
            /// <returns>Devuelve la instancia de la clase</returns>
            static public DominioTangerine.Entidades.M2.RolM2 crearRolCompleto(string nombre, ListaGenerica<Menu> menu)
            {
                return new DominioTangerine.Entidades.M2.RolM2(nombre, menu);
            }


            #endregion


        #endregion

        #region Modulo 3

        #endregion

        #region Modulo 4
        static public DominioTangerine.Entidades.M4.CompaniaM4 crearCompaniaVacia()
        {
            return new DominioTangerine.Entidades.M4.CompaniaM4();
        }

        static public DominioTangerine.Entidades.M4.CompaniaM4 crearCompaniaConId(int inputId, string inputNombre, string inputRif, string inputEmail, string inputTelefono,
                                                                                string inputAcronimo, DateTime inputFechaRegistro, int inputStatus, int inputPresupuesto,
                                                                                int inputPlazoPago, int inputIdLugar)
        {
            return new DominioTangerine.Entidades.M4.CompaniaM4( inputId, inputNombre , inputRif , inputEmail ,
                                                               inputTelefono , inputAcronimo , inputFechaRegistro , 
                                                               inputStatus , inputPresupuesto , inputPlazoPago ,
                                                               inputIdLugar );
        }

        static public DominioTangerine.Entidades.M4.CompaniaM4 crearCompaniaSinId(string inputNombre, string inputRif, string inputEmail, string inputTelefono, 
                                                                                string inputAcronimo, DateTime inputFechaRegistro, int inputStatus, 
                                                                                int inputPresupuesto, int inputPlazoPago, int inputIdLugar)
        {
            return new DominioTangerine.Entidades.M4.CompaniaM4( inputNombre , inputRif , inputEmail , inputTelefono ,
                                                               inputAcronimo , inputFechaRegistro , inputStatus ,
                                                               inputPresupuesto , inputPlazoPago , inputIdLugar );
        }

        static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionVacio()
        {
            return new DominioTangerine.Entidades.M4.LugarDireccionM4();
        }

        static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionConLugar(int lugId, string lugNombre)
        {
            return new DominioTangerine.Entidades.M4.LugarDireccionM4( lugId , lugNombre );
        }

        static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionCuatroParametros(int lugId, string lugNombre, string lugTipo, int fk_lugId)
        {
            return new DominioTangerine.Entidades.M4.LugarDireccionM4( lugId , lugNombre , lugTipo , fk_lugId );
        }

        static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionCompleto(int lugId, string lugNombre, string lugTipo, int fk_lugId,
                                                                                               List<DominioTangerine.Entidades.M4.LugarDireccionM4> address)
        {
            return new DominioTangerine.Entidades.M4.LugarDireccionM4( lugId , lugNombre , lugTipo , fk_lugId , 
                                                                     address);
        }

        static public DominioTangerine.Entidades.M4.LugarDireccionM4 crearLugarDireccionConLugarTipo(string lugNombre, string lugTipo)
        {
            return new DominioTangerine.Entidades.M4.LugarDireccionM4(lugNombre, lugTipo );
        }




        #endregion

        #region Modulo 5

        #endregion

        #region Modulo 6

        #endregion

        #region Modulo 7

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

        #endregion
    }
}
