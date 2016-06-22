using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoConsultarNumeroPropuestas : Comando<int>
    {
        public ComandoConsultarNumeroPropuestas()
        {
        }

        public override int Ejecutar()
        {
            try
            {
                IDAOPropuesta daoPropuesta = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
                return daoPropuesta.ConsultarNumeroPropuestas();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}