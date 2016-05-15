using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M6;
using System.Diagnostics;

namespace Tangerine.GUI.M6
{
    public partial class AgregarPropuesta : System.Web.UI.Page
    {
        string _nombcodigoPropuesta = String.Empty;
        string _idCompañia = String.Empty;
        string _nombrecompañia = String.Empty;
        string _descripcion = String.Empty;
        string _Tipoduracion = String.Empty;
        string _duracion = String.Empty;      
        DateTime _fechaI;
        DateTime _fechaF;
        string _moneda = String.Empty;
        int _costo = 0;
        string _acuerdo = String.Empty;
        int _entregaCant = 0;
        string _fdepago = String.Empty;
        string _estatusW;
        DateTime today = DateTime.Today;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarComboDuracion();
            llenarComboTipoCosto();
        }

        protected void btnagregar_Click(object sender, EventArgs e)
        {
            _nombcodigoPropuesta = cliente.Value + today.ToString("yyyyMMdd");
            _descripcion = descripcion.Value;
            _Tipoduracion = comboDuracion.SelectedIndex.ToString();
            _duracion = textoDuracion.Value;
            
            Debug.Print(datepicker1.Value);
            _fechaI = DateTime.ParseExact(datepicker1.Value, "MM/dd/yyyy", null);

            _fechaF = DateTime.ParseExact(datepicker2.Value, "MM/dd/yyyy", null);
            _moneda = comboTipoCosto.SelectedIndex.ToString();
            _costo = int.Parse(textoCosto.Value);
            _acuerdo = "pruebaclable";
            _entregaCant = 2;
            _fdepago = fpago.Value;
            _estatusW = estatus.Value;
            _idCompañia = "1";

            Propuesta propuesta = new Propuesta(_nombcodigoPropuesta, _descripcion, _Tipoduracion, _duracion, _acuerdo, _estatusW, _moneda,
                                                 _entregaCant, _fechaI, _fechaF, _costo, _idCompañia);
            LogicaPropuesta propuestaLogica = new LogicaPropuesta();
            propuestaLogica.agregar(propuesta);

         
        }

        public void llenarComboDuracion()
        {
            comboDuracion.Items.Add("Meses");
            comboDuracion.Items.Add("Dias");
            comboDuracion.Items.Add("Horas");
        }

   

        public void llenarComboTipoCosto()
        {
            comboTipoCosto.Items.Add("Bolivares");
            comboTipoCosto.Items.Add("Dolares");
            comboTipoCosto.Items.Add("Euros");
            comboTipoCosto.Items.Add("Bitcoins");
        }
    }
}