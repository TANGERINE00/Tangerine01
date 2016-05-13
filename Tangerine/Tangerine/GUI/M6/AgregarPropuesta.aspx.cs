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
        string _fechaI = String.Empty;
        string _fechaF = String.Empty;
        string _moneda = String.Empty;
        int _costo = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenaComboDuracion();
        }

        protected void btnagregar_Click(object sender, EventArgs e)
        {
            _descripcion = descripcion.Value;
          //  _duracion = ;
            

        }

        public void LlenaComboDuracion()
        {
            comboDuracion.Items.Add("Meses");
            comboDuracion.Items.Add("Dias2");
            comboDuracion.Items.Add("Horas");
        }
    }
}