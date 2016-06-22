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

namespace LogicaTangerine.Comandos.M2
{
    public class ComandoAgregarUsuario : Comando<Boolean>
    {
        public DominioTangerine.Entidad _usuario;

        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="usuario"></param>
        public ComandoAgregarUsuario( DominioTangerine.Entidad usuario )
        {
            _usuario = usuario;
        }

        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario y usar el método Agregar
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override Boolean Ejecutar()
        {
            try
            {
                bool resultado;
                IDAOUsuarios UsuarioAdd = FabricaDAOSqlServer.crearDaoUsuario();
                resultado = UsuarioAdd.Agregar(_usuario);
                return resultado;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionRegistro("Error al ejecutar ComandoAgregarUsuario", ex);
            }
        }
    }
}
