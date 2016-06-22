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
            _vista.empleado = null;
            LogicaTangerine.Comando<List<Entidad>> theComando = LogicaTangerine.Fabrica.FabricaComandos.ConsultarEmpleados();           
            List<Entidad> listaDeEmpleados = theComando.Ejecutar();

            foreach (Entidad theEmpleador in listaDeEmpleados)
            {
                DominioTangerine.Entidades.M10.EmpleadoM10 empleador = (DominioTangerine.Entidades.M10.EmpleadoM10)theEmpleador;
                LogicaTangerine.Comando<DominioTangerine.Entidad> theComandoObtener = LogicaTangerine.Fabrica.FabricaComandos.obtenerUsuario(empleador.emp_id);               
                DominioTangerine.Entidad theUser = theComandoObtener.Ejecutar();
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

        /// <summary>
        /// Método para actualizar la vista a traves del boton buscar
        /// </summary>
        public void actualizarVista()
        {
            if (_vista.nombreUsuario.Equals(""))
            {
                iniciarVista();
            }
            else
            {
                _vista.empleado = null;
                LogicaTangerine.Comando<Entidad> theComando
                    = LogicaTangerine.Fabrica.FabricaComandos.obtenerEmpleado( _vista.nombreUsuario );
                Entidad theEmpleador = theComando.Ejecutar();

                DominioTangerine.Entidades.M10.EmpleadoM10 empleador = (DominioTangerine.Entidades.M10.EmpleadoM10)theEmpleador;
                LogicaTangerine.Comando<DominioTangerine.Entidad> theComandoObtener = LogicaTangerine.Fabrica.FabricaComandos.obtenerUsuario(empleador.emp_id);
                DominioTangerine.Entidad theUser = theComandoObtener.Ejecutar();
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
                _vista.nombreUsuario = null;
            }
        }

    }
}
