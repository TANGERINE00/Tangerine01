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
    public class ComandoEliminarClientePotencial : Comando<bool>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="parametro">Cliente Potencial a activar</param>
        public ComandoEliminarClientePotencial(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        public override bool Ejecutar()
        {
            try
            {
                IDAOClientePotencial daoClientePotencial = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
                return daoClientePotencial.Eliminar(this.LaEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
