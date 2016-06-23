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
        /// <summary>
        /// Encabezado del nombre de la compania
        /// </summary>
        string inputNombre1 { get; set; }

        /// <summary>
        /// Encabezado acronimo de la compania
        /// </summary>
        string inputAcronimo1 { get; set; }

        /// <summary>
        /// Encabezado del rif de la compania
        /// </summary>
        string inputRIF1 { get; set; }

        /// <summary>
        /// Encabezado del dropdownlist de lugares para la compania
        /// </summary>
        DropDownList inputDireccion1 { get; set; }

        /// <summary>
        /// Encabezado del email de la compania
        /// </summary>
        string inputEmail1 { get; set; }

        /// <summary>
        /// Encabezado del telefono de la compania
        /// </summary>
        string inputTelefono1 { get; set; }

        /// <summary>
        /// Encabezado del campo fecha de ingreso de la compania
        /// </summary>
        string Datepicker1 { get; set; }

        /// <summary>
        /// Encabezado del presupuesto anual de la compania
        /// </summary>
        string inputPresupuesto1 { get; set; }

        /// <summary>
        /// Encabezado de los dias del plazo de pago para la compania
        /// </summary>
        string inputPlazoPago1 { get; set; }

        /// <summary>
        /// Encabezado acronimo del mensaje de error al momento de ocurrir una excepcion
        /// </summary>
        string msjError { get; set; }
    }
}
