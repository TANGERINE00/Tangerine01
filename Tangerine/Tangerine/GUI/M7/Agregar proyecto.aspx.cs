using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M7;

namespace Tangerine.GUI.M7
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Boolean _verificarCreacion =  false;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            Proyecto _proyecto = new Proyecto(0, textInputNombreProyecto.Value, textInputCodigo.Value, DateTime.Parse(textInputFechaInicio.Value),
                                              DateTime.Parse(textInputFechaEstimada.Value),Double.Parse(textInputCosto.Value), "", "", "En curso",
                                              "", 0, 0, 0);
            LogicaProyecto _logica =  new LogicaProyecto();
            if (_logica.agregarProyecto(_proyecto))
            {
                //colocar un mensaje de creacion con exito y vaciar text.
            }
            else
            { 
                //colocar  un mensaje de error en la creacion
            }
        } 
    }
}