using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoConsultarTodosPropuesta : Comando<List<Entidad>>
    {
        public ComandoConsultarTodosPropuesta()
        {

        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDAOPropuesta daoPropuesta = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
                return daoPropuesta.ConsultarTodos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
