using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M7;
using LogicaTangerine.M10;
using LogicaTangerine.M5;
using Tangerine_Presentador.M7;
using Tangerine_Contratos.M7;

namespace Tangerine.GUI.M7
{
    public partial class InformacionProyecto : System.Web.UI.Page, IContratoInformacionProyecto

    {
        PresentadorInformacionProyecto presentador;

        public InformacionProyecto()
        {
           this.presentador = new PresentadorInformacionProyecto(this);
        }

        #region Contrato
        public Label NombrePropuesta
        {
            get
            {
                return nombrePropuesta;
            }
            set
            {
                nombrePropuesta = value;
            }
        }

        public Label NombreProyecto
        {
            get
            {
                return nombreProyecto;
            }
            set
            {
                nombreProyecto = value;
            }
        }

        public Label CodigoProyecto
        {
            get
            {
                return codigoProyecto;
            }
            set
            {
                codigoProyecto = value;
            }
        }

        public Label FechaInicio
        {
            get
            {
                return fechaInicio;
            }
            set
            {
                fechaInicio = value;
            }
        }

        public Label FechaFin
        {
            get
            {
                return fechaFin;
            }
            set
            {
                fechaFin = value;
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

        public Label Porcentaje
        {
            get
            {
                return porcentaje;
            }
            set
            {
                porcentaje = value;
            }
        }

        public Label Estatus
        {
            get
            {
                return estatus;
            }
            set
            {
                estatus = value;
            }
        }

        public DropDownList inputPersonal
        {
            get
            {
                return inputPersonal1;
            }
            set
            {
                inputPersonal1 = value;
            }
        }

        public DropDownList inputEncargado
        {
            get
            {
                return inputEncargado1;
            }
            set
            {
                inputEncargado1 = value;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int Proyectoid = int.Parse(Request.QueryString["idCont"]);

            if (!IsPostBack)
            {
                presentador.CargarInformacionProyecto(Proyectoid);
            }
        }
    }
}
