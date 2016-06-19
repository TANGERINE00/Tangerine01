using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M7
{
    public interface IContratoModificarProyecto
    {
        TextBox inputPropuesta { get; set; }
        TextBox textInputNombreProyecto { get; set; }
        TextBox textInputCodigo { get; set; }
        TextBox textInputFechaInicio { get; set; }
        TextBox textInputFechaEstimada { get; set; }
        TextBox textInputCosto { get; set; }
        TextBox textInputPorcentaje { get; set; }
        Button btnGuardar { get; set; }
    }
}
