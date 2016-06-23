using LogicaTangerine.M2;
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
        string error;

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
            /// Manejo de errores
            /// </summary>
            public string msjError
            {
                get
                {
                    return error;
                }
                set
                {
                    error = value;
                }
            }

        #endregion

        /// <summary>
        /// Carga la ventana Accion Registrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                presentador = new PresentadorAccionRegistrar(this, int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString["idFicha"], false)),
                                                             AntiXssEncoder.HtmlEncode(Request.QueryString["Nombre"], false),
                                                             AntiXssEncoder.HtmlEncode(Request.QueryString["Apellido"], false),
                                                             AntiXssEncoder.HtmlEncode(Request.QueryString["Rol"], false));
                if (!IsPostBack)
                {
                    presentador.inicioVista();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("../M1/DashBoard.aspx");
            }
        }

        /// <summary>
        /// Crear el usuario de un empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            existenciaUsuario = presentador.usuarioExistente();

            if (!existenciaUsuario)
            {
                if (presentador.registrar())
                {
                    Response.Redirect("../M2/RegistroUsuario.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('" + msjError + "')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Nombre de usuario ya existente, intente otro.')", true); 
            }

        }
    }
}