using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M2;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M2
{
    public interface IDaoUsuarios : IDao<Entidad, bool, Entidad>
    {
        /*  /// <summary>
        /// Método para agregar un usuario
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Retorna el objeto en la base de datos</returns>
        bool Agregar ( Entidad theUsuario );

        /// <summary>
        /// Método para modificar un usuario
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Retorna el objeto en la base de datos</returns>
        bool Modificar ( Entidad theUsuario );

        /// <summary>
        /// Método para consultar un usuario por id
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Retorna la consulta</returns>
        Entidad ConsultarXId( Entidad theUsuario );

        /// <summary>
        /// Método para consultar todos los usuarios
        /// </summary>
        /// <returns>Retorna todos los usuarios</returns>
        List<Entidad> ConsultarTodos (); */

        /// <summary>
        /// Encabezado de verificar si el usuario por su ficha
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Devuelve true si existe, si no, false</returns>
        bool VerificarUsuarioPorFichaEmpleado ( int fichaEmpleado );

        /// <summary>
        /// Método usado para devolver todos los empleados sin usuario
        /// </summary>
        /// <returns>Retorna la lista de empleados</returns>
        List<Entidad> ConsultarListaDeEmpleados();

        /// <summary>
        /// Método usado para verificar si el usuario existe en el sistema
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns>Retorna una valor booleano indicando la disponibilidad del usuario</returns>
        bool VerificarExistenciaUsuario ( string nombreUsuario );

    }
}
