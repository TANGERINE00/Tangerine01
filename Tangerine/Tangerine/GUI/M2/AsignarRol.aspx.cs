using DatosTangerine.M10;
using DatosTangerine.M2;
using DominioTangerine;
using LogicaTangerine.M2;
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
    public partial class AsignarRol : System.Web.UI.Page, IContratoAsignarRol
    {
        private Tangerine_Presentador.M2.PresentadorAsignarRol presentador;
        private bool validacionUsuario;
        string error;

        #region Contrato

            /// <summary>
            /// textBox de nombre de usuario
            /// </summary>
            public string usuario
            {
                get { return textUsuario_M2.Value; }
                set { textUsuario_M2.Value = value; }
            }

            /// <summary>
            /// comboBox de seleccion de rol
            /// </summary>
            public string comboBoxRol
            {
                get { return textRol_M2.Value; }
                set { textRol_M2.Value = value; }
            }

            /// <summary>
            /// Mensaje error.
            /// </summary>
            public string msjError
            {
                get { return error;}
                set { error = value; }
            }

        #endregion

        /// <summary>
        /// Carga la ventana de Asignar Rol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load( object sender, EventArgs e )
        {
            try
            {
                presentador = new Tangerine_Presentador.M2.PresentadorAsignarRol( this, int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString["idEmpleado"], false)) );
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
        /// Le asignar un rol al usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void buttonAsignar_Click( object sender, EventArgs e )
        {
            validacionUsuario = presentador.asignar();

            if (validacionUsuario)
            {
                Response.Redirect("../M2/CambiarRol.aspx");
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('" + msjError + "')", true);
            }
           
        }
    }
}