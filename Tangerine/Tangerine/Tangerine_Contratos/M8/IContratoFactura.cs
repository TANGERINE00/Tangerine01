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
        string textNumeroFactura { get;  set; }
        string textFecha { set; }
        string textDescripcion { set; }
        string textCliente { set; }
        string textProyecto { set; }
        string textMonto { set; }
        string textRif { set; }
        string textDireccion { set; }
        string textTipoMoneda { set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
        string textIva { set; }
    }
}
