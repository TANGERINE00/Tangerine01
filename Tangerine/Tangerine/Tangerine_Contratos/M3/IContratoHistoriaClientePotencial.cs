using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace Tangerine_Contratos.M3
{
    public interface IContratoHistoriaClientePotencial
    {
        Literal NombreEtiqueta { get; set; }
        Literal EstatusEtiqueta { get; set; }
        Literal RIFEtiqueta { get; set; }
        Literal CorreoEtiqueta { get; set; }
        Literal PresupuestoInicialEtiqueta { get; set; }
        Literal SegumientoLLamadas { get; set; }
        Literal SeguimientoVisitas { get; set; }
    }
}
