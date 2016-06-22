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
       
        private PresentadorMasterPage presentador { get; set; }


        #region Contrato
        string IContratoMasterPage.sesionUsuario
        {
            get { return usuarioSesion.InnerText; }
            set { usuarioSesion.InnerText = value; }
        }

        string IContratoMasterPage.fechaUser
        {
            get { return fechaUsuario.InnerText; }
            set { fechaUsuario.InnerText = value; }
        }

        string IContratoMasterPage.usuarioDet
        {
            get { return UsuarioDetalle.InnerText; }
            set { UsuarioDetalle.InnerText = value; }
        }

        public bool IFindControl(string id)
        {

            this.FindControl(id).Visible = false;
            return true;
        }
        #endregion

        public Tangerine()
        {
           this.presentador = new PresentadorMasterPage(this);
        }



        protected void Page_Load( object sender, EventArgs e )
        {
           presentador.CargarSesion();
            //if (HttpContext.Current.Session["User"] == null)
            //    Response.Redirect("../M1/Login.aspx");
            //else
            //{
            //    if ((Util.MASTER_FLAG) && (HttpContext.Current.Session["Rol"] != null))
            //    {
            //        Uri thisPageUrl = Request.Url;
            //        string pathDePaginaActal = thisPageUrl.AbsolutePath;
            //        string nombreRol = HttpContext.Current.Session["Rol"].ToString();





            //        bool privilegioAcceso = LogicaPrivilegios.VerificarAccesoAPagina(pathDePaginaActal, nombreRol);

            //        if (privilegioAcceso)
            //        {
            //            Response.Redirect("../M1/Dashboard.aspx");
            //        }
            //        else
            //        {
            //            List<string> bloqueos = LogicaPrivilegios.VerificarAccesoAOpciones(nombreRol);

            //            foreach (string s in bloqueos)
            //            {
            //                System.Diagnostics.Debug.WriteLine(s);
            //                this.FindControl(s).Visible = false;
            //            }
            //        }
            //    }
            //}


            //if (HttpContext.Current.Session["User"] != null)
            //    usuarioSesion.InnerText = HttpContext.Current.Session["User"] + "";

            //if (HttpContext.Current.Session["User"] != null)
            //{
            //    usuarioSesion.InnerText = HttpContext.Current.Session["User"] + "";
            //    UsuarioDetalle.InnerText = HttpContext.Current.Session["Rol"] + "";
            //    fechaUsuario.InnerText = HttpContext.Current.Session["Date"] + "";
            //}

            //else
            //    usuarioSesion.InnerText = "Usuario";
        }

        public void CerrarSesion( object sender, EventArgs e )
        {
           presentador.CerrarSesionP();
            //Util._theGlobalUser = null;
            //HttpContext.Current.Session.Abandon();
            //Response.Redirect("../M1/Login.aspx");
        }

      

    }
}