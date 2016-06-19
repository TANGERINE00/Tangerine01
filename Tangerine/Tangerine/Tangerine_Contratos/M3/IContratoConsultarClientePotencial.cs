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
        Label NombreEtiqueta { get; set; }
        Label EstatusEtiqueta { get; set; }
        Label RIFEtiquete { get; set; }
        Label PresupuestoInicial { get; set; }
        Label Correo { get; set; }
        Label NumLlamadas { get; set; }
        Label NumVisitas { get; set; }
    }
}
