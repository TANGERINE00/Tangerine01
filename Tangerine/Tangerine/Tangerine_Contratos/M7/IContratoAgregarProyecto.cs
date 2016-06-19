using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M7
{
    public interface IContratoAgregarProyecto
    {
        String NombrePropuesta { get; set; }
        String NombreProyecto { get; set; }
        String CodigoProyecto { get; set; }
        String FechaInicio { get; set; }
        String FechaFin { get; set; }
        String Costo { get; set; }
        String Porcentaje { get; set; }
        String Estatus { get; set; }
        DropDownList inputPersonal { get; set; }
        DropDownList inputEncargado { get; set; }

    }
}
