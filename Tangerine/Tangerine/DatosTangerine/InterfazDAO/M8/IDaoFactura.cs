using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M8
{
    public interface IDaoFactura : IDao
    {
        bool DeleteFactura(Entidad parametro);

        bool AnnularFactura(Entidad parametro);

        List<Entidad> ContactFacturasCompania(Entidad parametro);

        List<Entidad> ContactFacturasPagadasCompania(Entidad parametro);

        double ContactMontoRestanteFactura(Entidad parametro);

        bool CheckExistingInvoice(Entidad parametro);
    }
}
