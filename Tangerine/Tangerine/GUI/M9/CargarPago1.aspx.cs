using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using Tangerine_Contratos.M9;
using Tangerine_Presentador.M9;
namespace Tangerine.GUI.M9
{
    public partial class WebForm3 : System.Web.UI.Page , IContratoCargarPago
    {
        #region Atributos
        public PresentadorCargarPago presentador;

        public WebForm3 ()
        {
            this.presentador = new PresentadorCargarPago(this);
        }
        
        public string cliente
        {
            get
            {
                return this.compCliente.Value;
            }

            set
            {
                this.compCliente.Value = value;
            }
        }

        public string numero
        {
            get
            {
                return this.numFactura.Value;
            }

            set
            {
                this.numFactura.Value = value;
            }
        }


        public string proyecto
        {
            get
            {
                return this.proyectoNombre.Value;
            }

            set
            {
                this.proyectoNombre.Value = value;
            }
        }

        public string monto
        {
            get
            {
                return this.montoFactura.Value;
            }

            set
            {
                this.montoFactura.Value = value;
            }
        }

        public string moneda
        {
            get
            {
                return this.monedaPago.Value;
            }

            set
            {
                this.monedaPago.Value = value;
            }
        }

        public string codAprob
        {
            get
            {
                return this.codAprobacion.Value;
            }
            set
            {
                this.codAprobacion.Value = value;
            }

        }

        public string formPago
        {
            get
            {
                return this.formaPago.Value;
            }
            set
            {
                this.formaPago.Value = value;
            }


        }
        #endregion





       
        protected void Page_Load(object sender, EventArgs e)
        {
            int identificador = int.Parse(Request.QueryString["id"]);
            presentador.LlenarPorId(identificador);

        }

        /// <summary>
        /// Metodo para tomar los valores de la vista y guardarlos en BD luego de apretar el boton agregar.
        public void btnagregar_Click(object sender, EventArgs e)
        {
            presentador.AgregarPago();
            Server.Transfer("SeleccionCompania.aspx", true);
        }

    }
}