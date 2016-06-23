using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine;
using DominioTangerine;
using Tangerine_Contratos.M9;
using Tangerine_Presentador.M9;

namespace Tangerine.GUI.M9
{
    public partial class PagosPorCompania : System.Web.UI.Page , IContratoPagosPorCompania
    {

        public PresentadorPagosPorCompania presentador;

        public PagosPorCompania()
        {

            this.presentador = new PresentadorPagosPorCompania(this);

        }

        public string pago
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
        /// Metodo para cargar los pagos realizados por una empresa 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int idComp = int.Parse(Request.QueryString.Get("id"));
            presentador.LlenarPagos(idComp);
        }
    }
}