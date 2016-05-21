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
        LogicaM4 prueba = new LogicaM4();
        protected void Page_Load(object sender, EventArgs e)
        {

            Compania laCompania;
            int idComp;
            try { 
                    idComp = int.Parse(Request.QueryString["idComp"]);
                    laCompania = prueba.SearchCompany(idComp);
                }
            catch
            {
            }


            /* ---  A PARTIR DE AQUI PUEDES EMPEZAR A USAR EL MODIF */
        }
    }
}