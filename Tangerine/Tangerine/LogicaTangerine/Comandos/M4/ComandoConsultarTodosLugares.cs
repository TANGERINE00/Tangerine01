using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.Fabrica;
using DatosTangerine.DAO;
using DatosTangerine.DAO.M4;
using DatosTangerine.InterfazDAO.M4;
using DominioTangerine.Entidades.M4;
using DominioTangerine.Fabrica;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M4 
{
    class ComandoConsultarTodosLugares : Comando<List<Entidad>>
    {

        public override List<Entidad> Ejecutar()
        {
           IDaoLugarDireccion DaoLugar = FabricaDAOSqlServer.crearDaoLugarDireccion();
            return DaoLugar.ConsultarTodos();
        }
    }
}
