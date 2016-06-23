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
    public class ComandoObtenerUsuario : Comando<DominioTangerine.Entidad>
    {
        int _theEmpleado;

        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="theEmpleado"></param>
        public ComandoObtenerUsuario( int numEmpleado )
        {
            _theEmpleado = numEmpleado;
        }

        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario y usar el método ObtenerUsuarioDeEmpleado
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override DominioTangerine.Entidad Ejecutar()
        {
            try
            {
                DominioTangerine.Entidad usuario;
                IDAOUsuarios ObtenerUsuario = FabricaDAOSqlServer.crearDaoUsuario();
                usuario = ObtenerUsuario.ObtenerUsuarioDeEmpleado( _theEmpleado );
                return usuario;
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                throw new ExceptionM2Tangerine( "DS-202" , "Metodo no implementado" , ex );
            }
        }
    }
}
