using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M4;

namespace Tangerine.GUI.M4
{
    public partial class ConsultarCompania : System.Web.UI.Page
    {
        LogicaM4 prueba = new LogicaM4();
       
        public string company
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

        /// <summary>
        /// Método de carga de página en el cual carga una tabla con los datos básicos de las compañías.
        /// </summary>
        /// <param name="typeHab, idComp">parametro que indica si la compañía está habilitada y su id</param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Compania laCompania;
                int idComp, typeHab;
                try
                {
                    typeHab = int.Parse(Request.QueryString["typeHab"]);
                    idComp = int.Parse(Request.QueryString["idComp"]);
                    laCompania = prueba.ConsultCompany(idComp);
                    if (typeHab == 1)
                    {
                        prueba.EnableCompany(laCompania);
                      
                    }
                    if (typeHab == 0)
                    {
                        prueba.DisableCompany(laCompania);
                    }
                }
                catch
                {
                }

                imprimirTabla();     
            }
        }

        /// <summary>
        /// Imprime la tabla de datos.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public void imprimirTabla()
        {
            List<Compania> listCompany = prueba.ConsultCompanies();
            try
            {
                foreach (Compania theCompany in listCompany)
                {
                    company += ResourceGUIM4.OpenTR;
                    company += ResourceGUIM4.OpenTD + theCompany.NombreCompania.ToString() + ResourceGUIM4.CloseTD;
                    //company += ResourceGUIM4.OpenTD + theCompany.AcronimoCompania.ToString() + ResourceGUIM4.CloseTD;
                    company += ResourceGUIM4.OpenTD + theCompany.RifCompania + ResourceGUIM4.CloseTD;
                    company += ResourceGUIM4.OpenTD + theCompany.TelefonoCompania + ResourceGUIM4.CloseTD;
                    //company += ResourceGUIM4.OpenTD + theCompany.FechaRegistroCompania.ToString() + ResourceGUIM4.CloseTD;

                    if (theCompany.StatusCompania.Equals(1))
                    {
                        company += ResourceGUIM4.OpenTD + ResourceGUIM4.habilitado + theCompany.IdCompania +
                            ResourceGUIM4.CloseSpanHab + ResourceGUIM4.CloseTD;
                    }
                    else if (theCompany.StatusCompania.Equals(0))
                    {
                        company += ResourceGUIM4.OpenTD + ResourceGUIM4.inhabilitado + theCompany.IdCompania +
                            ResourceGUIM4.CloseSpanInhab + ResourceGUIM4.CloseTD;
                    }

                    //Acciones de cada compania  
                    imprimirBotonesAccion(theCompany);
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Imprime botones de accion en la última columna de la tabla.
        /// </summary>
        /// <param name="theCompany">Objeto de tipo compañía</param>
        /// <returns></returns>
        public void imprimirBotonesAccion(Compania theCompany)
        {
            if (HttpContext.Current.Session["Rol"].Equals("Administrador") ||
                        HttpContext.Current.Session["Rol"].Equals("Gerente"))
            {
                company += ResourceGUIM4.OpenTD + ResourceGUIM4.OpenDivRow +
                ResourceGUIM4.OpenBotonInfo + theCompany.IdCompania + /*Boton Info */
                ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.OpenBotonEdit + theCompany.IdCompania + /*Boton Edit */
                ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.OpenBotonHab + theCompany.IdCompania + /*Boton Habilitar */
                ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.OpenBotonInhab + theCompany.IdCompania + /*Boton Inhabilitar*/
                ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.BotonInvol + theCompany.IdCompania + /*Boton Contacto*/
                ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.CloseDiv +
                ResourceGUIM4.CloseTD;

                company += ResourceGUIM4.CloseTR;
            }
            else if (HttpContext.Current.Session["Rol"].Equals("Programador") ||
                     HttpContext.Current.Session["Rol"].Equals("Director"))
            {
                company += ResourceGUIM4.OpenTD + ResourceGUIM4.OpenDivRow +
                ResourceGUIM4.OpenBotonInfo + theCompany.IdCompania + /*Boton Info */
                ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.BotonInvol + theCompany.IdCompania + /*Boton Contacto*/
                ResourceGUIM4.CloseBotonParametro + ResourceGUIM4.CloseDiv +
                ResourceGUIM4.CloseTD;

                company += ResourceGUIM4.CloseTR;
            }
        }
    }
}