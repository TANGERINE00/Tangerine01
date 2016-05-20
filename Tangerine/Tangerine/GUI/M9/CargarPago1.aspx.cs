using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M8;
using LogicaTangerine.M9;
using DominioTangerine;


namespace Tangerine.GUI.M9
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        public string cliente
        {
            get
            {
                return this.seccion1.Text;
            }

            set
            {
                this.seccion1.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //En este try atrapo el valor del id del Contacto si existe
            //para luego ser eliminado de los contactos de la empresa
            int identificador = int.Parse(Request.QueryString["id"]);

            LogicaM8 prueba = new LogicaM8();
            Facturacion factura = prueba.SearchFactura(identificador);

            if (factura != null)
            {
                cliente += ResourceLogicaM9.AbrirNombreCliente + factura.descripcionFactura + ResourceLogicaM9.CerrarNombreCliente;
            }
        }
    }
}