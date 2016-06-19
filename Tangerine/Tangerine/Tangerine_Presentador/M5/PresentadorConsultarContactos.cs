using DominioTangerine;
using DominioTangerine.Entidades.M4;
using DominioTangerine.Entidades.M5;
using DominioTangerine.Fabrica;
using LogicaTangerine;
using LogicaTangerine.Fabrica;
using LogicaTangerine.M3;
using LogicaTangerine.M4;
using LogicaTangerine.M5;
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

        public PresentadorConsultarContactos( IContratoConsultarContactos vista )
        {
            this._vista = vista;
        }

        public void CargarBotonVolver( int typeComp, int idComp )
        {
            if ( typeComp == 1 )
            { 
                Entidad compania = FabricaEntidades.crearCompaniaVacia();
                compania.Id = idComp;
                
                Comando<Entidad> comandoEntidad = FabricaComandos.CrearConsultarCompania( compania );
                compania = comandoEntidad.Ejecutar();

                CompaniaM4 companiaConsultada = ( CompaniaM4 )compania;

                _vista.botonVolver = _vista.BotonVolverCompania();
                _vista.nombreEmpresa = _vista.EmpresaGen() + companiaConsultada.NombreCompania;
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

                _vista.botonVolver = _vista.BotonVolverLead();
                _vista.nombreEmpresa = _vista.LeadGen() + leadConsultado.NombreClientePotencial;
            }
        }

        public void EliminarContacto()
        {
            try
            {
                int id = _vista.IdCont();

                Entidad contacto = FabricaEntidades.crearContactoVacio();
                contacto.Id= id;

                Comando<bool> comandoBool = FabricaComandos.CrearComandoEliminarContacto( contacto );
                comandoBool.Ejecutar();
            }
            catch (Exception ex)
            {
                //No se hace nada,  ya que el idCont no es un parametro obligatorio
            }
        }

        public void Alertas()
        {
            try
            {
                int status = _vista.StatusAccion();

                switch (status)
                {
                    case 1:
                        _vista.Alerta( _vista.ContactoAgregadoMsj(), _vista.StatusAgregado() );
                        break;
                    case 2:
                        _vista.Alerta( _vista.ContadoModificadoMsj(), _vista.StatusAgregado() );
                        break;
                    case 3:
                        _vista.Alerta( _vista.ContactoEliminadoMsj(), _vista.StatusAgregado() );
                        break;
                }
            }
            catch (Exception ex)
            {
                //No se hace nada,  ya que el status no es un parametro obligatorio
            } 
        }

        public void LlenarTablaContactos()
        {
            try
            {
                Entidad compania = FabricaEntidades.crearCompaniaVacia();
                compania.Id = _vista.getIdComp;

                Comando<List<Entidad>> comandoLista = 
                                       FabricaComandos.CrearComandoConsultarContactosPorCompania( compania,
                                                                                                  _vista.getTypeComp );

                List<Entidad> listaContactos = comandoLista.Ejecutar();

                foreach ( Entidad entidad in listaContactos )
                {
                    ContactoM5 contacto = ( ContactoM5 ) entidad;
                    _vista.LlenarTabla( contacto, _vista.getTypeComp, _vista.getIdComp );
                }

                _vista.CargarBotonNuevoContacto( _vista.getTypeComp, _vista.getIdComp );
            }
            catch ( Exception ex )
            {
                _vista.Alerta( ex.Message, int.Parse( _vista.StatusModificado() ) );
            }
        }

        public void CargarPagina()
        {
            CargarBotonVolver( _vista.getTypeComp, _vista.getIdComp );
            EliminarContacto();
            Alertas();
            LlenarTablaContactos();
        }
    }
}
