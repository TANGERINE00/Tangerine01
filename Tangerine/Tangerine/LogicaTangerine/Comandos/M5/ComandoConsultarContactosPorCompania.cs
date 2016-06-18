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
        private int _tipoCompania;
        public ComandoConsultarContactosPorCompania( Entidad compania, int tipoCompania ) 
        {
            _laEntidad = compania;
            _tipoCompania = tipoCompania;
        }

        public override List<Entidad> Ejecutar()
        {
            List<Entidad> listaContactos = new List<Entidad>();

            try
            {
                IDAOContacto daoContacto = FabricaDAOSqlServer.crearDAOContacto();
                listaContactos = daoContacto.ContactosPorCompania( _tipoCompania, _laEntidad.Id );
            }
            catch ( Exception ex )
            {
                return listaContactos;
            }

            return listaContactos;
        }
    }
}
