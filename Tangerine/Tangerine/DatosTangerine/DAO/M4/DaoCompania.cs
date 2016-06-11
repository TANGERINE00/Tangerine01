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
       


       int IDaoCompania.ConsultLastCompanyId()
       {
           throw new NotImplementedException();
       }

       bool IDaoCompania.DeleteCompany(CompaniaM4 theCompany)
       {
           throw new NotImplementedException();
       }

       bool IDaoCompania.EnableCompany(CompaniaM4 theCompany)
       {
           throw new NotImplementedException();
       }

       bool IDaoCompania.DisableCompany(CompaniaM4 theCompany)
       {
           throw new NotImplementedException();
       }

       public Resultado Agregar(Parametro TheCompany)
       {
           throw new NotImplementedException();
       }

       public Resultado Modificar(Parametro parametro)
       {
           throw new NotImplementedException();
       }

       public Resultado ConsultarXId(Parametro parametro)
       {
           throw new NotImplementedException();
       }

       public List<Resultado> ConsultarTodos()
       {
           throw new NotImplementedException();
       }

       public bool Agregar(CompaniaM4 parametro)
       {
           throw new NotImplementedException();
       }

       public bool Modificar(CompaniaM4 parametro)
       {
           throw new NotImplementedException();
       }

       public CompaniaM4 ConsultarXId(CompaniaM4 parametro)
       {
           throw new NotImplementedException();
       }

       List<CompaniaM4> InterfazDAO.IDao<CompaniaM4, bool, CompaniaM4>.ConsultarTodos()
       {
           throw new NotImplementedException();
       }
    }
}
