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
            
        }

        public void CerrarSesion( object sender, EventArgs e )
        {
           presentador.CerrarSesionP();
            
        }

      

    }
}