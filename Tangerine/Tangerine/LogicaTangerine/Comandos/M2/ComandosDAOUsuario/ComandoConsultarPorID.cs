using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M2;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M2;

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

        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario y usar el método ConsultarXId
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override DominioTangerine.Entidad Ejecutar()
        {
            try
            {
                DominioTangerine.Entidad usuario;
                IDAOUsuarios ObtenerUsuario = FabricaDAOSqlServer.crearDaoUsuario();
                usuario = ObtenerUsuario.ConsultarXId(_theUsuario);
                return usuario;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM2Tangerine("Error al ejecutar ComandoConsultarPorID", ex);
            }
        }
    }
}
