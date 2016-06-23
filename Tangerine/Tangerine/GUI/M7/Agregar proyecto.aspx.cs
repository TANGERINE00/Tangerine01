using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M7;
using Tangerine_Contratos.M7;
using Tangerine_Presentador.M7;
using DominioTangerine.Entidades.M7;
using System.Web.UI.HtmlControls;

namespace Tangerine.GUI.M7
{

    public partial class AgregarProyecto : System.Web.UI.Page, IContratoAgregarProyecto
    {
     
        private PresentadorAgregarProyecto _presentador;

        #region Implementación de Interfaz

        /// <summary>
        /// Implementación de la interfaz IContratoAgregarProyecto.
        /// </summary>
        public string NombreProyecto
        {
            get
            {
                return this.textInputNombreProyecto.Value;
            }
            set
            {
            }
        }

        public string CodigoProyecto
        {
            get
            {
                return this.textInputCodigo.Value;
            }
            set
            {
                this.textInputCodigo.Value = value.ToString();
            }
        }

        public string FechaInicio
        {
            get
            {
                return this.datepicker1.Value;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string FechaFin
        {
            get
            {
                return this.datepicker2.Value;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Costo
        {
            get
            {
                return this.textInputCosto.Value;
            }
            set
            {
                this.textInputCosto.Value = value.ToString();
            }
        }

        HtmlSelect IContratoAgregarProyecto.inputPersonal
        {
            get
            {
                return this.inputPersonal;
            }
            set
            {
            }
        }

        HtmlSelect IContratoAgregarProyecto.inputEncargado
        {
            get
            {
                return this.inputEncargado;
            }
            set
            {
            }
        }

        DropDownList IContratoAgregarProyecto.inputPropuesta
        {
            get
            {
                return this.inputPropuesta;
            }
            set
            {
            }
        }

        DropDownList IContratoAgregarProyecto.inputGerente
        {
            get
            {
                return this.inputGerente;
            }
            set
            {
            }
        }

        HtmlGenericControl IContratoAgregarProyecto.columna2
        {
            get
            {
                return this.columna2;
            }
            set
            {
                this.columna2 = value;
            }
        }

        Button IContratoAgregarProyecto.BtnGenerar
        {
            get
            {
                return this.btnGenerar;
            }
            set
            {
                this.btnGenerar = value;
            }
        }

        Button IContratoAgregarProyecto.btnAgregarPersonal
        {
            get
            {
                return this.btnAgregarPersonal;
            }
            set
            {
                this.btnAgregarPersonal = value;
            }

        }
        #endregion

        /// <summary>
        /// Constructor de la clase AgregarProyecto
        /// en la que se crea un nuevo presentador para esta vista.
        /// </summary>
        public AgregarProyecto()
        {
            _presentador = new PresentadorAgregarProyecto(this);
        }

        /// <summary>
        /// Método que se ejcutará al cargar la página por primera vez.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
               
           if (!IsPostBack)
           {
               _presentador.CargarPagina();
           }
        }


        /// <summary>
        /// Método que se ejecuta al hacer click
        /// el botón agregar personal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregarPersonal_Click(object sender, EventArgs e)
        {
            _presentador.AgregarPersonal();                  
        }

        /// <summary>
        /// Método que se ejecuta al seleccionar una propuesta
        /// del DropDownList en la vista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void comboPropuesta_Click(object sender, EventArgs e)
        {
            _presentador.CargarInformacionPropuesta(sender);
        }


        /// <summary>
        /// Método que se ejecuta al hacer click en
        /// el botón agregar en la vista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                _presentador.agregarProyecto();
                Server.Transfer("ConsultaProyecto.aspx", true);
            }
            catch (Exception)
            {
                Response.Redirect("../M7/ConsultaProyecto.aspx");
            }
        }


    }
}