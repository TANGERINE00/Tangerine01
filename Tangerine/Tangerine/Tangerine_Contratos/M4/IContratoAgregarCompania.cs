using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M4
{
    public interface IContratoAgregarCompania
    {
        string inputNombre1 { get; set; }
        string inputAcronimo1 { get; set; }
        string inputRIF1 { get; set; }
        DropDownList inputDireccion1 { get; set; }
        string inputEmail1 { get; set; }
        string inputTelefono1 { get; set; }
        string Datepicker1 { get; set; }
        string inputPresupuesto1 { get; set; }
        string inputPlazoPago1 { get; set; }
        string msjError { get; set; }
    }
}
