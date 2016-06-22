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
            bool respuesta = false;

            IDAOContacto daoContacto = FabricaDAOSqlServer.crearDAOContacto();
            respuesta = daoContacto.AgregarContactoAProyecto( _laEntidad, _proyecto );
           
            return respuesta;
        }
    }
}
