using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M10;
using DominioTangerine;
using Tangerine_Contratos.M10;
using Tangerine_Presentador.M10;
using System.Globalization;

namespace Tangerine.GUI.M1
{
    public partial class VerEmpleado : System.Web.UI.Page, IContratoVerEmpleados
    {
        private PresentadorConsultaEmpleadoId presentador;

        public Literal FormViewEmployees
        {
            get
            {
                return FormViewEmployee;
            }
            set
            {
                FormViewEmployee = value;
            }
        }

         public VerEmpleado()
        {
            this.presentador = new PresentadorConsultaEmpleadoId(this); 
        }

         protected void Page_Load(object sender, EventArgs e)
         {

             int Empleadoid = int.Parse(Request.QueryString["EmployeeId"]);

             if (!IsPostBack)
             {
                 presentador.cargarEmpleadosId(Empleadoid);

             }
         }
    }
}
