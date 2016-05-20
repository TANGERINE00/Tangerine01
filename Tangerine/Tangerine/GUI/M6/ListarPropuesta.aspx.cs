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
    public partial class AgregarRequerimiento : System.Web.UI.Page
    {
     
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            }

        public void btn_Elimina(String idPropuesta)
        {

            LogicaPropuesta logicaPropuesta = new LogicaPropuesta();
            Boolean siBorro;

            siBorro = logicaPropuesta.BorrarPropuesta(idPropuesta);

        }
        

    }
}