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

        public string BotonVolverCompania()
        {
            return ResourceGUIM5.VolverCompania;
        }

        public string BotonVolverLead()
        {
            return ResourceGUIM5.VolverCliPotencial;
        }

        public string EmpresaGen()
        {
            return ResourceGUIM5.Compania;
        }

        public string LeadGen()
        {
            return ResourceGUIM5.Lead;
        }

        public int IdCont()
        {
            return int.Parse( Request.QueryString[ ResourceGUIM5.idCont ] );
        }

        public int StatusAccion()
        {
            return int.Parse( Request.QueryString[ ResourceGUIM5.Status ] );
        }

        public int StatusAgregado()
        {
            return int.Parse( ResourceGUIM5.StatusAgregado );
        }

        public string ContactoAgregadoMsj()
        {
            return ResourceGUIM5.ContactoAgregado;
        }

        public string ContadoModificadoMsj()
        {
            return ResourceGUIM5.ContactoModificado;
        }

        public string ContactoEliminadoMsj()
        {
            return ResourceGUIM5.ContactoEliminado;
        }

        public string CargarBotonNuevoContacto( int typeComp, int idComp )
        {
            return this.button += ResourceGUIM5.VentanaAgregarContacto + typeComp.ToString()
                    + ResourceGUIM5.ParametroIdComp + idComp.ToString() + ResourceGUIM5.FinalAgregarContacto;
        }

        public void Alerta( string msj, int typeMsg )
        {
            if ( typeMsg == 1 )
                alertaClase = ResourceGUIM5.AlertSuccess;
            else
                alertaClase = ResourceGUIM5.AlertDanger;

            alertaRol = ResourceGUIM5.Alert;
            alerta = ResourceGUIM5.AlertShowSu1 + msj + ResourceGUIM5.AlertShowSu2;
        }
        /*
        public void LlenarTabla( ContactoM5 _theContact2, int typeComp, int idComp )
        {
            contact.Text += ResourceGUIM5.AbrirTR;
            contact.Text += ResourceGUIM5.AbrirTD + _theContact2.Apellido.ToString() + ResourceGUIM5.Coma
                + _theContact2.Nombre.ToString() + ResourceGUIM5.CerrarTD;
            contact.Text += ResourceGUIM5.AbrirTD + _theContact2.Departamento.ToString() + ResourceGUIM5.CerrarTD;
            contact.Text += ResourceGUIM5.AbrirTD + _theContact2.Cargo.ToString() + ResourceGUIM5.CerrarTD;
            contact.Text += ResourceGUIM5.AbrirTD + _theContact2.Telefono.ToString() + ResourceGUIM5.CerrarTD;
            contact.Text += ResourceGUIM5.AbrirTD + _theContact2.Correo.ToString() + ResourceGUIM5.CerrarTD;
            //Acciones de cada contacto
            contact.Text += ResourceGUIM5.AbrirTD2;
            contact.Text += ResourceGUIM5.ButtonModContact + typeComp + ResourceGUIM5.BotonVolver2 + idComp
                + ResourceGUIM5.BotonEliminar2 + _theContact2.Id + ResourceGUIM5.BotonCerrar
                + ResourceGUIM5.BotonEliminar + typeComp + ResourceGUIM5.BotonVolver2 + idComp
                + ResourceGUIM5.BotonEliminar2 + _theContact2.Id + ResourceGUIM5.BotonVolver4
                + ResourceGUIM5.StatusEliminado + ResourceGUIM5.BotonCerrar;
            contact.Text += ResourceGUIM5.CerrarTD;
            contact.Text += ResourceGUIM5.CerrarTR;
        }*/
        public string StatusModificado()
        {
            return ResourceGUIM5.StatusModificado;
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
