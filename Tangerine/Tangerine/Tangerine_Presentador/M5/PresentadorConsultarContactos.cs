using DominioTangerine;
using DominioTangerine.Entidades.M4;
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
    public class PresentadorConsultarContactos
    {
        private IContratoConsultarContactos _vista;
        private int estadoActual = 0;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="vista"></param>
        public PresentadorConsultarContactos( IContratoConsultarContactos vista )
        {
            this._vista = vista;
        }

        /// <summary>
        /// Método que carga el boton volver de la vista
        /// </summary>
        /// <param name="typeComp"></param>
        /// <param name="idComp"></param>
        public void CargarBotonVolver( int typeComp, int idComp )
        {
            try
            {
                if ( typeComp == 1 )
                {
                    Entidad compania = FabricaEntidades.CrearCompaniaVacia();
                    compania.Id = idComp;

                    Comando<Entidad> comandoEntidad = FabricaComandos.CrearConsultarCompania( compania );
                    compania = comandoEntidad.Ejecutar();

                    CompaniaM4 companiaConsultada = ( CompaniaM4 ) compania;

                    _vista.botonVolver = RecursoM5.VolverCompania;
                    _vista.nombreEmpresa = RecursoM5.Compania + companiaConsultada.NombreCompania;
                }
                else
                {
                    Entidad clientePotencial = FabricaEntidades.ObtenerClientePotencial();
                    clientePotencial.Id = idComp;

                    Comando<Entidad> comandoEntidad =
                                     FabricaComandos.ObtenerComandoConsultarClientePotencial( clientePotencial );

                    clientePotencial = comandoEntidad.Ejecutar();

                    DominioTangerine.Entidades.M3.ClientePotencial leadConsultado =
                        ( DominioTangerine.Entidades.M3.ClientePotencial ) clientePotencial;

                    _vista.botonVolver = RecursoM5.VolverCliPotencial;
                    _vista.nombreEmpresa = RecursoM5.Lead + leadConsultado.NombreClientePotencial;
                }
            }
            catch( ConsultarContactoException ex )
            {
                estadoActual = 6;
            }
            catch( BaseDeDatosContactoException ex )
            {
                estadoActual = 4;
            }
            catch ( Exception ex )
            {
                Alerta( RecursoM5.ErrorConsultarCompania, 0 );
            }
        }

        /// <summary>
        /// Metodo que elimina un contacto seleccionado de la tabla de contactos de la vista
        /// </summary>
        public void EliminarContacto()
        {
            try
            {
                int id = _vista.IdCont();

                if( id != 0 )
                {
                    Entidad contacto = FabricaEntidades.crearContactoVacio();
                    contacto.Id= id;

                    Comando<bool> comandoBool = FabricaComandos.CrearComandoEliminarContacto( contacto );
                    comandoBool.Ejecutar();
                }
            }
            catch( EliminarContactoException ex )
            {
                estadoActual = 5;
            }
            catch( BaseDeDatosContactoException ex )
            {
                estadoActual = 4;
            }
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
        /// Método que carga alertas de la vista
        /// </summary>
        public void Alertas()
        {
            switch ( estadoActual )
            {
                case 1:
                    Alerta( RecursoM5.ContactoAgregado, int.Parse( RecursoM5.StatusAgregado ) );
                    break;
                case 2:
                    Alerta( RecursoM5.ContactoModificado, int.Parse( RecursoM5.StatusAgregado ) );
                    break;
                case 3:
                    Alerta( RecursoM5.ContactoEliminado, int.Parse( RecursoM5.StatusAgregado ) );
                    break;
                case 4:
                    Alerta( RecursoM5.ErrorBaseDeDatos, 0 );
                    break;
                case 5:
                    Alerta( RecursoM5.ErrorEliminarContacto, 0 );
                    break;
                case 6:
                    Alerta( RecursoM5.ErrorConsultarContacto, 0 );
                    break;
            }
        }

        /// <summary>
        /// Método que agrega un row a la tabla de la vista
        /// </summary>
        /// <param name="_theContact2"></param>
        /// <param name="typeComp"></param>
        /// <param name="idComp"></param>
        private void LlenarTabla( ContactoM5 _theContact2, int typeComp, int idComp )
        {
            try
            {
                _vista.contact.Text += RecursoM5.AbrirTR;
                _vista.contact.Text += RecursoM5.AbrirTD + _theContact2.Apellido.ToString() + RecursoM5.Coma
                    + _theContact2.Nombre.ToString() + RecursoM5.CerrarTD;
                _vista.contact.Text += RecursoM5.AbrirTD + _theContact2.Departamento.ToString() + RecursoM5.CerrarTD;
                _vista.contact.Text += RecursoM5.AbrirTD + _theContact2.Cargo.ToString() + RecursoM5.CerrarTD;
                _vista.contact.Text += RecursoM5.AbrirTD + _theContact2.Telefono.ToString() + RecursoM5.CerrarTD;
                _vista.contact.Text += RecursoM5.AbrirTD + _theContact2.Correo.ToString() + RecursoM5.CerrarTD;
                //Acciones de cada contacto
                _vista.contact.Text += RecursoM5.AbrirTD2;
                _vista.contact.Text += RecursoM5.ButtonModContact + typeComp + RecursoM5.BotonVolver2 + idComp
                    + RecursoM5.BotonEliminar2 + _theContact2.Id + RecursoM5.BotonCerrar
                    + RecursoM5.BotonEliminar + typeComp + RecursoM5.BotonVolver2 + idComp
                    + RecursoM5.BotonEliminar2 + _theContact2.Id + RecursoM5.BotonVolver4
                    + RecursoM5.StatusEliminado + RecursoM5.BotonCerrar;
                _vista.contact.Text += RecursoM5.CerrarTD;
                _vista.contact.Text += RecursoM5.CerrarTR;
            }
            catch( Exception ex )
            {
                Alerta( RecursoM5.ErrorLlenarTabla, 0 );
            }
        }

        /// <summary>
        /// Método para llenar la tabla de contactos de la vista
        /// </summary>
        public void LlenarTablaContactos()
        {
            try
            {
                Entidad compania = FabricaEntidades.CrearCompaniaVacia();
                compania.Id = _vista.getIdComp();

                Comando<List<Entidad>> comandoLista = 
                                       FabricaComandos.CrearComandoConsultarContactosPorCompania( compania,
                                                                                                _vista.getTypeComp() );

                List<Entidad> listaContactos = comandoLista.Ejecutar();

                foreach ( Entidad entidad in listaContactos )
                {
                    ContactoM5 contacto = ( ContactoM5 ) entidad;
                    LlenarTabla( contacto, _vista.getTypeComp(), _vista.getIdComp() );
                }

                _vista.CargarBotonNuevoContacto( _vista.getTypeComp(), _vista.getIdComp() );
            }
            catch ( ConsultarContactoException ex )
            {
                Alerta( RecursoM5.ErrorConsultarContacto, 0 );
            }
            catch( BaseDeDatosContactoException ex )
            {
                Alerta( RecursoM5.ErrorBaseDeDatos, 0 );
            }
        }

        /// <summary>
        /// Método que se ejecuta al cargar la vista
        /// </summary>
        public void CargarPagina()
        {
            estadoActual = _vista.StatusAccion();
            CargarBotonVolver( _vista.getTypeComp(), _vista.getIdComp() );
            EliminarContacto();
            Alertas();
            LlenarTablaContactos();
        }
    }
}
