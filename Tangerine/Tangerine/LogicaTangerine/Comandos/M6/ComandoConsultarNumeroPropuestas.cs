using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoConsultarNumeroPropuestas : Comando<int>
    {
        /// <summary>
        /// Constructor, recibe parametro de tipo requerimiento
        /// </summary>
        /// <param name="elRequerimiento">objeto de tipo requerimiento</param>
        public ComandoConsultarNumeroPropuestas()
        {
        }

        /// <summary>
        /// Método para utilizar el metodo ConsultarNumeroPropuestas en capa de datos.
        /// </summary>
        /// <returns>Retorna numero de propuestas registradas</returns>
        public override int Ejecutar()
        {
            try
            {
                IDAOPropuesta daoPropuesta = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
                return daoPropuesta.ConsultarNumeroPropuestas();
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (ExcepcionesTangerine.ExceptionsTangerine ex)
            {
                throw ex;
            }
        }

    }
}