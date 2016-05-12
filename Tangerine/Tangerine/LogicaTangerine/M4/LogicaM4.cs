using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M4;

namespace LogicaTangerine.M4
{
    public class LogicaM4
    {
        public Compania theCompany;
        List<Compania> answer;
        bool answer2;

        public void init()
        {

        }
        
        public List<Compania> getCompanies()
        { 
             try
            {
            return BDCompania.ConsultCompanies(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
  
        }
        
        public List<Compania> fillTable()
        {
            try
            {
                return BDCompania.ConsultCompanies();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddNewCompany(Compania company)
        {
            try
            {
                return BDCompania.AddCompany(company);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Compania SearchCompany(int idCompany)
        {
            try
            {
                return BDCompania.ConsultCompany(idCompany);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
