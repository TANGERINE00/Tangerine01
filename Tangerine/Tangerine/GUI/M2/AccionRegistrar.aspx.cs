using LogicaTangerine.M2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M2;

namespace Tangerine.GUI.M2
{
    public partial class AccionRegistrar : System.Web.UI.Page, IContratoAccionRegistrar
    {
        public static int numFicha;
        public static string nombreUsuario;
        public static string apellidoUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            numFicha = int.Parse(Request.QueryString["idFicha"]);
            nombreUsuario = Request.QueryString["Nombre"];
            apellidoUsuario = Request.QueryString["Apellido"];
            userDefault.Value = ObtenerUsuarioDefault2(nombreUsuario,apellidoUsuario);
        }

        #region Web Methods 

        public void ObtenerUsuarioDefault()
        {
            string resultado = "";

            resultado = LogicaAgregarUsuario.CrearUsuarioDefault(nombreUsuario, apellidoUsuario);

            userDefault.Value = resultado;
        }

        /// <summary>
        /// Método para crear el usuario por defecto
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="apellidoUsuario"></param>
        /// <returns></returns>
        [WebMethod]
        public static string ObtenerUsuarioDefault2(string nombreUsuario, string apellidoUsuario)
        {
            string resultado = "";

            resultado = LogicaAgregarUsuario.CrearUsuarioDefault(nombreUsuario, apellidoUsuario);

            return resultado;
        }

        /// <summary>
        /// Método para validar si el usuario escrito existe o no.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [WebMethod]
        public static string validarUsuario(string usuario)
        {
            string nombreUsuario = usuario;
            bool respuesta = false;
            respuesta = LogicaAgregarUsuario.ExisteUsuario(nombreUsuario);

            string retorno = "Disponible";

            if (respuesta)
            {
                retorno = "Usuario Existe!";
            }

            return retorno;
        }

        #endregion

        #region Contrato

            /// <summary>
            /// comboBox de seleccion de rol
            /// </summary>
            public string comboRol
            {
                get { return textRol_M2.Value;}
                set { textRol_M2.Value = value; }
            }

            /// <summary>
            /// textBox de la contraseña
            /// </summary>
            public string contrasena
            {
                get { return passwordDefault.Value; }
                set { passwordDefault.Value = value;}
            }

            /// <summary>
            /// Encabezado del textBox del nombre de usuario
            /// </summary>
            public string usuario
            {
                get { return userDefault.Value; }
                set { userDefault.Value = value;}
            }

        #endregion

        /// <summary>
        /// Crear el usuario de un empleado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            string rol = textRol_M2.Value;
            string nombreUsuario = userDefault.Value;
            string contraseniaUsuario = passwordDefault.Value;

            LogicaAgregarUsuario.PrepararUsuario(nombreUsuario, contraseniaUsuario, rol, numFicha);

            Response.Redirect("../M2/RegistroUsuario.aspx");
        }
    }
}