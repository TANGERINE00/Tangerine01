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
    public class ComandoAgregarContactoAProyecto : Comando<bool>
    {
        private Entidad _proyecto;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="contacto"></param>
        /// <param name="proyecto"></param>
        public ComandoAgregarContactoAProyecto( Entidad contacto, Entidad proyecto ) 
        {
            _laEntidad = contacto;
            _proyecto = proyecto;
        }

        /// <summary>
        /// Método para ejecutar el comando
        /// </summary>
        /// <returns></returns>
        public override bool Ejecutar()
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursoComandosM5.MensajeInicioInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            bool respuesta = false;

            try 
            {
                IDAOContacto daoContacto = FabricaDAOSqlServer.crearDAOContacto();
                respuesta = daoContacto.AgregarContactoAProyecto( _laEntidad, _proyecto );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                return respuesta;
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursoComandosM5.MensajeFinInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            return respuesta;
        }
    }
}
