using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M9;
using DominioTangerine.Entidades.M9;

namespace DatosTangerine.DAO.M9
{
    public class DAOPago : DAOGeneral , IDAOPago
    {
    
        public bool CargarPago (Pago pago)
        {
            return true;
        }
    
        public bool CargarStatus (int factura, int status)
        {
            return true;
        }
    }
}
