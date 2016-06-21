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

        public ModificarFacturaM8()
        {
            _presentador = new PresentadorModificarFactura(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            textNumeroFactura = Request.QueryString["idFac"]; ;
            if (!IsPostBack)
            {
                _presentador.llenarModificar();
            }
        }
















        //int _numeroFactura = 0;
        //DateTime _fechaEmision = DateTime.Now;
        //DateTime _fechaUltimoPago = DateTime.Now;
        //int _montoTotal = 0;
        //static int _montoRestante = 0;
        //static string _tipoMoneda = String.Empty;
        //string _descripcion = String.Empty;
        //int _estatus = 0;
        //int _proyectoId = 0;
        //int _companiaId = 0;
        //public static Facturacion theFactura = null;



        /// <summary>
        /// Evento que se dispara con el boton de modificar factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonModificarFactura_Click(object sender, EventArgs e)
        {
            ///*  if (textDescripcion_M8.Value.Equals(""))
            //  {
            //      string script = "<script type=\"text/javascript\">alert('No puede dejar el campo de descripción vacío.');</script>";
            //      ClientScript.RegisterClientScriptBlock(this.GetType(), "Waring", script);
            //  }
            //  else
            //  {*/
            //_numeroFactura = int.Parse(textNumeroFactura_M8.Value);
            //_fechaEmision = DateTime.Parse(textFecha_M8.Value);
            //_fechaUltimoPago = DateTime.Now;
            //_companiaId = int.Parse(theFactura.idCompaniaFactura.ToString());
            //_proyectoId = int.Parse(theFactura.idProyectoFactura.ToString());
            //_descripcion = textDescripcion_M8.Value;
            //_estatus = theFactura.estatusFactura;
            //_montoTotal = int.Parse(textMonto_M8.Value);
            //// _montoRestante = int.Parse(textMonto_M8.Value);

            //Facturacion factura = new Facturacion(_numeroFactura, _fechaEmision, _fechaUltimoPago, _montoTotal, _montoRestante, _tipoMoneda, _descripcion, _estatus,
            //    _proyectoId, _companiaId);
            //LogicaM8 facturaLogic = new LogicaM8();
            //facturaLogic.ChangeExistingFactura(factura);
            //Server.Transfer("ConsultarFacturaM8.aspx");
            ////}
        }

    }

}