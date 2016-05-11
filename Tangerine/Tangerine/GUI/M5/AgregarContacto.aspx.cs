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
    public partial class AgregarContacto : System.Web.UI.Page
    {
        string _nombre = String.Empty;
        string _apellido = String.Empty;
        string _departamento = String.Empty;
        string _cargo = String.Empty;
        string _telefono = String.Empty;
        string _correo = String.Empty;
        int typeComp;
        int idComp;
        protected void Page_Load(object sender, EventArgs e)
        {
            typeComp = int.Parse(Request.QueryString["typeComp"]);
            idComp = int.Parse(Request.QueryString["idComp"]);

            if (!IsPostBack)
            {
                
            }
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            _nombre = nombre.Value;
            _apellido = apellido.Value;
            _departamento = departamento.Value;
            _cargo = cargo.Value;
            _telefono = telefono.Value;
            _correo = correo.Value;

            //Los dos ultimos valores deben de venir de la ventana de consultar contactos (tipo empresa y id empresa)
            Contacto contact = new Contacto(_nombre, _apellido, _departamento,
                _cargo, _telefono, _correo, typeComp, idComp);
            LogicaM5 contactLogic = new LogicaM5();
            contactLogic.AddNewContact(contact);
            
        }
    }
}