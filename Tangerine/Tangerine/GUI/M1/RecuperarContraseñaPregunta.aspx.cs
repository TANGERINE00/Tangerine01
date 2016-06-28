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

        }

        protected void VolverBtn(object sender, EventArgs e)
        {
            presentador.Regresar();

        }
    }
}