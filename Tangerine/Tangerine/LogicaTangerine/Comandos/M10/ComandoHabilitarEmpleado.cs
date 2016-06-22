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
        public ComandoHabilitarEmpleado(Entidad estatus)

        {
            elEstatus=estatus;
        }
               

        public override bool Ejecutar()
        {
            try
            {
                IDAOEmpleado daoEstatus = DatosTangerine.Fabrica.FabricaDAOSqlServer.EstatusDAOEmpleado();
                return daoEstatus.CambiarEstatus(elEstatus);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
   
    public Entidad elEstatus {get;set;}
    
    }
}

