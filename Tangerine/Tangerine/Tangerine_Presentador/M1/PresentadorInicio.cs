using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DominioTangerine.Entidades.M1;
using DominioTangerine;
using LogicaTangerine;
using System.Threading.Tasks;
using Tangerine_Contratos.M1;
using System.Web;
using DominioTangerine.Entidades.M2;
using LogicaTangerine.Comandos.M8;
using DominioTangerine.Entidades.M8;
using LogicaTangerine.Comandos.M7;
using LogicaTangerine.Fabrica;
using DominioTangerine.Fabrica;

namespace Tangerine_Presentador.M1
{
    public class PresentadorInicio
    {
        #region Variables

        private IContratoInicio _iMaster;

        string _usuario = String.Empty;
        string _contraseña = String.Empty;
        bool facturaExistente = false;
        int montoFactura = 0;


        #endregion

        public PresentadorInicio(IContratoInicio iMaster)
        {
            _iMaster = iMaster;
        }


        public void ValidarSesion()
        {
            if (HttpContext.Current.Session["User"] + "" != "")
            {
                HttpContext.Current.Session.Abandon();
            }

        }

        public void ValidarElUsuario()
        {

            UsuarioM2 usuarioEncrip = new UsuarioM2();
            _usuario = _iMaster.userInput.ToString();
            _contraseña = usuarioEncrip.GetMD5(_iMaster.passwordInput.ToString());
            
            //Creación del Objeto Usuario.
            Entidad user =
            DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioConUsuarioYContrasena(_usuario,_contraseña);

            //Creación y Ejecución del Objeto Comando de Agregar Usuario
            Comando<Entidad> cmdConsultar = LogicaTangerine.Fabrica.FabricaComandos.consultarUsuarioLogin(user);

            user = cmdConsultar.Ejecutar();



            if (((DominioTangerine.Entidades.M2.UsuarioM2)user).activo != null)
            {
                UtilM1._theGlobalUser = ((DominioTangerine.Entidades.M2.UsuarioM2)user);
                HttpContext.Current.Session["User"] = UtilM1._theGlobalUser.nombreUsuario;
                HttpContext.Current.Session["UserID"] = UtilM1._theGlobalUser.fichaEmpleado;
                HttpContext.Current.Session["Rol"] = UtilM1._theGlobalUser.rol.nombre;
                HttpContext.Current.Session["Date"] = UtilM1._theGlobalUser.fechaCreacion.ToString("dd/MM/yyyy");

                ComandoConsultarAcuerdoPagoMensual _comandoAcuerdo =
                    (ComandoConsultarAcuerdoPagoMensual)FabricaComandos.ObtenerComandoConsultarAcuerdoPagoMensual();
                List<Entidad> listProyecto = _comandoAcuerdo.Ejecutar();

                foreach (DominioTangerine.Entidades.M7.Proyecto theProyecto in listProyecto)
                {
                    ComandoCalcularPagoMensual _comandoCalcular = (ComandoCalcularPagoMensual)FabricaComandos.ObtenerComandoCalcularPagoMesual(theProyecto);
                    montoFactura = Convert.ToInt32(_comandoCalcular.Ejecutar());

                    Facturacion factura = (Facturacion)FabricaEntidades.ObtenerFacturacion(DateTime.Now, DateTime.Now,
                        montoFactura, montoFactura, "Bolivares", "Facturación Mensual", 0, theProyecto.Id,
                        theProyecto.Idresponsable);

                    ComandoSearchExistingBill _comandoBill = (ComandoSearchExistingBill)FabricaComandos.CrearSearchExistingBill(factura);
                    facturaExistente = _comandoBill.Ejecutar();

                    if (facturaExistente == false)
                    {
                        ComandoAgregarFactura _comandoAgregar = (ComandoAgregarFactura)FabricaComandos.CrearAgregarFactura(factura);
                        _comandoAgregar.Ejecutar();
                    }
                    facturaExistente = false;
                }

                HttpContext.Current.Response.Redirect("Dashboard.aspx");


            }
            else
            {
                _iMaster.mensajeVista = "Error en el inicio de sesión";
            }

        }

    }
}
