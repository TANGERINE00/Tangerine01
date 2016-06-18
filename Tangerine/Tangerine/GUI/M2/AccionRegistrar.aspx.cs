using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tangerine.GUI.M2
{
    public partial class AccionRegistrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int numFicha = int.Parse(Request.QueryString["idFicha"]);
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
        }
    }
}