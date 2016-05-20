using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M8;


namespace Tangerine.GUI.M8
{
    public partial class GenerarFacturaM8 : System.Web.UI.Page
    {
        DateTime _fechaEmision = DateTime.Now;
        DateTime _fechaUltimoPago = DateTime.Now;
        int _montoTotal = 0;
        int _montoRestante = 0;
        string _tipoMoneda = String.Empty;
        string _Descripcion = String.Empty;
        int _estatus = 0;
        int _proyectoId = 0;
        int _companiaId = 0;

        protected void Page_Load( object sender, EventArgs e )
        {
            textFecha_M8.Value = DateTime.Now.ToString("dd/MM/yyyy");
            textDescripcion_M8.Value = null;
        }

        /// <summary>
        /// Evento que se dispara con el boton de generar factura
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonGenerarFactura_Click( object sender, EventArgs e )
        {
            if (textDescripcion_M8.Value.Equals(""))
            {
                string script = "<script type=\"text/javascript\">alert('No puede dejar el campo de descripción vacío.');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "Waring", script);
            }
            else
            {
                _montoTotal = int.Parse(textMonto_M8.Value);
                _fechaEmision = DateTime.Parse(textFecha_M8.Value);
                _fechaUltimoPago = DateTime.Now;
                _montoRestante = int.Parse(textMonto_M8.Value);
                _Descripcion = textDescripcion_M8.Value;
                _tipoMoneda = "Bolivares";

                Facturacion factura = new Facturacion(_fechaEmision, _fechaUltimoPago, _montoTotal, _montoRestante, _tipoMoneda, _Descripcion, 0, 1, 1);
                LogicaM8 facturaLogic = new LogicaM8();
                facturaLogic.AddNewFactura(factura);
                Server.Transfer("ConsultarFacturaM8.aspx");
            }
  

        }
    }
}