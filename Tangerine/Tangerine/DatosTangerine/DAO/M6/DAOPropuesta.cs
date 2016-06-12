using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine.Entidades.M6;

namespace DatosTangerine.DAO.M6
{
    public class DAOPropuesta : DAOGeneral, IDAOPropuesta
    {
        /// <summary>
        /// Metodo para agregar una propuesta en la base de datos.
        /// </summary>
        ///  <param name="parametro">objeto de tipo Propuesta para agregar en BD</param>
        ///  <param name="theConnection">Objeto de tipo BDConexion para la conexion a la BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>true si fue agregado</returns>
        public bool AgregarPropuesta(Propuesta laPropuesta)
        {
            return true;
        }


        /// <summary>
        /// Metodo para agregar un Requerimiento en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Requerimiento para agregar en bd</param>
        /// <returns>true si fue agregado</returns>
        public bool AgregarRequerimiento(Requerimiento elRequerimiento)
        {
            return true;
        }


        /// <summary>
        /// Metodo diseñado para M7, que devuelve la lista de propuestas con estatus aprobado y que no están en proyecto
        /// </summary>
        /// <returns>Retorna la lista de propuestas con estatus= Aprobado y que no se encuentran aún en Proyecto</returns>
        public List<Propuesta> PropuestaProyecto()
        {
            List<Propuesta> listaPropuesta = new List<Propuesta>();

            return listaPropuesta;
        }


        /// <summary>
        /// Metodo que consulta todas las propuestas
        /// </summary>
        ///
        /// <returns>Retorna la lista de propuestas</returns>
        public List<Propuesta> ListarLasPropuestas()
        {
            List<Propuesta> listaPropuesta = new List<Propuesta>();

            return listaPropuesta;
        }


        /// <summary>
        /// Método para listar los requerimientos por propuesta 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Requerimiento> ConsultarRequerimientosPorPropuesta(String id)
        {
            List<Requerimiento> listaRequerimientos = new List<Requerimiento>();
            return listaRequerimientos;
        }


        /// <summary>
        /// Metodo para consultar propuesta por id (nombre)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Propuesta ConsultarPropuestaporNombre(String id)
        {
            Propuesta propuesta = null;

            return propuesta;
        }


        /// <summary>
        /// Metodo para eliminar una Propuesta de la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Contacto a eliminar en bd</param>
        /// <returns>true si fue eliminado</returns>
        public Boolean BorrarPropuesta(string nombrePropuesta)
        {
            return true;
        }


        /// <summary>
        /// Metodo para modificar un requerimiento
        /// </summary>
        /// <param name="elrequerimiento"></param>
        /// <returns></returns>
        public Boolean Modificar_Requerimiento(Requerimiento elrequerimiento)
        {
            return true;
        }


        /// <summary>
        /// Metodo que permite modificar una propuesta en la BD
        /// </summary>
        /// <param name="propuesta"></param>
        /// <returns></returns>
        public Boolean Modificar_Propuesta(Propuesta propuesta)
        {
            return true;
        }

    }
}