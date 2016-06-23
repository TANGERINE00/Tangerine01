using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M6;
using DominioTangerine;

namespace LogicaTangerine.M6
{
    public class LogicaRequerimiento
    {

        /// <summary>
        /// Metodo para agregar un requerimiento a su respcetiva propuesta.
        /// </summary>
        /// <param name="propuesta">objeto de tipo Requerimiento para agregar</param>
        /// <returns>true si fue agregado</returns>
        public bool agregar(Requerimiento requerimiento)
        {
            try
            {
                return BDPropuesta.agregarRequerimiento(requerimiento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo para traer una lista de requerimientos asociados a una propuesta
        /// </summary>
        /// <param name="id">id de la propuesta</param>
        /// <returns>lista de requerimientos</returns>
        public List<Requerimiento> TraerRequerimientoPropuesta(String id)
        {
            return BDPropuesta.ConsultarRequerimientosPorPropuesta(id);
        }



        /// <summary>
        /// Metodo para modificar un requerimiento
        /// </summary>
        /// <param name="requerimiento">Requerimiento a modificar</param>
        /// <returns>true si la accion fue completada correctamente</returns>
        public bool ModRequerimiento(Requerimiento requerimiento)
        {
            return BDPropuesta.Modificar_Requerimiento(requerimiento);
        }

      

    }
}
