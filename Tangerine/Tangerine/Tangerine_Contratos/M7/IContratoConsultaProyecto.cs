using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M7
{
    public interface IContratoConsultaProyecto
    {
        /// <summary>
        /// Encabezado del Literal donde se carga la tabla a mostrar
        /// </summary>
        Literal Tabla { get; set; }
 
    }
}
