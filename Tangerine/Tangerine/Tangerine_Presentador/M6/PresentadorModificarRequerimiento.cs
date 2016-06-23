using DatosTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M6;
using LogicaTangerine;
using DominioTangerine;
using DominioTangerine.Entidades.M6;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Tangerine_Presentador.M6
{

    // Este método agrega tanto Propuestas como sus requerimientos asociados.
    public class PresentadorModificarRequerimiento
    {
        IContratoModificarRequerimiento vista;



        public PresentadorModificarRequerimiento(IContratoModificarRequerimiento vista)
        {
            this.vista = vista;
        }
    }
}