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

namespace LogicaTangerine.Comandos.M2.ComandosDAORol
{
    public class ComandoModificarRolUsuario : Comando<Boolean>
    {
        public DominioTangerine.Entidad _theUsuario;

        /// <summary>
        /// Constructor que recibe un parametro del tipo entidad
        /// </summary>
        /// <param name="theUsuario"></param>
        public ComandoModificarRolUsuario( DominioTangerine.Entidad theUsuario )
        {
            _theUsuario = theUsuario;
        }

        /// <summary>
        /// Método para crear la instancia de la clase DaoRol y usar el método ModificarRolUsuario
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override bool Ejecutar()
        {
            bool resultado = false;

            try
            {
                IDAORol RolUsuario = FabricaDAOSqlServer.crearDaoRol();
                resultado = RolUsuario.ModificarRolUsuario( _theUsuario );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                throw new ExceptionModificarRol("Error al ejecutar ComandoModificarRolUsuario", ex);
            }

            return resultado;   
        }
    }
}
