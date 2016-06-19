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

namespace LogicaTangerine.Comandos.M2.ComandosDAORol
{
    public class ComandoModificarRol : Comando<Boolean>
    {
        String _elUsuario, _elRol;

        /// <summary>
        /// Constructor que recibe dos parametros de tipo string
        /// </summary>
        /// <param name="elUsuario"></param>
        /// <param name="elRol"></param>
        public ComandoModificarRol( string elUsuario , string elRol )
        {
            _elUsuario = elUsuario;
            _elRol = elRol;
        }

        public override bool Ejecutar()
        {
            bool resultado = false;

            try
            {
                RolM2 rol = new RolM2( _elRol );
                UsuarioM2 usuario = new UsuarioM2( _elUsuario , rol );

                LogicaTangerine.Comando<Boolean> commandModificarRolUsuario = FabricaComandos.obtenerComandoModificarRolUsuario( usuario );
                resultado = commandModificarRolUsuario.Ejecutar();
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M2.ExcepcionModificarRol("Error al ejecutar " +
                                                                         "ModificarRol()", ex);
            }

            return resultado;
        }


    }
}
