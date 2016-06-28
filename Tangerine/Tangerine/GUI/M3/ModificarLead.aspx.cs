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
    public partial class ModificarLead : System.Web.UI.Page, IContratoModificarClientePotencial
    {
        bool accionEnBd;
        PresentadorModificarClientePotencial presentador;
        int idClip;

        /// <summary>
        /// Constructor de la vista
        /// </summary>
        /// <returns></returns>
        public ModificarLead() 
        {
            presentador = new PresentadorModificarClientePotencial(this);
        }

        #region Contrato
        public String NombreEtiqueta 
        {
            get 
            {
                return this.nombre.Value;
            }
            set 
            {
                this.nombre.Value = value;
            }
        }

        public String RifEtiqueta 
        {
            get 
            {
                return this.rif.Value;
            }
            set 
            {
                this.rif.Value = value;
            }
        }

        public String CorreoElectronico
        {
            get 
            {
                return this.correo.Value;
            }
            set 
            {
                this.correo.Value = value;
            }
        }

        public float PresupuestoInversion
        {
            get
            {
                return Convert.ToSingle(this.presupuesto.Value);
            }
            set
            {
                this.presupuesto.Value = value.ToString();
            }

        }

        public int NumeroLlamadas
        {
            get 
            {
                return Int32.Parse(this.numLlamadas.Value);
            }

            set
            {
                this.numLlamadas.Value = value.ToString();
            }
        }

        public int NumeroVisitas 
        {
            get
            {
                return Int32.Parse(this.visitas.Value);
            }
            set
            {
                this.visitas.Value = value.ToString();
            }
        }

        public bool AccionSobreBd 
        {
            get 
            {
                return this.accionEnBd;
            }
            set 
            {
                this.accionEnBd = value;
            }
        }
        #endregion

        /// <summary>
        /// Método que carga la vista y muestra los datos del cliente potencial a modificar
        /// Llama al presentador para mostrar
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                idClip = int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString["idclp"], false));
                if (!IsPostBack)
                {
                    presentador.Llenar(idClip);
                }
            }
            catch
            {
                Response.Redirect("Listar.aspx");
            }     
         }

        /// <summary>
        /// Método que carga la vista y muestra los datos del cliente potencial a activar
        /// Llama al presentador para mostrar
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        protected void Modificar_Click(object sender, EventArgs e)
        {
            presentador.ModificarClientePotencial(idClip);

            if (this.accionEnBd)
            {
                Server.Transfer("Listar.aspx", true);
            }
            else
            {
                this.alert.InnerHtml = ResourceInterfaz.AlertModificar;
            }
        }
 
    }
    
}