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
        Label NombrePropuesta { get; set; }
        Label NombreProyecto { get; set; }
        Label CodigoProyecto { get; set; }
        Label FechaInicio { get; set; }
        Label FechaFin { get; set; }
        Label Costo { get; set; }
        Label Porcentaje { get; set; }
        Label Estatus { get; set; }
        DropDownList inputPersonal { get; set; }
        DropDownList inputEncargado { get; set; }

    }
}
