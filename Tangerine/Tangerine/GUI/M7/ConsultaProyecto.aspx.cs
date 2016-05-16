using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine;
using LogicaTangerine.M10;
using LogicaTangerine.M6;
using LogicaTangerine.M4;
using LogicaTangerine.M7;

namespace Tangerine.GUI.M7
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        public string proyecto
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

        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaProyecto pruebaM7 = new LogicaProyecto();
            LogicaM4 pruebaM4 = new LogicaM4();
            LogicaPropuesta pruebaM6 = new LogicaPropuesta();
        }
    }
}