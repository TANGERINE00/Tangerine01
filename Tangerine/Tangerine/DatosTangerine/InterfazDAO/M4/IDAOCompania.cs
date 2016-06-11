using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M4;

namespace DatosTangerine.InterfazDAO.M4
{
    public interface IDaoCompania : IDao<CompaniaM4, Boolean , CompaniaM4>
    {
         int ConsultLastCompanyId();
         bool DeleteCompany(CompaniaM4 theCompany);
         bool EnableCompany(CompaniaM4 theCompany);
         bool DisableCompany(CompaniaM4 theCompany);

    }
}
