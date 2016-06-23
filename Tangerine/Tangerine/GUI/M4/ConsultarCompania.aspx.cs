using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using Tangerine_Contratos.M4;

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
                    if(Presentador.BotonHabilitarInhabilitar(int.Parse(Request.QueryString["typeHab"]), int.Parse(Request.QueryString["idComp"])))
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('"+ msjError +"')", true); 
                }
                catch 
                { 
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