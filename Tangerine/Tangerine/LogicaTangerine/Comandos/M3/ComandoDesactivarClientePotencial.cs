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
    public class ComandoDesactivarClientePotencial : Comando<bool>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="parametro">Cliente Potencial a desactivar</param>
        public ComandoDesactivarClientePotencial(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        /// <summary>
        /// Método que ejecuta el comando para desactivar a un cliente potencial
        /// </summary>
        /// <param name="contacto"></param>
        public override bool Ejecutar()
        {
            try
            {
                IDAOClientePotencial daoClientePotencial = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
                return daoClientePotencial.Desactivar(this.LaEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
