using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoAgregarPropuesta : Comando<bool>
    {
        /// <summary>
        /// Constructor, recibe parametro de tipo propuesta
        /// </summary>
        /// <param name="laPropuesta">objeto de tipo propuesta</param>
        public ComandoAgregarPropuesta(Entidad laPropuesta) 
        {
             _laEntidad = laPropuesta;
        }
        /// <summary>
        /// Método para utilizar el metodo AgregarPropuesta en capa de datos.
        /// </summary>
        /// <returns>Retorna true si fue satisfactoria la insercion</returns>
        public override bool Ejecutar()
        {
            try
            {
                IDAOPropuesta daoPropuesta = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
                return daoPropuesta.Agregar(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
