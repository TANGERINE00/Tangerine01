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
        int _idComp;

        public int IdCompania
        {
            get { return _idComp; }
            set { _idComp = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Compania laCompania;

            try
            {
                IdCompania = int.Parse(Request.QueryString["idComp"]);
                laCompania = logica.ConsultCompany(IdCompania);

                if (!IsPostBack)
                {
                    llenarComboBoxLugar();
                    InputNombre1.Value = laCompania.NombreCompania;
                    InputAcronimo1.Value = laCompania.AcronimoCompania;
                    InputRIF1.Value = laCompania.RifCompania;
                    InputDireccion1.Value = logica.MatchNombreLugar(laCompania.IdLugar);
                    InputEmail1.Value = laCompania.EmailCompania;
                    InputTelefono1.Value = laCompania.TelefonoCompania;
                    datepicker1.Value = laCompania.FechaRegistroCompania.ToShortDateString();
                    InputPresupuesto1.Value = laCompania.PresupuestoCompania.ToString();
                    InputPlazoPago1.Value = laCompania.PlazoPagoCompania.ToString();
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
            string _fecha = datepicker1.Value;
            int _status = logica.ConsultCompany(IdCompania).StatusCompania;
            int _presupuesto = int.Parse(InputPresupuesto1.Value);
            int _plazo = int.Parse(InputPlazoPago1.Value.ToString());
            int _direccionId = logica.MatchIdLugar(InputDireccion1.Value);

            Compania company = new Compania(IdCompania, _nombre, _rif, _email, _telefono, _acronimo,
                                            DateTime.ParseExact(_fecha, "MM/dd/yyyy", null), _status, _presupuesto, 
                                            _plazo, _direccionId);
            logica.ChangeCompany(company);

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