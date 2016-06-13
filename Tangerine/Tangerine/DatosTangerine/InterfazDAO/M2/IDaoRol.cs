﻿using System;
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
      /*  /// <summary>
        /// Método para agregar un rol
        /// </summary>
        /// <param name="theRol"></param>
        /// <returns>Retorna el objeto en la base de datos</returns>
        bool Agregar( Entidad theRol );

        /// <summary>
        /// Método para modificar un rol
        /// </summary>
        /// <param name="theRol"></param>
        /// <returns>Retorna el objeto en la base de datos</returns>
        bool Modificar( Entidad theRol );

        /// <summary>
        /// Método para consultar un rol por id
        /// </summary>
        /// <param name="theRol"></param>
        /// <returns>Retorna la consulta</returns>
        Entidad ConsultarXId( Entidad theRol );

        /// <summary>
        /// Método para consultar todos los roles
        /// </summary>
        /// <returns>Retorna todos los roles</returns>
        List<Entidad> ConsultarTodos(); */

        /// <summary>
        /// Método para modificar el rol del usuario
        /// </summary>
        /// <param name="rol"></param>
        /// <returns>Retorna true cuando el rol del usuario se modifico exitosamente</returns>
        bool ModificarRolUsuario( UsuarioM2 usuario );
    }
}
