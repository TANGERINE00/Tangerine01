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
        TextBox ItextDateEmployee { get; set; }
        TextBox ItextDateJob { get; set; }
        TextBox ItextJobMode { get; set; }
        TextBox ItextSalaryJob { get; set; }
        TextBox ItextCityAddress { get; set; }
        TextBox ItextAddresEspecific { get; set; }
        TextBox ItextEmailPerson { get; set; }
        TextBox ItextPhonePerson { get; set; }
        
    }
}
