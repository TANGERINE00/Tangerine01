using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M8
{
    public interface IContratoCorreo
    {
        string numero { get; set; }
        string destinatario { get; set; }
        string asunto { get; set; }
        string mensaje { get; set; }
        string adjunto { get; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}
