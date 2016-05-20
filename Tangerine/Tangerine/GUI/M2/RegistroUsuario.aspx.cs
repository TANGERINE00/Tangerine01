using DominioTangerine;
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
                empleado += ResourceGUIM2.OpenTD + "1" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "Armando" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "Perez" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "20183273" + ResourceGUIM2.CloseTD;
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

        protected void btnCrear_Click(object sender, EventArgs e)
        {

            string rol = rolDefault.Value;
            string nombreUsuario = userDefault.Value;
            string contraseniaUsuario = passwordDefault.Value;
            string fichaEmpleado = fichaEmp.Value;

            LogicaAgregarUsuario.PrepararUsuario( nombreUsuario, contraseniaUsuario, rol, int.Parse(fichaEmpleado) );
        }
    }
}