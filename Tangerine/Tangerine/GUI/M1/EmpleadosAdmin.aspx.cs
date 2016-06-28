using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M10;
using System.Globalization;
using Tangerine_Contratos.M10;
using Tangerine_Presentador.M10;
using System.Web.Security.AntiXss;


namespace Tangerine.GUI.M1
{
    public partial class EmpleadosAdmin : System.Web.UI.Page, IContratoConsultaEmpleados
    {
        private PresentadorConsultaEmpleado presentador;


        #region Contrato
        public string empleado
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

        public Literal Tabla
        {
            get
            {
                return tabla;
            }
            set
            {
                tabla = value;
            }
        }


        public string alertaClase
        {
            set { alerta.Attributes[ResourceGUIM10.alertaC] = value; }
        }

        public string alertaRol
        {
            set { alerta.Attributes[ResourceGUIM10.alertaR] = value; }
        }

        public string alertas
        {
            set { alerta.InnerHtml = value; }
        }

        #endregion




        public EmpleadosAdmin()
        {
            this.presentador = new PresentadorConsultaEmpleado(this);

        }

        /// <summary>
        /// Carga la ventana Consulta Empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                int Empleadoid = int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString[ResourceGUIM10.IdEmpleado], false));
                presentador.AlertasCase();
                presentador.CambiarEstatus(Empleadoid);
                if (!IsPostBack) 
                {
                    presentador.cargarConsultarEmpleados(); 
                }
            }
            catch (Exception)
            {
                Response.Redirect(ResourceGUIM10.Dashboard);
            }
        }

        protected void Activar_Empleado(object sender, EventArgs e)
        {
            int Empleadoid = int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString[ResourceGUIM10.IdEmpleado], false));

        }

    }
}