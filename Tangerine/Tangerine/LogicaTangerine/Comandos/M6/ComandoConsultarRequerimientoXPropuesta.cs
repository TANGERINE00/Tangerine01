using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    class ComandoConsultarRequerimientoXPropuesta : Comando<List<Entidad>>
    {
        public ComandoConsultarRequerimientoXPropuesta(Entidad laPropuesta)
        {
            _laEntidad = laPropuesta;
        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDAORequerimiento daoRequerimiento = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
                DominioTangerine.Entidades.M6.Propuesta propuesta = (DominioTangerine.Entidades.M6.Propuesta)_laEntidad;
                return daoRequerimiento.ConsultarRequerimientosXPropuesta(propuesta.Nombre);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
