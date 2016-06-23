using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M9;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M9
{
    public interface IDAOPago : IDao
    {

        //bool Agregar (Entidad pagoParam);

        bool CargarStatus(int factura, int status);

        List<Entidad> ConsultarPagosCompania(Entidad parametro);
    
    }
}
