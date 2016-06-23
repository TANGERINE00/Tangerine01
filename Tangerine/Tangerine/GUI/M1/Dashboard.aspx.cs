using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M10;
using Tangerine_Contratos.M1;
using Tangerine_Presentador.M1;

namespace Tangerine.GUI.M1
{
    public partial class Dashboard : System.Web.UI.Page, IcontratoDashboard
    {
      
        PresentadorDashboard presentador;

        #region Contrato
        public Literal VistaForm
        {
            get
            {
                return FormViewProjects;
            }
            set
            {
                FormViewProjects = value;
            }
        }

        #endregion

        public Dashboard()
        {
            this.presentador = new PresentadorDashboard(this);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                presentador.CargarDashBoard();
               
            }
        }

      
    }
}