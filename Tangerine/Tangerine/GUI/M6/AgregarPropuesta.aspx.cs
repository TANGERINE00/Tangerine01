using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DominioTangerine;
using LogicaTangerine;
using Tangerine_Contratos.M6;
using Tangerine_Presentador.M6;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Tangerine.GUI.M6
{
    public partial class AgregarPropuesta : System.Web.UI.Page, IContratoAgregarPropuesta
    {
        
        PresentadorAgregarPropuesta presenter;
        
        /// <summary>
        /// Constructor de la vista
        /// </summary>
        public AgregarPropuesta()
        {
            this.presenter = new PresentadorAgregarPropuesta(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try {
                presenter.llenarVista();
                }catch (Exception)
                {
                    Response.Redirect("../M6/ConsultarPropuesta.aspx");
                }

            }
        }

        /// <summary>
        /// Accion del boton a presionar "Agregar"
        /// </summary>
        protected void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                presenter.agregarPropuesta();
                Server.Transfer("ConsultarPropuesta.aspx", true);
            }
            catch (Exception)
            {
                Response.Redirect("../M6/ConsultarPropuesta.aspx");
            }
            
        }

        #region Contrato
        public DropDownList ComboCompania 
        {
            get { return comboCompañia; }
            set { comboCompañia = value; }
        }
        public string IdCompania
        {
            get { return comboCompañia.SelectedValue.ToString(); }
            set { }
        }
        public string Descripcion
        {
            get { return descripcion.Value; }
        }
        public string ArrPrecondicion
        {
            get { return arrPrecondicion.Value; }

        }
        public string ComboDuracion
        {
            get { return comboDuracion.Value; }
            set { comboDuracion.Value = value; }
        }
        public string TextoDuracion
        {
            get { return textoDuracion.Value; }

        }
        public string DatePickerUno
        {
            get { return datepicker1.Value; }
        }
        public string DatePickerDos
        {
            get { return datepicker2.Value; }
        }
        public DropDownList TipoCosto
        {
            get { return comboTipoCosto; }
            set { comboTipoCosto= value; }
        }
        public string TextoCosto
        {
            get { return textoCosto.Value; }
        } 
        public string FormaPago
        {
            get { return formaPago.Value; }
            set { formaPago.Value = value; }
        }
        public string CantidadCuotas
        {
            get { return cantidadCuotas.Value; }
        }
        public DropDownList ComboStatus
        {
            get { return comboEstatus; }
            set { comboEstatus=value; }
        }
        
        //REVISAR ADAPTACION
        public string alertaClase
        {
            set { alert.Attributes[RecursosGUI_M6.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[RecursosGUI_M6.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }
        #endregion
    }
}