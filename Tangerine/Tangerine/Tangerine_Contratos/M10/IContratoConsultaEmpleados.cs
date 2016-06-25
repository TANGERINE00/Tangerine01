using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M10
{
    public interface IContratoConsultaEmpleados
    {
        /// <summary>
        /// Encabezado de la tabla de consultar empleados
        /// </summary>
         Literal Tabla { get; set;}

        /// <summary>
        /// Clase para las alertas
        /// </summary>
         string alertaVista
         {
             set;
         }

     }

    }

