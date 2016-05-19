using LogicaTangerine.M2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
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
                empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonReg + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.CloseTR;

                empleado += ResourceGUIM2.OpenTR;
                empleado += ResourceGUIM2.OpenTD + "referencia #O52" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "luis" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "Rodriguez" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "23617644" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "Programador" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonReg + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.CloseTR;
            }
        }

        [WebMethod] 
        public static string ObtenerUsuarioDefault(string nombreUsuario, string apellidoUsuario)
        {
            string resultado = "";

            resultado = LogicaAgregarUsuario.CrearUsuarioDefault(nombreUsuario, apellidoUsuario);

            return resultado;
        }

        [WebMethod]
        protected void botonCrear_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Entro");
        }
    }
}