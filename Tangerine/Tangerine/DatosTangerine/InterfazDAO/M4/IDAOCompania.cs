using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M4
{
    public interface IDaoCompania : IDao<Entidad, Boolean , Entidad>
    {
         int ConsultLastCompanyId();
         bool DeleteCompany(Entidad theCompany);
         bool EnableCompany(Entidad theCompany);
         bool DisableCompany(Entidad theCompany);

    }
}
