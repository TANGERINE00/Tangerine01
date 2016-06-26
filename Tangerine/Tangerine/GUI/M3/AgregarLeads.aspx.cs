using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security.AntiXss;
using DominioTangerine;
using LogicaTangerine;
using Tangerine_Contratos.M3;
using Tangerine_Presentador.M3;


namespace Tangerine.GUI.M3
{
    public partial class AgregarLeads : System.Web.UI.Page, IContratoAgregarClientePotencial
    {
        bool accionEnBd;
        PresentadorAgregarClientePotencial presentador;

        /// <summary>
        /// Constructor de la vista
        /// </summary>
        /// <returns></returns>
        public AgregarLeads()
        {
            presentador = new PresentadorAgregarClientePotencial(this);
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
                return this.email.Value;
            }
            set
            {
                this.email.Value = value;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Método que se encarga de llamar al presentador para
        /// agregar a un cliente potencial
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            presentador.Agregar();

            if (this.accionEnBd)
            {
                Server.Transfer("Listar.aspx", true);
            }
            else
            {
                Response.Write("<script type='text/javascript'> alert('El cliente no pudo ser creado') </script>");
            }
        }
    }
}



