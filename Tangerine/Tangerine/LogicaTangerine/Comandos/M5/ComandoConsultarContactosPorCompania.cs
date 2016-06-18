using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M5;
using DominioTangerine;
using DominioTangerine.Entidades.M4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M5
{
    public class ComandoConsultarContactosPorCompania : Comando<List<Entidad>>
    {
        public ComandoConsultarContactosPorCompania( Entidad compania ) 
        {
            _laEntidad = compania;
        }

        public override List<Entidad> Ejecutar()
        {
            List<Entidad> listaContactos = new List<Entidad>();

            try
            {
                IDAOContacto daoContacto = FabricaDAOSqlServer.crearDAOContacto();
                listaContactos = daoContacto.ContactosPorCompania( 1, _laEntidad.Id );
            }
            catch ( Exception ex )
            {
                return listaContactos;
            }

            return listaContactos;
        }
    }
}
