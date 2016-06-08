using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M1
{
    public interface IContratoRestablecer
    {
        String ClaveEtq { get; }

        String ClaveConfirmacionEtq { get; }

        String InfoRestablecerEtqText { get; set; }

        String WarningCaracterEtqText { get; set; }

        Boolean InfoRestablecerEtq { get; set; }

        Boolean WarningCaracterEtq { get; set; }
    }
}
