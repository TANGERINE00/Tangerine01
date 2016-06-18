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

        /// <summary>
        /// Método que se ejecuta al cargar la página, se carga la tabla de empleados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load( object sender, EventArgs e )
        {
            if (!IsPostBack)
            {
                List<Empleado> listaDeEmpleados = LogicaAgregarUsuario.ConsultarListaDeEmpleados();

                foreach( Empleado empleado in listaDeEmpleados )
                {
                    tablaEmpleado += ResourceGUIM2.OpenTR;
                    tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_num_ficha.ToString() + ResourceGUIM2.CloseTD;
                    tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_p_nombre + ResourceGUIM2.CloseTD;
                    tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_p_apellido + ResourceGUIM2.CloseTD;
                    tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_cedula + ResourceGUIM2.CloseTD;
                    tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Job.Nombre + ResourceGUIM2.CloseTD;

                    if ( !LogicaAgregarUsuario.VerificarUsuarioDeEmpleado( empleado.Emp_num_ficha ) )
                    {
                        tablaEmpleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonRegNuevaVentana + empleado.emp_num_ficha + ResourceGUIM2.NombreEmpleado
                                        + empleado.emp_p_nombre + ResourceGUIM2.ApellidoEmpleado + empleado.emp_p_apellido 
                                        + ResourceGUIM2.CloseBotonParametro + ResourceGUIM2.CloseTD;
                    }
                    else
                    {
                        tablaEmpleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonRegBlock + ResourceGUIM2.CloseTD;
                    }

                    tablaEmpleado += ResourceGUIM2.CloseTR;
                }
            }
        }

        /// <summary>
        /// Método para crear el usuario por defecto
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="apellidoUsuario"></param>
        /// <returns></returns>
        [WebMethod] 
        public static string ObtenerUsuarioDefault(  string nombreUsuario, string apellidoUsuario )
        {
            string resultado = "";

            resultado = LogicaAgregarUsuario.CrearUsuarioDefault( nombreUsuario, apellidoUsuario );

            return resultado;
        }

        /// <summary>
        /// Método para validar si el usuario escrito existe o no.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [WebMethod]
        public static string validarUsuario( string usuario )
        {
            string nombreUsuario = usuario;
            bool respuesta = false;
            respuesta = LogicaAgregarUsuario.ExisteUsuario( nombreUsuario );

            string retorno = "Disponible";

            if ( respuesta )
            {
                retorno = "Usuario Existe!";
            }

            return retorno;
        }

        /// <summary>
        /// Método para crear el usuario, se ejecuta al presionar el boton Crear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCrear_Click( object sender, EventArgs e )
        {

            string rol = rolDefault.Value;
            string nombreUsuario = userDefault.Value;
            string contraseniaUsuario = passwordDefault.Value;
            string fichaEmpleado = fichaEmp.Value;

            LogicaAgregarUsuario.PrepararUsuario( nombreUsuario, contraseniaUsuario, rol, int.Parse(fichaEmpleado) );

            Response.Redirect( "../M2/RegistroUsuario.aspx" );
        }
    }
}