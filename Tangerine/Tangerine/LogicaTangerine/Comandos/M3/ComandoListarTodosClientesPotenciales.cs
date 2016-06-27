using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine;
using DatosTangerine.InterfazDAO.M3;

namespace LogicaTangerine.Comandos.M3
{
    public class ComandoListarTodosClientesPotenciales : Comando<List<Entidad>>
    {
        /// <summary>
        /// Método que ejecuta el comando para consultar todos los clientes potenciales
        /// </summary>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDAOClientePotencial daoClientePotencial = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
                return daoClientePotencial.ConsultarTodos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
