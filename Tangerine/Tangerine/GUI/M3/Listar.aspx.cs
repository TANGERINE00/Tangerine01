using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using DatosTangerine;
using Tangerine_Contratos.M3;
using Tangerine_Presentador.M3;


namespace Tangerine.GUI.M3
{
    public partial class Listar : System.Web.UI.Page, IContratoListarClientePotencial
    {
        PresentadorListarClientePotencial presentador;

        /// <summary>
        /// Constructor de la vista
        /// </summary>
        /// <returns></returns>
        public Listar()
        {
            this.presentador = new PresentadorListarClientePotencial(this);
        }

        #region Contrato
        public Literal ClientePotencial
        {
            get
            {
                return Lista;
            }

            set
            {
                Lista = value;
            }
        }
        #endregion

        /// <summary>
        /// Método que llama al presentador para mostrar los clientes potenciales
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                presentador.Llenar();
            }

        }
    }
}
  
 
