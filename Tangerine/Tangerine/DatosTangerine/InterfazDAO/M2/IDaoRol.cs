using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M2;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M2
{
    public interface IDAORol : IDao
    {
        /// <summary>
        /// Metodo para modificar el rol del usuario
        /// </summary>
        /// <param name="usuario">Atributo de tipo Entidad, que posee los datos de un usuario</param>
        /// <returns>Retorna true cuando el rol del usuario se modifico exitosamente</returns>
        bool ModificarRolUsuario( Entidad usuario );

        /// <summary>
        /// Metodo que retorna el rol de un usuario
        /// </summary>
        /// <param name="codigoRol">El codigo de un rol en especifico</param>
        /// <returns>El rol del usuario</returns>
        Entidad ObtenerRolUsuario( int codigoRol );

        /// <summary>
        /// Metodo que obtiene la opciones de un menu
        /// </summary>
        /// <param name="nombreMenu">El menu que sera proporpecionado en el sistema</param>
        /// <param name="codigoRol">El codigo de un rol en especifico</param>
        /// <returns>Una lista con las opciones</returns>
        Entidad ObtenerOpciones( string nombreMenu , int codigoRol );

        /// <summary>
        /// Metodo que devuelve el rol del usuario
        /// </summary>
        /// <param name="nombreRol">El nombre de un rol, por ejemplo, gerente</param>
        /// <returns>Devuelve el rol del usuario por nombre</returns>
        Entidad ObtenerRolUsuarioPorNombre( string nombreRol );

    }
}
