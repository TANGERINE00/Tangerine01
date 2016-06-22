using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Tangerine_Contratos.M8
{
    public interface IContratoFactura
    {
        string textNumeroFactura { get; set; }
        string textFecha { get; set; }
        string textDescripcion { get; set; }
        string textCliente { get; set; }
        string textProyecto { get; set; }
        string textMonto { get; set; }
        string textTipoMoneda { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
    }
}