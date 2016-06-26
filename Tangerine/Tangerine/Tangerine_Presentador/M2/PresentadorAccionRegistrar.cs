using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M2;
using Tangerine_Presentador.M2;

namespace Tangerine_Presentador.M2
{
    public class PresentadorAccionRegistrar
    {
        private IContratoAccionRegistrar _vista;
        private int _numFicha;
        private string _nombreUser;
        private string _apellidoUser;
        private string _rol;

        /// <summary>
        /// Constructor de la clase, que recibe la vista, el numero ficha, nombre y apellido del empleado
        /// </summary>
        /// <param name="vista"></param>
        /// <param name="numFicha"></param>
        /// <param name="nombreUser"></param>
        /// <param name="apellidoUser"></param>
        /// <param name="rol"></param>
        public PresentadorAccionRegistrar( IContratoAccionRegistrar vista , int numFicha , string nombreUser , string apellidoUser ,
                                           string rol )
        {
            _vista = vista;
            _numFicha = numFicha;
            _nombreUser = nombreUser;
            _apellidoUser = apellidoUser;
            _rol = rol;
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
        /// Metodo que inicializa la vista de AccionRegistrar generando un nombre usuario
        /// </summary>
        public void inicioVista()
        {
            try
            {
                _vista.ficha = _numFicha.ToString();
                _vista.comboRol = _rol;
                LogicaTangerine.Comando<String> theComando =
                    LogicaTangerine.Fabrica.FabricaComandos.crearUsuario( _nombreUser , _apellidoUser );
                _vista.usuario = theComando.Ejecutar();
            }
            catch ( ExcepcionesTangerine.M2.ExceptionM2Tangerine ex )
            {
                _vista.alertaClase = ResourceGUIM2.alertaError;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + ex.Message + ResourceGUIM2.alertaHtmlFinal;
            }

        }

        /// <summary>
        /// Registra el usuario en la Base de Datos
        /// </summary>
        public bool registrar()
        {
            try
            {
                LogicaTangerine.Comando<Boolean> theComando = LogicaTangerine.Fabrica.FabricaComandos.prepararUsuario( _vista.usuario ,
                                                              _vista.contrasena , _vista.comboRol , _numFicha );
                return theComando.Ejecutar();
            }
            catch ( ExcepcionesTangerine.M2.ExceptionM2Tangerine ex )
            {
                _vista.alertaClase = ResourceGUIM2.alertaError;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + ex.Message + ResourceGUIM2.alertaHtmlFinal;
                return false;
            }
        }

        /// <summary>
        /// Verificar si el nombre de usuario ya existe en la BD.
        /// </summary>
        /// <returns></returns>
        public bool usuarioExistente()
        {
            try
            {
                bool respuesta = false;
                LogicaTangerine.Comando<Boolean> comando = LogicaTangerine.Fabrica.FabricaComandos.validarUsuario( _vista.usuario );
                respuesta = comando.Ejecutar();
                return respuesta;
            }
            catch ( ExcepcionesTangerine.M2.ExceptionM2Tangerine ex )
            {
                _vista.alertaClase = ResourceGUIM2.alertaError;
                _vista.alertaRol = ResourceGUIM2.tipoAlerta;
                _vista.alerta = ResourceGUIM2.alertaHtml + ex.Message + ResourceGUIM2.alertaHtmlFinal;
                return true;
            }
        }
    }
}
