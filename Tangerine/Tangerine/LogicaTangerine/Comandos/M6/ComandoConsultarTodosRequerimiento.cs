using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoConsultarTodosRequerimiento : Comando<List<Entidad>>
    {
        public ComandoConsultarTodosRequerimiento()
        {

        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDAORequerimiento daoRequerimiento = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
                return daoRequerimiento.ConsultarTodos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
