using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoBorrarPropuesta : Comando<bool>
    {
        /// <summary>
        /// Constructor, recibe parametro de tipo propuesta
        /// </summary>
        /// <param name="laPropuesta">objeto de tipo propuesta</param>
        public ComandoBorrarPropuesta( Entidad laPropuesta )
        {
            _laEntidad = laPropuesta;
        }

        /// <summary>
        /// Método para utilizar el metodo BorrarPropuesta en capa de datos.
        /// </summary>
        /// <returns>Retorna true si fue satisfactorio el borrado</returns>
        public override bool Ejecutar()
        {
            try
            {
                IDAOPropuesta daoPropuesta = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
                DominioTangerine.Entidades.M6.Propuesta propuesta = ( DominioTangerine.Entidades.M6.Propuesta )_laEntidad;
                return daoPropuesta.BorrarPropuesta( propuesta.Nombre );
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
