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
using DatosTangerine.InterfazDAO.M4;

namespace LogicaTangerine.Comandos.M4
{
    class ComanodHabilitarCompania : Comando <bool>
    {
        public ComanodHabilitarCompania(Entidad Company)
        {
             _laEntidad = Company;
        }

       /// <summary>
       /// Comando que permite desabilitar una compania
       /// </summary>
       /// <returns>boolean true or false </returns>
        public override bool Ejecutar()
        {

            IDaoCompania C = FabricaDAOSqlServer.crearDaoCompania();
            return  C.EnableCompany(_laEntidad);
        }
    }
}
