using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security.AntiXss;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M2;
using Tangerine_Presentador.M2;


namespace Tangerine.GUI.M2
{
    public partial class AccionRegistrar : System.Web.UI.Page, IContratoAccionRegistrar
    {
        private PresentadorAccionRegistrar presentador;
        private bool existenciaUsuario;

        #region Contrato

            /// <summary>
            /// comboBox de seleccion de rol
            /// </summary>
            public string comboRol
            {
                get { return textRol_M2.Value; }
                set { textRol_M2.Value = value; }
            }

            /// <summary>
            /// textBox de la contraseña
            /// </summary>
            public string contrasena
            {
                get { return passwordDefault.Value; }
                set { passwordDefault.Value = value; }
            }

            /// <summary>
            /// Encabezado del textBox del nombre de usuario
            /// </summary>
            public string usuario
            {
                get { return userDefault.Value; }
                set { userDefault.Value = value; }
            }

            /// <summary>
            /// Textbox de la ficha del usuario
            /// </summary>
            public string ficha
            {
                get { return textFicha_M2.Value; }
                set { textFicha_M2.Value = value; }
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
            public string alertaRol
            {
                set { alert.Attributes[ResourceM2.alertRole] = value; }
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
        /// Carga la ventana Accion Registrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load( object sender , EventArgs e )
        {
            try
            {
                presentador = new PresentadorAccionRegistrar(this, int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString[ResourceM2.IDFicha], false)),
                                                             AntiXssEncoder.HtmlEncode(Request.QueryString[ResourceM2.Nombre], false),
                                                             AntiXssEncoder.HtmlEncode(Request.QueryString[ResourceM2.Apellido], false),
                                                             AntiXssEncoder.HtmlEncode(Request.QueryString[ResourceM2.Rol], false));
                if (!IsPostBack)
                {
                    presentador.inicioVista();
                }
            }
            catch ( Exception ex )
            {
                Response.Redirect( ResourceM2.RedirectPageLoad );
            }
        }

        /// <summary>
        /// Crear el usuario de un empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCrear_Click( object sender , EventArgs e )
        {
            existenciaUsuario = presentador.usuarioExistente();

            if ( !existenciaUsuario )
            {
                if ( presentador.registrar() )
                {
                    Response.Redirect(ResourceM2.RedirectBtnCrearAccionRegistar);
                }
            }
            else
            {
                presentador.Alerta(ResourceM2.AlertaBtnCrear);
            }

        }
    }
}