using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M2;
using DominioTangerine;
using DatosTangerine.M10;
using ExcepcionesTangerine;
using System.Data;
using DominioTangerine.Entidades.M2;

namespace DatosTangerine.DAO.M2
{
    public class DAOUsuario : DAOGeneral, IDAOUsuarios
    {
        /// <summary>
        /// Método para agregar un usuario
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Retorna el objeto en la base de datos</returns>
        public bool Agregar(Entidad theUsuario)
        {
            return true;
        }
        
        /// <summary>
        /// Método para modificar un usuario
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Retorna el objeto en la base de datos</returns>
        public bool Modificar(Entidad theUsuario)
        {
            return true;
        }

        /// <summary>
        /// Método para consultar un usuario por id
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Retorna la consulta</returns>
        public Entidad ConsultarXId(Entidad theUsuario)
        {
            return theUsuario;
        }

        /// <summary>
        /// Método para consultar todos los usuarios
        /// </summary>
        /// <returns>Retorna todos los usuarios</returns>
        public List<Entidad> ConsultarTodos()
        {
            List<Entidad> listaUser = new List<Entidad>();
            return listaUser; 
        }

        /// <summary>
        /// Verificar si el usuario por su ficha
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Si existe True, si no, False</returns>
        public bool VerificarUsuarioPorFichaEmpleado( int fichaEmpleado )
        {
            return true;
        }

        /// <summary>
        /// Método usado para devolver todos los empleados sin usuario
        /// </summary>
        /// <returns>Retorna la lista de empleados</returns>
        public List<Empleado> ConsultarListaDeEmpleados()
        {
            List<Empleado> listaDeEmpleados = new List<Empleado>();
            try
            {
                //Hablar con mod10 para que cambien el metodo ListaEmpleados() de lugar.
                listaDeEmpleados = BDEmpleado.ListarEmpleados();
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro("Error al ejecutar " +
                                                                     "ConsultarListaDeEmpleados()", ex);
            }
            return listaDeEmpleados;
        }

        /// <summary>
        /// Método usado para verificar si el usuario existe en el sistema
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns>Retorna una valor booleano indicando la disponibilidad del usuario</returns>
        public bool VerificarExistenciaUsuario( string nombreUsuario )
        {
            BDConexion laConexion = new BDConexion();
            List<Parametro> parametros = new List<Parametro>();
            Parametro elParametro = new Parametro();

            bool resultado = false;

            try
            {
                laConexion.Conectar();

                elParametro = new Parametro(ResourceUser.ParametroUsuario, SqlDbType.VarChar, nombreUsuario,
                                             false);
                parametros.Add(elParametro);

                DataTable dt = laConexion.EjecutarStoredProcedureTuplas(ResourceUser.VerificarExistenciaUsuario, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    resultado = true;
                }
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                return false;
            }

            return resultado;
        }

    }
}
