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
        string _nombre = String.Empty;
        string _acronimo = String.Empty;
        string _rif = String.Empty;
        string _email = String.Empty;
        string _telefono = String.Empty;
        string _fecha = String.Empty;
        int _status = 1; // se crea el status activo por default.
        int _direccionId = 1; //hacer el combo-box de lugares, se utiliza 1 para pruebas. ARREGLAR!!

        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaM4 prueba = new LogicaM4();

            if (!IsPostBack)
            {
                List<LugarDireccion> listPlace = prueba.getPlaces();

                try
                {
                    foreach (LugarDireccion thePlace in listPlace)
                    {
                       
                    }
                }

                catch (Exception ex)
                {

                }
            }
            
        }

        protected void btnagregar_Click(object sender, EventArgs e)
        {
            _nombre = InputNombre1.Value;
            _acronimo = InputAcronimo1.Value;
            _rif = InputRIF1.Value;
            _email = InputEmail1.Value;
            _telefono = InputTelefono1.Value;
            _fecha = InputFechaRegistro1.Value;

            Compania company = new Compania(_nombre, _rif, _email, _telefono, _acronimo, DateTime.Parse(_fecha),
                                                _status, _direccionId);
            LogicaM4 companyLogic = new LogicaM4();
            companyLogic.AddNewCompany(company);

            Server.Transfer("ConsultarCompania.aspx", true);
        }
    }
}