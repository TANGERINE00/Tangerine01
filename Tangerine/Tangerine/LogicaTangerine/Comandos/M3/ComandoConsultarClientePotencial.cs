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
    public class ComandoConsultarClientePotencial : Comando<Entidad>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="parametro">Cliente Potencial a consultar</param>
        public ComandoConsultarClientePotencial(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        /// <summary>
        /// Método encargado de ejecutar el comando para consultar a un cliente potencial
        /// </summary>
        public override Entidad Ejecutar()
        {
            try
            {
                IDAOClientePotencial daoClientePotencial = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
                return daoClientePotencial.ConsultarXId(this.LaEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
