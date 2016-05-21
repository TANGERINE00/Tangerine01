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

namespace Tangerine.GUI.M5
{
    public partial class ConsultarContactos : System.Web.UI.Page
    {
        #region Atributos
        public ClientePotencial cliPotencial;
        public Compania compania;

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

        public string nombreEmpresa
        {
            get
            {
                return this.empresa.Text;
            }
            set
            {
                this.empresa.Text = value;
            }
        }
        #endregion

        /// <summary>
        /// Metodo de carga de los elementos de la ventana.
        /// </summary>
        /// Puede recibir 3 parametros, idCont no es obligatorio.
        /// <param name="typeComp">Entero, representa el tipo de empresa (compañia o lead)</param>
        /// <param name="idComp">Entero, representa el id de la empresa</param>
        /// <param name="idCont">Entero, representa el id del contacto (Para ser eliminado)</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaM3 logicM3 = new LogicaM3();
            LogicaM4 logicM4 = new LogicaM4();
            LogicaM5 logicM5 = new LogicaM5();
            Contacto _contact = new Contacto();
            int typeComp = int.Parse(Request.QueryString[ResourceGUIM5.typeComp]);
            int idComp = int.Parse(Request.QueryString[ResourceGUIM5.idComp]);

            if (typeComp == 1)
            {
                compania = logicM4.SearchCompany(idComp);
                botonVolver = ResourceGUIM5.VolverCompania;
                nombreEmpresa = ResourceGUIM5.Compania + compania.NombreCompania  ;
            }
            else
            {
                cliPotencial = logicM3.BuscarClientePotencial(idComp);
                botonVolver = ResourceGUIM5.VolverCliPotencial;
                nombreEmpresa = ResourceGUIM5.Lead + cliPotencial.NombreClientePotencial ;
            }

            try
            {
                //En este try atrapo el valor del id del Contacto si existe
                //para luego ser eliminado de los contactos de la empresa
                int idCont = int.Parse(Request.QueryString[ResourceGUIM5.idCont]);
                _contact.IdContacto = idCont;
                if (idCont > 0)
                {
                    logicM5.DeleteContact(_contact);
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
                List<Contacto> listContact = logicM5.GetContacts(typeComp, idComp);

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
                        contact += ResourceGUIM5.AbrirTD2;
                        contact += ResourceGUIM5.ButtonModContact + typeComp + ResourceGUIM5.BotonVolver2 + idComp
                            + ResourceGUIM5.BotonEliminar2 + theContact.IdContacto + ResourceGUIM5.BotonCerrar 
                            + ResourceGUIM5.BotonEliminar + typeComp + ResourceGUIM5.BotonVolver2 + idComp 
                            + ResourceGUIM5.BotonEliminar2 + theContact.IdContacto + ResourceGUIM5.BotonCerrar ;
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
    }
}