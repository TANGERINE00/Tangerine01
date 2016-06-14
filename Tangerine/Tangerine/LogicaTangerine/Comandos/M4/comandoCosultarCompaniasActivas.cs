using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatosTangerine.Fabrica;
using DatosTangerine.DAO;
using DatosTangerine.DAO.M4;
using DominioTangerine.Entidades.M4;
using DominioTangerine.Fabrica;
using DominioTangerine;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M4
{
    class comandoCosultarCompaniasActivas : Comando<List<Entidad>>
    {
        List<Entidad> mock; 

        public comandoCosultarCompaniasActivas (Entidad Company)
        {
             _laEntidad = Company;
        }

       /// <summary>
       /// Comando que permite desabilitar una compania
       /// </summary>
       /// <returns>boolean true or false </returns>
        public override List<Entidad> Ejecutar()
        {

            DAOGeneral C = FabricaDAOSqlServer.crearDaoCompania();
            return mock; // C.EnableCompany(_laEntidad);
        }
    }
}
