using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M7
{
    public interface IContratoInformacionProyecto
    {
        /// <summary>
        /// Encabezado del Label de Nombre Propuesta
        /// </summary>
        Label NombrePropuesta { get; set; }

        /// <summary>
        /// Encabezado del Label de Nombre del Proyecto
        /// </summary>
        Label NombreProyecto { get; set; }

        /// <summary>
        /// Encabezado del Label de Codigo del Proyecto
        /// </summary>
        Label CodigoProyecto { get; set; }

        /// <summary>
        /// Encabezado del Label de fecha de Inicio del proyecto
        /// </summary>
        Label FechaInicio { get; set; }

        /// <summary>
        /// Encabezado del Label de fecha Fin del proyecto
        /// </summary>
        Label FechaFin { get; set; }

        /// <summary>
        /// Encabezado del Label de costo del Proyecto
        /// </summary>
        Label Costo { get; set; }

        /// <summary>
        /// Encabezado del Label de porcentaje del Proyecto
        /// </summary>
        Label Porcentaje { get; set; }

        /// <summary>
        /// Encabezado del Label de estatus del Proyecto
        /// </summary>
        Label Estatus { get; set; }

        /// <summary>
        /// Encabezado del comboBox de Personal del proyecto
        /// </summary>
        DropDownList inputPersonal { get; set; }

        /// <summary>
        /// Encabezado del comboBox de encargado del proyecto
        /// </summary>
        DropDownList inputEncargado { get; set; }

        /// <summary>
        /// Encabezado del comboBox de Gerente del proyecto
        /// </summary>
        DropDownList InputGerente { get; set; }
    }
}
