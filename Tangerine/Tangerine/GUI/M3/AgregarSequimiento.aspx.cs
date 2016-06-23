using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M3;
using Tangerine_Presentador.M3;
using System.Web;

namespace Tangerine.GUI.M3
{
    public partial class AgregarSequimiento : System.Web.UI.Page, IContratoAgregarSeguimiento
    {
        PresentadorAgregarSeguimiento presentador;
        private String opcion;

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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int idClientePotencial = int.Parse(Request.QueryString["idclp"]);
            if (!IsPostBack)
            {
                presentador.CargarTipoDeSeguimiento();
                presentador.MostrarFechaDeRegistro();
            }
        }

        protected void SelectedType_Change(object sender, EventArgs e)
        {
            opcion = SelecteTipo.SelectedItem.Text.ToString();
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {

        }

    }
}