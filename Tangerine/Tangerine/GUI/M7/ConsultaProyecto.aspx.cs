using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine;
using DominioTangerine;
using LogicaTangerine.M10;
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
        public string alertaClase
        {
            set { alert.Attributes["class"] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes["role"] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string _estado = Request.QueryString["estado"];

            if (!IsPostBack)
            {
                presentador.Alerta(_estado);
                presentador.cargarConsultarProyectos();
            }
        }


    }
}