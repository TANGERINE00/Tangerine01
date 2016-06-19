using DatosTangerine.M2;
using DominioTangerine;
using LogicaTangerine.M2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.Master;
using Tangerine_Presentador.Master;
using DominioTangerine.Entidades.M1;

namespace Tangerine.GUI.Master
{
    public partial class Tangerine : System.Web.UI.MasterPage, IContratoMasterPage
    {
        /// <summary>
        /// Método que ejecuta al cargar la página. Aqui se verifica la permisología del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private Cuenta userLogin = new Cuenta();
        private PresentadorMasterPage presentador { get; set; }


        Cuenta IContratoMasterPage.UserLogin
        {
            get { return userLogin; }
            set { userLogin = value; }
        }


        public void CargarMenus()
        { 
           // presentador.
        }



        protected void Page_Load( object sender, EventArgs e )
        {
            
            if ( HttpContext.Current.Session[ "User" ] == null )
                Response.Redirect( "../M1/Login.aspx" );
            else
            {
                if ( ( Util.MASTER_FLAG ) && ( HttpContext.Current.Session[ "Rol" ] !=null ) )
                {
                    Uri thisPageUrl = Request.Url;
                    string pathDePaginaActal = thisPageUrl.AbsolutePath;
                    string nombreRol = HttpContext.Current.Session[ "Rol" ].ToString();

                    bool privilegioAcceso = LogicaPrivilegios.VerificarAccesoAPagina( pathDePaginaActal, nombreRol );

                    if ( privilegioAcceso )
                    {
                        Response.Redirect( "../M1/Dashboard.aspx" );
                    }
                    else
                    {
                        List<string> bloqueos = LogicaPrivilegios.VerificarAccesoAOpciones( nombreRol );

                        foreach ( string s in bloqueos )
                        {
                            System.Diagnostics.Debug.WriteLine(s);
                            this.FindControl( s ).Visible = false;
                        }
                    }
                }
            }


            if ( HttpContext.Current.Session[ "User" ] != null )
                usuarioSesion.InnerText = HttpContext.Current.Session[ "User" ] + "";

            if (HttpContext.Current.Session["User"] != null)
            {
                usuarioSesion.InnerText = HttpContext.Current.Session["User"] + "";
                UsuarioDetalle.InnerText = HttpContext.Current.Session["Rol"] + "";
                fechaUsuario.InnerText = HttpContext.Current.Session["Date"] + "";
            }

            else
                usuarioSesion.InnerText = "Usuario";
        }

        public void CerrarSesion( object sender, EventArgs e )
        {
            Util._theGlobalUser = null;
            HttpContext.Current.Session.Abandon();
            Response.Redirect( "../M1/Login.aspx" );
        }

      

    }
}