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
    public class DaoUsuario : DAOGeneral, IDaoUsuarios
    {
        /// <summary>
        /// Método para agregar un usuario
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Retorna el objeto en la base de datos</returns>
        public bool Agregar ( UsuarioM2 theUsuario )
        {
            return true;
        }
        
        /// <summary>
        /// Método para modificar un usuario
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Retorna el objeto en la base de datos</returns>
        public bool Modificar ( UsuarioM2 theUsuario )
        {
            return true;
        }

        /// <summary>
        /// Método para consultar un usuario por id
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Retorna la consulta</returns>
        public UsuarioM2 ConsultarXId( UsuarioM2 theUsuario )
        {
            return theUsuario;
        }

        /// <summary>
        /// Método para consultar todos los usuarios
        /// </summary>
        /// <returns>Retorna todos los usuarios</returns>
        public List<UsuarioM2> ConsultarTodos()
        {
            List<UsuarioM2> listaUser = new List<UsuarioM2>();
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

        bool IDaoUsuarios.VerificarUsuarioPorFichaEmpleado(int fichaEmpleado)
        {
            throw new NotImplementedException();
        }

        bool IDaoUsuarios.VerificarExistenciaDeUsuario(string nombreUsuario)
        {
            throw new NotImplementedException();
        }

        bool InterfazDAO.IDao<DominioTangerine.Entidades.M2.UsuarioM2, bool, DominioTangerine.Entidades.M2.UsuarioM2>.Agregar(DominioTangerine.Entidades.M2.UsuarioM2 parametro)
        {
            throw new NotImplementedException();
        }

        bool InterfazDAO.IDao<DominioTangerine.Entidades.M2.UsuarioM2, bool, DominioTangerine.Entidades.M2.UsuarioM2>.Modificar(DominioTangerine.Entidades.M2.UsuarioM2 parametro)
        {
            throw new NotImplementedException();
        }

        DominioTangerine.Entidades.M2.UsuarioM2 InterfazDAO.IDao<DominioTangerine.Entidades.M2.UsuarioM2, bool, DominioTangerine.Entidades.M2.UsuarioM2>.ConsultarXId(DominioTangerine.Entidades.M2.UsuarioM2 parametro)
        {
            throw new NotImplementedException();
        }

        List<DominioTangerine.Entidades.M2.UsuarioM2> InterfazDAO.IDao<DominioTangerine.Entidades.M2.UsuarioM2, bool, DominioTangerine.Entidades.M2.UsuarioM2>.ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
