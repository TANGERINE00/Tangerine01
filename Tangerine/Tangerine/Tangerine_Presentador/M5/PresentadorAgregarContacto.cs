using DominioTangerine;
using DominioTangerine.Fabrica;
using ExcepcionesTangerine.M5;
using LogicaTangerine;
using LogicaTangerine.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M5;

namespace Tangerine_Presentador.M5
{
    public class PresentadorAgregarContacto
    {
        private IContratoAgregarContacto _vista;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vista"></param>
        public PresentadorAgregarContacto( IContratoAgregarContacto vista )
        {
            this._vista = vista;
        }

        /// <summary>
        /// Método que carga el boton volver en la vista
        /// </summary>
        public void CargarPagina()
        {
            _vista.botonVolver = _vista.CargarBotonVolver( _vista.GetTypeComp(), _vista.GetIdComp() );
        }

        /// <summary>
        /// Método que agrega un contacto nuevo
        /// </summary>
        public void AgregarContacto()
        {
            try
            {
                Entidad contactoNuevo = FabricaEntidades.crearContactoSinId( _vista.input_nombre, _vista.input_apellido,
                                                                             _vista.input_departamento, _vista.item_cargo,
                                                                             _vista.input_telefono, _vista.input_correo,
                                                                             _vista.GetTypeComp(), _vista.GetIdComp() );

                Comando<bool> comandoBool = FabricaComandos.CrearComandoAgregarContacto( contactoNuevo );
                comandoBool.Ejecutar();
                _vista.BotonAceptar( _vista.GetTypeComp(), _vista.GetIdComp() );
            }
            catch( AgregarContactoException ex )
            {
                //Muestro en pantalla el error
                System.Diagnostics.Debug.WriteLine("Error Agregar Contacto");
            }
            catch( BaseDeDatosContactoException ex )
            {
                //Muestro en pantalla el error
                System.Diagnostics.Debug.WriteLine("Error Base de Datos");
            }
        }
    }
}
