using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M1;

namespace Tangerine.GUI.M1
{
    public partial class Login1 : System.Web.UI.MasterPage
    {
        LogicaM1 _logicaM1 = new LogicaM1();
        string _usuario = String.Empty;
        string _contrasena = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Metodo resultante de accionar el acceder, realiza la conexion con LogicaTangerine para validar las entradas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ValidarUsuario(object sender, EventArgs e)
        {
            _usuario = userIni.Value.ToString();
            _contrasena = passwordIni.Value.ToString();
            if (_logicaM1.ValidarUsuario(_usuario, _contrasena))
            {
                HttpContext.Current.Session["User"] = _usuario;
                HttpContext.Current.Session["Clave"] = _contrasena;
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }



        }
    }
}