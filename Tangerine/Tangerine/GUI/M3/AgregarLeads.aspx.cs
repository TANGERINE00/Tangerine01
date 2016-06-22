using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M3;
using Tangerine_Contratos.M3;
using Tangerine_Presentador.M3;


namespace Tangerine.GUI.M3
{
    public partial class AgregarLeads : System.Web.UI.Page, IContratoAgregarClientePotencial
    {
        bool accionEnBd;


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
            /*if (!IsPostBack)
            {

            }*/
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            /*_nombre = nombre.Value;
            _rif = rif.Value;
            _email = email.Value;
            _presupuesto = float.Parse(presupuesto.Value);
          //  _llamadas = int.Parse(llamadas.Value);
          //  _visitas = int.Parse(Visitas.Value);
          //  _potencial=Potencial.Value;
          //  _borrado = Borrado.Value;
            //Los dos ultimos valores deben de venir de la ventana de consultar contactos (tipo empresa y id empresa)
            // ((_nombre, _rif, _email, _presupuesto, _lla) en esa parte esta usando lo del constructor sin id
            ClientePotencial clientePotencial = new ClientePotencial(_nombre, _rif, _email, _presupuesto,1);//, _llamadas, _visitas, _potencial, _borrado);
            LogicaM3 clientePotencialLogica = new LogicaM3();
            //clientePotencialLogica. AgregarNuevoclientePotencial(clientePotencial);
            Response.Redirect("Listar.aspx");*/


        }
    }
}



