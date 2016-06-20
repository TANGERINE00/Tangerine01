using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M9
{
    public interface IContratoCargarPago
    {
        string cliente { get; set; }
        string proyecto { get; set; }
        string moneda { get; set; }
        string monto { get; set; }
        string numero { get; set; }
        string codAprob { get; set; }
        string formPago { get; set; }
        void btnagregar_Click(object sender, EventArgs e);

    }
}
