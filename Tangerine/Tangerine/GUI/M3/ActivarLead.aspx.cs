using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using Tangerine_Contratos.M3;
using Tangerine_Presentador.M3;
using System.Web.Security.AntiXss;

namespace Tangerine.GUI.M3
{
    public partial class ActivarLead : System.Web.UI.Page, IContratoConsultarClientePotencial
    {
        PresentadorConsultarClientePotencial presentadorMostrar;
        PresentadorActivarClientePotencial presentadorActivar;
        int idClientePotencial;

        /// <summary>
        /// Constructor de la vista
        /// </summary>
        /// <returns></returns>
        public ActivarLead()
        {
            this.presentadorMostrar = new PresentadorConsultarClientePotencial(this);
            this.presentadorActivar = new PresentadorActivarClientePotencial(this);
        }

        #region Contrato
        public Literal NombreEtiqueta
        {
            get
            {
                return this.Nombre;
            }

            set
            {
                this.Nombre = value;
            }
        }

        public Literal RIFEtiqueta
        {
            get
            {
                return this.Rif;
            }

            set
            {
                this.Rif = value;
            }
        }

        public Literal CorreoEtiqueta
        {
            get
            {
                return this.correo;
            }

            set
            {
                this.correo = value;
            }
        }

        public Literal EstatusEtiqueta
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }

        public Literal PresupuestoInicialEtiqueta
        {
            get
            {
                return this.presupuesto;
            }

            set
            {
                this.presupuesto = value;
            }
        }

        public Literal NumLlamadasEtiqueta
        {
            get
            {
                return this.llamadas;
            }

            set
            {
                this.llamadas = value;
            }
        }
        public Literal NumVisitasEtiqueta
        {
            get
            {
                return this.visitas;
            }

            set
            {
                this.visitas = value;
            }
        }
        #endregion

        /// <summary>
        /// Método que carga la vista y muestra los datos del cliente potencial a activar
        /// Llama al presentador para mostrar
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                idClientePotencial = int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString["idclp"], false));
                if (!IsPostBack)
                {
                    presentadorMostrar.Llenar(idClientePotencial);
                }
            }
            catch
            {
                Response.Redirect("Listar.aspx");
            }
        }

        /// <summary>
        /// Metodo que llama al presentador para activar el cliente potencial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected void Activar_Click(object sender, EventArgs e)
        {
            presentadorActivar.Activar(idClientePotencial);
            Response.Redirect("Listar.aspx");
        }

    }
}