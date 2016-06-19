using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M3
{
    public interface IContratoConsultarClientePotencial
    {
        string NombreEtiqueta { get; set; }
        string EstatusEtiqueta { get; set; }
        string RIFEtiquete { get; set; }
        string PresupuestoInicial { get; set; }
        string Correo { get; set; }
        string NumLlamadas { get; set; }
        string NumVisitas { get; set; }
    }
}
