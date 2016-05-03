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
            theContact = new Contacto();
            theContact.IdContacto = 7;
            theContact.Nombre = "Eduardo";
            theContact.Apellido = "Araque";
            theContact.Departamento = "Satnev";
            theContact.Cargo = "Etnereg";
            theContact.Correo = "b@b.com";
            theContact.Telefono = "1234567";
            theContact.TipoCompañia = 1;
            theContact.IdCompañia = 1;

            DatosTangerine.M5.BDContacto prueba = new DatosTangerine.M5.BDContacto();

            //Aqui llamo al metodo que inserta un contacto (theContact)
            answer2 =prueba.AddContactProy(2,1);
        }

        public List<Contacto> fillTable(int typeComp, int idComp) 
        {
            BDContacto bdContact = new BDContacto();
            List<Contacto> listContact =  bdContact.ContactCompany(typeComp,idComp);

            return listContact; 
        }

        public bool AddNewContact(Contacto contact){
            try
            {
                return BDContacto.AddContact(contact);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
