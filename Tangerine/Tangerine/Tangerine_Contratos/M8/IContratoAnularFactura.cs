using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M8
{
    public interface IContratoAnularFactura
    {
        string numero { get; set; }
        string fecha { get; set; }
        string compania { get; set; }
        string proyecto { get; set; }
        string descripcion { get; set; }
        string monto { get; set; }
        string moneda { get; set; }
    }
}
