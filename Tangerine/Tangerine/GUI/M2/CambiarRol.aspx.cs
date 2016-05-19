using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M2;
using DominioTangerine;

namespace Tangerine.GUI.M2
{
    public partial class CambiarRol : System.Web.UI.Page
    {
        public string empleado
        {
            get
            {
               return this.tablaempleados.Text;
            }

            set
            {
                this.tablaempleados.Text = value;
            }
        }


        protected void Page_Load( object sender, EventArgs e )
        {

            if (!IsPostBack)
            {
                string nombre = "geastone";
                empleado += ResourceGUIM2.OpenTR;
                empleado += ResourceGUIM2.OpenTD + "Gerardo" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "Astone" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + nombre + ResourceGUIM2.CloseTD;
               // empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonModif +nombre +ResourceGUIM2.CloseBotonModify;
                empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.llamadoCompleto + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.CloseTR;

                empleado += ResourceGUIM2.OpenTR;
                empleado += ResourceGUIM2.OpenTD + "luis" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "rodriguez" + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.OpenTD + "lurodr" + ResourceGUIM2.CloseTD;
                // empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonModif +nombre +ResourceGUIM2.CloseBotonModify;
                empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.llamadoCompleto + ResourceGUIM2.CloseTD;
                empleado += ResourceGUIM2.CloseTR;

            }

        }
        
        protected void botonCambiar_Click( object sender, EventArgs e )
        {
            /*string usuarioNombre = usuarioCambiar.Value;
            Rol rol = new Rol( rolCambiar.Value );

            Usuario usuario = new Usuario(usuarioNombre, rol);

            LogicaModificarRol.ModificarRol( usuario );*/
        }


    }
}