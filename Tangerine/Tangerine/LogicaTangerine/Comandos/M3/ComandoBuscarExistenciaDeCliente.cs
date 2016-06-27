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
    public class ComandoBuscarExistenciaDeCliente:Comando<Entidad>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="parametro">Cliente Potencial a verificar</param>
        public ComandoBuscarExistenciaDeCliente(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        /// <summary>
        /// Método encargado de ejecutar el comando para verifiacr a un cliente potencial
        /// </summary>
        public override Entidad Ejecutar()
        {
            Entidad valor;
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
