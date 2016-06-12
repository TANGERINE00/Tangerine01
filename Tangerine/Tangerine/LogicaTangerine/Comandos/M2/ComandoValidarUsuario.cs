using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;
using DatosTangerine.Fabrica;

namespace LogicaTangerine.Comandos.M2
{
    public class ComandoValidarUsuario : Comando<Boolean>
    {
        String _usuario;

        /// <summary>
        /// Constructor que recibe el parametro usuario
        /// </summary>
        /// <param name="_usuario"></param>
        public ComandoValidarUsuario( String usuario )
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
                //Revisar instanciacion
                /*FabricaDAOSqlServer factoryDAO = new FabricaDAOSqlServer();
                resultado = factoryDAO.VerificarExistenciaUsuario(_usuario);*/
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
