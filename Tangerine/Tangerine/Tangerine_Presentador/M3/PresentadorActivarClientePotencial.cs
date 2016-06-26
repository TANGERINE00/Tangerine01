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
    public class PresentadorActivarClientePotencial 
    {
        IContratoConsultarClientePotencial vista;

        /// <summary>
        /// Constructor de la clase presentador
        /// </summary>
        /// <param name="vista"></param>
        public PresentadorActivarClientePotencial(IContratoConsultarClientePotencial vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método que instancia y ejecuta al comando para activar a un cliente potencial dado su ID
        /// </summary>
        /// <param name="idCliente"></param>
        public void Activar(int idCliente)
        {
            Entidad _entidad = DominioTangerine.Fabrica.FabricaEntidades.ObtenerClientePotencial();
            _entidad.Id = idCliente;

            Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoActivarClientePotencial(_entidad);
            comando.Ejecutar();
        }
    }
}
