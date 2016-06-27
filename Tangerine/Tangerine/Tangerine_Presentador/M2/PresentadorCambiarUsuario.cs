using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M2;

namespace Tangerine_Presentador.M2
{
    public class PresentadorCambiarUsuario
    {
        private int _numFicha;
        private IContratoCambiarUsuario _vista;

        /// <summary>
        /// Constructor que recibe la vista de CambiarUsuario y el numero de ficha del usuario en cuestión
        /// </summary>
        /// <param name="vista"></param>
        /// <param name="numFicha"></param>
        public PresentadorCambiarUsuario( IContratoCambiarUsuario vista , int numFicha )
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
            _vista.alertaUsuario = ResourceGUIM2.tipoAlerta;
            _vista.alerta = ResourceGUIM2.alertaHtml + msj + ResourceGUIM2.alertaHtmlFinal;
        }

        /// <summary>
        /// Inicio de vista de la página de Cambiar Usuario
        /// </summary>
        public void inicioVista()
        {
            try
            {
                LogicaTangerine.Comando<DominioTangerine.Entidad> theComando =
                            LogicaTangerine.Fabrica.FabricaComandos.obtenerUsuario( _numFicha );
                DominioTangerine.Entidad theUser = theComando.Ejecutar();
                DominioTangerine.Entidades.M2.UsuarioM2 user = ( DominioTangerine.Entidades.M2.UsuarioM2 )theUser;
                _vista.fichaEmpleado = _numFicha.ToString();
                _vista.nombreUsuario = user.nombreUsuario;
            }
            catch ( ExcepcionesTangerine.M2.ExceptionM2Tangerine ex )
            {
                _vista.alertaClase = ResourceGUIM2.alertaError;
                _vista.alertaUsuario = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + ex.Message + ResourceGUIM2.alertaHtmlFinal;
            }

        }

        /// <summary>
        /// Asigna un nuevo nombre de usuario al usuario en cuestión
        /// </summary>
        public bool asignar()
        {
            try
            {
                LogicaTangerine.Comando<Boolean> theComando =
                    LogicaTangerine.Fabrica.FabricaComandos.modificarUsuario( int.Parse( _vista.fichaEmpleado ) , _vista.nombreUsuario );
                return theComando.Ejecutar();
            }
            catch ( ExcepcionesTangerine.M2.ExceptionM2Tangerine ex )
            {
                _vista.alertaClase = ResourceGUIM2.alertaError;
                _vista.alertaUsuario = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + ex.Message + ResourceGUIM2.alertaHtmlFinal;
                return false;
            }
        }

        /// <summary>
        /// Verificar si el nombre de usuario ya existe en la BD.
        /// </summary>
        /// <returns>Retorna un valor booleano indicando si el usuario ya existe</returns>
        public bool usuarioExistente()
        {
            bool respuesta = false;
            LogicaTangerine.Comando<Boolean> comando = LogicaTangerine.Fabrica.FabricaComandos.validarUsuario( _vista.nombreUsuario );
            respuesta = comando.Ejecutar();
            return respuesta;
        }

        /// <summary>
        /// Verifica el ID del ultimo empleado de la BD
        /// </summary>
        /// <returns>Retorna el ID del ultimo empleado</returns>
        public bool ultimoIDEmpleado()
        {   
            bool respuesta = true;
            int resultado;
            LogicaTangerine.Comando<int> comando = LogicaTangerine.Fabrica.FabricaComandos.consultarIDUltimoEmpleado();
            resultado = comando.Ejecutar();
            if ( int.Parse( _vista.fichaEmpleado ) > resultado )
            {
                respuesta = false;
            }
            return respuesta;
        }
    }
}
