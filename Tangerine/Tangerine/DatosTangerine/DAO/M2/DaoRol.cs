using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;
using System.Data;
using DominioTangerine.Entidades.M2;
using DatosTangerine.InterfazDAO.M2;

namespace DatosTangerine.DAO.M2
{
    public class DaoRol : DAOGeneral, IDaoRol
    {
        /// <summary>
        /// Método para agregar un rol
        /// </summary>
        /// <param name="theRol"></param>
        /// <returns>Retorna el objeto en la base de datos</returns>
        public bool Agregar(RolM2 theRol)
        {
            return true;
        }

        /// <summary>
        /// Método para modificar un rol
        /// </summary>
        /// <param name="theRol"></param>
        /// <returns>Retorna el objeto en la base de datos</returns>
        public bool Modificar(RolM2 theRol)
        {
            return true;
        }

        /// <summary>
        /// Método para consultar un rol por id
        /// </summary>
        /// <param name="theRol"></param>
        /// <returns>Retorna la consulta</returns>
        public RolM2 ConsultarXId(RolM2 theRol)
        {
            return theRol;
        }

        /// <summary>
        /// Método para consultar todos los roles
        /// </summary>
        /// <returns>Retorna todos los roles</returns>
        public List<RolM2> ConsultarTodos()
        {
            List<RolM2> listaRol = new List<RolM2>();
            return listaRol; 
        }

        /// <summary>
        /// Método para modificar el rol del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Retorna true cuando el rol del usuario se modifico exitosamente</returns>
        public bool ModificarRolUsuario(UsuarioM2 usuario)
        {
            List<Parametro> parametros = new List<Parametro>();
            BDConexion laConexion = new BDConexion();
            Parametro elParametro;

            try
            {
                elParametro = new Parametro(ResourceUser.ParametroUsuario, SqlDbType.VarChar, usuario.nombreUsuario,
                                             false);
                parametros.Add(elParametro);

                elParametro = new Parametro(ResourceUser.ParametroRolUsuario, SqlDbType.VarChar, usuario.rol.nombre,
                                             false);
                parametros.Add(elParametro);

                List<Resultado> results = laConexion.EjecutarStoredProcedure(ResourceUser.ModificarRolUsuario,
                                                                              parametros);
            }
            catch (NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Codigo,
                                                                    RecursoGeneralBD.Mensaje, ex);
            }

            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                return false;
            }

            return true;
        }
    }
}
