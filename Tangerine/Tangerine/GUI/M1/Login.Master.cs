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
using DominioTangerine.Entidades.M1;
using Tangerine_Contratos.M1;
using Tangerine_Presentador.M1;
using LogicaTangerine.Comandos.M8;
using LogicaTangerine.Comandos.M7;
using LogicaTangerine.Fabrica;
using DominioTangerine.Entidades.M8;
using DominioTangerine.Fabrica;



namespace Tangerine.GUI.M1
{
    public partial class Login1 : System.Web.UI.MasterPage, IContratoInicio
    {
       // LogicaM1 _logicaM1 = new LogicaM1();
        //string _usuario = String.Empty;
        //string _contrasena = String.Empty;
        //LogicaProyecto proyectoLogic = new LogicaProyecto();
        //bool facturaExistente = false;
        //int montoFactura = 0;

        PresentadorInicio presentador;

        #region Contrato

        /// <summary>
        /// textBox de la contraseña
        /// </summary>
        public string passwordInput
        {
            get { return passwordIni.Value; }
            set { passwordIni.Value = value; }
        }

        /// <summary>
        /// Encabezado del textBox del nombre de usuario
        /// </summary>
        public string userInput
        {
            get { return userIni.Value; }
            set { userIni.Value = value; }
        }

        /// <summary>
        /// Encabezado del textBox del mensaje de error
        /// </summary>
        public string mensajeVista
        {
            get { return mensaje.Text; }
            set { mensaje.Text = value; }
        }

        #endregion

        public Login1()
        {
            this.presentador = new PresentadorInicio(this);
        }

        /// <summary>
        /// Carga la ventana Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            presentador.ValidarSesion();
            
        }
       
        public void ValidarUsuario(object sender, EventArgs e)
        {
            presentador.ValidarElUsuario();
           

        }
    }
}