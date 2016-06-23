using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
//using DatosTangerine.M8;
//using LogicaTangerine.M8;
using Tangerine_Presentador.M8;
using Tangerine_Contratos.M8;

namespace Tangerine.GUI.M8
{
    public partial class EnviarCorreoM8 : System.Web.UI.Page, IContratoCorreo
    {

        #region presentador
        PresentadorCorreo _presentador;

        public EnviarCorreoM8()
        {
            _presentador = new PresentadorCorreo(this);
        }
        #endregion

        #region contrato
        public string numero
        {
            get { return this.textNumeroFactura.Text; }
            set { this.textNumeroFactura.Text = value; }
        }

        public string destinatario
        {
            get { return this.textDestinatario_M8.Value; }
            set { this.textDestinatario_M8.Value = value; }
        }

        public string asunto
        {
            get { return this.textAsunto_M8.Value; }
            set { this.textAsunto_M8.Value = value; }
        }

        public string mensaje
        {
            get { return this.textMensaje_M8.Value; }
            set { this.textMensaje_M8.Value = value; }
        }

        public string alertaClase
        {
            set { alert.Attributes[ResourceGUIM8.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[ResourceGUIM8.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                textNumeroFactura.Text = Request.QueryString[ResourceGUIM8.idFac]; ;
                if (!IsPostBack)
                {
                    _presentador.correofactura();
                }
            }
            catch
            {
                Response.Redirect(ResourceGUIM8.volver);
            }
        }

        protected void buttonEnviarCorreo_Click(object sender, EventArgs e)
        {

            if (_presentador.enviarCorreo())
                Server.Transfer("ConsultarFacturaM8.aspx");
        }
    }
}