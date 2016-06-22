using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoAgregarRequerimiento: Comando<bool>
    {
        /// <summary>
        /// Constructor, recibe parametro de tipo requerimiento
        /// </summary>
        /// <param name="elRequerimiento">objeto de tipo requerimiento</param>
        public ComandoAgregarRequerimiento(Entidad elRequerimiento) 
        {
             _laEntidad = elRequerimiento;
        }
        /// <summary>
        /// Método para utilizar el metodo AgregarRequerimiento en capa de datos.
        /// </summary>
        /// <returns>Retorna true si fue satisfactoria la insercion</returns>
        public override bool Ejecutar()
        {
            try
            {
                IDAORequerimiento daoRequerimiento = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
                return daoRequerimiento.Agregar(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
