using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M4;

namespace DatosTangerine.InterfazDAO.M4
{
    public interface IDaoCompania // : IDao<Parametro, Resultado, Resultado>
    {
         int ConsultLastCompanyId();
         bool DeleteCompany(CompaniaM4 theCompany);
         bool EnableCompany(CompaniaM4 theCompany);
         bool DisableCompany(CompaniaM4 theCompany);

    }
}
