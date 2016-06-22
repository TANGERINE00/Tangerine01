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
        /// <summary>
        /// Constructor
        /// </summary>
        public ComandoConsultarTodosPropuesta()
        {

        }

        /// <summary>
        /// Método para utilizar el metodo ConsultarTodosPropuesta en capa de datos.
        /// </summary>
        /// <returns>Retorna lista de propuestas</returns>
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
