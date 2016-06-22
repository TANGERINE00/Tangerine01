using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M3;



namespace Tangerine.GUI.M3
{
    public partial class AgregarLeads : System.Web.UI.Page
    {
        string _nombre = String.Empty;
        string _rif = String.Empty;
        string _email = String.Empty;
        float _presupuesto = 0;
      //  int _llamadas = 0;
      //  int _visitas = 0;
      //  string _potencial = String.Empty;
      //  string _borrado = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            _nombre = nombre.Value;
            _rif = rif.Value;
            _email = email.Value;
            _presupuesto = float.Parse(presupuesto.Value);
          //  _llamadas = int.Parse(llamadas.Value);
          //  _visitas = int.Parse(Visitas.Value);
          //  _potencial=Potencial.Value;
          //  _borrado = Borrado.Value;
            //Los dos ultimos valores deben de venir de la ventana de consultar contactos (tipo empresa y id empresa)
            // ((_nombre, _rif, _email, _presupuesto, _lla) en esa parte esta usando lo del constructor sin id
            ClientePotencial clientePotencial = new ClientePotencial(_nombre, _rif, _email, _presupuesto,1);//, _llamadas, _visitas, _potencial, _borrado);
            LogicaM3 clientePotencialLogica = new LogicaM3();
            //clientePotencialLogica. AgregarNuevoclientePotencial(clientePotencial);
            Response.Redirect("Listar.aspx");


        }
    }
}



