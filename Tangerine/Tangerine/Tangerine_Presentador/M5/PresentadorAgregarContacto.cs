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
        /// Método para verificar si el contacto que se va a agregar ya existe.
        /// </summary>
        /// <returns>true si el contacto existe</returns>
        public bool VerificarExistenciaContacto() 
        {
            bool respuesta = false;

            try 
            {
                Comando<List<Entidad>> comando = FabricaComandos.CrearComandoConsultarTodosContactos();
                List<Entidad> listaContactos = comando.Ejecutar();

                foreach ( Entidad e in listaContactos )
                {
                    ContactoM5 c = ( ContactoM5 ) e;

                    if ( c.Nombre.Equals( _vista.input_nombre ) && c.Apellido.Equals( _vista.input_apellido )
                         && c.Telefono.Equals( _vista.input_telefono ) && c.Correo.Equals( _vista.input_correo )   
                         && c.Departamento.Equals( _vista.input_departamento ) && c.Cargo.Equals( _vista.item_cargo )
                         && c.TipoCompañia.Equals( _vista.GetTypeComp() ) 
                         && c.IdCompañia.Equals( _vista.GetIdComp() ) )
                    {
                        respuesta = true;
                    }
                }

                return respuesta;
            }
            catch ( ConsultarContactoException ex )
            {
                Alerta( ex.Mensaje + ", por favor intente de nuevo.", 0 );
            }
            catch ( BaseDeDatosContactoException ex )
            {
                Alerta( ex.Mensaje + ", por favor intente de nuevo.", 0 );
            }

            return respuesta;
        }

        /// <summary>
        /// Método que agrega un contacto nuevo
        /// </summary>
        public void AgregarContacto()
        {
            try
            {
                bool verificar = VerificarExistenciaContacto();

                if (!verificar)
                {
                    Entidad contactoNuevo = FabricaEntidades.crearContactoSinId(_vista.input_nombre,
                                                                      _vista.input_apellido, _vista.input_departamento,
                                                                      _vista.item_cargo, _vista.input_telefono,
                                                                      _vista.input_correo, _vista.GetTypeComp(),
                                                                      _vista.GetIdComp());

                    Comando<bool> comandoBool = FabricaComandos.CrearComandoAgregarContacto(contactoNuevo);
                    comandoBool.Ejecutar();
                    _vista.BotonAceptar(_vista.GetTypeComp(), _vista.GetIdComp());
                }
                else
                {
                    Alerta( "El contacto que desea agregar ya existe", 0 );
                }
            }
            catch( AgregarContactoException ex )
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
