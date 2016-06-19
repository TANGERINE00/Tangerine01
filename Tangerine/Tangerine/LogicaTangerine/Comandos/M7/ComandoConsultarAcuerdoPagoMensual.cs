using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoConsultarAcuerdoPagoMensual : Comando<List<Entidad>>
    {
        
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
                List<Entidad> proyectos = daoProyecto.ContactProyectoxAcuerdoPago();
                return proyectos;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
