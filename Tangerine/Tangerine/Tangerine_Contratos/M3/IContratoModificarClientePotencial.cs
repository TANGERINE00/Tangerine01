using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M3
{
    public interface IContratoModificarClientePotencial
    {
        String NombreEtiqueta { get; set; }
        String RifEtiqueta { get; set; }
        String CorreoElectronico { get; set; }
        float PresupuestoInversion { get; set; }
        int NumeroLlamadas { get; set; }
        int NumeroVisitas { get; set; }
        bool AccionSobreBd { get; set; }
    }
}
