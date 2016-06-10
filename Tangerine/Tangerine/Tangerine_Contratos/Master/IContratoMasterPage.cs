using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.Master
{
    public interface IContratoMasterPage
    {

        String RolesEtq { get; set; }

        String NombreEtq { get; set; }

        String NombreTagEtq { get; set; }

        String IdModulo { get; set; }

        String LogoutEtq { get; set; }

        String[] RolesUsuario { get; set; }

    }
}
