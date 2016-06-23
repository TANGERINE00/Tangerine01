using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M4
{
    public interface IContratoInformacionCompania
    {
        /// <summary>
        /// Encabezado del nombre de la compania
        /// </summary>
        Label NombreCompania { get; set; }

        /// <summary>
        /// Encabezado del estatus de la compania
        /// </summary>
        Label Estatus { get; set; }

        /// <summary>
        /// Encabezado acronimo de la compania
        /// </summary>
        Label Acronimo { get; set; }

        /// <summary>
        /// Encabezado de los dias para el plazo de pago de la compania
        /// </summary>
        Label PlazoDePagos { get; set; }

        /// <summary>
        /// Encabezado del rif de la compania
        /// </summary>
 
        Label RIF { get; set; }

        /// <summary>
        /// Encabezado del presupuesto anual de la compania
        /// </summary>
        Label Presupuesto { get; set; }

        /// <summary>
        /// Encabezado de la direccion de la compania
        /// </summary>
        Label Direccion { get; set; }

        /// <summary>
        /// Encabezado del correo electronico de la compania
        /// </summary>
        Label Correo { get; set; }

        /// <summary>
        /// Encabezado del telefono de la compania
        /// </summary>
        Label Telefono { get; set; }

        /// <summary>
        /// Encabezado de la fecha de ingreso de la compania
        /// </summary>
        Label Fecha { get; set; }

        /// <summary>
        /// Encabezado acronimo del mensaje de error al momento de ocurrir una excepcion
        /// </summary>
        string msjError { get; set; }
    }
}
