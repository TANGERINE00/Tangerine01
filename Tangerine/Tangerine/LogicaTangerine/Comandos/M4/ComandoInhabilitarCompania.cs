using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.Fabrica;
using DatosTangerine.DAO;
using DatosTangerine.DAO.M4;
using DominioTangerine.Entidades.M4;
using DominioTangerine.Fabrica;
using DominioTangerine;


namespace LogicaTangerine.Comandos.M4
{
    class ComandoInhabilitarCompania : Comando <bool>
    {

        public ComandoInhabilitarCompania(Entidad Company)
        {
             _laEntidad = Company;
        }

       /// <summary>
       /// Comando que permite desabilitar una compania
       /// </summary>
       /// <returns>boolean true or false </returns>
        public override bool Ejecutar()
        {

            DAOGeneral C = FabricaDAOSqlServer.crearDaoCompania();
            return true;//C.DisableCompany(_laEntidad);
        }
    }
}
