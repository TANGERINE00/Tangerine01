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
        public LogicaM3 _logicM3 = new LogicaM3();
        public LogicaM4 _logicM4 = new LogicaM4();
        public LogicaM5 _logicM5 = new LogicaM5();
        public Contacto _theContact = new Contacto();
        public List<Contacto> _listContact;

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
        /// <param name="idCont">Entero, representa el id del contacto (Para ser eliminado, no es obligatorio)</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int typeComp = int.Parse(Request.QueryString[ResourceGUIM5.typeComp]);
            int idComp = int.Parse(Request.QueryString[ResourceGUIM5.idComp]);

            CargarBotonVolver(typeComp, idComp);
            
            //En esta seccion se maneja el eliminar contacto con el idCont
            try
            {
                //En este try atrapo el valor del id del Contacto (si existe)
                //para luego ser eliminado de los contactos de la empresa
                int idCont = int.Parse(Request.QueryString[ResourceGUIM5.idCont]);
                _theContact.IdContacto = idCont;

                _logicM5.DeleteContact(_theContact);
            }
            catch (Exception ex)
            {
                //No se hace nada,  ya que el idCont no es un parametro obligatorio
            }

            //En esta seccion se manejan los mensajes que se reciben por acciones del usuario
            try
            {
                int status = int.Parse(Request.QueryString[ResourceGUIM5.Status]);

                switch (status)
                {
                    case 1:
                        Alerta(ResourceGUIM5.ContactoAgregado,int.Parse(ResourceGUIM5.StatusAgregado));
                        break;
                    case 2:
                        Alerta(ResourceGUIM5.ContactoModificado, int.Parse(ResourceGUIM5.StatusAgregado));
                        break;
                    case 3:
                        Alerta(ResourceGUIM5.ContactoEliminado, int.Parse(ResourceGUIM5.StatusAgregado));
                        break;
                }
            }
            catch (Exception ex)
            {
                //No se hace nada,  ya que el status no es un parametro obligatorio
            } 

            try
            {
                _listContact = _logicM5.GetContacts(typeComp, idComp);
                foreach (Contacto _theContact2 in _listContact)
                {
                    LlenarTabla(_theContact2, typeComp, idComp);
                }
                button += ResourceGUIM5.VentanaAgregarContacto + typeComp.ToString()
                    + ResourceGUIM5.ParametroIdComp + idComp.ToString() + ResourceGUIM5.FinalAgregarContacto;
            }
            catch (Exception ex)
            {
                Alerta(ex.Message,int.Parse(ResourceGUIM5.StatusModificado));
            }
        }

        /// <summary>
        /// Funcion para manipular los memsajes que van a interfaz (Errores del programa o Acciones del usuario).
        /// </summary>
        /// <param name="msj">string que contiene el mensaje a mostrar</param>
        /// <param name="typeMsg">Tipo de mensaje (1 para acciones del usuario, 2 para errores del programa</param>
        public void Alerta(string msj, int typeMsg)
        {
            if (typeMsg == 1)
                alertaClase = ResourceGUIM5.AlertSuccess;
            else
                alertaClase = ResourceGUIM5.AlertDanger;

            alertaRol = ResourceGUIM5.Alert;
            alerta = ResourceGUIM5.AlertShowSu1 + msj + ResourceGUIM5.AlertShowSu2;
        }

        /// <summary>
        /// Funcion para cargar el boton de regreso a Compania o Cliente Potencial.
        /// </summary>
        /// <param name="typeComp">Entero, representa el tipo de empresa (1 compañia o 2 lead)</param>
        /// <param name="idComp">Entero, representa el id de la empresa</param>
        public void CargarBotonVolver(int typeComp, int idComp)
        {
            if (typeComp == 1)
            {
                compania = _logicM4.SearchCompany(idComp);
                botonVolver = ResourceGUIM5.VolverCompania;
                nombreEmpresa = ResourceGUIM5.Compania + compania.NombreCompania;
            }
            else
            {
                cliPotencial = _logicM3.BuscarClientePotencial(idComp);
                botonVolver = ResourceGUIM5.VolverCliPotencial;
                nombreEmpresa = ResourceGUIM5.Lead + cliPotencial.NombreClientePotencial;
            }
        }

        /// <summary>
        /// Funcion para llenar una fila de la tabla a mostrar en interfaz con los contactos.
        /// </summary>
        /// <param name="_theContact2">Contacto, para crear su fila</param>
        /// <param name="typeComp">Entero, representa el tipo de empresa</param>
        /// <param name="idComp">Entero, representa el id de la empresa</param>
        public void LlenarTabla(Contacto _theContact2, int typeComp, int idComp)
        {
            contact += ResourceGUIM5.AbrirTR;
            contact += ResourceGUIM5.AbrirTD + _theContact2.Apellido.ToString() + ResourceGUIM5.Coma
                + _theContact2.Nombre.ToString() + ResourceGUIM5.CerrarTD;
            contact += ResourceGUIM5.AbrirTD + _theContact2.Departamento.ToString() + ResourceGUIM5.CerrarTD;
            contact += ResourceGUIM5.AbrirTD + _theContact2.Cargo.ToString() + ResourceGUIM5.CerrarTD;
            contact += ResourceGUIM5.AbrirTD + _theContact2.Telefono.ToString() + ResourceGUIM5.CerrarTD;
            contact += ResourceGUIM5.AbrirTD + _theContact2.Correo.ToString() + ResourceGUIM5.CerrarTD;
            //Acciones de cada contacto
            contact += ResourceGUIM5.AbrirTD2;
            contact += ResourceGUIM5.ButtonModContact + typeComp + ResourceGUIM5.BotonVolver2 + idComp
                + ResourceGUIM5.BotonEliminar2 + _theContact2.IdContacto + ResourceGUIM5.BotonCerrar
                + ResourceGUIM5.BotonEliminar + typeComp + ResourceGUIM5.BotonVolver2 + idComp
                + ResourceGUIM5.BotonEliminar2 + _theContact2.IdContacto + ResourceGUIM5.BotonVolver4
                + ResourceGUIM5.StatusEliminado + ResourceGUIM5.BotonCerrar;
            contact += ResourceGUIM5.CerrarTD;
            contact += ResourceGUIM5.CerrarTR;
        }
    }
}