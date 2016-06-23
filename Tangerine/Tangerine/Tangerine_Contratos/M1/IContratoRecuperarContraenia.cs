using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M1
{
    public interface IContratoRecuperarContrasenia
    {
        string elcorreo { get; set; }

        string elusuario { get; set; }

        string elmensaje { get; set; }

    }
}
