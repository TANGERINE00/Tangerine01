using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M2;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M2
{
    public interface IDAORol : IDao<Entidad, bool, Entidad>
    {
        /// <summary>
        /// Método para modificar el rol del usuario
        /// </summary>
        /// <param name="rol"></param>
        /// <returns>Retorna true cuando el rol del usuario se modifico exitosamente</returns>
        bool ModificarRolUsuario( UsuarioM2 usuario );
    }
}
