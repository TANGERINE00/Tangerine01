using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M6;
using LogicaTangerine.M4;
using Tangerine_Contratos.M6;
using Tangerine_Presentador.M6;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace Tangerine.GUI.M6
{
    public partial class ModificarRequerimiento : System.Web.UI.Page, IContratoModificarRequerimiento
    {

        string idPropuesta;

        PresentadorModificarRequerimiento presenter;
     public ModificarRequerimiento()
        {
            this.presenter = new PresentadorModificarRequerimiento(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            idPropuesta = Request.QueryString.Get("id");
      //      presenter.llenarVista();

        }


        protected void ModificarPropuesta_Click(object sender, EventArgs e)
        {
          //  presenter.ModificarRequerimiento();

            Server.Transfer("ConsultarPropuesta.aspx", true);
        }

       
        public string IdPropuesta
        {
            get { return idPropuesta; }
        }
      
    
      
    }
}