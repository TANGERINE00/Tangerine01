using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M3
{
    public interface IContratoAgregarClientePotencial
    {
        String NombreEtiqueta { get; set; }
        String RifEtiqueta { get; set; }
        String CorreoElectronico { get; set; }
        float PresupuestoInversion { get; set; }
        bool AccionSobreBd { get; set; }
    }
}
