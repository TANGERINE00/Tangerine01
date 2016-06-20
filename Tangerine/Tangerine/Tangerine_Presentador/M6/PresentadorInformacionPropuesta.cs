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
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
