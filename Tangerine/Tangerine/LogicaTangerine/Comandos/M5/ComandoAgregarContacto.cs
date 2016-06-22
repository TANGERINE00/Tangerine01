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
    public class ComandoAgregarContacto : Comando<bool>
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="contacto"></param>
        public ComandoAgregarContacto( Entidad contacto ) 
        {
            _laEntidad = contacto;
        }

        /// <summary>
        /// Método para ejecutar el comando
        /// </summary>
        /// <returns></returns>
        public override bool Ejecutar()
        {
            try
            {
                bool respuesta = false;

                IDAOContacto daoContacto = FabricaDAOSqlServer.crearDAOContacto();
                respuesta = daoContacto.Agregar( _laEntidad );

                return respuesta;
            }
            catch ( AgregarContactoException ex )
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
