using DatosTangerine.M2;
using DominioTangerine;
using LogicaTangerine.M2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tangerine.GUI.Master
{
    public partial class Tangerine : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if( Util.MASTER_FLAG )
            {
                Util._theGlobalUser.NombreUsuario = "luarropa";                            //En teoria esto no va,
                Util._theGlobalUser.Contrasenia = "1234";                                  //se haria al hacer login
                Util._theGlobalUser = BDUsuario.ObtenerDatoUsuario( Util._theGlobalUser ); //-----------------------

                Uri thisPageUrl = Request.Url;
                string pathDePaginaActal = thisPageUrl.AbsolutePath;

                bool privilegioAcceso = LogicaPrivilegios.VerificarAccesoAPagina(pathDePaginaActal);

                if (privilegioAcceso)
                {
                    List<string> bloqueos = LogicaPrivilegios.VerificarAccesoAOpciones();

                    foreach (string s in bloqueos)
                    {
                        this.FindControl(s).Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("../../M1/Dashboard.aspx");
                }
            }
        }
    }
}