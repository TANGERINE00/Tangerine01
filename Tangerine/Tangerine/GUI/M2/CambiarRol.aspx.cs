using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using Tangerine_Contratos.M2;
using Tangerine_Presentador.M2;
using System.Web.Security.AntiXss;

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
            _presentador = new PresentadorCambioRol( this );
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
        /// Método que se ejecuta al cargar la página, se carga la tabla de empleados con sus respectivos usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load( object sender , EventArgs e )
        {
            try
            {
                //Esto ocurre cuando se modifica una factura, se muestra mensaje a usuario
                string _estado = AntiXssEncoder.HtmlEncode( Request.QueryString[ResourceM2.estado], false );
                if (_estado != null)
                    _presentador.Alerta(_estado);
            }
            catch
            {
                Response.Redirect(ResourceM2.RedirectPageLoad);
            }

            if ( !IsPostBack )
            {
                _presentador.iniciarVista();
            }
        }
    }
}