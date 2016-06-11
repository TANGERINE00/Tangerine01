using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.Fabrica;

namespace LogicaTangerine.Comandos.M9
{
    public class ComandoCargarPago : Comando<Boolean>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Boolean Ejecutar()
        {
            DAOGeneral Pago = FabricaDAOSqlServer.CrearDAOPago();
            return true;

        }
    
    }
}
