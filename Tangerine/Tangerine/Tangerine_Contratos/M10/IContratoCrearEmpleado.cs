using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M1
{
    public interface IContratoCrearEmpleado
    {
        DropDownList IcomboGenero { get; set; }
        DropDownList IcomboNivelEstudio { get; set; }
        DropDownList IcomboPais { get; set; }
        DropDownList IcomboCargo { get; set; }
        DropDownList IcomboEstado { get; set; }
        TextBox ItextCedula { get; set; }
        TextBox ItextFirstName { get; set; }
        TextBox ItextSecondName { get; set; }
        TextBox ItextFirstLastName { get; set; }
        TextBox ItextSecondLastName { get; set; }
        String ItextDateEmployee { get; set; }
        String ItextDateJob { get; set; }
        String ItextJobMode { get; set; }
        String ItextSalaryJob { get; set; }
        String ItextCityAddress { get; set; }
        String ItextAddresEspecific { get; set; }
        String ItextEmailPerson { get; set; }
        String ItextPhonePerson { get; set; }
        
    }
}
