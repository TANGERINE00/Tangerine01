using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M2;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M2
{
    public class ComandoValidarUsuario : Comando<Boolean>
    {
        public string _usuario;

        /// <summary>
        /// Constructor que recibe el parametro usuario
        /// </summary>
        /// <param name="_usuario"></param>
        public ComandoValidarUsuario( string usuario )
        {
            _usuario = usuario;
        }
        
        /// <summary>
        ///  Método usado para verificar si el nombre de usuario existe
        /// </summary>
        /// <returns>Retorna un valor booleano indicando si el nombre de usuario existe o no</returns>
        public override bool Ejecutar()
        {
            bool resultado = false;
            try
            {
                IDAOUsuarios ExistUsuario = FabricaDAOSqlServer.crearDaoUsuario();
                resultado = ExistUsuario.VerificarExistenciaUsuario( _usuario );
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro("Error al ejecutar " +
                                                                     "ExisteUsuario()", ex);
            }

            return resultado;
        }
    }
}
