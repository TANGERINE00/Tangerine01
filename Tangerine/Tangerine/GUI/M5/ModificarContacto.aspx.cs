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
        public int typeComp;
        public int idComp;

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
            typeComp = int.Parse(Request.QueryString[ResourceGUIM5.typeComp]);
            idComp = int.Parse(Request.QueryString[ResourceGUIM5.idComp]);
            int idCont = int.Parse(Request.QueryString[ResourceGUIM5.idCont]);

            botonVolver = ResourceGUIM5.BotonVolver + typeComp + ResourceGUIM5.BotonVolver2 + idComp
                + ResourceGUIM5.BotonVolver3;

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

        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            Contacto contact = new Contacto();
            contact.IdContacto = int.Parse(Request.QueryString[ResourceGUIM5.idCont]);
            contact.Nombre = nombre.Value; 
            contact.Apellido = apellido.Value;
            contact.Departamento = departamento.Value;
            contact.Cargo = cargo.Value;
            contact.Telefono = telefono.Value;
            contact.Correo = correo.Value;            
            
            LogicaM5 contactLogic = new LogicaM5();
            contactLogic.ChangeContact(contact);

            Server.Transfer(ResourceGUIM5.hrefConsultarContacto + typeComp + ResourceGUIM5.BotonVolver2 + idComp);
        }
    }
}