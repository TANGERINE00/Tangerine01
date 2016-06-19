using DatosTangerine.M10;
using DatosTangerine.M2;
using DominioTangerine;
using LogicaTangerine.M2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M2;

namespace Tangerine.GUI.M2
{
    public partial class AsignarRol : System.Web.UI.Page, IContratoAsignarRol
    {
        private int numFicha;
        private string rol;
        private Tangerine_Presentador.M2.PresentadorAsignarRol presentador;

        protected void Page_Load(object sender, EventArgs e)
        {
            numFicha = int.Parse(Request.QueryString["idEmpleado"]);
            rol = Request.QueryString["Rol"];
            presentador = new Tangerine_Presentador.M2.PresentadorAsignarRol(this, numFicha, rol);
            if (!IsPostBack)
            {
                presentador.inicioVista(); 
            }
        }

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

        #endregion

        protected void buttonAsignar_Click(object sender, EventArgs e)
        {
            presentador.asignar();
            Response.Redirect("../M2/CambiarRol.aspx");
        }

        public static bool isPostBack { get; set; }
    }
}