using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Presentador.M8;
using Tangerine_Contratos.M8;
using ExcepcionesTangerine;
using System.Text.RegularExpressions;

namespace Tangerine.GUI.M8
{
    public partial class Factura : System.Web.UI.Page, IContratoFactura
    {
        PresentadorFactura _presentador;

        #region Implementacion de Contrato

        public string textNumeroFactura
        {
            get { return this.textNumeroFactura_M8.Text; }
            set { this.textNumeroFactura_M8.Text = value; }
        }
        public string textFecha
        {
            set { this.textFecha_M8.Text = value; }
        }
        public string textDescripcion
        {
            set { this.textDescripcion_M8.Text = value; }
        }
        public string textCliente
        {
            set { this.textCliente_M8.Text = value; }
        }
        public string textProyecto
        {
            set { this.textProyecto_M8.Text = value; }
        }
        public string textMonto
        {
            set { this.textMonto_M8.Text = value; }
        }
        public string textDireccion
        {
            set { this.textDireccion_M8.Text = value; }
        }
        public string textRif
        {
            set { this.textRif_M8.Text = value; }
        }
        public string textTipoMoneda
        {
            set { this.textTipoMoneda_M8.Text = value; }
        }
        public string textIva
        {
            set { this.textIva_M8.Text = value; }
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

        #region Constructor

        public Factura()
        {
            _presentador = new PresentadorFactura(this);
        }

        #endregion

        /// <summary>
        /// Carga la ventana Ver Factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="idFac">Para manejar la alerta a UI de acciones positivas en otras ventanas,
        /// no obligatorio</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                textNumeroFactura = Request.QueryString[ResourceGUIM8.idFac]; ;
                if (!IsPostBack)
                {
                    _presentador.llenarFactura();
                }
            }
            catch
            {
                Response.Redirect(ResourceGUIM8.volver);
            }
        }
    }
}