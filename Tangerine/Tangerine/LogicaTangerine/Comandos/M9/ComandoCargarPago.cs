using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO.M9;
using DatosTangerine.Fabrica;

namespace LogicaTangerine.Comandos.M9
{
    public class ComandoAgregarPago : Comando<Boolean>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Boolean Ejecutar()
        {
            DAOPago Pago = FabricaDAOSqlServer.CrearDAOPago();
            return true;

        }
    
    }
}
