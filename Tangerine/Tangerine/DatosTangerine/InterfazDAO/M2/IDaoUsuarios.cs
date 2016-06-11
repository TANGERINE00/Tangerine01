using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M2;

namespace DatosTangerine.InterfazDAO.M2
{
    public interface IDaoUsuarios // : IDao<Parametro, Resultado, Resultado>
    {
        /// <summary>
        /// Encabezado de verificar si el usuario por su ficha
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        bool VerificarUsuarioPorFichaEmpleado (int fichaEmpleado);

        /// <summary>
        /// Encabezado de verificación si un usuario existe
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns></returns>
        bool VerificarExistenciaDeUsuario(string nombreUsuario);

    }
}
