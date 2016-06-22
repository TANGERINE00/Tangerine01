using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoConsultarNumeroRequerimientos : Comando<int>
    {
        public ComandoConsultarNumeroRequerimientos()
        {
        }

        public override int Ejecutar()
        {
            try
            {
                IDAORequerimiento daoRequerimiento = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
                return daoRequerimiento.ConsultarNumeroRequerimientos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}