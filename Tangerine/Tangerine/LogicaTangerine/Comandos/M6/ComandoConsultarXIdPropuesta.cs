using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    class ComandoConsultarXIdPropuesta : Comando<Entidad>
    {
        public ComandoConsultarXIdPropuesta(Entidad laPropuesta)
        {
            _laEntidad = laPropuesta;
        }

        public override Entidad Ejecutar()
        {
            try
            {
                IDAOPropuesta daoPropuesta = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
                return daoPropuesta.ConsultarXId(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
