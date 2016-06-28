using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Windows;
using DominioTangerine;
using LogicaTangerine;
using Tangerine_Contratos.M4;
using System.Web.Security.AntiXss;

namespace Tangerine.GUI.M4
{
    public partial class ConsultarCompania : System.Web.UI.Page, IContratoConsultarCompania
    {
        #region CargarPresentador
        Tangerine_Presentador.M4.PresentadorConsultarCompania Presentador;
        string error;

        public ConsultarCompania()
        {
            this.Presentador = new Tangerine_Presentador.M4.PresentadorConsultarCompania(this);
        }
        #endregion

        #region Contrato
        public Literal Tabla
        {
            get 
            {
                return tabla;            
            }
            
            set 
            {
                tabla = value;
            }
        }
        public string msjError
        {
            get
            {
                return error;
            }
            set
            {
                error = value;
            }
        }
        #endregion

        /// <summary>
        /// Método de carga de página en el cual carga una tabla con los datos básicos de las compañías.
        /// </summary>
        /// <param name="typeHab, idComp">parametro que indica si la compañía está habilitada y su id</param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
            {
                try
                {
                    if (Presentador.BotonHabilitarInhabilitar(int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString["typeHab"], false)), int.Parse(AntiXssEncoder.HtmlEncode(Request.QueryString["idComp"], false))))
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('" + msjError + "')", true);
                }
                catch (Exception ex)
                {
                    if(!ex.Message.Equals("Value cannot be null.\r\nParameter name: String"))
                        Response.Redirect("../M1/PaginaError.aspx", false);
                }
                try
                {
                    if(Presentador.ImprimirCompania(HttpContext.Current.Session["Rol"].ToString()))
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('" + msjError + "')", true); 
                }
               catch
               {
               }
            
            }
        }
    }
}