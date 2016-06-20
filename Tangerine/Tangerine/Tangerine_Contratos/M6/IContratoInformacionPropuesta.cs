using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M6
{
    public interface IContratoInformacionPropuesta
    {
        Label Codigo
        {
            get;
            set;
        }

        Label Status
        {
            get;
            set;
        }

        Label Compania
        {
            get;
            set;
        }

        Literal Descripcion
        {
            get;
            set;
        }
    }
}
