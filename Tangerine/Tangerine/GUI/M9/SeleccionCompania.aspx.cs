using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M9;

namespace Tangerine.GUI.M9
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public string contact;

        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaM9 prueba = new LogicaM9();
            List<Compania> listCompania = prueba.getCompanias();

            try
            {
                foreach (Compania compania in listCompania )
                {
                    contact += ResourceLogicaM9.AbrirTR;
                    contact += ResourceLogicaM9.AbrirTD;
                    contact += compania.NombreCompania.ToString();
                    contact += ResourceLogicaM9.CerrarTD;
                    contact += ResourceLogicaM9.AbrirTD;
                    contact += compania.AcronimoCompania.ToString();
                    contact += ResourceLogicaM9.CerrarTD;
                    contact += ResourceLogicaM9.AbrirTD;
                    contact += compania.RifCompania.ToString();
                    contact += ResourceLogicaM9.CerrarTD;
                    contact += ResourceLogicaM9.AbrirTD;
                    contact += compania.EmailCompania.ToString();
                    contact += ResourceLogicaM9.CerrarTD;
                    contact += ResourceLogicaM9.AbrirTD;
                    contact += compania.FechaRegistroCompania.ToString();
                    contact += ResourceLogicaM9.CerrarTD;
                    contact += ResourceLogicaM9.AbrirTD;
                    contact += ResourceLogicaM9.AbrirSpan;
                        if (compania.StatusCompania.Equals(1))
                        {
                            contact += ResourceLogicaM9.EtiquetaHabilitada;
                        }
                        if (compania.StatusCompania.Equals(0))
                        {
                            contact += ResourceLogicaM9.EtiquetaHabilitada;
                        }
                    contact += compania.RifCompania.ToString();
                    contact += ResourceLogicaM9.CerrarTD;
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}