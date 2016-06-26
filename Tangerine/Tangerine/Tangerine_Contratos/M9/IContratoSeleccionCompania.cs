using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M9
{
    public interface IContratoSeleccionCompania
    {

        string company { get; set; }
        string alertaClase { set;}
        string alertaRol { set; }
        string alerta { set; }
        int StatusAccion();
    
    }
}
