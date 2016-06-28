using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M3;
using Tangerine_Presentador.M3;
using System.Web.Security.AntiXss;

namespace Tangerine.GUI.M3
{
    public partial class AgregarSequimiento : System.Web.UI.Page, IContratoAgregarSeguimiento
    {
        PresentadorAgregarSeguimiento presentador;
        private String opcion;
        private int idCliente;

        /// <summary>
        /// Constructor de la vista
        /// </summary>
        public AgregarSequimiento()
        {
            presentador = new PresentadorAgregarSeguimiento(this);
        }

        #region Contrato
        public String Opcion
        {
            get 
            {
                return this.opcion;
            }
            set
            {
                this.opcion = value;
            }
        }
        public DropDownList Tipo
        {
            get 
            {
                return this.SelecteTipo; 
            }
            set
            {
                this.SelecteTipo = value;
            }

        }

        public String Motivo
        {
            get
            {
                return this.motivo.Value;
            }
            set 
            {
                this.motivo.Value = value;
            }
        }

        /*public DateTime Fecha
        {
            get
            {
                return DateTime.Parse(this.fechaActual.Value);
            }
            set
            {
                String v = this.fechaActual.ToString();
                 v = value.ToString();
            }
        }*/
        public String Fecha
        {
            get
            {
                return this.fechaActual.Value;
            }
            set
            {
                this.fechaActual.Value = value;
            }
        }
        #endregion

        /// <summary>
        /// Método que carga la vista con el formulario para agregar un registro de seguimiento
        /// Llama al presentador para manipular los datos del formulario
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.idCliente = int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString["idclp"], false));
                if (!IsPostBack)
                {
                    presentador.CargarTipoDeSeguimiento();
                    presentador.MostrarFechaDeRegistro();
                }
            }
            catch
            {
                Response.Redirect(ResourceInterfaz.Dashboard);
            }
        }

        /// <summary>
        /// Método que permite tomar n valor del tipo llamada o visita para un registro de 
        /// seguiminto
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        protected void SelectedType_Change(object sender, EventArgs e)
        {
            opcion = SelecteTipo.SelectedItem.Text.ToString();
        }

        /// <summary>
        /// Método que pasa la llamada de agregar un registro de seguimiento al presentador
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            try
            {
                presentador.Agregar(this.idCliente);
                Server.Transfer("AdministrarListaClientesPotenciales.aspx");
            }
            catch
            {
                this.alert.InnerHtml = ResourceInterfaz.AlertAgregar;
            }
        }

    }
}