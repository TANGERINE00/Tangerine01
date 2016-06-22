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
    public class ComandoConsultarContacto : Comando<Entidad>
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="contacto"></param>
        public ComandoConsultarContacto( Entidad contacto ) 
        {
            _laEntidad = contacto;
        }

        /// <summary>
        /// Método para ejecutar el comando
        /// </summary>
        /// <returns></returns>
        public override Entidad Ejecutar()
        {
            try
            {
                IDAOContacto daoContacto = FabricaDAOSqlServer.crearDAOContacto();
                _laEntidad = daoContacto.ConsultarXId( _laEntidad );

                return _laEntidad;
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
