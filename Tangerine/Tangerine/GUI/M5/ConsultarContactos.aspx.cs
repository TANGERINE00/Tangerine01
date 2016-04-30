using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M5;

namespace Tangerine.GUI.M5
{
    public partial class ConsultarContactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaTangerine.M5.Class1 prueba = new Class1();
            prueba.init();
            
        }
    }
}