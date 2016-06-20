using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M6;
using LogicaTangerine;
using DominioTangerine;
using System.Web;

namespace Tangerine_Presentador.M6
{
    public class PresentadorInformacionPropuesta
    {
        IContratoInformacionPropuesta vistaInformacion;

        public PresentadorInformacionPropuesta(IContratoInformacionPropuesta vista)
        {
            this.vistaInformacion = vista;
        }


        public void consultarPropuesta(string id)
        {
            Entidad _propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta(
                id, null, null, null, null, null, null, 0, DateTime.Now, DateTime.Now, 0, null);

            Comando<Entidad> cmdConsultar = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdPropuesta(_propuesta);

            _propuesta = cmdConsultar.Ejecutar();
 
            try
            {
                vistaInformacion.Codigo.Text = ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Nombre;
                
                if ( ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Estatus == "Aprobado" )
                {
                    vistaInformacion.Status.Text = RecursosPresentadorPropuesta.aprobado;
                }
                else if (((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Estatus == "Cerrado")
                {
                    vistaInformacion.Status.Text = RecursosPresentadorPropuesta.cerrado;
                }
                else if (((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Estatus == "Pendiente")
                {
                    vistaInformacion.Status.Text = RecursosPresentadorPropuesta.pendiente;
                }

                imprimirCompania(_propuesta);

                vistaInformacion.Descripcion.Text = ((DominioTangerine.Entidades.M6.Propuesta)_propuesta).Descripcion;
                 
            }
            catch (Exception ex)
            {
               
            }
        }

        public void imprimirCompania(Entidad _propuesta)
        {
            Entidad _compania = DominioTangerine.Fabrica.FabricaEntidades.CrearEntidadCompaniaM4Llena(
                Int32.Parse(((DominioTangerine.Entidades.M6.Propuesta)_propuesta).IdCompañia), null, null, null, null, null,
                DateTime.Now, 0, 0, 0, 0);

            Comando<Entidad> cmdConsultarCompania = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(_compania);

            _compania = cmdConsultarCompania.Ejecutar();

            vistaInformacion.Compania.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_compania).NombreCompania;
        }

    }
}
