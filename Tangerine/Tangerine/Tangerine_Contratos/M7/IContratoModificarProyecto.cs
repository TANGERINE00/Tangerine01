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
        /// <summary>
        /// Mensajes de alerta
        /// </summary>
        string alerta { set; }
        
        /// <summary>
        /// Encabezado del TextBox de nombre de la propuesta
        /// </summary>
        TextBox inputPropuesta { get; set; }

        /// <summary>
        /// Encabezado del TextBox de nombre del proyecto
        /// </summary>
        TextBox textInputNombreProyecto { get; set; }

        /// <summary>
        /// Encabezado del TextBox de codigo del proyecto
        /// </summary>
        TextBox textInputCodigo { get; set; }

        /// <summary>
        /// Encabezado del TextBox de fecha de inicio del proyecto
        /// </summary>
        TextBox textInputFechaInicio { get; set; }

        /// <summary>
        /// Encabezado del Calendar de fecha de fin estimada
        /// </summary>
        Calendar textInputFechaEstimada { get; set; }

        /// <summary>
        /// Encabezado del TextBox de costo del proyecto
        /// </summary>
        TextBox textInputCosto { get; set; }

        /// <summary>
        /// Encabezado del TextBox de porcentaje de realizacion del proyecto
        /// </summary>
        TextBox textInputPorcentaje { get; set; }

        /// <summary>
        /// Encabezado del DropDownList de gerente del proyecto
        /// </summary>
        DropDownList inputGerente { get; set; }

        /// <summary>
        /// Encabezado del DropDownList del estatus del proyecto
        /// </summary>
        DropDownList inputEstatus { get; set; }

        /// <summary>
        /// Encabezado del TextBox de comentario del proyecto
        /// </summary>
        TextBox text10 { get; set; }

        /// <summary>
        /// Encabezado del ListBox de encargado del proyecto
        /// </summary>
        ListBox imputEncargado { get; set; }

        /// <summary>
        /// Encabezado del ListBox de personal asignado del proyecto
        /// </summary>
        ListBox inputPersonal { get; set; }

        /// <summary>
        /// Encabezado del TextBox de id de la propuesta del proyecto
        /// </summary>
        TextBox idPropuesta { get; set; }

        /// <summary>
        /// Encabezado del TextBox de id del proyecto
        /// </summary>
        TextBox idProyecto { get; set; }

        /// <summary>
        /// Encabezado del ListBox de gerentes pasados del proyecto
        /// </summary>
        ListBox GerentesPasados { get; set; }

        /// <summary>
        /// Encabezado del ListBox del personal no asignado al proyecto
        /// </summary>
        ListBox inputPersonalNoActivo { get; set; }

        /// <summary>
        /// Encabezado del TextBox de acuerdo de pago del proyecto
        /// </summary>
        TextBox acuerdoPago { get; set; }

        /// <summary>
        /// Encabezado del TextBox de id de la compania duena del proyecto
        /// </summary>
        TextBox idCompania { get; set; }

        /// <summary>
        /// Encabezado del TextBox de descripcion del proyecto del proyecto
        /// </summary>
        TextBox descripcion { get; set; }

        /// <summary>
        /// Encabezado del TextBox de porcentaje de realizacion del proyecto del proyecto
        /// </summary>
        TextBox realizacion { get; set; }
    }
}
