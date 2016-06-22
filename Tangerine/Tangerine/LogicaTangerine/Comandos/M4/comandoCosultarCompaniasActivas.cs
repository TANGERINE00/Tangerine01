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
using ExcepcionesTangerine.M4;

namespace LogicaTangerine.Comandos.M4
{
    class comandoCosultarCompaniasActivas : Comando<List<Entidad>>
    {
        

        

       /// <summary>
       /// Comando que permite desabilitar una compania
       /// </summary>
       /// <returns>boolean true or false </returns>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoCompania C = FabricaDAOSqlServer.crearDaoCompania();
                return C.ConsultarCompaniasActivas();
            }
            catch (NotImplementedException e)
            {
                return null;
                throw new ExceptionM4Tangerine("DS-404", "Metodo no implementado", e);
            }
        }
    }
}
