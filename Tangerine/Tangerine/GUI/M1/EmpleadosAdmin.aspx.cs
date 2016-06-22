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


namespace Tangerine.GUI.M1
{
    public partial class EmpleadosAdmin : System.Web.UI.Page, IContratoConsultaEmpleados
    {
        private PresentadorConsultaEmpleado presentador;
        private PresentadorConsultaEmpleado presentador1;

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

        public string button
        {
            get
            {
                return this.nuevoempleado.Text;
            }
            set
            {
                this.nuevoempleado.Text = value;
            }
        }

      
         public EmpleadosAdmin()
        {
            this.presentador = new PresentadorConsultaEmpleado(this);
            this.presentador1 = new PresentadorConsultaEmpleado(this);
        }

       



        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                presentador.cargarConsultarEmpleados();
            }

        }

        protected void Activar_Empleado(object sender, EventArgs e)
        {
            int Empleadoid = int.Parse(Request.QueryString["id"]);
            presentador1.CambiarEstatus(Empleadoid);
            Response.Redirect("EmpleadosAdmin.aspx");
        }

    }
}