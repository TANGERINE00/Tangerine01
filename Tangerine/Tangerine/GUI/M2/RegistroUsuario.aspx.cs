using DominioTangerine;
using LogicaTangerine.M2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M2;
using Tangerine_Presentador.M2;

namespace Tangerine.GUI.M2
{
    public partial class RegistroUsuario : System.Web.UI.Page, IContratoRegistroUsuario
    {
        private PresentadorRegistroUsuario _presentador;

        /// <summary>
        /// Constructor de PresentadorRegistroUsuario
        /// </summary>
        public RegistroUsuario()
        {
            _presentador = new PresentadorRegistroUsuario(this);
        }

        #region Contrato

        /// <summary>
        /// Implementacion del contrato
        /// </summary>
        public string tablaEmpleado
        {
            get
            {
                return this.tabla.Text;
            }
            set
            {
                this.tabla.Text = value;
            }
        }
        #endregion

        /// <summary>
        /// Método que se ejecuta al cargar la página, se carga la tabla de empleados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load( object sender, EventArgs e )
        {
            if (!IsPostBack)
            {
                _presentador.inicioVista();
            }
        }
    }
}