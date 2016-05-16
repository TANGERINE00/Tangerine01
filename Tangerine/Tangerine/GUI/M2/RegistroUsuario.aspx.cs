using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tangerine.GUI.M2
{
    public partial class RegistroUsuario : System.Web.UI.Page
    {
        public string empleado
        {
            get 
            {
                return this.tablaempleados.Text;
            }
            set
            {
                this.tablaempleados.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                empleado += ResourceGUIM2.OpenTR;
                empleado += ResourceGUIM2.OpenTD + "referencia #O52" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "gerardo" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "Astone" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "23617644" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "Programador" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonReg;
                empleado += ResourceGUIM2.CloseTR;
            }
        }
    }
}