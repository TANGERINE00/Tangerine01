using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M1;
using Tangerine_Contratos.M1;
using Tangerine_Presentador.M1;
//using LogicaTangerine.M8;

namespace Tangerine.GUI.M1
{
    public partial class RecuperarContraseñaPregunta : System.Web.UI.Page, IContratoRecuperarContrasenia
    {
        //LogicaM1 _logicaM1 = new LogicaM1();
        //string _correo = String.Empty;
        //string _usuario = String.Empty;

        PresentadorRecuperarContrasenia presentador;

        #region Contrato

        /// <summary>
        /// textBox del correo
        /// </summary>
        public string elcorreo
        {
            get { return correo.Value; }
            set { correo.Value = value; }
        }

        /// <summary>
        /// textBox de la contraseña
        /// </summary>
        public string elusuario
        {
            get { return usuario.Value; }
            set { usuario.Value = value; }
        }

        /// <summary>
        /// textBox del mensaje
        /// </summary>
        public string elmensaje
        {
            get { return mensaje.Text; }
            set { mensaje.Text = value; }
        }

        #endregion


        public RecuperarContraseñaPregunta()
        {
            this.presentador = new PresentadorRecuperarContrasenia(this);
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Validar_Correo(object sender, EventArgs e)
        {
            presentador.RecuperarContraseña();
            
            //Usuario nuevoUsuario = new Usuario();
            //string _mensaje;
            //_correo = correo.Value.ToString();

            //_usuario = usuario.Value.ToString();

            //if (_logicaM1.ValidarCorreoUsuario(_correo, _usuario))
            //{
            //    //mensaje.Text = "Correcto";
            //    string nueva = _logicaM1.GenerarNuevaContrasena(_correo, _usuario);
            //    //CorreoM8 correoEnvio = new CorreoM8();
            //    _mensaje = "Su nueva contraseña para ingresar al sistema Tangerine es " + nueva +
            //            ". Por favor ingrese al sistema para cambiarla por una propia.";
            //    //correoEnvio.enviarCorreoGmail("Cambio contraseña - Tangerine", _correo, _mensaje);

            //    mensaje.Text = "Su nueva contraseña es: " + nueva + " Ingrese al sistema para cambiarla por una propia.";
            //}
            //else
            //{
            //    mensaje.Text = "Datos incorrectos, comuniquese con el administrador del sistema.";
            //}

        }
    }
}