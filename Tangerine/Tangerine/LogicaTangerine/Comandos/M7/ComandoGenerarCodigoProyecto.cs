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
        

        public ComandoGenerarCodigoProyecto(Entidad propuesta)
        {
             this._propuesta = propuesta;
        }
        public override String Ejecutar()
        {
            IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
            String resultado = daoProyecto.GenerarCodigoProyecto(_propuesta);
            return resultado;

        }

    }
}


