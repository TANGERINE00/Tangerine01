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
        /// <summary>
        /// Constructor
        /// </summary>
        public ComandoConsultarTodosRequerimiento()
        {

        }

        /// <summary>
        /// Método para utilizar el metodo AgregarPropuesta en capa de datos.
        /// </summary>
        /// <returns>Retorna lista de todos los requerimientos registrados</returns>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDAORequerimiento daoRequerimiento = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
                return daoRequerimiento.ConsultarTodos();
            }
            catch ( Exception e )
            {
                throw e;
            }
        }
    }
}
