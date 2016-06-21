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
            List<Entidad> listaContactos = new List<Entidad>();

            IDAOContacto daoContacto = FabricaDAOSqlServer.crearDAOContacto();
            listaContactos = daoContacto.ContactosPorProyecto( _laEntidad );

            return listaContactos;
        }
    }
}
