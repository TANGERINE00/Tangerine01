using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tangerine_Contratos.M6;
using Tangerine_Presentador.M6;

namespace Tangerine.GUI.M6
{
    public partial class AgregarRequerimientos : System.Web.UI.Page, IContratoAgregarRequerimientos
    {
        PresentadorAgregarRequerimientos presenter;

        public AgregarRequerimientos()
        {
            this.presenter = new PresentadorAgregarRequerimientos(this);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                  //
                }
            }
            catch
            {
                Response.Redirect("../M6/ConsultarPropuesta.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        
        protected void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                presenter.AgregarRequerimientos();
                Response.Redirect("../M6/ConsultarPropuesta.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD)
            {
                Response.Redirect("../M6/ConsultarPropuesta.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception)
            {
                Response.Redirect("../M6/ModificarPropuesta.aspx?id=" + Request.QueryString.Get("id") + "&idReq=0", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }

        #region Contrato
        public string IdPropuesta
        {
            get
            {   
                try 
                {
                    return Request.QueryString.Get("id");
                }
                catch (Exception e)
                {
                    Response.Redirect("../M6/ConsultarPropuesta.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return null;
                }
            }
        }

        public string ArrPrecondicion
        {
            get { return arrPrecondicion.Value; }

        }
        #endregion

    }
}