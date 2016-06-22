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
using DatosTangerine.InterfazDAO.M4;
using ExcepcionesTangerine.M4;

namespace LogicaTangerine.Comandos.M4
{
    class ComandoDeshabilitarCompania : Comando <bool>
    {

        public ComandoDeshabilitarCompania(Entidad Company)
        {
             _laEntidad = Company;
        }

       /// <summary>
       /// Comando que permite desabilitar una compania
       /// </summary>
       /// <returns>boolean true or false </returns>
        public override bool Ejecutar()
        {
            try
            {
                IDaoCompania C = FabricaDAOSqlServer.crearDaoCompania();
                return C.DisableCompany(_laEntidad);
            }
            catch (NotImplementedException e )
            {
                return false;
                throw new ExceptionM4Tangerine("DS-404", "Metodo no implementado", e);
            }
        }
    }
}
