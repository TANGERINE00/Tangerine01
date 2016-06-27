using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M2;
using DominioTangerine.Entidades.M2;
using LogicaTangerine.Fabrica;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M2;

namespace LogicaTangerine.Comandos.M2.ComandosDAORol
{
    public class ComandoModificarRol : Comando<Boolean>
    {
        String _elUsuario, _elRol;

        /// <summary>
        /// Constructor que recibe dos parametros de tipo string
        /// </summary>
        /// <param name="elUsuario">El usuario</param>
        /// <param name="elRol">El rol del usuario</param>
        public ComandoModificarRol( string elUsuario , string elRol )
        {
            _elUsuario = elUsuario;
            _elRol = elRol;
        }

        /// <summary>
        /// Método para crear la instancia de la clase DaoRol y usar el método ComandoModificarRolUsuario
        /// </summary>
        /// <returns>Retorna una instancia del tipo ComandoModificarRolUsuario</returns>
        public override bool Ejecutar()
        {
            bool resultado = false;

            try
            {
                RolM2 rol = new RolM2( _elRol );
                UsuarioM2 usuario = new UsuarioM2( _elUsuario , rol );

                LogicaTangerine.Comando<Boolean> commandModificarRolUsuario
                    = FabricaComandos.obtenerComandoModificarRolUsuario( usuario );
                resultado = commandModificarRolUsuario.Ejecutar();
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                throw new ExceptionM2Tangerine( "DS-202" , "Metodo no implementado" , ex );
            }

            return resultado;
        }


    }
}
