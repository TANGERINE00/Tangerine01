using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M10
{
    public class ComandoHabilitarEmpleado: Comando<bool>
    {
        public ComandoHabilitarEmpleado(Entidad parametro)

        {
            LaEntidad=parametro;
        }                                                                                                              
               

        public override bool Ejecutar()
        {
            try
            {
                IDAOEmpleado daoEstatus = DatosTangerine.Fabrica.FabricaDAOSqlServer.EstatusDAOEmpleado();
                return daoEstatus.CambiarEstatus(this.LaEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

