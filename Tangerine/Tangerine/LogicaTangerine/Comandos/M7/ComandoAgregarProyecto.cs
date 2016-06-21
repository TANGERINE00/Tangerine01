using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoAgregarProyecto : Comando<bool>
    {
        public ComandoAgregarProyecto(Entidad proyecto)
        {
            _laEntidad = proyecto;
        }

        public override bool Ejecutar()
        {
            try
            {
                IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
                return daoProyecto.Agregar(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
