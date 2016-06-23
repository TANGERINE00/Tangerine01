using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M1
{
    public interface IcontratoDashboard
    {
        /// <summary>
        /// Encabezado del Literal donde se carga la tabla a mostrar
        /// </summary>
        Literal VistaForm { get; set; } 
    }
}
