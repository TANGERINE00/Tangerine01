using DominioTangerine;
using DominioTangerine.Entidades.M5;
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
    public class PresentadorModificarContacto
    {
        private IContratoModificarContacto _vista;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vista"></param>
        public PresentadorModificarContacto ( IContratoModificarContacto vista )
        {
            this._vista = vista;    
        }

        /// <summary>
        /// Método que se ejecuta al cargar la vista
        /// </summary>
        public void CargarPagina() 
        {
            int idcont = _vista.GetidCont();
            _vista.botonVolver = _vista.CargarBotonVolver( _vista.GetTypeComp(), _vista.GetIdComp() );
        }

        /// <summary>
        /// Método que contigura el div de alerta de la vista
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="typeMsg"></param>
        public void Alerta( string msj, int typeMsg )
        {
            if ( typeMsg == 1 )
                _vista.alertaClase = RecursoM5.AlertSuccess;
            else
                _vista.alertaClase = RecursoM5.AlertDanger;

            _vista.alertaRol = RecursoM5.Alert;
            _vista.alerta = RecursoM5.AlertShowSu1 + msj + RecursoM5.AlertShowSu2;
        }

        /// <summary>
        /// Método que carga los datos del contacto a modificar en la vista
        /// </summary>
        public void NoPostPagina()
        {
            try
            {
                int idcont = _vista.GetidCont();
                Entidad contacto = FabricaEntidades.crearContactoVacio();
                contacto.Id = idcont;

                Comando<Entidad> comandoEntidad = FabricaComandos.CrearComandoConsultarContacto( contacto );
                contacto = comandoEntidad.Ejecutar();

                ContactoM5 contactoConsultado = ( ContactoM5 ) contacto;

                _vista.input_nombre = contactoConsultado.Nombre;
                _vista.input_apellido = contactoConsultado.Apellido;
                _vista.item_cargo = contactoConsultado.Cargo;
                _vista.input_correo = contactoConsultado.Correo;
                _vista.input_departamento = contactoConsultado.Departamento;
                _vista.input_telefono = contactoConsultado.Telefono;
            }
            catch ( ConsultarContactoException ex )
            {
                Alerta( ex.Mensaje + ", por favor intente de nuevo.", 0 );
            }
            catch ( BaseDeDatosContactoException ex ) 
            {
                Alerta( ex.Mensaje + ", por favor intente de nuevo.", 0 );
            }
        }

        /// <summary>
        /// Método para modificar el contacto
        /// </summary>
        public void ModificarContacto() 
        {
            try
            {
                Entidad contacto = FabricaEntidades.crearContactoConId( _vista.GetidCont(), _vista.input_nombre,
                                                                        _vista.input_apellido, _vista.input_departamento,
                                                                        _vista.item_cargo, _vista.input_telefono,
                                                                        _vista.input_correo, _vista.GetTypeComp(),
                                                                        _vista.GetIdComp() );

                Comando<bool> comandoEntidad = FabricaComandos.CrearComandoModificarContacto( contacto );
                comandoEntidad.Ejecutar();
                _vista.BotonAceptar( _vista.GetTypeComp(), _vista.GetIdComp() );
            }
            catch( ModificarContactoException ex )
            {
                Alerta( ex.Mensaje + ", por favor intente de nuevo.", 0 );
            }
            catch( BaseDeDatosContactoException ex )
            {
                Alerta( ex.Mensaje + ", por favor intente de nuevo.", 0 );
            }
        }
    }
}
