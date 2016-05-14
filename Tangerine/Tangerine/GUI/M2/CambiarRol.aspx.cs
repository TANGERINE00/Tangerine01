using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M2;

namespace Tangerine.GUI.M2
{
    public partial class CambiarRol : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaModificarRol.prueba();
        }
    }
}