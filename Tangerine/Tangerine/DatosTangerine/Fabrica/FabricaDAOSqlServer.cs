using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.InterfazDAO;
using DatosTangerine.InterfazDAO.M7;
using DatosTangerine.InterfazDAO.M2;

namespace DatosTangerine.Fabrica
{
    public class FabricaDAOSqlServer
    {
        #region Modulo 1
        
        #endregion

        #region Modulo 2

        /// <summary>
        /// Método que crea la instancia de DAO Usuario
        /// </summary>
        /// <returns>Retorna la instancia a la clase DaoUsuario</returns>
        static public IDAOUsuarios crearDaoUsuario()
        {
            return new DAO.M2.DAOUsuario();
        }

        /// <summary>
        /// Método que crea la instancia de DAO Rol
        /// </summary>
        /// <returns>Retorna la instancia a la clase DaoRol</returns>
        static public IDAORol crearDaoRol()
        {
            return new DAO.M2.DAORol();
        }

        #endregion

        #region Modulo 3

        #endregion

        #region Modulo 4

        /// <summary>
        /// Metodo que crea la instancia de DAO Compania
        /// </summary>
        /// <returns>Retorna la instancia a la clase DaoCompania</returns>

        static public DAO.M4.DaoCompania crearDaoCompania()
        {
            return new DAO.M4.DaoCompania();
        }

        /// <summary>
        /// Metodo que crea la instancia de DAO LugarDireccion
        /// </summary>
        /// <returns>Retorna la instancia a la clase DaoLugarDireccion</returns>

        static public DAO.M4.DaoLugarDireccion crearDaoLugarDireccion()
        {
            return new DAO.M4.DaoLugarDireccion();
        }

        #endregion

        #region Modulo 5

        #endregion

        #region Modulo 6

        /// <summary>
        /// Metodo que crea la instancia de DAO Propuesta
        /// </summary>
        /// <returns>La instancia</returns>
        public static InterfazDAO.M6.IDAOPropuesta CrearDAOPropuesta()
        {
            return new DAO.M6.DAOPropuesta();
        }

        /// <summary>
        /// Metodo que crea la instancia de DAO Requerimiento
        /// </summary>
        /// <returns>La instancia</returns>
        public static InterfazDAO.M6.IDAORequerimiento CrearDAORequerimiento()
        {
            return new DAO.M6.DAORequerimiento();
        }

        #endregion

        #region Modulo 7

        public static IDaoProyecto ObetenerDaoProyecto()
        {
            return new DAO.M7.DaoProyecto();
        }

        public static IDaoProyectoContacto ObetenerDaoContacto()
        {
            return new DAO.M7.DaoProyectoContacto();
        }

        public static IDaoProyectoEmpleado ObetenerDaoProyectoEmpleado()
        {
            return new DAO.M7.DaoProyectoEmpleado();
        }
        #endregion

        #region Modulo 8

        #endregion

        #region Modulo 9

        public static DAO.M9.DAOPago CrearDAOPago()
        {
            return new DAO.M9.DAOPago();
        }

        #endregion

        #region Modulo 10

        /// <summary>
        /// Metodo que crea la instacia de DAO Empleado
        /// </summary>
        /// <returns></returns>

        public static DAO.M10.DAOEmpleado CrearDAOEmpleado()
        {
            return new DAO.M10.DAOEmpleado();
        }

        #endregion
    }
}
