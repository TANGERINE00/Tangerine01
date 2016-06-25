using DominioTangerine;
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
            _presentador = new PresentadorRegistroUsuario( this );
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
        /// Método que se ejecuta al cargar la página, se carga la tabla de empleados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load( object sender, EventArgs e )
        {
            try
            {
                //Esto ocurre cuando se modifica una factura, se muestra mensaje a usuario
                string _estado = Request.QueryString[ResourceM2.estado];
                if (_estado != null)
                    _presentador.Alerta(_estado);
            }
            catch
            {
                //No hago nada, no es obligatorio el parametro
            }

            if (!IsPostBack)
            {
               _presentador.inicioVista();
            }
        }
    }
}