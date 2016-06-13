using DatosTangerine.DAO.M4;
using DatosTangerine.Fabrica;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M4
{
    class ComandoConsultarCompania : Comando <Entidad>
    {
        public ComandoConsultarCompania(Entidad Company)
        {
             _laEntidad = Company;
        }

       /// <summary>
       /// Comando que permite Consultar la infomacion de una compania
       /// </summary>
       /// <returns>una entidad compania </returns>
        public override Entidad Ejecutar()
        {

            DaoCompania C = FabricaDAOSqlServer.crearDaoCompania();
            return C.ConsultarXId(_laEntidad);
        }
    }
}
