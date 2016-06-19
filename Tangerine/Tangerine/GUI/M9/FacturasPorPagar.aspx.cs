using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine;
using LogicaTangerine.M9;
using DominioTangerine;
using Tangerine_Contratos;
using Tangerine_Presentador;

namespace Tangerine.GUI.M9
{
    public partial class WebForm1 : System.Web.UI.Page , Tangerine_Contratos.M9.IContratoFacturasPorPagar
    {
        public Tangerine_Presentador.M9.PresentadorFacturasPorPagar presentador;
        
        public WebForm1()
        {

            this.presentador = new Tangerine_Presentador.M9.PresentadorFacturasPorPagar(this);

        }

        public string factura
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

        /// <summary>
        /// Metodo de carga de los elementos de la ventana.
        /// </summary>
        /// recibe un solo parametro, id de la compania para consultar todas las facturas asociadas, este parametro se recibe via URL
        /// <param name="id">Entero, representa el id de la empresa seleccionada</param>
        protected void Page_Load(object sender, EventArgs e)
        {
           int idComp = int.Parse(Request.QueryString.Get("id"));
           presentador.LlenarFacturas(idComp);   

        }
    }
}