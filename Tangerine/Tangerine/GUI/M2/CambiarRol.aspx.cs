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
            if ( !IsPostBack )
            {
                List<Empleado> listaDeEmpleados = LogicaAgregarUsuario.ConsultarListaDeEmpleados();

                foreach ( Empleado  empleador in listaDeEmpleados )
                {
                    Usuario user = LogicaModificarRol.ObtenerUsuario( empleador );
                  
                    empleado += ResourceGUIM2.OpenTR;
                    empleado += ResourceGUIM2.OpenTD + empleador.emp_p_nombre + ResourceGUIM2.CloseTD;
                    empleado += ResourceGUIM2.OpenTD + empleador.emp_p_apellido + ResourceGUIM2.CloseTD;
                    if ( user.NombreUsuario != null )
                    {  
                        empleado += ResourceGUIM2.OpenTD + user.NombreUsuario + ResourceGUIM2.CloseTD;
                        empleado += ResourceGUIM2.OpenTD + user.Rol.Nombre + ResourceGUIM2.CloseTD;
                        empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.llamadoCompleto + ResourceGUIM2.CloseTD;
                        empleado += ResourceGUIM2.CloseTR;
                    }
                    else 
                    {
                        empleado += ResourceGUIM2.OpenTD + " " + ResourceGUIM2.CloseTD;
                        empleado += ResourceGUIM2.OpenTD + " " + ResourceGUIM2.CloseTD;
                        empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.Botonblock + ResourceGUIM2.CloseTD;
                        empleado += ResourceGUIM2.CloseTR;
                    }
                }
            } 
        }

        protected void botonCambiar_Click( object sender, EventArgs e )
        {
            string nombreUsuario = usuarioCambiar.Value;
            string rol = rolCambiar.Value; 

            LogicaModificarRol.ModificarRol( nombreUsuario, rol );

            Response.Redirect( "../M2/CambiarRol.aspx" );
        }
    }
}