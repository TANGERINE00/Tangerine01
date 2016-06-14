using DatosTangerine.DAO;
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

            DAOGeneral C = FabricaDAOSqlServer.crearDaoCompania();
            return _laEntidad;//C.ConsultarXId(_laEntidad);
        }
    }
}
