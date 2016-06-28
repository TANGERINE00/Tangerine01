using DominioTangerine;
using LogicaTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows;
using Tangerine_Contratos.M4;
using Tangerine_Presentador.M4;

namespace Tangerine.GUI.M4
{
    public partial class AgregarCompania : System.Web.UI.Page , IContratoAgregarCompania
    {
        PresentadorAgregarCompania Presentador;
        string error;

        public AgregarCompania() {
            Presentador = new PresentadorAgregarCompania(this);
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
       public string msjError
       {
           get 
           {
               return error;
           }
           set 
           {
               error = value;
           }
       }


       /// <summary>
       /// Clase de alerta, para excepciones
       /// </summary>
       public string alertaClase
       {
           set { alert.Attributes[ResourceGUIM4.alertClase] = value; }
       }

       /// <summary>
       /// Atributos de alerta, para excepciones
       /// </summary>
       public string alertaRol
       {
           set { alert.Attributes[ResourceGUIM4.alertRol] = value; }
       }
       /// <summary>
       /// Alerta cuando hay una excepcion
       /// </summary>
       public string alerta
       {
           set { alert.InnerHtml = value; }
       }
        #endregion

        /// <summary>
        /// Método de carga de página en el cual carga los lugares tipo ciudad en un combobox.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Presentador.CargarLugares();
            }
            
        }

        /// <summary>
        /// Método que concreta la agregación de una nueva compañía luego de ser presionado el botón agregar.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected void btnagregar_Click(object sender, EventArgs e)
        {

            if (Presentador.AgregarCompania())
                Response.Redirect("../M4/ConsultarCompania.aspx", false);
            else
                Presentador.Alerta(msjError);
        }
    }
}