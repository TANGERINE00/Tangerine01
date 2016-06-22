using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M2;

namespace LogicaTangerine.Comandos.M2.ComandosDAOUsuario
{
    public class ComandoConsultarEmpleadoPorUsuario : Comando<DominioTangerine.Entidad>
    {
        public string _nombreUsuario;

        /// <summary>
        /// Constructor que recibe un parametro del tipo string
        /// </summary>
        /// <param name="nombreUsuario"></param>
        public ComandoConsultarEmpleadoPorUsuario( string nombreUsuario )
        {
            _nombreUsuario = nombreUsuario;
        }

        public override DominioTangerine.Entidad Ejecutar()
        {
            DominioTangerine.Entidad usuario;
            IDAOUsuarios ObtenerEmpleadoPorUsuario = FabricaDAOSqlServer.crearDaoUsuario();
            usuario = ObtenerEmpleadoPorUsuario.ConsultarEmpleadoPorUsuario( _nombreUsuario );
            return usuario;
        }
    }
}
