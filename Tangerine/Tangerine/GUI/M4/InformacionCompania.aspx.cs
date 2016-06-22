using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using Tangerine_Contratos.M4;
using Tangerine_Presentador.M4;

namespace Tangerine.GUI.M4
{
    public partial class HabilitarCompania : System.Web.UI.Page, IContratoInformacionCompania
    {
        #region CargarPresentador
        PresentadorInformacionCompania _presentador;
        string error;

        public HabilitarCompania()
        {
            this._presentador = new PresentadorInformacionCompania(this);
        }

        #endregion

        #region Contrato
        public Label NombreCompania 
        {
            get
            {
                return Nombre;
            }
            set
            {
                Nombre = value;
            }
        }   
        public Label Estatus
        {
            get
            {
                return habilitado;
            }
            set
            {
                habilitado = value;
            }
        }   
        public Label Acronimo      
        {
            get
            {
                return acronimo;
            }
            set
            {
                acronimo = value;
            }
        }   
        public Label PlazoDePagos      
        {
            get
            {
                return plazo;
            }
            set
            {
                plazo = value;
            }
        }
        public Label RIF      
        {
            get
            {
                return Rif;
            }
            set
            {
                Rif = value;
            }
        }
        public Label Presupuesto      
        {
            get
            {
                return presupuesto;
            }
            set
            {
                presupuesto = value;
            }
        }
        public Label Direccion      
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }
        public Label Correo
        {
            get 
            {
                return correo;
            }
            set 
            {
                correo = value;
            }
        }
        public Label Telefono      
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
            }
        }
        public Label Fecha      
        {
            get
            {
                return fecha;
            }
            set
            {
                fecha = value;
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

        #region Load
        /// <summary>
        /// Método de carga de página en el cual carga los datos de la compañía.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = int.Parse(Request.QueryString["idComp"]);
            if (!IsPostBack)
                if(!_presentador.CargarInformacionCompania(i))
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('" + msjError + "')", true); 
                
        }
        #endregion
    }
}