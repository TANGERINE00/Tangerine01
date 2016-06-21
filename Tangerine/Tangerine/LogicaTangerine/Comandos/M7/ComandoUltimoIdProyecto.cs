using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoUltimoIdProyecto : Comando<int>
    {

        /// <summary>
        /// Método override para ejecutar el comando
        /// y obtener el ID del último proyecto de la BD.
        /// </summary>
        /// <returns></returns>
        public override int Ejecutar()
        {
            try
            {
                IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
                return daoProyecto.ContactMaxIdProyecto();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
