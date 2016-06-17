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
    public class ComandoConsultarContacto : Comando<Entidad>
    {
        public ComandoConsultarContacto( Entidad contacto ) 
        {
            _laEntidad = contacto;
        }

        public override Entidad Ejecutar()
        {
            try 
            {
                IDAOContacto daoContacto = FabricaDAOSqlServer.crearDAOContacto();
                _laEntidad = daoContacto.ConsultarXId( _laEntidad );
            }
            catch ( Exception ex )
            {
                throw ex;
            }

            return _laEntidad;
        }
    }
}
