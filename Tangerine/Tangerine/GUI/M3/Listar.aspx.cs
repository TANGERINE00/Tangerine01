using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using DatosTangerine.M3;
using LogicaTangerine.M3;
using Tangerine.GUI.M3;
using Tangerine_Contratos.M3;
using Tangerine_Presentador.M3;


namespace Tangerine.GUI.M3
{
    public partial class Listar : System.Web.UI.Page, IContratoListarLeads
    {
        PresentadorListarLeads presentador;

        public Listar()
        {
            this.presentador = new PresentadorListarLeads(this);
        }
        
        public Literal ClientePotencial
        {
            get
            {
                return Lista;
            }

            set
            {
                Lista = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                presentador.Llenar();
            }

        }
    }
}
  
 
