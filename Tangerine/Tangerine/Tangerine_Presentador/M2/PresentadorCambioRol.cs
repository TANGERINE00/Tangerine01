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
            LogicaTangerine.Comando<List<Entidad>> theComando = LogicaTangerine.Fabrica.FabricaComandos.ConsultarEmpleados();
            LogicaTangerine.Comandos.M10.ComandoConsultarEmpleado comando = (LogicaTangerine.Comandos.M10.ComandoConsultarEmpleado)theComando;
            List<Entidad> listaDeEmpleados = comando.Ejecutar();

            foreach (Entidad theEmpleador in listaDeEmpleados)
            {
                DominioTangerine.Entidades.M10.EmpleadoM10 empleador = (DominioTangerine.Entidades.M10.EmpleadoM10)theEmpleador;
                LogicaTangerine.Comando<DominioTangerine.Entidad> theComandoObtener = LogicaTangerine.Fabrica.FabricaComandos.obtenerUsuario(empleador.emp_id);
                LogicaTangerine.Comandos.M2.ComandoObtenerUsuario comandoObtener = (LogicaTangerine.Comandos.M2.ComandoObtenerUsuario)theComandoObtener;
                DominioTangerine.Entidad theUser = comandoObtener.Ejecutar();
                DominioTangerine.Entidades.M2.UsuarioM2 user = (DominioTangerine.Entidades.M2.UsuarioM2)theUser;

                _vista.empleado += ResourceGUIM2.OpenTR;
                _vista.empleado += ResourceGUIM2.OpenTD + empleador.emp_p_nombre + ResourceGUIM2.CloseTD;
                _vista.empleado += ResourceGUIM2.OpenTD + empleador.emp_p_apellido + ResourceGUIM2.CloseTD;
                if (user.nombreUsuario != null)
                {
                    _vista.empleado += ResourceGUIM2.OpenTD + user.nombreUsuario + ResourceGUIM2.CloseTD;
                    _vista.empleado += ResourceGUIM2.OpenTD + user.rol.nombre + ResourceGUIM2.CloseTD;
                    _vista.empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.llamadoNuevaPagina + empleador.emp_id
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
