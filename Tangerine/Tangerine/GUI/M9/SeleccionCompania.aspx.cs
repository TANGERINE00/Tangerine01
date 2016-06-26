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
        public string alertaClase
            {
                set { alert.Attributes[ResourceLogicaM9.alertClase] = value; }
            }

        public string alertaRol
        {
            set { alert.Attributes[ResourceLogicaM9.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
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
        public int StatusAccion()
        {
            try
            {
                return int.Parse(Request.QueryString[ResourceLogicaM9.Status]);
            }
            catch (ArgumentNullException ex)
            {
                return 0;
            }
        }

        /// <summary>
        /// Metodo de carga de los elementos de la ventana.
        /// </summary>
        /// No recibe ningun parametro, solo muestra el listado de las companias que tiene proyectos.
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            
            
                presentador.CargarPagina();

            
            }

        }
    }