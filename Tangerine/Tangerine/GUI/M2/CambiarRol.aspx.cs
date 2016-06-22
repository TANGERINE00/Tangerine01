using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M2;
using DominioTangerine;
using Tangerine_Contratos.M2;
using Tangerine_Presentador.M2;

namespace Tangerine.GUI.M2
{
    public partial class CambiarRol : System.Web.UI.Page, IContratoCambiarRol
    {
        private PresentadorCambioRol _presentador;

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
            { return this.tablaempleados.Text; }

            set
            { this.tablaempleados.Text = value; }
        }

        /// <summary>
        /// Implementacion del contrato
        /// </summary>
        public string nombreUsuario
        {
            get
            {
                return this.textBuscarNombre.Value;
            }
            set
            {
                this.textBuscarNombre.Value = value;
            }
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
                _presentador.iniciarVista();
            }
        }

        /// <summary>
        /// Método para actualizar la pagina cuando se activa el evento del boton buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void busquedaNombre_Click(object sender, EventArgs e)
        {
            _presentador.actualizarVista();
        }
    }
}