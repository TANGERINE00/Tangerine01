using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M5;

namespace Tangerine.GUI.M5
{
    public partial class Modificar : System.Web.UI.Page
    {
        string _nombre = String.Empty;
        string _apellido = String.Empty;
        string _departamento = String.Empty;
        string _cargo = String.Empty;
        string _telefono = String.Empty;
        string _correo = String.Empty;
        Contacto theContact = new Contacto();
        public string botonVolver
        {
            get
            {
                return this.volver.Text;
            }
            set
            {
                this.volver.Text = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            int typeComp = int.Parse(Request.QueryString["typeComp"]);
            int idComp = int.Parse(Request.QueryString["idComp"]);
            int idCont = int.Parse(Request.QueryString["idCont"]);

            botonVolver = ResourceGUIM5.VolverConsultarCon + typeComp + ResourceGUIM5.BotonVolver2 + idComp 
                + ResourceGUIM5.BotonCerrar2;

            theContact.IdContacto = idCont;
            if (!IsPostBack)
            {
                LogicaM5 contactLogic = new LogicaM5();
                theContact = contactLogic.SearchContact(theContact);

                this.nombre.Value = theContact.Nombre;
                this.apellido.Value = theContact.Apellido;
                this.departamento.Value = theContact.Departamento;
                this.cargo.Value = theContact.Cargo;
                this.telefono.Value = theContact.Telefono;
                this.correo.Value = theContact.Correo;
            }
        }
    }
}