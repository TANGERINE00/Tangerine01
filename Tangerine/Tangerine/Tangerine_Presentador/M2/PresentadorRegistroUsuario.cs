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
    public class PresentadorRegistroUsuario
    {
        private IContratoRegistroUsuario _vista;

        public PresentadorRegistroUsuario(IContratoRegistroUsuario vista)
        {
            _vista = vista;
        }

        public void inicioVista()
        {
            List<Empleado> listaDeEmpleados = LogicaAgregarUsuario.ConsultarListaDeEmpleados();

            foreach (Empleado empleado in listaDeEmpleados)
            {
                _vista.tablaEmpleado += ResourceGUIM2.OpenTR;
                _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_num_ficha.ToString() + ResourceGUIM2.CloseTD;
                _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_p_nombre + ResourceGUIM2.CloseTD;
                _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_p_apellido + ResourceGUIM2.CloseTD;
                _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_cedula + ResourceGUIM2.CloseTD;
                _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Job.Nombre + ResourceGUIM2.CloseTD;

                if (!LogicaAgregarUsuario.VerificarUsuarioDeEmpleado(empleado.Emp_num_ficha))
                {
                    _vista.tablaEmpleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonRegNuevaVentana + empleado.emp_num_ficha + ResourceGUIM2.NombreEmpleado
                                            + empleado.emp_p_nombre + ResourceGUIM2.ApellidoEmpleado + empleado.emp_p_apellido
                                            + ResourceGUIM2.CloseBotonParametro + ResourceGUIM2.CloseTD;
                }
                else
                {
                    _vista.tablaEmpleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonRegBlock + ResourceGUIM2.CloseBotonParametroDesactivado + ResourceGUIM2.CloseTD;
                }

                _vista.tablaEmpleado += ResourceGUIM2.CloseTR;
            }
        }
    }
}
