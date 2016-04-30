using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace LogicaTangerine.M5
{
    public class Class1
    {

        public Contacto theContact;
        public bool answer;
        public void init()
        {
            theContact = new Contacto();
            theContact.IdContacto = 1;
            theContact.Nombre = "Istvan";
            theContact.Apellido = "Bokor";
            theContact.Departamento = "Ventas";
            theContact.Cargo = "Gerente";
            theContact.Correo = "asd@asd.com";
            theContact.Telefono = "7654321";
            theContact.TipoCompañia = 1;
            theContact.IdCompañia = 1;

            DatosTangerine.M5.BDContacto prueba = new DatosTangerine.M5.BDContacto();
            answer = prueba.AddContact(theContact);
        }
    }
}
