using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using Tangerine_Presentador.M8;
using Tangerine_Contratos.M8;
using System.Text.RegularExpressions;


namespace Tangerine.GUI.M8
{
    public partial class GenerarFacturaM8 : System.Web.UI.Page, IContratoGenerarFactura
    {

        #region Implementacion de Contrato
        public string moneda
        {
            get { return this.textTipoMoneda_M8.Value; }
            set { this.textTipoMoneda_M8.Value = value; }
        }

        public string fecha
        {
            get { return this.textFecha_M8.Value; }
            set { this.textFecha_M8.Value = value; }
        }

        public string compania
        {
            get { return this.textCompania_M8.Value; }
            set { this.textCompania_M8.Value = value; }
        }

        public string proyecto
        {
            get { return this.textProyecto_M8.Value; }
            set { this.textProyecto_M8.Value = value; }
        }

        public string descripcion
        {
            get { return this.textDescripcion_M8.Value; }
            set { this.textDescripcion_M8.Value = value; }
        }

        public string monto
        {
            get { return this.textMonto_M8.Value; }
            set { this.textMonto_M8.Value = value; }
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

        DateTime _fechaEmision = DateTime.Now;
        DateTime _fechaUltimoPago = DateTime.Now;
        static int _montoTotal = 0;
        int _montoRestante = 0;
        string _tipoMoneda = String.Empty;
        string _Descripcion = String.Empty;
        int _estatus = 0;
        static int _proyectoId = 0;
        static int _companiaId = 0;
        #endregion

        #region Constructor
        PresentadorGenerarFactura _presentador;

        public GenerarFacturaM8()
        {
            _presentador = new PresentadorGenerarFactura(this);
        }

        #endregion

        /// <summary>
        /// Carga la ventana Generar Factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="idC">Id de la compania del proyecto</param>
        /// <param name="idP">Id del proyecto</param>
        /// <param name="amount">Monto para hacer la factura</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try 
            {
            this.compania = Request.QueryString[ResourceGUIM8.idC];
            this.proyecto = Request.QueryString[ResourceGUIM8.idP];            
            this.monto = Request.QueryString[ResourceGUIM8.amount];
            _presentador.llenarGenerar();
            }
            catch
            {
                Response.Redirect(ResourceGUIM8.volver);
            }
        }

        /// <summary>
        /// Evento que se dispara con el boton de generar factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonGenerarFactura_Click(object sender, EventArgs e)
        {
            this.compania = Request.QueryString[ResourceGUIM8.idC];
            _presentador.GenerarFactura();
            Response.Redirect(ResourceGUIM8.Factura + _presentador.UltimaFactura().ToString());
        }
    }
}