using DominioTangerine;
using DominioTangerine.Entidades.M1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine;
using Tangerine_Contratos.Master;



namespace Tangerine_Presentador.Master
{
    public class PresentadorMasterPage
    {
        private IContratoMasterPage _iMaster;
        

        public PresentadorMasterPage(IContratoMasterPage Imaster)
        {
            _iMaster = Imaster;
        }


        /// <summary>
        /// Metodo que Carga la sesion y la mantiene en ella
        /// </summary>
        public void CargarSesion()
        {
            if (HttpContext.Current.Session["User"] == null)
                HttpContext.Current.Response.Redirect("../M1/Login.aspx");
            else
            {
                if (( UtilM1.MASTER_FLAG) && (HttpContext.Current.Session["Rol"] != null))
                {

                    Uri thisPageUrl = HttpContext.Current.Request.Url;
                    string pathDePaginaActal = thisPageUrl.AbsolutePath;
                    string nombreRol = HttpContext.Current.Session["Rol"].ToString();

                    //Creación y Ejecución del Objeto Comando de verificacion de acceso a la pagina, se le envia 
                    //por parámetro el path de la pagina y el rol del usuario
                   
                    Comando<bool> comando =
                     LogicaTangerine.Fabrica.FabricaComandos.obtenerComandoVerificarAccesoAPagina(pathDePaginaActal, nombreRol);

                    bool privilegioAcceso = comando.Ejecutar();

                    if (privilegioAcceso)
                    {
                        HttpContext.Current.Response.Redirect("../M1/Dashboard.aspx");
                    }
                    else
                    {
                        Comando<List<string>> comandoL = 
                            LogicaTangerine.Fabrica.FabricaComandos.obtenerComandoVerificarAccesoAOpciones(nombreRol);
                        List<string> bloqueos = comandoL.Ejecutar();
                       

                        foreach (string s in bloqueos)
                        {
                            System.Diagnostics.Debug.WriteLine(s);
                            _iMaster.IFindControl(s);
                            
                        }
                    }
                }
            }


            if (HttpContext.Current.Session["User"] != null)
               _iMaster.sesionUsuario = HttpContext.Current.Session["User"] + "";
            

            if (HttpContext.Current.Session["User"] != null)
            {
                _iMaster.sesionUsuario = HttpContext.Current.Session["User"] + "";
                _iMaster.usuarioDet = HttpContext.Current.Session["Rol"] + "";
                _iMaster.fechaUser = HttpContext.Current.Session["Date"] + "";
            }

            else
                _iMaster.sesionUsuario = "Usuario";
        }

        /// <summary>
        /// Metodo que cierra la sesion
        /// </summary>
         public void CerrarSesionP()
        {
            UtilM1._theGlobalUser = null;
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Redirect("../M1/Login.aspx");
        }




    }
}
