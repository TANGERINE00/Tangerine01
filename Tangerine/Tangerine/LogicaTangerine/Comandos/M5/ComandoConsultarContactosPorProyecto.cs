using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M5;
using DominioTangerine;
using ExcepcionesTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M5
{
    public class ComandoConsultarContactosPorProyecto : Comando<List<Entidad>>
    {
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="proyecto"></param>
        public ComandoConsultarContactosPorProyecto( Entidad proyecto ) 
        {
            _laEntidad = proyecto;
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
                listaContactos = daoContacto.ContactosPorProyecto( _laEntidad );
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
