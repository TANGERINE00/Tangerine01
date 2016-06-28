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
using System.Web.Security.AntiXss;

namespace Tangerine.GUI.M1
{
    public partial class VerEmpleado : System.Web.UI.Page, IContratoVerEmpleados
    {
        private PresentadorConsultaEmpleadoId presentador;

        #region Contrato

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

        #endregion

        public VerEmpleado()
        {
            this.presentador = new PresentadorConsultaEmpleadoId(this); 
        }

        /// <summary>
        /// Carga la ventana Ver Empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         protected void Page_Load(object sender, EventArgs e)
         {

             int Empleadoid = int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString[ResourceGUIM1.Empleado], false));
             

             if (!IsPostBack)
             {
                 presentador.cargarEmpleadosId(Empleadoid);

             }
         }
    }
}
