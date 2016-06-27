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
    public class ComandoPromoverClientePotencial : Comando<bool>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="parametro">Cliente Potencial a promover</param>
        public ComandoPromoverClientePotencial(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        /// <summary>
        /// Método que permite la ejecucion del comando para promover a un cliente potencial
        /// </summary>
        public override bool Ejecutar()
        {
            try
            {
                IDAOClientePotencial daoClientePotencial = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
                return daoClientePotencial.Promover(this.LaEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
