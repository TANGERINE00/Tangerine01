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
    public class ComandoConsultarListaDeEmpleados : Comando<List<Empleado>>
    {
        public List<Empleado> _listaEmpleados;

        public override List<Empleado> Ejecutar()
        {
            IDAOUsuarios ConsultarLista = FabricaDAOSqlServer.crearDaoUsuario();
            _listaEmpleados = ConsultarLista.ConsultarListaDeEmpleados();
            return _listaEmpleados;
        }
    }
}
