using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine;
using DominioTangerine;
using LogicaTangerine.M10;
using LogicaTangerine.M6;
using LogicaTangerine.M4;
using LogicaTangerine.M7;
using Tangerine_Contratos.M7;
using Tangerine_Presentador.M7;

namespace Tangerine.GUI.M7
{
    public partial class ConsultaProyecto : System.Web.UI.Page, IContratoConsultaProyecto
    {
        PresentadorConsultaProyecto presentador;

        public ConsultaProyecto()
        {
            this.presentador = new PresentadorConsultaProyecto(this);
        }

        #region Contrato
        public Literal Tabla
        {
            get
            {
                return tablaProyectos;
            }
            set
            {
                tablaProyectos = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                presentador.cargarConsultarProyectos();
            }
        }


    }
}