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
    public class PresentadorAgregarClientePotencial
    {
        IContratoAgregarClientePotencial vista;

        /// <summary>
        /// Constructor d la clase presentador 
        /// </summary>
        /// <param name="vista"></param>
        /// <returns></returns>
        public PresentadorAgregarClientePotencial(IContratoAgregarClientePotencial vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método que instancia y ejecuta al comando para agregar un cliente potencial
        /// </summary>
        /// <returns></returns>
        public void Agregar()
        {

            Entidad _entidad = DominioTangerine.Fabrica.FabricaEntidades.CrearClientePotencial(vista.NombreEtiqueta,
                                                                                              vista.RifEtiqueta, vista.CorreoElectronico,
                                                                                              vista.PresupuestoInversion,1);
            Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoAgregarClientePotencial(_entidad);

            vista.AccionSobreBd = comando.Ejecutar() ? true : false;
        }

    }
}
