using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M4;
using Tangerine_Contratos.M4;

namespace Tangerine.GUI.M4
{
    public partial class ConsultarCompania : System.Web.UI.Page, IContratoConsultarCompania
    {
        #region CargarPresentador
        Tangerine_Presentador.M4.PresentadorConsultarCompania Presentador;

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
                Presentador.ImprimirCompania();
                /*Compania laCompania;
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

                imprimirTabla();   */  
            }
        }
    }
}