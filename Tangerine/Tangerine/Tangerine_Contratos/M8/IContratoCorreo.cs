using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M8
{
    public interface IContratoCorreo
    {
        string destinatario { get; set; }
        string asunto { get; set; }
        string mensaje { get; set; }
    }
}
