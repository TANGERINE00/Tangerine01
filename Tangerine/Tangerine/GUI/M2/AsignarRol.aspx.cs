using DatosTangerine.M10;
using DatosTangerine.M2;
using DominioTangerine;
using LogicaTangerine.M2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tangerine.GUI.M2
{
    public partial class AsignarRol : System.Web.UI.Page
    {

        string nombreUsuario = String.Empty;
        string rol = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            int numFicha = int.Parse(Request.QueryString["idEmpleado"]);
            
            if (!IsPostBack)
            {
                Usuario user = LogicaModificarRol.ObtenerUsuario(numFicha);
                textUsuario_M2.Value = user.NombreUsuario;
                textRol_M2.Value = user.Rol.Nombre;
            }  

        }

        protected void buttonAsignar_Click(object sender, EventArgs e)
        {
            nombreUsuario = textUsuario_M2.Value;
            rol = textRol_M2.Value;

            LogicaModificarRol.ModificarRol(nombreUsuario, rol);

            Response.Redirect("../M2/CambiarRol.aspx");
        }
    }
}