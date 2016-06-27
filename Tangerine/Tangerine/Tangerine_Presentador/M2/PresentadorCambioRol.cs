using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M2;
using DominioTangerine;

namespace Tangerine_Presentador.M2
{
    public class PresentadorCambioRol
    {
        private IContratoCambiarRol _vista;

        /// <summary>
        /// Constructor que recibe la vista Cambio Rol
        /// </summary>
        /// <param name="vista"></param>
        public PresentadorCambioRol( IContratoCambiarRol vista )
        {
            _vista = vista;
        }

        /// <summary>
        /// Método para manejar los errores y mensajes a interfaz
        /// </summary>
        public void Alerta( string msj )
        {
            if ( msj == "1" )
            {
                _vista.alertaClase = ResourceGUIM2.alertaModificado;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + ResourceGUIM2.MsjRolModificado + ResourceGUIM2.alertaHtmlFinal;
            }
            else if ( msj == "2" )
            {
                _vista.alertaClase = ResourceGUIM2.alertaModificado;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + ResourceGUIM2.MsjModificadoUser + ResourceGUIM2.alertaHtmlFinal;
            }
            else
            {
                _vista.alertaClase = ResourceGUIM2.alertaError;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + msj + ResourceGUIM2.alertaHtmlFinal;
            }
        }

        /// <summary>
        /// Carga en la tabla todos los empleados
        /// </summary>
        public void iniciarVista()
        {
            try
            {
                _vista.empleado = null;
                LogicaTangerine.Comando<List<Entidad>> theComando = LogicaTangerine.Fabrica.FabricaComandos.ConsultarEmpleados();
                List<Entidad> listaDeEmpleados = theComando.Ejecutar();

                foreach ( Entidad theEmpleador in listaDeEmpleados )
                {
                    DominioTangerine.Entidades.M10.EmpleadoM10 empleador = ( DominioTangerine.Entidades.M10.EmpleadoM10 )theEmpleador;
                    LogicaTangerine.Comando<DominioTangerine.Entidad> theComandoObtener =
                        LogicaTangerine.Fabrica.FabricaComandos.obtenerUsuario( empleador.emp_id );
                    DominioTangerine.Entidad theUser = theComandoObtener.Ejecutar();
                    DominioTangerine.Entidades.M2.UsuarioM2 user = ( DominioTangerine.Entidades.M2.UsuarioM2 )theUser;

                    _vista.empleado += ResourceGUIM2.OpenTR;
                    _vista.empleado += ResourceGUIM2.OpenTD + empleador.emp_p_nombre + ResourceGUIM2.CloseTD;
                    _vista.empleado += ResourceGUIM2.OpenTD + empleador.emp_p_apellido + ResourceGUIM2.CloseTD;
                    if ( user.nombreUsuario != null )
                    {
                        _vista.empleado += ResourceGUIM2.OpenTD + user.nombreUsuario + ResourceGUIM2.CloseTD;
                        _vista.empleado += ResourceGUIM2.OpenTD + user.rol.nombre + ResourceGUIM2.CloseTD;
                        _vista.empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.llamadoNuevaPagina + empleador.emp_id + 
                                           ResourceGUIM2.CloseBotonParametro + ResourceGUIM2.BotonModificar + empleador.emp_id +
                                           ResourceGUIM2.CloseBotonParametro + ResourceGUIM2.CloseTD;
                        _vista.empleado += ResourceGUIM2.CloseTR;
                    }
                    else
                    {
                        _vista.empleado += ResourceGUIM2.OpenTD + " " + ResourceGUIM2.CloseTD;
                        _vista.empleado += ResourceGUIM2.OpenTD + " " + ResourceGUIM2.CloseTD;
                        _vista.empleado += ResourceGUIM2.OpenTD + ResourceGUIM2.Botonblock +
                                           ResourceGUIM2.CloseBotonParametroDesactivado + ResourceGUIM2.BotonModificarBlock +
                                           ResourceGUIM2.CloseBotonParametroDesactivado + ResourceGUIM2.CloseTD;
                        _vista.empleado += ResourceGUIM2.CloseTR;
                    }
                }
            }
            catch ( ExcepcionesTangerine.M2.ExceptionM2Tangerine ex )
            {
                _vista.alertaClase = ResourceGUIM2.alertaError;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + ex.Message + ResourceGUIM2.alertaHtmlFinal;
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD e)
            {
                _vista.alertaClase = ResourceGUIM2.alertaError;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + e.Message + ResourceGUIM2.alertaHtmlFinal;
            }

        }
    }
}
