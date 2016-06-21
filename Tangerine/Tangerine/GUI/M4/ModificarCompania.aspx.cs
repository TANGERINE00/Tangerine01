using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M4;
using Tangerine_Contratos.M4;
using Tangerine_Presentador.M4;

namespace Tangerine.GUI.M4
{
    public partial class ModificarCompania : System.Web.UI.Page , IContratoAgregarCompania
    {
        PresentadorModificarCompania Presentador;

        public ModificarCompania()
        {
            Presentador = new PresentadorModificarCompania(this);
        }

        #region Contrato
        public string inputNombre1
        {
            get
            {
                return InputNombre1.Value;
            }
            set
            {
                InputNombre1.Value = value;
            }
        }
        public string inputAcronimo1
        {
            get
            {
                return InputAcronimo1.Value;
            }
            set
            {
                InputAcronimo1.Value = value;
            }
        }
        public string inputRIF1
        {
            get
            {
                return InputRIF1.Value;
            }
            set
            {
                InputRIF1.Value = value;
            }
        }
        public DropDownList inputDireccion1
        {
            get
            {
                return InputDireccion1;
            }
            set
            {
                InputDireccion1 = value;
            }
        }
        public string inputEmail1
        {
            get
            {
                return InputEmail1.Value;
            }
            set
            {
                InputEmail1.Value = value;
            }
        }
        public string inputTelefono1
        {
            get
            {
                return InputTelefono1.Value;
            }
            set
            {
                InputTelefono1.Value = value;
            }
        }
        public string Datepicker1
        {
            get
            {
                return datepicker1.Value;
            }
            set
            {
                datepicker1.Value = value;
            }
        }
        public string inputPresupuesto1
        {
            get
            {
                return InputPresupuesto1.Value;
            }
            set
            {
                InputPresupuesto1.Value = value;
            }
        }
        public string inputPlazoPago1
        {
            get
            {
                return InputPlazoPago1.Value;
            }
            set
            {
                InputPlazoPago1.Value = value;
            }
        }

        public DropDownList direccion
        {
            get
            {
                return this.InputDireccion1;
            }
            set
            {
                //InputDireccion1 = value;
            }
        }
        #endregion


        /// <summary>
        /// Método de carga de página en el cual carga los campos con los datos de la compañía.
        /// </summary>
        /// <param name="idComp">id de la compañía a modificar</param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Presentador.CargarCompania(int.Parse(Request.QueryString["idComp"]));
                }
            }
            catch (Exception ex)
            { 
            }
        }

        /// <summary>
        /// Método para concretar la modificación luego de que se haga click en "modificar"
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            Presentador.ModificarCompania(int.Parse(Request.QueryString["idComp"]));
            Server.Transfer("ConsultarCompania.aspx", true);
        }

        /// <summary>
        /// Método de carga de lugares tipo ciudad en el combobox de dirección.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
    }
}