using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.Comandos;
using Tangerine_Contratos.M9;
using Tangerine_Presentador.M9;


namespace Tangerine.GUI.M9
{
    public partial class WebForm5 : System.Web.UI.Page , IContratoSeleccionCompania
    {
        public PresentadorSeleccionCompania presentador;

            public WebForm5 ()
            {

                this.presentador = new PresentadorSeleccionCompania(this);

            }
        public string company
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

        /// <summary>
        /// Metodo de carga de los elementos de la ventana.
        /// </summary>
        /// No recibe ningun parametro, solo muestra el listado de las companias que tiene proyectos.
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!IsPostBack)
            {
                presentador.LlenarCompanias();

            }
            }

        }
    }