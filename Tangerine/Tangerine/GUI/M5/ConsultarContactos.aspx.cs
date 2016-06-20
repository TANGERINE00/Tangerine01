using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M5;
using LogicaTangerine.M3;
using LogicaTangerine.M4;
using Tangerine_Contratos.M5;
using Tangerine_Presentador.M5;
using DominioTangerine.Entidades.M5;

namespace Tangerine.GUI.M5
{
    public partial class ConsultarContactos : System.Web.UI.Page, IContratoConsultarContactos
    {
        private PresentadorConsultarContactos presentador;

        #region Atributos

        public string alertaClase
        {
            set { alert.Attributes[ ResourceGUIM5.alertClase ] = value; }
        }

        public string alertaRol
        {
            set { alert.Attributes[ ResourceGUIM5.alertRole ] = value; }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }

        public Literal contact
        {
            get { return this.tabla; }
            set { this.tabla = value; }
        }

        public string botonVolver
        {
            get { return this.volver.Text; }
            set { this.volver.Text = value; }
        }

        public string button
        {
            get { return this.nuevocontacto.Text; }
            set { this.nuevocontacto.Text = value; }
        }

        public string nombreEmpresa
        {
            get { return this.empresa.Text; }
            set { this.empresa.Text = value; }
        }

        public int getTypeComp
        {
            get { return int.Parse( Request.QueryString[ ResourceGUIM5.typeComp ] ); }
        }
        public int getIdComp
        {
            get { return int.Parse( Request.QueryString[ ResourceGUIM5.idComp ] ); }
        }

        public int IdCont()
        {
            return int.Parse( Request.QueryString[ ResourceGUIM5.idCont ] );
        }

        public int StatusAccion()
        {
            return int.Parse( Request.QueryString[ ResourceGUIM5.Status ] );
        }

        public string CargarBotonNuevoContacto( int typeComp, int idComp )
        {
            return this.button += ResourceGUIM5.VentanaAgregarContacto + typeComp.ToString()
                    + ResourceGUIM5.ParametroIdComp + idComp.ToString() + ResourceGUIM5.FinalAgregarContacto;
        }
        #endregion

        /// <summary>
        /// Metodo de carga de los elementos de la ventana.
        /// </summary>
        protected void Page_Load( object sender, EventArgs e )
        {
            presentador = new PresentadorConsultarContactos( this );
            presentador.CargarPagina();
        }
    }
}
