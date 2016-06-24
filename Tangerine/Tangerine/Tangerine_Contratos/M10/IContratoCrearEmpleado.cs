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
        /// <summary>
        /// Encabezado combo genere
        /// </summary>
        DropDownList IcomboGenero { get; set; }

        /// <summary>
        /// Encabezado combo nivel de estudio
        /// </summary>
        DropDownList IcomboNivelEstudio { get; set; }

        /// <summary>
        /// Encabezado combo paises
        /// </summary>
        DropDownList IcomboPais { get; set; }

        /// <summary>
        /// Encabezado combo cargo
        /// </summary>
        DropDownList IcomboCargo { get; set; }

        /// <summary>
        /// Encabezado combo estado
        /// </summary>
        DropDownList IcomboEstado { get; set; }

        /// <summary>
        /// Encabezado textbox para la cedula
        /// </summary>
        TextBox ItextCedula { get; set; }

        /// <summary>
        /// Encabezado textbox para el primer nombre
        /// </summary>
        TextBox ItextFirstName { get; set; }

        /// <summary>
        /// Encabezado textbox para el segundo nombre
        /// </summary>
        TextBox ItextSecondName { get; set; }

        /// <summary>
        /// Encabezado textbox primer apellido
        /// </summary>
        TextBox ItextFirstLastName { get; set; }

        /// <summary>
        /// Encabezado segundo apellido
        /// </summary>
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
