using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M6;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;
using DominioTangerine.Entidades.M6;

namespace DatosTangerine.DAO.M6
{
    public class DAORequerimiento : DAOGeneral, IDAORequerimiento
    {

        #region IDAO

        /// <summary>
        /// Metodo para agregar una propuesta en la base de datos.
        /// </summary>
        ///  <param name="parametro">objeto de tipo Propuesta para agregar en BD</param>
        ///  <param name="theConnection">Objeto de tipo BDConexion para la conexion a la BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>true si fue agregado</returns>
        public bool Agregar(Entidad laPropuesta)
        {
            return true;
        }


        /// <summary>
        /// Metodo que permite modificar una propuesta en la BD
        /// </summary>
        /// <param name="propuesta"></param>
        /// <returns></returns>
        public Boolean Modificar(Entidad propuesta)
        {
            return true;
        }


        /// <summary>
        /// Metodo para consultar propuesta por id (nombre)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entidad ConsultarXId(Entidad id)
        {
            Entidad propuesta = null;

            return propuesta;
        }


        /// <summary>
        /// Metodo que consulta todas las propuestas
        /// </summary>
        ///
        /// <returns>Retorna la lista de propuestas</returns>
        public List<Entidad> ConsultarTodos()
        {
            List<Entidad> listaPropuesta = new List<Entidad>();

            return listaPropuesta;
        }

        #endregion


        #region IDAORequerimiento

        /// <summary>
        /// Método para listar los requerimientos por propuesta 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Entidad> ConsultarRequerimientosXPropuesta(String id)
        {
            List<Entidad> listaRequerimientos = new List<Entidad>();
            return listaRequerimientos;
        }
        
        #endregion

    }
}
