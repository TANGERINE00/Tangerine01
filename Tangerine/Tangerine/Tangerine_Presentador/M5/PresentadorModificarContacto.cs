using DominioTangerine;
using DominioTangerine.Entidades.M5;
using DominioTangerine.Fabrica;
using LogicaTangerine;
using LogicaTangerine.Fabrica;
using LogicaTangerine.M5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M5;

namespace Tangerine_Presentador.M5
{
    public class PresentadorModificarContacto
    {
        private IContratoModificarContacto _vista;

        public PresentadorModificarContacto ( IContratoModificarContacto vista )
        {
            this._vista = vista;    
        }

        public void CargarPagina() 
        {
            int idcont = _vista.GetidCont;
            _vista.botonVolver = _vista.CargarBotonVolver( _vista.GetTypeComp, _vista.GetIdComp );
        }

        public void NoPostPagina()
        {
            int idcont = _vista.GetidCont;
            Entidad contacto = FabricaEntidades.crearContactoVacio();
            contacto.Id = idcont;

            Comando<Entidad> comandoEntidad = FabricaComandos.CrearComandoConsultarContacto( contacto );
            contacto = comandoEntidad.Ejecutar();

            ContactoM5 contactoConsultado = ( ContactoM5 ) contacto;

            _vista.input_nombre = contactoConsultado.Nombre;
            _vista.input_apellido = contactoConsultado.Apellido;
            _vista.input_cargo = contactoConsultado.Cargo;
            _vista.input_correo = contactoConsultado.Correo;
            _vista.input_departamento = contactoConsultado.Departamento;
            _vista.input_telefono = contactoConsultado.Telefono; 
        }

        public void ModificarContacto() 
        {
            Entidad contacto = FabricaEntidades.crearContactoConId( _vista.GetidCont, _vista.input_nombre,
                                                                    _vista.input_apellido, _vista.input_departamento,
                                                                    _vista.input_cargo, _vista.input_telefono, 
                                                                    _vista.input_correo, _vista.GetTypeComp,
                                                                    _vista.GetIdComp );

            Comando<bool> comandoEntidad = FabricaComandos.CrearComandoModificarContacto( contacto );
            comandoEntidad.Ejecutar();
            _vista.BotonAceptar( _vista.GetTypeComp, _vista.GetIdComp );
        }
    }
}
