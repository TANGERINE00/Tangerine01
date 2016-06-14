using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoConsultarTodosGerentes : Comando<List<Entidad>>
    {
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoProyectoEmpleado daoProyectoEmpleado = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyectoEmpleado();
                List<Entidad> empleados = daoProyectoEmpleado.ConsultarTodos();
                return empleados;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
   }
}
