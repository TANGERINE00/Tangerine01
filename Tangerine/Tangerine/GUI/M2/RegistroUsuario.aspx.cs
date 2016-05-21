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
        public string tablaEmpleado
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
                List<Empleado> listaDeEmpleados = LogicaAgregarUsuario.ConsultarListaDeEmpleados();

                foreach(Empleado empleado in listaDeEmpleados)
                {
                    tablaEmpleado += ResourceGUIM2.OpenTR;
                    tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_num_ficha.ToString() + ResourceGUIM2.CloseTD;
                    tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_p_nombre + ResourceGUIM2.CloseTD;
                    tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_p_apellido + ResourceGUIM2.CloseTD;
                    tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_cedula + ResourceGUIM2.CloseTD;
                    tablaEmpleado += ResourceGUIM2.OpenTD + "CARGO" + ResourceGUIM2.CloseTD;

                    if ( !LogicaAgregarUsuario.VerificarUsuarioDeEmpleado( empleado.Emp_num_ficha ) )
                    {
                        tablaEmpleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonReg + ResourceGUIM2.CloseTD;
                    }
                    else
                    {
                        tablaEmpleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonRegBlock + ResourceGUIM2.CloseTD;
                    }

                    tablaEmpleado += ResourceGUIM2.CloseTR;
                }
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

            Response.Redirect("../M2/RegistroUsuario.aspx");
        }

        protected void validarUsuario()
        {
            System.Diagnostics.Debug.WriteLine("Entré");
            string nombreUsuario = userDefault.Value;
            bool respuesta = false;
            
            respuesta = LogicaAgregarUsuario.ExisteUsuario( nombreUsuario );

            if ( respuesta ) 
            {
                userDefault.Value = "Usuario existe";
                System.Diagnostics.Debug.WriteLine("Usuario existe");
            }
        }
    }
}