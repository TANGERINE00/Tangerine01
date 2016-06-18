using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M3;
using DatosTangerine.InterfazDAO.M3;

namespace LogicaTangerine.Comandos.M3
{
    public class ComandoListarTodosLeads : Comando<List<Entidad>>
    {
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDAOLead daoLead = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDaoLead();
                List<Entidad> leads = daoLead.ConsultarTodos();
                return leads;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
