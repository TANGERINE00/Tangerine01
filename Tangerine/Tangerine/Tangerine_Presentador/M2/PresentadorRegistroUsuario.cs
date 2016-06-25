using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M2;
using DominioTangerine;


namespace Tangerine_Presentador.M2
{
    public class PresentadorRegistroUsuario
    {
        private IContratoRegistroUsuario _vista;

        /// <summary>
        /// Constructor del presentador de la vista Registrar Usuario
        /// </summary>
        /// <param name="vista"></param>
        public PresentadorRegistroUsuario( IContratoRegistroUsuario vista )
        {
            _vista = vista;
        }

        /// <summary>
        /// Método para manejar los errores y mensajes a interfaz
        /// </summary>
        public void Alerta(string msj)
        {
            if (msj == "1")
            {
                _vista.alertaClase = ResourceGUIM2.alertaModificado;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + ResourceGUIM2.MsjCreado + ResourceGUIM2.alertaHtmlFinal;
            }
            else
            {
                _vista.alertaClase = ResourceGUIM2.alertaError;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + msj + ResourceGUIM2.alertaHtmlFinal;
            }
        }

        /// <summary>
        /// Método que inicia la vista de la página registrar usuario
        /// </summary>
        public void inicioVista()
        {
            try
            {
                _vista.tablaEmpleado = null;
                LogicaTangerine.Comando<List<Entidad>> theComando = LogicaTangerine.Fabrica.FabricaComandos.ConsultarEmpleados();
                List<Entidad> listaDeEmpleados = theComando.Ejecutar();
                foreach (Entidad theEmpleado in listaDeEmpleados)
                {
                    DominioTangerine.Entidades.M10.EmpleadoM10 empleado = (DominioTangerine.Entidades.M10.EmpleadoM10)theEmpleado;
                    LogicaTangerine.Comando<Boolean> theComandoVerificar =
                        LogicaTangerine.Fabrica.FabricaComandos.verificarUsuario( empleado.emp_id );
                    _vista.tablaEmpleado += ResourceGUIM2.OpenTR;
                    _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.emp_id.ToString() + ResourceGUIM2.CloseTD;
                    _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_p_nombre + ResourceGUIM2.CloseTD;
                    _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_p_apellido + ResourceGUIM2.CloseTD;
                    _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.Emp_cedula + ResourceGUIM2.CloseTD;
                    _vista.tablaEmpleado += ResourceGUIM2.OpenTD + empleado.jobs.Nombre + ResourceGUIM2.CloseTD;

                    if ( !theComandoVerificar.Ejecutar() )
                    {
                        _vista.tablaEmpleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonRegNuevaVentana + empleado.emp_id +
                                                ResourceGUIM2.NombreEmpleado + empleado.emp_p_nombre + ResourceGUIM2.ApellidoEmpleado +
                                                empleado.emp_p_apellido + ResourceGUIM2.RolEmpleado + empleado.jobs.Nombre +
                                                ResourceGUIM2.CloseBotonParametro + ResourceGUIM2.CloseTD;
                    }
                    else
                    {
                        _vista.tablaEmpleado += ResourceGUIM2.OpenTD + ResourceGUIM2.BotonRegBlock +
                                                ResourceGUIM2.CloseBotonParametroDesactivado + ResourceGUIM2.CloseTD;
                    }

                    _vista.tablaEmpleado += ResourceGUIM2.CloseTR;
                }
            }
            catch ( ExcepcionesTangerine.M2.ExceptionM2Tangerine ex )
            {
                _vista.alertaClase = ResourceGUIM2.alertaError;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + ex.Message + ex.InnerException.Message
                                + ResourceGUIM2.alertaHtmlFinal;
            }
    
        }
    }
}
