using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M5;
using DominioTangerine;
using DominioTangerine.Entidades.M4;
using ExcepcionesTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M5
{
    public class ComandoConsultarContactosPorCompania : Comando<List<Entidad>>
    {
        private int _tipoCompania;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="compania"></param>
        /// <param name="tipoCompania"></param>
        public ComandoConsultarContactosPorCompania( Entidad compania, int tipoCompania ) 
        {
            _laEntidad = compania;
            _tipoCompania = tipoCompania;
        }

        /// <summary>
        /// Método para ejecutar el comando
        /// </summary>
        /// <returns></returns>
        public override List<Entidad> Ejecutar()
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursoComandosM5.MensajeInicioInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Entidad> listaContactos = new List<Entidad>();

            try
            {
                IDAOContacto daoContacto = FabricaDAOSqlServer.crearDAOContacto();
                listaContactos = daoContacto.ContactosPorCompania( _tipoCompania, _laEntidad.Id );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                return listaContactos;
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursoComandosM5.MensajeFinInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            return listaContactos;
        }
    }
}
