using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoEliminarRequerimiento : Comando<bool>
    {
        public ComandoEliminarRequerimiento(Entidad elRequerimiento)
        {
            _laEntidad = elRequerimiento;
        }

        public override bool Ejecutar()
        {
            try
            {
                IDAORequerimiento daoRequerimiento = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
                return daoRequerimiento.EliminarRequerimiento(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}