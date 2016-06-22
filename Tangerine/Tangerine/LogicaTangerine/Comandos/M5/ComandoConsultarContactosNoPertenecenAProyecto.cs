using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M5;
using DominioTangerine;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M5
{
    public class ComandoConsultarContactosNoPertenecenAProyecto : Comando<List<Entidad>>
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="proyecto"></param>
        public ComandoConsultarContactosNoPertenecenAProyecto( Entidad proyecto ) 
        {
            _laEntidad = proyecto;
        }

        /// <summary>
        /// Método para elecutar el comando
        /// </summary>
        /// <returns></returns>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                List<Entidad> listaContactos = new List<Entidad>();

                IDAOContacto daoCotacto = FabricaDAOSqlServer.crearDAOContacto();
                listaContactos = daoCotacto.ContactosNoPertenecenAProyecto( _laEntidad );

                return listaContactos;
            }
            catch ( ConsultarContactoException ex )
            {
                throw ex;
            }
            catch ( BaseDeDatosContactoException ex )
            {
                throw ex;
            }
        }
    }
}
