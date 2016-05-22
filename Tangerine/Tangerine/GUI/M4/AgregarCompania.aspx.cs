using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M4;

namespace Tangerine.GUI.M4
{
    public partial class AgregarCompania : System.Web.UI.Page
    {
        LogicaM4 logica = new LogicaM4();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarComboBoxLugar();
            }
            
        }

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
            int _direccionId = logica.MatchIdLugar(InputDireccion1.Value);

            Compania company = new Compania(_nombre, _rif, _email, _telefono, _acronimo, 
                                            DateTime.ParseExact(_fecha, "MM/dd/yyyy", null), _status, _presupuesto, _plazo, 
                                            _direccionId);
            logica.AddNewCompany(company);

            Server.Transfer("ConsultarCompania.aspx", true);
        }

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