using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using Tangerine_Contratos.M2;
using Tangerine_Presentador.M2;

namespace Tangerine.GUI.M2
{
    public partial class CambiarRol : System.Web.UI.Page, IContratoCambiarRol
    {
        private PresentadorCambioRol _presentador;
        string error;
        private bool errorManejo;

        /// <summary>
        /// Constructor de PresentadorCambioRol
        /// </summary>
        public CambiarRol()
        {
            _presentador = new PresentadorCambioRol(this);
        }

        #region Contrato

            /// <summary>
            /// tabla consulta de empleados
            /// </summary>
            public string empleado
            {
                get
                { return this.tabla.Text; }

                set
                { this.tabla.Text = value; }
            }

            /// <summary>
            /// Mensaje de error
            /// </summary>
            public string msjError
            {
                get { return error; }
                set { error = value;}
            }

        #endregion

        /// <summary>
        /// Método que se ejecuta al cargar la página, se carga la tabla de empleados con sus respectivos usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                errorManejo = _presentador.iniciarVista();

                if (!errorManejo)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('" + msjError + "')", true);
                }
            }
        }
    }
}