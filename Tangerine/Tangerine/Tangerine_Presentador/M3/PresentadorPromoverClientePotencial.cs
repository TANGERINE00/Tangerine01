using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M3;
using LogicaTangerine;
using DominioTangerine;
using System.Web;

namespace Tangerine_Presentador.M3
{
    public class PresentadorPromoverClientePotencial
    {
        IContratoConsultarClientePotencial vista;

        public PresentadorPromoverClientePotencial(IContratoConsultarClientePotencial vista)
        {
            this.vista = vista;
        }

        public void Promover(int idCliente)
        {
            Entidad _entidad = DominioTangerine.Fabrica.FabricaEntidades.ObtenerClientePotencial();
            _entidad.Id = idCliente;

            Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoPromoverClientePotencial(_entidad);
            comando.Ejecutar();
        }
    }
}
