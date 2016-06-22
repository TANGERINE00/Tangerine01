using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M3;
using Tangerine_Presentador.M3;


namespace Tangerine.GUI.M3
{
    public partial class ModificarLead : System.Web.UI.Page, IContratoModificarClientePotencial
    {
        bool accionEnBd;
        PresentadorModificarClientePotencial presentador;

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

        protected void Page_Load(object sender, EventArgs e)
        {
             int idClip = int.Parse(Request.QueryString["idclp"]);
             if (!IsPostBack)
              {
                  presentador.Llenar(idClip);        
              }
                  
         }


        protected void Modificar_Click(object sender, EventArgs e)
        {
            int idClip = int.Parse(Request.QueryString["idclp"]);
            presentador.ModificarClientePotencial(idClip);

            if (this.accionEnBd)
            {
                Server.Transfer("Listar.aspx", true);
            }
            else
            {
                Response.Write("<script type='text/javascript'> alert('Los datos del Cliente no fueron procesados') </script>");
            }
        }
 
    }
    
}