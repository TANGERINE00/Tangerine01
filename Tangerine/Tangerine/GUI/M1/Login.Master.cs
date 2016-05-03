using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M1;
using LogicaTangerine.M8;
using DatosTangerine.M7;

namespace Tangerine.GUI.M1
{
    public partial class Login1 : System.Web.UI.MasterPage
    {
        LogicaM1 _logicaM1 = new LogicaM1();
        string _usuario = String.Empty;
        string _contrasena = String.Empty;
        BDProyecto proyectoBD = new BDProyecto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["User"]+"" != "")
                HttpContext.Current.Session.Abandon();
        }
        /// <summary>
        /// Metodo resultante de accionar el acceder, realiza la conexion con LogicaTangerine para validar las entradas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ValidarUsuario(object sender, EventArgs e)
        {
            Usuario nuevoUsuario = new Usuario(); 
            _usuario = userIni.Value.ToString();
            _contrasena = passwordIni.Value.ToString();


            if (_logicaM1.ValidarUsuario(_usuario, _contrasena))
            {

                HttpContext.Current.Session["User"] = Util._theGlobalUser.NombreUsuario;
                HttpContext.Current.Session["UserID"] = Util._theGlobalUser.FichaEmpleado;
                HttpContext.Current.Session["Rol"] = Util._theGlobalUser.Rol.Nombre;
                /*
                List<Proyecto> listProyecto = proyectoBD.ContactProyectosxAcuerdoPago();
                foreach (Proyecto theProyecto in listProyecto)
                {
                    Facturacion factura = new Facturacion(DateTime.Now, DateTime.Now, theProyecto.Costo, theProyecto.Costo, "Bolivares", "Facturación Mensual", 0, theProyecto.Idproyecto, theProyecto.Idresponsable);
                    LogicaM8 facturaLogic = new LogicaM8();
                    facturaLogic.AddNewFactura(factura);
                }
                */
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                mensaje.Text = "Error en el inicio de sesión";
                //Response.Redirect("Login.aspx");
            }
            
            

        }
    }
}