using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M6;
using System.Diagnostics;

namespace Tangerine.GUI.M6
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
       
public void submit(object sender, EventArgs e)
{
   lbl1.Text="Your name is ";
   LogicaPropuesta logicaPropuesta = new LogicaPropuesta();
   Boolean siBorro;

   siBorro = logicaPropuesta.BorrarPropuesta("Modulo de prueba");

}
    }
}