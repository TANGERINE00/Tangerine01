using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M5;
using DominioTangerine;
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
            List<Entidad> listaContactos = new List<Entidad>();

            try 
            {
                IDAOContacto daoCotacto = FabricaDAOSqlServer.crearDAOContacto();
                listaContactos = daoCotacto.ContactosNoPertenecenAProyecto( _laEntidad );
            }
            catch ( Exception ex )
            {
                return listaContactos;
            }

            return listaContactos;
        }
    }
}
