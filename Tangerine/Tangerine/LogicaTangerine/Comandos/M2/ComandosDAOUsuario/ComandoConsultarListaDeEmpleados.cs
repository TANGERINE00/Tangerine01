using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M2;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M2
{
    public class ComandoConsultarListaDeEmpleados : Comando<List<DominioTangerine.Entidad>>
    {
        public List<DominioTangerine.Entidad> _listaEmpleados;

        public override List<DominioTangerine.Entidad> Ejecutar()
        {
            IDAOUsuarios ConsultarLista = FabricaDAOSqlServer.crearDaoUsuario();
            _listaEmpleados = ConsultarLista.ConsultarListaDeEmpleados();
            return _listaEmpleados;
        }
    }
}
