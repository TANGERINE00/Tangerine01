using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M3;
using LogicaTangerine;
using DominioTangerine;
using System.Web;

namespace Tangerine_Presentador.M3
{
    public class PresentadorAgregarSeguimiento
    {
        IContratoAgregarSeguimiento vista;

        public PresentadorAgregarSeguimiento(IContratoAgregarSeguimiento vista)
        {
            this.vista = vista;
        }

        public void CargarTipoDeSeguimiento()
        {
            vista.Tipo.Items.Insert(0, "Seleccione una opción");
            vista.Tipo.Items.Insert(1, "Llamada");
            vista.Tipo.Items.Insert(2, "Visita");
            vista.Tipo.DataBind();
        }
    }
}
