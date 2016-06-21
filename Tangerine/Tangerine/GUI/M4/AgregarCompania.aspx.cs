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
    public partial class AgregarCompania : System.Web.UI.Page , IContratoAgregarCompania
    {
        LogicaM4 logica = new LogicaM4();
        PresentadorAgregarCompania Presentador;

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

     /*   public DropDownList direccion 
        {
            get
            {

            }
            set
            {
                InputDireccion1 = value;
            } 
        }*/
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
                //llenarComboBoxLugar();
            }
            
        }

        /// <summary>
        /// Método que concreta la agregación de una nueva compañía luego de ser presionado el botón agregar.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected void btnagregar_Click(object sender, EventArgs e)
        {
            string _nombre = InputNombre1.Value;
            string _acronimo = InputAcronimo1.Value;
            string _rif = InputRIF1.Value;
            string _email = InputEmail1.Value;
            string _telefono = InputTelefono1.Value;
            string _fecha = datepicker1.Value;

            //Por defecto se crea la compania HABILITADA.
            int _status = 1;  
                            
            int _presupuesto = int.Parse(InputPresupuesto1.Value);
            int _plazo = int.Parse(InputPlazoPago1.Value.ToString());
            /*int _direccionId = logica.MatchIdLugar(/*InputDireccion1);

            Compania company = new Compania(_nombre, _rif, _email, _telefono, _acronimo, 
                                            DateTime.ParseExact(_fecha, "MM/dd/yyyy", null), _status, _presupuesto, 
                                            _plazo, _direccionId);
            logica.AddNewCompany(company);*/

            Server.Transfer("ConsultarCompania.aspx", true);
        }

        /// <summary>
        /// Método de carga de lugares tipo ciudad en un combobox.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected void llenarComboBoxLugar()
        {
            List<LugarDireccion> listPlace = logica.getPlaces();

            try
            {
                foreach (LugarDireccion thePlace in listPlace)
                {
                    InputDireccion1.Items.Add(thePlace.LugNombre);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}