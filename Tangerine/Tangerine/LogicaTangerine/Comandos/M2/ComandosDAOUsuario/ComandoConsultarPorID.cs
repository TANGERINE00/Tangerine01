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
    public class ComandoConsultarPorID : Comando<DominioTangerine.Entidad>
    {
        public DominioTangerine.Entidad _theUsuario;

        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="usuario"></param>
        public ComandoConsultarPorID( DominioTangerine.Entidad usuario )
        {
            _theUsuario = usuario;
        }

        public override DominioTangerine.Entidad Ejecutar()
        {
            DominioTangerine.Entidad usuario;
            IDAOUsuarios ObtenerUsuario = FabricaDAOSqlServer.crearDaoUsuario();
            usuario = ObtenerUsuario.ConsultarXId( _theUsuario );
            return usuario;
        }
    }
}
