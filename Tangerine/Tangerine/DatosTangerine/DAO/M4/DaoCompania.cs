using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M4;
using DominioTangerine.Entidades.M4;

namespace DatosTangerine.DAO.M4
{
    public class DaoCompania : DAOGeneral, IDaoCompania
    {
       public int ConsultLastCompanyId()
        {
            return 0;
        }

       public bool DeleteCompany(CompaniaM4 theCompany)
       {
           return true;
       }
       public bool EnableCompany(CompaniaM4 theCompany)
       {
           return true;
       }
       public bool DisableCompany(CompaniaM4 theCompany)
       {
           return true;
       }
    }
}
