using DatosTangerine.DAO.M10;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M10
{
    public class ComandoObtenerPais : Comando<List<Entidad>>
    {
        private Entidad Lugar;
        
        /// <summary>
        /// Metodo para ejecutar el comando
        /// </summary>
        /// <returns></returns>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDAOEmpleado daoEmpleado = (DatosTangerine.DAO.M10.DAOEmpleado)
                                           DatosTangerine.Fabrica.FabricaDAOSqlServer.ObtenerIDaoPaises();
                return daoEmpleado.ObtenerPaises();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
