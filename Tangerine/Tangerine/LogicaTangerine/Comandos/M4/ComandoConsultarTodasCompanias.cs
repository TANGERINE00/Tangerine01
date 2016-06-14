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

namespace LogicaTangerine.Comandos.M4
{
    class ComandoConsultarTodasCompanias : Comando <List<Entidad>>

    { 
    
    
       /// <summary>
       /// Comando que permite Consultar todas la s companias
       /// </summary>
       /// <returns>lista de entidades compania</returns>
        public override List<Entidad> Ejecutar()
        {

          IDaoCompania C = FabricaDAOSqlServer.crearDaoCompania();
            return C.ConsultarTodos();
        }    
    }
}
