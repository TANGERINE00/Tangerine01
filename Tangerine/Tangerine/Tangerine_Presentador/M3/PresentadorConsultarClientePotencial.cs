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
    public class PresentadorConsultarClientePotencial
    {
        IContratoConsultarClientePotencial vista;
        
        public PresentadorConsultarClientePotencial(IContratoConsultarClientePotencial vista)
        {
            this.vista = vista;
        }
    }
}
