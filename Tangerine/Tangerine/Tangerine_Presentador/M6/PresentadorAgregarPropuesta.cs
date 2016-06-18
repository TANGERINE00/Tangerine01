using DatosTangerine;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M6;
using LogicaTangerine;
using DominioTangerine.Entidades.M6;

namespace Tangerine_Presentador.M6
{

    class PresentadorAgregarPropuesta
    {
        IContratoAgregarPropuesta vista;
        Boolean Confirmacion;

        public PresentadorAgregarPropuesta(IContratoAgregarPropuesta vista)
        {
            this.vista = vista;
        }
        public void agregarPropuesta()
        {
            DominioTangerine.Entidades.M6.Propuesta p = new DominioTangerine.Entidades.M6.Propuesta();
            LogicaTangerine.Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(p);
            Confirmacion = comando.Ejecutar();
        }
    }
}