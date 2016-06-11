using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M2;

namespace DatosTangerine.DAO.M2
{
    public class DaoUsuario : DAOGeneral, IDaoUsuarios
    {
        /// <summary>
        /// Verificar si el usuario por su ficha
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Si existe True, si no, False</returns>
        public bool VerificarUsuarioPorFichaEmpleado(int fichaEmpleado)
        {
            return true;
        }


        /// <summary>
        /// Verificación si un usuario existe
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns>Si existe True, si no, False</returns>
        public bool VerificarExistenciaDeUsuario(string nombreUsuario)
        {
            return true;
        }
    }
}
