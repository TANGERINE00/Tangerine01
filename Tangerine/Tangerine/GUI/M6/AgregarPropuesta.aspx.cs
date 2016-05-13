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

namespace Tangerine.GUI.M6
{
    public partial class AgregarPropuesta : System.Web.UI.Page
    {

        string _descripcion = String.Empty;
        string _duracion = String.Empty;
        string _fechaI ;
        string _fechaF ;
        string _moneda = String.Empty;
        int _costo = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarComboDuracion();
            llenarComboTipoCosto();
        }

        protected void btnagregar_Click(object sender, EventArgs e)
        {
            _descripcion = descripcion.Value;
            _duracion = comboDuracion.SelectedIndex.ToString();
            _fechaI = datepicker1.ToString();
            DateTime.Parse(_fechaI);
          //  _duracion = ;
            

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