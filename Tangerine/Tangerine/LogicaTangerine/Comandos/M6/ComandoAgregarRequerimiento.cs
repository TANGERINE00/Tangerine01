using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoAgregarRequerimiento: Comando<bool>
    {
        public ComandoAgregarRequerimiento(Entidad elRequerimiento) 
        {
             _laEntidad = elRequerimiento;
        }

        public override bool Ejecutar()
        {
            try
            {
                IDAORequerimiento daoRequerimiento = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
                return daoRequerimiento.Agregar(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
