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
    public partial class ConsultarFacturaM8 : System.Web.UI.Page, IContratoConsultarFactura
    {
        PresentadorConsultaFactura _presentador;

        public string facturasCreadas
        {
            get
            {
                return this.tabla.Text;
            }

            set
            {
                this.tabla.Text = value;
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

        public ConsultarFacturaM8()
        {
            _presentador = new PresentadorConsultaFactura(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Esto ocurre cuando se modifica una factura, se muestra mensaje a usuario
                string _estado = Request.QueryString["estado"];
                if (_estado != null)
                    _presentador.Alerta(_estado);
            }
            catch
            {
                //No hago nada, no es obligatorio el parametro
            }
            if (!IsPostBack)
            {
                _presentador.cargarConsultarFacturas();
            }
        }
    }
}
