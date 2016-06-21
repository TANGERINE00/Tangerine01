using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Tangerine_Contratos.M7
{
    public interface IContratoAgregarProyecto
    {
        String NombreProyecto { get; set; }
        String CodigoProyecto { get; set; }
        String FechaInicio { get; set; }
        String FechaFin { get; set; }
        String Costo { get; set; }
        String Porcentaje { get; set; }
        String Estatus { get; set; }
        HtmlSelect inputPersonal { get; set; }
        HtmlSelect inputEncargado { get; set; }
        DropDownList inputPropuesta { get; set; }
        DropDownList inputGerente { get; set; }
        HtmlGenericControl columna2 { get; set; }
        Button BtnGenerar { get; set; }

    }
}
