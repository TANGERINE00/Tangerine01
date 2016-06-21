using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoCalcularPagoMensual : Comando<Double>
    {
        private Entidad _proyecto;

        /// <summary>
        /// Constructor de la clase ComandoCalcularPagoMensual
        /// </summary>
        /// <param name="proyecto"> entidad de tipo proyecto </param>
        public ComandoCalcularPagoMensual(Entidad proyecto)
        {
             this._proyecto = proyecto;
        }

        /// <summary>
        /// Método Override para ejecutar el comando
        /// </summary>
        /// <returns></returns>
        public override Double Ejecutar()
        {
            IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
            Double resultado = daoProyecto.CalcularPagoMensual(_proyecto);
            return resultado;

        }

    }
}
