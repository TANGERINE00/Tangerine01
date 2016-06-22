using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M2
{
     public interface IContratoRegistroUsuario
    {

        /// <summary>
        /// Encabezado de la tabla de usuarios
        /// </summary>
        string tablaEmpleado
        {
            get;
            set;
        }

        /// <summary>
        /// Encabezado del campo Numero Empleado
        /// </summary>
        string numeroEmpleado
        {
            get;
            set;
        }
    }
}
