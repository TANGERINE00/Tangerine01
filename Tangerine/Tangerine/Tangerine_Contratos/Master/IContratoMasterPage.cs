using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M1;

namespace Tangerine_Contratos.Master
{
    public interface IContratoMasterPage
    {
        string sesionUsuario { get; set; }
        string usuarioDet { get; set; }
        string fechaUser { get; set; }

        bool IFindControl(string id);
        

    }
}
