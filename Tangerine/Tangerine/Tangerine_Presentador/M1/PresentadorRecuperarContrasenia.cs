using System;
using System.Collections.Generic;
using System.Linq;
using DominioTangerine;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine;
using LogicaTangerine.M1;
using System.Security.Cryptography;
using LogicaTangerine.Fabrica;
using Tangerine_Contratos.M1;

namespace Tangerine_Presentador.M1
{
    public class PresentadorRecuperarContrasenia

    {
        private IContratoRecuperarContrasenia _vista;

        #region Variables
        string _usuario = String.Empty;
        string _correo = String.Empty;
        #endregion

        public PresentadorRecuperarContrasenia(IContratoRecuperarContrasenia vista)
        {
            _vista = vista;
        }


        public void RecuperarContraseña()
        {
            try
            {

                Entidad p = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioVacio();
                ((DominioTangerine.Entidades.M2.UsuarioM2)p).nombreUsuario = _vista.elusuario;
                ((DominioTangerine.Entidades.M2.UsuarioM2)p).contrasena = _vista.elcorreo;


                Comando<Entidad> cmdConsultar = LogicaTangerine.Fabrica.FabricaComandos.ConsultarUsuarioxCorreo(p);

                p = cmdConsultar.Ejecutar();

                if (((DominioTangerine.Entidades.M2.UsuarioM2)p).activo != null)
                {
                    string nueva;
                    nueva = NuevaContrasenaGenerar();

                    ((DominioTangerine.Entidades.M2.UsuarioM2)p).contrasena = GetMD5(nueva);
                    bool resultado2;

                    LogicaTangerine.Comando<Boolean> commandModificarContrasena = FabricaComandos.modificarContrasenaUsuario(p);
                    resultado2 = commandModificarContrasena.Ejecutar();

                    if (resultado2)
                    {
                        _vista.elmensaje = "Su nueva contraseña es: " + nueva +
                            " Ingrese al sistema para cambiarla por una propia.";
                        string asunto = "Tangerine - Cambio de contraseña";
                        Entidad datoCorreo =
                            DominioTangerine.Fabrica.FabricaEntidades.ObtenerDatosCorreo(asunto, _vista.elcorreo, _vista.elmensaje);

                        Comando<bool> cmdEnvio = LogicaTangerine.Fabrica.FabricaComandos.EnviarCorreoG(datoCorreo);
                        bool envio;

                        envio = cmdEnvio.Ejecutar();


                    }
                    else
                    {
                        _vista.elmensaje = "Datos incorrectos, comuniquese con el administrador del sistema.";
                    }

                }
                else
                {
                    _vista.elmensaje = "Usuario invalido";
                }

            }
            catch(Exception e)
            {
                _vista.elmensaje = "Error Inesperado - Intente nuevamente";
            }

        }

        /// <summary>
        /// Metodo que genera una nueva contraseña
        /// </summary>
        private string NuevaContrasenaGenerar()
        {
            string nueva;
            char[] caracteres = {
                    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
                    'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
                    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 
                    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 
                    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_'
            };
            char[] identificador = new char[10];
            byte[] numeroAleatorio = new byte[10];

            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            rngCsp.GetBytes(numeroAleatorio);
            for (int idx = 0; idx < identificador.Length; idx++)
            {
                int pos = numeroAleatorio[idx] % caracteres.Length;
                identificador[idx] = caracteres[pos];
            }

            return nueva = new string(identificador);
        }


        /// <summary>
        /// Método para encriptar la contraseña del usuario,se utiliza al crear el usuario y en el login para comparar
        /// la contraseña colocada y la contraseña real
        /// </summary>
        /// <param name="contrasenia"></param>
        /// <returns></returns>
        private string GetMD5(string contrasenia)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();

            ASCIIEncoding encoding = new ASCIIEncoding();

            StringBuilder sb = new StringBuilder();

            byte[] stream = md5.ComputeHash(encoding.GetBytes(contrasenia));

            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }

            return sb.ToString();
        }




    }
}
