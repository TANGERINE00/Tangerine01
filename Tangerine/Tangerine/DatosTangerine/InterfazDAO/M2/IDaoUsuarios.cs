using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M2;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M2
{
    public interface IDAOUsuarios : IDao<Entidad, bool, Entidad>
    {

        /// <summary>
        /// Encabezado de verificar si el usuario por su ficha
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Devuelve true si existe, si no, false</returns>
        bool VerificarUsuarioPorFichaEmpleado( int fichaEmpleado );

        /// <summary>
        /// Encabezado de metodo para devolver todos los empleados sin usuario
        /// </summary>
        /// <returns>Retorna la lista de empleados</returns>
        List<Entidad> ConsultarListaDeEmpleados();

        /// <summary>
        /// Encabezado de metodo usado para verificar si el usuario existe en el sistema
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns>Retorna una valor booleano indicando la disponibilidad del usuario</returns>
        bool VerificarExistenciaUsuario( string nombreUsuario );

        /// <summary>
        /// Encabezado de metodo que retorna el usuario y rol de un empleado
        /// </summary>
        /// <param name="theEmpleado"></param>
        /// <returns>Retorna el usuario de un empleado</returns>
        Entidad ObtenerUsuarioDeEmpleado( Entidad num_empleado );

        /// <summary>
        /// Encabezado del metodo para retornar los datos del usuario
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Retorna los datos del ususario</returns>
        Entidad ObtenerDatoUsuario( Entidad theUsuario );

        /// <summary>
        /// Modifica la contraseña de un usuario
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Retorna true si cambia la contraseña exitosamente</returns>
        bool ModificarContraseniaUsuario( Entidad theUsuario  );

        /// <summary>
        /// Encabezado del metodo para retornar el ultimo ID del usuario
        /// </summary>
        /// <returns>Retorna el ultimo ID de Usuario</returns>
        int ConsultLastUserID();

    }
}
