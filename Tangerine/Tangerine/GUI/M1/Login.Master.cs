using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M1;
using LogicaTangerine.M7;
using LogicaTangerine.Comandos.M8;
using LogicaTangerine.Fabrica;
using DominioTangerine.Entidades.M8;
using DominioTangerine.Fabrica;

namespace Tangerine.GUI.M1
{
    public partial class Login1 : System.Web.UI.MasterPage
    {
        LogicaM1 _logicaM1 = new LogicaM1();
        string _usuario = String.Empty;
        string _contrasena = String.Empty;
        LogicaProyecto proyectoLogic = new LogicaProyecto();
        bool facturaExistente = false;
        int montoFactura = 0;

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
                HttpContext.Current.Session["Date"] = Util._theGlobalUser.FechaCreacion.ToString("dd/MM/yyyy");

                #region Generación de facturas mensuales
                //// AQUI EMPIEZA EL CODIGO PARA GENERAR LAS FACTURAS DE PROYECTOS CON FORMA DE PAGO MENSUAL

                //List<Proyecto> listProyecto = proyectoLogic.consultarAcuerdoPagoMensual();
                //foreach (Proyecto theProyecto in listProyecto)
                //{
                //    montoFactura = Convert.ToInt32(proyectoLogic.calcularPagoMesual(theProyecto));
                //    //Facturacion factura = new Facturacion(DateTime.Now, DateTime.Now, montoFactura, montoFactura, "Bolivares", "Facturación Mensual", 0, theProyecto.Idproyecto, theProyecto.Idresponsable);
                //    //LogicaM8 facturaLogic = new LogicaM8();
                //    Facturacion factura2 = (Facturacion)FabricaEntidades.ObtenerFacturacion(DateTime.Now, DateTime.Now,
                //        montoFactura, montoFactura, "Bolivares", "Facturación Mensual", 0, theProyecto.Idproyecto,
                //        theProyecto.Idresponsable);

                //    facturaExistente = facturaLogic.SearchExistingBill(DateTime.Now, theProyecto.Idproyecto, theProyecto.Idresponsable);
                //    if (facturaExistente == false)
                //    {
                //        facturaLogic.AddNewFactura(factura);
                //    }
                //    facturaExistente = false;
                //}

                //// AQUI TERMINA EL CODIGO PARA GENERAR LA FACTURAS DE PROYECTOS CON FORMA DE PAGO MENSUAL
                //// HECHO POR EL MÓDULO 7 Y MÓDULO 8
                #endregion


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