using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoGenerarCodigoProyecto : Comando<String>
    {
        private Entidad _propuesta;
        
        /// <summary>
        /// Constructor de la clase ComandoGenerarCodigoProyecto.
        /// </summary>
        /// <param name="propuesta">Propuesta a la cual se le generará 
        /// un código de proyecto.</param>
        public ComandoGenerarCodigoProyecto(Entidad propuesta)
        {
             this._propuesta = propuesta;
        }

        /// <summary>
        /// Método override para ejecutar el comando
        /// y generar un código de proyecto dada una propuesta.
        /// </summary>
        /// <returns></returns>
        public override String Ejecutar()
        {
            IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
            String resultado = daoProyecto.GenerarCodigoProyecto(_propuesta);
            return resultado;

        }

    }
}


