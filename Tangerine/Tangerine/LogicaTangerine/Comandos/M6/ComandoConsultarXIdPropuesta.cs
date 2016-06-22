using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    class ComandoConsultarXIdPropuesta : Comando<Entidad>
    {
        /// <summary>
        /// Constructor, recibe parametro de tipo propuesta
        /// </summary>
        /// <param name="laPropuesta">objeto de tipo propuesta</param>
        public ComandoConsultarXIdPropuesta(Entidad laPropuesta)
        {
            _laEntidad = laPropuesta;
        }
        
        /// <summary>
        /// Método para utilizar el metodo ConsultarXIdPropuesta en capa de datos.
        /// </summary>
        /// <returns>Retorna una propuesta</returns>
        public override Entidad Ejecutar()
        {
            try
            {
                IDAOPropuesta daoPropuesta = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
                return daoPropuesta.ConsultarXId(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
