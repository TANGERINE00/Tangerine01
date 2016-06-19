using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M2;
using DominioTangerine;
using LogicaTangerine.M2;

namespace Tangerine_Presentador.M2
{
    public class PresentadorCambioRol
    {
        private IContratoCambiarRol _vista;

        /// <summary>
        /// Constructor que recibe la vista Cambio Rol
        /// </summary>
        /// <param name="vista"></param>
        public PresentadorCambioRol(IContratoCambiarRol vista)
        {
            _vista = vista;
        }

        /// <summary>
        /// Carga en la tabla todos los empleados
        /// </summary>
        public void iniciarVista()
        {
            List<Empleado> listaDeEmpleados = LogicaAgregarUsuario.ConsultarListaDeEmpleados();

            foreach (Empleado empleador in listaDeEmpleados)
            {
                Usuario user = LogicaModificarRol.ObtenerUsuario(empleador.emp_num_ficha);

                _vista.empleado += ResourceGUIM2.OpenTR;
                _vista.empleado += ResourceGUIM2.OpenTD + empleador.emp_p_nombre + ResourceGUIM2.CloseTD;
                _vista.empleado += ResourceGUIM2.OpenTD + empleador.emp_p_apellido + ResourceGUIM2.CloseTD;
                if (user.NombreUsuario != null)
                {
                    _vista.empleado += ResourceGUIM2.OpenTD + user.NombreUsuario + ResourceGUIM2.CloseTD;
                    _vista.empleado += ResourceGUIM2.OpenTD + user.Rol.Nombre + ResourceGUIM2.CloseTD;
                    _vista.empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.llamadoNuevaPagina + empleador.emp_num_ficha + ResourceGUIM2.RolEmpleado + user.Rol.Nombre
                                      + ResourceGUIM2.CloseBotonParametro + ResourceGUIM2.CloseTD;
                    _vista.empleado += ResourceGUIM2.CloseTR;
                }
                else
                {
                    _vista.empleado += ResourceGUIM2.OpenTD + " " + ResourceGUIM2.CloseTD;
                    _vista.empleado += ResourceGUIM2.OpenTD + " " + ResourceGUIM2.CloseTD;
                    _vista.empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.Botonblock + ResourceGUIM2.CloseBotonParametroDesactivado + ResourceGUIM2.CloseTD;
                    _vista.empleado += ResourceGUIM2.CloseTR;
                }
            }
        }
    }
}
