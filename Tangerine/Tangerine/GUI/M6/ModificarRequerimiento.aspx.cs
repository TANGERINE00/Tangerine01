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
    public partial class ModificarRequerimiento : System.Web.UI.Page, IContratoModificarRequerimiento
    {
        
         PresentadorModificarRequerimiento presenter;

        public ModificarRequerimiento()
        {
            this.presenter = new PresentadorModificarRequerimiento(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    presenter.llenarVista();
                }
            }
            catch
            {
                Response.Redirect("../M6/ConsultarPropuesta.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }
        protected void btnmodificar_Click(object sender, EventArgs e)
        {
            try
            {
                presenter.ModificarRequerimiento();
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
                Response.Redirect("../M6/ModificarPropuesta.aspx?id=" + Request.QueryString.Get("idPro") + "&idReq=0", false);
                Context.ApplicationInstance.CompleteRequest();
            }
        }


       public string IdRequerimiento
        {
            get
            {
                try
                {
                    return Request.QueryString.Get("idReq");
                }
                catch (Exception e)
                {
                    Response.Redirect("../M6/ConsultarPropuesta.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return null;
                }
            }
            set { requerimiento_id.Value = value; }

        }

       public string IdPropuesta
       {
           get
           {
               try
               {
                   return Request.QueryString.Get("idPro");
               }
               catch (Exception e)
               {
                   Response.Redirect("../M6/ConsultarPropuesta.aspx", false);
                   Context.ApplicationInstance.CompleteRequest();
                   return null;
               }
           }
       }
       public string Concepto
        {
            get { return concepto.Value; }
            set { concepto.Value = value; }
        }
       
    }
}