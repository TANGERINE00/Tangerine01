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
    public partial class ModificarCompania : System.Web.UI.Page
    {
        LogicaM4 logica = new LogicaM4();

        protected void Page_Load(object sender, EventArgs e)
        {
            Compania laCompania;
            int idComp;

            try
            {
                idComp = int.Parse(Request.QueryString["idComp"]);
                laCompania = logica.SearchCompany(idComp);

                if (!IsPostBack)
                {
                    llenarComboBoxLugar();
                    InputNombre1.Value = laCompania.NombreCompania;
                    InputAcronimo1.Value = laCompania.AcronimoCompania;
                    InputRIF1.Value = laCompania.RifCompania;
                    InputDireccion1.Value = logica.MatchNombreLugar(laCompania.IdLugar);
                    InputEmail1.Value = laCompania.EmailCompania;
                    InputTelefono1.Value = laCompania.TelefonoCompania;
                    InputFechaRegistro1.Value = laCompania.FechaRegistroCompania.ToShortDateString();
                    // InputPresupuesto1.Value = laCompania.PresupuestoCompania;
                    // InputPlazoPago1.Value = laCompania.PlazoPagoCompania;
                }
            }
            catch (Exception ex)
            { 
            }
        }

        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            string _nombre = InputNombre1.Value;
            string _acronimo = InputAcronimo1.Value;
            string _rif = InputRIF1.Value;
            string _email = InputEmail1.Value;
            string _telefono = InputTelefono1.Value;
            string _fecha = InputFechaRegistro1.Value;
            int _status = 1; //ARREGLAR ESTO, hacer un constructor que modifique todo MENOS status.
            int _presupuesto = 1; //ARREGLAR!
            int _plazo = 1; //ARREGLAR!
            int _direccionId = logica.MatchIdLugar(InputDireccion1.Value);

            Compania company = new Compania(_nombre, _rif, _email, _telefono, _acronimo, DateTime.Parse(_fecha),
                                                _status, _presupuesto, _plazo, _direccionId);
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