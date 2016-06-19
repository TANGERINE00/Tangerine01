using DominioTangerine;
using DominioTangerine.Fabrica;
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

        public PresentadorAgregarContacto( IContratoAgregarContacto vista )
        {
            this._vista = vista;
        }

        public void CargarPagina()
        {
            _vista.botonVolver = _vista.CargarBotonVolver( _vista.GetTypeComp, _vista.GetIdComp );
        }

        public void AgregarContacto()
        {
            Entidad contactoNuevo = FabricaEntidades.crearContactoSinId( _vista.input_nombre, _vista.input_apellido,
                                                                         _vista.input_apellido, _vista.input_cargo,
                                                                         _vista.input_telefono, _vista.input_correo,
                                                                         _vista.GetTypeComp, _vista.GetIdComp );
            
            Comando<bool> comandoBool = FabricaComandos.CrearComandoAgregarContacto( contactoNuevo );
            comandoBool.Ejecutar();
            _vista.BotonAceptar(_vista.GetTypeComp, _vista.GetIdComp);
        }
    }
}
