using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M4;
using LogicaTangerine.M7;
using Tangerine_Presentador.M8;
using Tangerine_Contratos.M8;


namespace Tangerine.GUI.M8
{
    public partial class GenerarFacturaM8 : System.Web.UI.Page, IContratoGenerarFactura
    {

        #region Implementacion de Contrato

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
        #endregion

        #region Constructor
        PresentadorGenerarFactura _presentador;

        public GenerarFacturaM8()
        {
            _presentador = new PresentadorGenerarFactura(this);
        }

        #endregion

        DateTime _fechaEmision = DateTime.Now;
        DateTime _fechaUltimoPago = DateTime.Now;
        static int _montoTotal = 0;
        int _montoRestante = 0;
        string _tipoMoneda = String.Empty;
        string _Descripcion = String.Empty;
        int _estatus = 0;
        static int _proyectoId = 0;
        static int _companiaId = 0;
        LogicaM4 logicaCompania = new LogicaM4();
        LogicaProyecto logicaProyecto = new LogicaProyecto();
        //Proyecto proyecto = new Proyecto();
        //Compania compania = new Compania();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.compania = Request.QueryString[ResourceGUIM8.idC];
            this.proyecto = Request.QueryString[ResourceGUIM8.idP];
            this.fecha = DateTime.Now.ToString(ResourceGUIM8.dateTipe);
            this.monto = Request.QueryString[ResourceGUIM8.amount];
            this.
            _presentador.llenarGenerar();/*
            compania = logicaCompania.ConsultCompany(_companiaId);
            textCompania_M8.Value = compania.NombreCompania;
            proyecto = logicaProyecto.consultarProyecto(_proyectoId);
            textProyecto_M8.Value = proyecto.Nombre;*/
        }

        /// <summary>
        /// Evento que se dispara con el boton de generar factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonGenerarFactura_Click(object sender, EventArgs e)
        {
            this.compania = Request.QueryString[ResourceGUIM8.idC];
            this.proyecto = Request.QueryString[ResourceGUIM8.idP];
            _presentador.GenerarFactura();
            Response.Redirect(ResourceGUIM8.volverModificado);
            /* if (textDescripcion_M8.Value.Equals(""))
             {
                 string script = "<script type=\"text/javascript\">alert('No puede dejar el campo de descripción vacío.');</script>";
                 ClientScript.RegisterClientScriptBlock(this.GetType(), "Waring", script);
             }
             else
             {*/

            //    _Descripcion = textDescripcion_M8.Value;
            //    _fechaEmision = DateTime.Parse(textFecha_M8.Value);
            //    _fechaUltimoPago = DateTime.Parse(textFecha_M8.Value);
            //    int _companiaId = int.Parse(Request.QueryString["IdCompania"]);
            //    int _proyectoId = int.Parse(Request.QueryString["IdProyecto"]);
            //    _tipoMoneda = textTipoMoneda_M8.Value;
            //    Facturacion factura = new Facturacion(_fechaEmision, _fechaUltimoPago, int.Parse(Request.QueryString["Monto"]), int.Parse(Request.QueryString["Monto"]), _tipoMoneda, _Descripcion, 0, _proyectoId, _companiaId);
            //    LogicaM8 facturaLogic = new LogicaM8();
            //    facturaLogic.AddNewFactura(factura);
            //    Server.Transfer("ConsultarFacturaM8.aspx");
            ////}


        }
    }
}