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

                    InputNombre1.Value = laCompania.NombreCompania;
                    InputAcronimo1.Value = laCompania.AcronimoCompania;
                    InputRIF1.Value = laCompania.RifCompania;
                    InputDireccion1.Value = logica.MatchNombreLugar(laCompania.IdLugar);
                    InputEmail1.Value = laCompania.EmailCompania;
                    InputTelefono1.Value = laCompania.TelefonoCompania;
                    InputFechaRegistro1.Value = laCompania.FechaRegistroCompania.ToString();
                }
            }
            catch (Exception ex)
            { 
            }
        }

        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            Server.Transfer("ConsultarCompania.aspx", true);
        }
    }
}