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
        String ItextCedula { get; set; }

        /// <summary>
        /// Encabezado textbox para el primer nombre
        /// </summary>
        String ItextFirstName { get; set; }

        /// <summary>
        /// Encabezado textbox para el segundo nombre
        /// </summary>
        String ItextSecondNamee { get; set; }

        /// <summary>
        /// Encabezado textbox primer apellido
        /// </summary>
        String ItextFirstLastName { get; set; }

        /// <summary>
        /// Encabezado segundo apellido
        /// </summary>
        String ItextSecondLastName { get; set; }

        /// <summary>
        /// Encabezado fecha de nacimiento
        /// </summary>
        String ItextDateEmployee { get; set; }

        /// <summary>
        /// Encabezado Fecha de contratación
        /// </summary>
        String ItextDateJob { get; set; }

        /// <summary>
        /// Encabezado Modalidad de Trabajo
        /// </summary>
        String ItextJobMode { get; set; }

        /// <summary>
        /// Encabezado salario
        /// </summary>
        String ItextSalaryJob { get; set; }

        /// <summary>
        /// Encabezado Ciudad
        /// </summary>
        String ItextCityAddress { get; set; }

        /// <summary>
        /// Encabezado direccion
        /// </summary>
        String ItextAddresEspecific { get; set; }

        /// <summary>
        /// Encabezado Email
        /// </summary>
        String ItextEmailPerson { get; set; }

        /// <summary>
        /// Encabezado Telefono
        /// </summary>
        String ItextPhonePerson { get; set; }

        /// <summary>
        /// Clase para el manejo de alertas
        /// </summary>
      
        

        
    }
}
