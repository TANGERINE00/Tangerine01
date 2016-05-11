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
    public partial class ConsultarContactos : System.Web.UI.Page
    {
        int typeComp;
        int idComp;
        public string contact
        {
            get
            {
                return this.tabla.Text;
            }
            set
            {
                this.tabla.Text = value;
            }
        }

        public string button
        {
            get
            {
                return this.nuevocontacto.Text;
            }
            set
            {
                this.nuevocontacto.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int typeComp = 2;
            int idComp = 3;
            LogicaM5 prueba = new LogicaM5();
            //Aqui debe recibir typeComp y idComp de MOD3 y MOD4
            //int typeComp = int.Parse(Request.QueryString["typeComp"]);
            //int idComp = int.Parse(Request.QueryString["idComp"]);
            try
            {
                int idCont = int.Parse(Request.QueryString["idCont"]);
                if (idCont != null)
                {
                    prueba.DeleteContact(idCont);
                }
            }
            catch
            {
 
            } 

            if (!IsPostBack)
            {
                //Aqui ejecuto el filltable de la clase creada en logica para probar la conexion a la bd
                //los parametros son tipo de empresa 1 (Compania), id de la empresa 1.
                //prueba.fillTable(1,1);
                List<Contacto> listContact = prueba.GetContacts(typeComp, idComp);

                try
                {
                    foreach (Contacto theContact in listContact)
                    {
                        contact += ResourceGUIM5.AbrirTR;
                        contact += ResourceGUIM5.AbrirTD + theContact.Apellido.ToString() + ResourceGUIM5.Coma 
                            + theContact.Nombre.ToString() + ResourceGUIM5.CerrarTD;
                        contact += ResourceGUIM5.AbrirTD + theContact.Departamento.ToString() + ResourceGUIM5.CerrarTD;
                        contact += ResourceGUIM5.AbrirTD + theContact.Cargo.ToString() + ResourceGUIM5.CerrarTD;
                        contact += ResourceGUIM5.AbrirTD + theContact.Telefono.ToString() + ResourceGUIM5.CerrarTD;
                        contact += ResourceGUIM5.AbrirTD + theContact.Correo.ToString() + ResourceGUIM5.CerrarTD;
                        //Acciones de cada contacto
                        contact += ResourceGUIM5.AbrirTD;
                        contact += ResourceGUIM5.ButtonModContact + theContact.IdContacto + ResourceGUIM5.BotonCerrar 
                            + ResourceGUIM5.BotonEliminar + theContact.IdContacto + ResourceGUIM5.BotonCerrar ;
                        contact += ResourceGUIM5.CerrarTD;
                        contact += ResourceGUIM5.CerrarTR;
                    }
                    button += ResourceGUIM5.VentanaAgregarContacto + typeComp.ToString()
                            + ResourceGUIM5.ParametroIdComp + idComp.ToString() + ResourceGUIM5.FinalAgregarContacto;
                }
                catch (Exception ex)
                {

                }
            }
            
        }
        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            //Los dos ultimos valores deben de venir de la ventana de consultar contactos (tipo empresa y id empresa)



        }
    }
}