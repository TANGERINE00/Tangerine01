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
        Calendar textInputFechaEstimada { get; set; }
        TextBox textInputCosto { get; set; }
        TextBox textInputPorcentaje { get; set; }
        DropDownList inputGerente { get; set; }
        DropDownList inputEstatus { get; set; }
        TextBox text10 { get; set; }
        ListBox imputEncargado { get; set; }
        ListBox inputPersonal { get; set; }
        TextBox idPropuesta { get; set; }
        TextBox idProyecto { get; set; }
        ListBox GerentesPasados { get; set; }
        ListBox inputPersonalNoActivo { get; set; }
        TextBox acuerdoPago { get; set; } 
        TextBox idCompania { get; set; }
        TextBox descripcion { get; set; }
    }
}
