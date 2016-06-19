using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M2;
using DominioTangerine;
using Tangerine_Contratos.M2;

namespace Tangerine.GUI.M2
{
    public partial class CambiarRol : System.Web.UI.Page, IContratoCambiarRol
    {
        #region Contrato
            /// <summary>
            /// tabla consulta
            /// </summary>
            public string empleado
            {
                get
                { return this.tablaempleados.Text; }

                set
                { this.tablaempleados.Text = value; }
            }
        #endregion

        /// <summary>
        /// Método que se ejecuta al cargar la página, se carga la tabla de empleados con sus respectivos usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load( object sender, EventArgs e )
        {
            if ( !IsPostBack )
            {
                List<Empleado> listaDeEmpleados = LogicaAgregarUsuario.ConsultarListaDeEmpleados();

                foreach ( Empleado  empleador in listaDeEmpleados )
                {
                    Usuario user = LogicaModificarRol.ObtenerUsuario( empleador.emp_num_ficha );
                    
                    empleado += ResourceGUIM2.OpenTR;
                    empleado += ResourceGUIM2.OpenTD + empleador.emp_p_nombre + ResourceGUIM2.CloseTD;
                    empleado += ResourceGUIM2.OpenTD + empleador.emp_p_apellido + ResourceGUIM2.CloseTD;
                    if ( user.NombreUsuario != null )
                    {  
                        empleado += ResourceGUIM2.OpenTD + user.NombreUsuario + ResourceGUIM2.CloseTD;
                        empleado += ResourceGUIM2.OpenTD + user.Rol.Nombre + ResourceGUIM2.CloseTD;
                        empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.llamadoNuevaPagina + empleador.emp_num_ficha + ResourceGUIM2.CloseBotonParametro + ResourceGUIM2.CloseTD;
                        empleado += ResourceGUIM2.CloseTR;
                    }
                    else 
                    {
                        empleado += ResourceGUIM2.OpenTD + " " + ResourceGUIM2.CloseTD;
                        empleado += ResourceGUIM2.OpenTD + " " + ResourceGUIM2.CloseTD;
                        empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.Botonblock + ResourceGUIM2.CloseBotonParametroDesactivado + ResourceGUIM2.CloseTD;
                        empleado += ResourceGUIM2.CloseTR;
                    }
                }
            } 
        }
    }
}