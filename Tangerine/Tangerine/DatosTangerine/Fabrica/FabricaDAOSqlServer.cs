using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.InterfazDAO;
using DatosTangerine.InterfazDAO.M7;

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
        static public DAO.M2.DaoUsuario crearDaoUsuario()
        {
            return new DAO.M2.DaoUsuario();
        }

        /// <summary>
        /// Método que crea la instancia de DAO Rol
        /// </summary>
        /// <returns>Retorna la instancia a la clase DaoRol</returns>
        static public DAO.M2.DaoRol crearDaoRol()
        {
            return new DAO.M2.DaoRol();
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
        public static DAO.M6.DAOPropuesta CrearDAOPropuesta()
        {
            return new DAO.M6.DAOPropuesta();
        }
        #endregion

        #region Modulo 7

        public static IDaoProyecto ObetenerIdaoProyecto()
        {
            return new DAO.M7.DaoProyecto();
        }

        public static IDaoProyectoContacto ObetenerIdaoContacto()
        {
            return new DAO.M7.DaoProyectoContacto();
        }

        public static IDaoProyectoEmpleado ObetenerIdaoProyectoEmpleado()
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

        #endregion
    }
}
