using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M6;
using LogicaTangerine.M4;
using Tangerine_Contratos.M6;
using Tangerine_Presentador.M6;
using System.Diagnostics;

namespace Tangerine.GUI.M6
{
    public partial class InformacionPropuesta : System.Web.UI.Page, IContratoInformacionPropuesta
    {
        PresentadorInformacionPropuesta presentadorInformacion;

        public InformacionPropuesta()
        {
            this.presentadorInformacion = new PresentadorInformacionPropuesta(this);
        }

        public Label Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        public Label Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public Label Compania
        {
            get
            {
                return compania;
            }
            set
            {
                compania = value;
            }
        }

        public Literal Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
            }
        }

        public Literal Requerimientos
        {
            get
            {
                return requerimientos;
            }
            set
            {
                requerimientos = value;
            }
        }

        public Label Duracion
        {
            get
            {
                return duracion;
            }
            set
            {
                duracion = value;
            }
        }

        public Label Costo
        {
            get
            {
                return costo;
            }
            set
            {
                costo = value;
            }
        }

        public Label AcuerdoPago
        {
            get
            {
                return acuerdopago;
            }
            set
            {
                acuerdopago = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            if (!IsPostBack)
            {
                presentadorInformacion.consultarPropuesta(id);
            }
        }
    }
}