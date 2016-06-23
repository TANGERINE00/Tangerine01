using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M2
{
    public interface IContratoCambiarRol
    {
        /// <summary>
        /// Encabezado de la tabla consulta
        /// </summary>
        string empleado
        {
            get;
            set;
        }

        /// <summary>
        /// Encabezado de mensaje de error
        /// </summary>
        string msjError
        {
            get;
            set;
        }
    }
}
