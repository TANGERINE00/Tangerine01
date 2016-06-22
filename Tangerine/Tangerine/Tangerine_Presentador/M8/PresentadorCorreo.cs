using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M8;
using LogicaTangerine;
using DominioTangerine;
using System.Web;

namespace Tangerine_Presentador.M8
{
    public class PresentadorCorreo
    {
        IContratoCorreo vista;

        public PresentadorCorreo(IContratoCorreo vista)
        {
            this.vista = vista;
        }


    }
}
