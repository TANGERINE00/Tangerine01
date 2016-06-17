using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M6;
using LogicaTangerine;
using DominioTangerine;
using System.Web;

namespace Tangerine_Presentador.M6
{
    public class PresentadorConsultarPropuesta
    {
        IContratoConsultarPropuesta vistaConsultar;

        public PresentadorConsultarPropuesta(IContratoConsultarPropuesta vista)
        {
            this.vistaConsultar = vista;
        }


        public void consultarPropuestas()
        {
            /*
             * Aqui va el uso del recurso para imprimir la tabla 
             * (guiarse del que hicimos en ../GUI/M4/ConsultarCompania)
             * Ver recurso ya hecho por el M6 para la entrega anterior
             */
        }


        public void imprimirBotones()
        {
            /*
             * Same here... En M4 se pico la impresion de la tabla en DATOS y BOTONEs (acciones).
             */
        }
    }
}
