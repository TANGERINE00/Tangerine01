using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using DatosTangerine;
using LogicaTangerine.M4;
using LogicaTangerine.M7;
using Tangerine_Presentador.M8;
using Tangerine_Contratos.M8;


namespace Tangerine.GUI.M8
{
    public partial class AnularFacturaM8 : System.Web.UI.Page, IContratoAnularFactura
    {
        #region contrato
        public string numero
        {
            get
            {
                return this.NumeroFactura.Text;
            }

            set
            {
                this.NumeroFactura.Text = value;
            }
        }

        public string fecha
        {
            get
            {
                return this.Fecha.Text;
            }

            set
            {
                this.Fecha.Text = value;
            }
        }

        public string compania
        {
            get
            {
                return this.Compania.Text;
            }

            set
            {
                this.Compania.Text = value;
            }
        }

        public string descripcion
        {
            get
            {
                return this.Descripcion.Text;
            }

            set
            {
                this.Descripcion.Text = value;
            }
        }

        public string proyecto
        {
            get
            {
                return this.Proyecto.Text;
            }

            set
            {
                this.Proyecto.Text = value;
            }
        }

        public string monto
        {
            get
            {
                return this.Monto.Text;
            }

            set
            {
                this.Monto.Text = value;
            }
        }

        public string moneda
        {
            get
            {
                return this.TipoMoneda.Text;
            }

            set
            {
                this.TipoMoneda.Text = value;
            }
        }
        #endregion

        #region presentador
        PresentadorAnularFactura _presentador;

        public AnularFacturaM8()
        {
            _presentador = new PresentadorAnularFactura(this);
        }
        #endregion

        DateTime _fechaEmision = DateTime.Now;
        DateTime _fechaUltimoPago = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
            //int idFac = int.Parse(Request.QueryString[ResourceGUIM8.idF]);
            this.numero = Request.QueryString[ResourceGUIM8.idF];

            if (!IsPostBack)
            {
                _presentador.cargarFactura();                
            }  
        }

        protected void buttonAnularFactura_Click(object sender, EventArgs e)
        {
            _presentador.anularFactura();
            //Server.Transfer("ConsultarFacturaM8.aspx");
            Server.Transfer(ResourceGUIM8.redirectHome);
        }
    }
}