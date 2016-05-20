using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M6;

namespace LogicaTangerine.M6
{
    public class LogicaPropuesta
    {


        /// <summary>
        /// Metodo para agregar una nueva propuesta.
        /// </summary>
        /// <param name="propuesta">objeto de tipo Propuesta para agregar</param>
        /// <returns>true si fue agregado</returns>
        public bool agregar(Propuesta propuesta)
        {
            try
            {
                return BDPropuesta.agregarPropuesta(propuesta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Propuesta TraerPropuesta(String id) 
        {
            //try
            //{
                return BDPropuesta.ConsultarPropuestaporNombre(id);
            //}
            ////catch (Exception ex)
            ////{
            ////    throw ex;
            ////}
            
        }

        public Boolean BorrarPropuesta(String id)
        {
            //try
            //{
            return BDPropuesta.BorrarPropuesta(id);
            //}
            ////catch (Exception ex)
            ////{
            ////    throw ex;
            ////}

        }



       
    }
}
