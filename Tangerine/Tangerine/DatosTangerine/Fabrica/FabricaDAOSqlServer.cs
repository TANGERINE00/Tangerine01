using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.InterfazDAO;

namespace DatosTangerine.Fabrica
{
    public class FabricaDAOSqlServer
    {
        #region Modulo 1
        
        #endregion

        #region Modulo 2

        /// <summary>
        /// Metodo que crea la instancia de DAO Usuario
        /// </summary>
        /// <returns>La instancia</returns>
        static public DAO.M2.DaoUsuario crearDaoUsuario()
        {
            return new DAO.M2.DaoUsuario();
        }
        #endregion

        #region Modulo 3

        #endregion

        #region Modulo 4
        static public DAO.M4.DaoCompania crearDaoCompania()
        {
            return new DAO.M4.DaoCompania();
        }

        static public DAO.M4.DaoLugarDireccion crearDaoLugarDireccion()
        {
            return new DAO.M4.DaoLugarDireccion();
        }

        #endregion

        #region Modulo 5

        #endregion

        #region Modulo 6

        #endregion

        #region Modulo 7

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
