using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
//using DatosTangerine.M8;
//using LogicaTangerine.M8;
using LogicaTangerine.M4;
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
            get
            {
                return Request.QueryString[ResourceGUIM8.idF];
            }

            set
            {
                Request.QueryString[ResourceGUIM8.idF] = value;
            }
        }

        public string destinatario
        {
            get
            {
                return this.textDestinatario_M8.Value;
            }

            set
            {
                this.textDestinatario_M8.Value = value;
            }
        }

        public string asunto
        {
            get
            {
                return this.textAsunto_M8.Value;
            }

            set
            {
                this.textAsunto_M8.Value = value;
            }
        }

        public string mensaje
        {
            get
            {
                return this.textMensaje_M8.Value;
            }

            set
            {
                this.textMensaje_M8.Value = value;
            }
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

        //public static Facturacion theFactura = null;
        string _destinatario = String.Empty;
        string _asunto = String.Empty;
        string _mensaje = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.numero = Request.QueryString[ResourceGUIM8.idF];
            if (!IsPostBack)
            {
                _presentador.correofactura();
                //LogicaM8 facturaLogic = new LogicaM8();
                //LogicaM4 companiaLogic = new LogicaM4();
                //theFactura = facturaLogic.SearchFactura(idFac);

                //Compania compania = companiaLogic.ConsultCompany(int.Parse(theFactura.idCompaniaFactura.ToString()));
                //Destinatario = compania.EmailCompania;
                //Proyecto proyecto = facturaLogic.SearchProyectoFactura(int.Parse(theFactura.idProyectoFactura.ToString()));
                //Asunto = "Recordatorio de Pago - Proyecto: " + proyecto.Nombre + "";
                //Mensaje += "Saludos Cordiales, Compañia: " + compania.NombreCompania + ".\n";
                //Mensaje += "Se le recuerda que tiene una factura por pagar, por un monto de: " + theFactura.montoFactura.ToString() + " "
                //            + theFactura.tipoMoneda + ".";
            }
        }

        protected void buttonEnviarCorreo_Click(object sender, EventArgs e)
        {
            _destinatario = textDestinatario_M8.Value;
            _asunto = textAsunto_M8.Value;
            _mensaje = textMensaje_M8.Value;

            //CorreoM8 correo = new CorreoM8();
            //correo.enviarCorreoGmail(_asunto, _destinatario, _mensaje);
            Server.Transfer("ConsultarFacturaM8.aspx");
        }
    }
}