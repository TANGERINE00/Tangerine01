using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M2;
using DatosTangerine.Fabrica;
using ExcepcionesTangerine;

namespace LogicaTangerine.Comandos.M2
{
    public class ComandoModificarRol : Comando<Boolean>
    {
        String _usuario, _rol;

        /// <summary>
        /// Constructor que recibe el parametro usuario y rol
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="rol"></param>
        public ComandoModificarRol( String usuario, String rol )
        {
            _usuario = usuario;
            _rol = rol;
        }

        public override bool Ejecutar()
        {
            bool resultado = false;

            try
            {
                RolM2 rol = new RolM2(_rol);
                UsuarioM2 usuario = new UsuarioM2(_usuario, rol);

                //Revisar instanciacion
                /*FabricaDAOSqlServer factoryDAO = new FabricaDAOSqlServer();
                resultado = factoryDAO.ModificarRolUsuario(usuario);*/
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
