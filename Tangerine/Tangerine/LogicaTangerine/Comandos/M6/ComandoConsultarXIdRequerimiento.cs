using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    class ComandoConsultarXIdRequerimiento : Comando<Entidad>
    {
        public ComandoConsultarXIdRequerimiento(Entidad elRequerimiento)
        {
            _laEntidad = elRequerimiento;
        }

        public override Entidad Ejecutar()
        {
            try
            {
                IDAORequerimiento daoRequerimiento = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
                return daoRequerimiento.ConsultarXId(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
