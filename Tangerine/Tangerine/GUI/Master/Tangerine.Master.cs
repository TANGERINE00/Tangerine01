using DatosTangerine.M2;
using DominioTangerine;
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
                /*Util._theGlobalUser.NombreUsuario = "luarropa";
                Util._theGlobalUser.Contrasenia = "1234";
                Util._theGlobalUser = BDUsuario.ObtenerDatoUsuario( Util._theGlobalUser );

                foreach ( DominioTangerine.Menu m in Util._theGlobalUser.Rol.Menus )
                {
                    foreach (Opcion o in m.Opciones)
                    {
                        this.FindControl(o.Nombre).Visible = false;
                    }
                }*/
            }
        }
    }
}