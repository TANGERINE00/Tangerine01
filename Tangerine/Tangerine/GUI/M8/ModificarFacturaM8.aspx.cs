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
    public partial class ModificarFacturaM8 : System.Web.UI.Page, IContratoModificarFactura
    {
        PresentadorModificarFactura _presentador;

        #region Implementacion de Contrato

        public string textNumeroFactura
        {
            get { return this.textNumeroFactura_M8.Value; }
            set { this.textNumeroFactura_M8.Value = value; }
        }
        public string textFecha
        {
            get { return this.textFecha_M8.Value; }
            set { this.textFecha_M8.Value = value; }
        }
        public string textDescripcion
        {
            get { return this.textDescripcion_M8.Value; }
            set { this.textDescripcion_M8.Value = value; }
        }
        public string textCliente
        {
            get { return this.textCliente_M8.Value; }
            set { this.textCliente_M8.Value = value; }
        }
        public string textProyecto
        {
            get { return this.textProyecto_M8.Value; }
            set { this.textProyecto_M8.Value = value; }
        }
        public string textMonto
        {
            get { return this.textMonto_M8.Value; }
            set { this.textMonto_M8.Value = value; }
        }
        public string textTipoMoneda
        {
            get { return this.textTipoMoneda_M8.Value; }
            set { this.textTipoMoneda_M8.Value = value; }
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

        public ModificarFacturaM8()
        {
            _presentador = new PresentadorModificarFactura(this);
        }

        #endregion

        /// <summary>
        /// Carga la ventana Modificar Factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="IdFac">Para manejar la alerta a UI de acciones positivas en otras ventanas,
        /// no obligatorio</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                textNumeroFactura = Request.QueryString[ResourceGUIM8.idFac]; ;
                if (!IsPostBack)
                {
                    _presentador.llenarModificar();
                }
            }
            catch
            {
                Response.Redirect(ResourceGUIM8.volver);
            }
        }

        /// <summary>
        /// Evento que se dispara con el boton de modificar factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonModificarFactura_Click(object sender, EventArgs e)
        {
            Boolean validar = _presentador.ModificarFactura();
            if (validar)
            {
                Response.Redirect(ResourceGUIM8.Factura + textNumeroFactura);
            }
        }
    }
}