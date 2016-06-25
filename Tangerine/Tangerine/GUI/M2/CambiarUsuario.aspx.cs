using DatosTangerine.M10;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security.AntiXss;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M2;

namespace Tangerine.GUI.M2
{
    public partial class CambiarUsuario : System.Web.UI.Page, IContratoCambiarUsuario
    {
        private Tangerine_Presentador.M2.PresentadorCambiarUsuario presentador;
        private bool existenciaUsuario;

        #region Contrato

            /// <summary>
            /// textBox de la ficha del empleado
            /// </summary>
            public string fichaEmpleado
            {
                get { return textFichaEmpleado_M2.Value; }
                set { textFichaEmpleado_M2.Value = value; }
            }

            /// <summary>
            /// textBox del nombre de usuario
            /// </summary>
            public string nombreUsuario
            {
                get { return textUsuario_M2.Value; }
                set { textUsuario_M2.Value = value; }
            }

            /// <summary>
            /// Clase de alerta, para excepciones
            /// </summary>
            public string alertaClase
            {
                set { alert.Attributes[ResourceM2.alertClase] = value; }
            }

            /// <summary>
            /// Atributos de alerta, para excepciones
            /// </summary>
            public string alertaUsuario
            {
                set { alert.Attributes[ResourceM2.alertUsuario] = value; }
            }

            /// <summary>
            /// Alerta cuando hay una excepcion
            /// </summary>
            public string alerta
            {
                set { alert.InnerHtml = value; }
            }

        #endregion

        /// <summary>
        /// Método para cargar la ventana Cambiar Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load( object sender , EventArgs e )
        {
            try
            {
                presentador = new Tangerine_Presentador.M2.PresentadorCambiarUsuario( this ,
                                  int.Parse( AntiXssEncoder.HtmlEncode( Request.QueryString["idEmpleado"] , false ) ) );
                if (!IsPostBack)
                {
                    presentador.inicioVista();
                }
            }
            catch ( Exception ex )
            {
                Response.Redirect("../M1/DashBoard.aspx");
            }
        }

        protected void buttonAsignar_Click( object sender , EventArgs e )
        {
            try
            {
                existenciaUsuario = presentador.usuarioExistente();

                if ( !existenciaUsuario )
                {
                    presentador.asignar();
                    Response.Redirect("../M2/CambiarRol.aspx?estado=2");
                }
                else
                {
                    presentador.Alerta( "Nombre de usuario ya existente, intente otro." );
                }
            }
            catch ( ExcepcionesTangerine.M2.ExceptionM2Tangerine ex )
            {
                presentador.Alerta("Error en datos, por favor, intente otra vez.");
            }
        }
    }
}