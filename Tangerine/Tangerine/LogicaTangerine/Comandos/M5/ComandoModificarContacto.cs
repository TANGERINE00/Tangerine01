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
    public class ComandoModificarContacto : Comando<bool>
    {
        public ComandoModificarContacto( Entidad contacto ) 
        {
            _laEntidad = contacto;
        }

        public override bool Ejecutar()
        {
            bool respuesta = false;

            try 
            {
                IDAOContacto daoContacto = FabricaDAOSqlServer.crearDAOContacto();
                respuesta = daoContacto.Modificar( _laEntidad );
            }
            catch ( Exception ex )
            {
                return respuesta;
            }

            return respuesta;
        }
    }
}
