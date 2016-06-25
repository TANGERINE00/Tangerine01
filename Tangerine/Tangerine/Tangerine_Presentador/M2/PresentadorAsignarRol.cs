using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M2;

namespace Tangerine_Presentador.M2
{
    public class PresentadorAsignarRol
    {
        private int _numFicha;
        private IContratoAsignarRol _vista;

        /// <summary>
        /// Constructor que recibe la vista de AsignarRol y el numero de ficha del usuario en cuestión
        /// </summary>
        /// <param name="vista"></param>
        /// <param name="numFicha"></param>
        public PresentadorAsignarRol ( IContratoAsignarRol vista , int numFicha )
        {
            _vista = vista;
            _numFicha = numFicha;
        }

        /// <summary>
        /// Método para manejar los errores y mensajes a interfaz
        /// </summary>
        public void Alerta( string msj )
        {
            _vista.alertaClase = ResourceGUIM2.alertaError;
            _vista.alertaRol = ResourceGUIM2.tipoAlerta;
            _vista.alerta = ResourceGUIM2.alertaHtml + msj + ResourceGUIM2.alertaHtmlFinal;
        }

        /// <summary>
        /// Inicio de vista de la página de Asignar Rol
        /// </summary>
        public void inicioVista()
        {
            try
            {
                LogicaTangerine.Comando<DominioTangerine.Entidad> theComando =
                            LogicaTangerine.Fabrica.FabricaComandos.obtenerUsuario(_numFicha);
                DominioTangerine.Entidad theUser = theComando.Ejecutar();
                DominioTangerine.Entidades.M2.UsuarioM2 user = (DominioTangerine.Entidades.M2.UsuarioM2)theUser;
                _vista.usuario = user.nombreUsuario;
                _vista.comboBoxRol = user.rol.nombre;
            }
            catch (ExcepcionesTangerine.M2.ExceptionM2Tangerine ex)
            {
                _vista.alertaClase = ResourceGUIM2.alertaError;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + ex.Message + ex.InnerException.Message
                    + ResourceGUIM2.alertaHtmlFinal;
            }

        }

        /// <summary>
        /// Asigna un nuevo rol al usuario en cuestión
        /// </summary>
        public bool asignar()
        {
            try
            {
                LogicaTangerine.Comando<Boolean> theComando =
                    LogicaTangerine.Fabrica.FabricaComandos.obtenerComandoModificarRol( _vista.usuario , _vista.comboBoxRol );
                return theComando.Ejecutar();
            }
            catch ( ExcepcionesTangerine.M2.ExceptionM2Tangerine ex )
            {
                _vista.alertaClase = ResourceGUIM2.alertaError;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + ex.Message + ex.InnerException.Message
                    + ResourceGUIM2.alertaHtmlFinal;
                return false;
            }
        }
    }
}
