using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    class ComandoConsultarXIdRequerimiento : Comando<Entidad>
    {
        /// <summary>
        /// Constructor, recibe parametro de tipo requerimiento
        /// </summary>
        /// <param name="elRequerimiento">objeto de tipo requerimiento</param>
        public ComandoConsultarXIdRequerimiento(Entidad elRequerimiento)
        {
            _laEntidad = elRequerimiento;
        }

        /// <summary>
        /// Método para utilizar el metodo ConsultarXIdRequerimiento en capa de datos.
        /// </summary>
        /// <returns>Retorna un requerimiento</returns>
        public override Entidad Ejecutar()
        {
            try
            {
                IDAORequerimiento daoRequerimiento = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
                return daoRequerimiento.ConsultarXId(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
