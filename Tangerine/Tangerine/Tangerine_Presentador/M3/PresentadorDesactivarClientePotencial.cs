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
    public class PresentadorDesactivarClientePotencial
    {
        IContratoConsultarClientePotencial vista;

        /// <summary>
        /// Constructor d la clase presentador 
        /// </summary>
        /// <param name="vista"></param>
        /// <returns></returns>
        public PresentadorDesactivarClientePotencial(IContratoConsultarClientePotencial vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método que instancia y ejecuta el comando para desactivar a un cliente potencial
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public void Desactivar(int idCliente)
        {
            Entidad _entidad = DominioTangerine.Fabrica.FabricaEntidades.ObtenerClientePotencial();
            _entidad.Id = idCliente;

            Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoDesactivarClientePotencial(_entidad);
            comando.Ejecutar();
        }
    }
}
