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
    public class ComandoUltimoIdClientePotencial : Comando<int>
    {
        /// <summary>
        /// Método que permite ejecutar el comando para consultar el id del ultimo cliente insertado
        /// </summary>
        public override int Ejecutar()
        {
            try
            {
                IDAOClientePotencial daoClientePotencial = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
                return daoClientePotencial.ConsultarIdUltimoClientePotencial();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
