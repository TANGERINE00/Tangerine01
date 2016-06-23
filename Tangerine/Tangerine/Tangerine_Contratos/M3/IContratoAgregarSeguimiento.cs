using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M3
{
    public interface IContratoAgregarSeguimiento
    {
        DropDownList Tipo { get; set; }
        //DateTime Fecha { get; set; }
        String Fecha { get; set; }
        String Motivo { get; set; }
        String Opcion { get; set; }
    }
}
