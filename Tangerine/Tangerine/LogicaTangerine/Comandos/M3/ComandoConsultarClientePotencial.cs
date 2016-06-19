using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M3;
using DatosTangerine.InterfazDAO.M3;

namespace LogicaTangerine.Comandos.M3
{
    public class ComandoConsultarClientePotencial : Comando<Entidad>
    {
        /// <summary>
        /// Constructor del comando
        /// </summary>
        /// <param name="parametro">Factura a consultar</param>
        public ComandoConsultarClientePotencial(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        public override Entidad Ejecutar()
        {
            try
            {
                IDAOClientePotencial daoClientePotencial = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
                Entidad clientePotencial = daoClientePotencial.ConsultarXId(this.LaEntidad);
                return clientePotencial;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
