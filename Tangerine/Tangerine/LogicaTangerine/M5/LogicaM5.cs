using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M5;

namespace LogicaTangerine.M5
{
    public class LogicaM5
    {
        public Contacto theContact;
        List<Contacto> answer;
        bool answer2;

        public void init()
        {

        }

        public List<Contacto> fillTable(int typeComp, int idComp) 
        {
            try
            {
            return BDContacto.ContactCompany(typeComp,idComp); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddNewContact(Contacto contact)
        {
            try
            {
                return BDContacto.AddContact(contact);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contacto SearchContact(int idContact)
        {
            try
            {
                return BDContacto.SingleContact(idContact);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
