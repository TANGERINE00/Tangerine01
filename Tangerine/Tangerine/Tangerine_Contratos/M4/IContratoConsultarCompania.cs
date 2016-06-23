using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;


namespace Tangerine_Contratos.M4
{
    public interface IContratoConsultarCompania
    {
        /// <summary>
        /// Encabezado de la tabla con todas las companias de la compania
        /// </summary>
        Literal Tabla { get; set; }

        /// <summary>
        /// Encabezado acronimo del mensaje de error al momento de ocurrir una excepcion
        /// </summary>
        string msjError { get; set; }
    }
}
