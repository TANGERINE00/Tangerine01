using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using Tangerine_Contratos.M5;
using Tangerine_Presentador.M5;
using System.Web.Security.AntiXss;

namespace Tangerine.GUI.M5
{
    public partial class Modificar : System.Web.UI.Page, IContratoModificarContacto
    {
        private PresentadorModificarContacto presentador;
        #region Atributos
        public string botonVolver
        {
            get { return this.volver.Text; }
            set { this.volver.Text = value; }
        }
        public string input_nombre
        {
            get { return this.nombre.Value; }
            set { this.nombre.Value = value; }
        }

        public string input_apellido
        {
            get { return this.apellido.Value; }
            set { this.apellido.Value = value; }
        }

        public string input_correo
        {
            get { return this.correo.Value; }
            set { this.correo.Value = value; }
        }

        public string input_departamento
        {
            get { return this.departamento.Value; }
            set { this.departamento.Value = value; }
        }

        public string input_telefono
        {
            get { return this.telefono.Value; }
            set { this.telefono.Value = value; }
        }

        public string item_cargo
        {
            get { return this.cargoLB.Value; }
            set { this.cargoLB.Value = value; }
        }
        public string alertaClase
        {
            set { alert.Attributes[ResourceGUIM5.alertClase] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[ResourceGUIM5.alertRole] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }
        public int GetTypeComp()
        {
            try
            {
                return int.Parse( AntiXssEncoder.HtmlEncode( Request.QueryString[ ResourceGUIM5.typeComp ],
                                                             false ) );
            }
            catch ( Exception ex )
            {
                Response.Redirect( "../M1/DashBoard.aspx" );
            }

            return 0;
        }

        public int GetIdComp()
        {
            try 
            {
                return int.Parse( AntiXssEncoder.HtmlEncode( Request.QueryString[ ResourceGUIM5.idComp ],
                                                             false ) ); 
            }
            catch ( Exception ex )
            {
                Response.Redirect( "../M1/DashBoard.aspx" );
            }

            return 0;
        }

        public int GetidCont()
        {
            try 
            {
                return int.Parse( AntiXssEncoder.HtmlEncode( Request.QueryString[ ResourceGUIM5.idCont ],
                                                             false ) ); 
            }
            catch ( Exception ex )
            {
                Response.Redirect( "../M1/DashBoard.aspx" );
            }

            return 0;
        }
        #endregion

        /// <summary>
        /// Carga el boton volver, configurado para regresar con los datos de la pagina anterior 
        /// </summary>
        /// <param name="typeComp"></param>
        /// <param name="idComp"></param>
        /// <returns></returns>
        public string CargarBotonVolver( int typeComp, int idComp )
        {
            return this.botonVolver = ResourceGUIM5.BotonVolver + typeComp + ResourceGUIM5.BotonVolver2 + idComp
                                      + ResourceGUIM5.BotonVolver3;
        }

        /// <summary>
        /// Método que se ejecuta luego hacer la accion de agregar el contacto. Regresa a la pagina anterior,
        /// indicando si se agregó o no el contacto.
        /// </summary>
        /// <param name="typeComp"></param>
        /// <param name="idComp"></param>
        public void BotonAceptar( int typeComp, int idComp )
        {
            Server.Transfer( ResourceGUIM5.hrefConsultarContacto + typeComp + ResourceGUIM5.BotonVolver2 + idComp
                             + ResourceGUIM5.BotonVolver4 + ResourceGUIM5.StatusModificado );
        }

        /// <summary>
        /// Método que se ejecuta al cargar la página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load( object sender, EventArgs e )
        {
            presentador = new PresentadorModificarContacto( this );
            presentador.CargarPagina();
            if ( !IsPostBack )
            {
                presentador.NoPostPagina();
            }
        }

        /// <summary>
        /// Método que se ejecuta al hacer click en el boton modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnmodificar_Click( object sender, EventArgs e )
        {
            presentador.ModificarContacto();
        }
    }
}
