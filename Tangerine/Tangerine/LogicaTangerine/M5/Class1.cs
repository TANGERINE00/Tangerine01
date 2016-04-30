using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace LogicaTangerine.M5
{
    //Esta clase la invente para probar la base de datos, no es la logica de Contacto
    //se activa corriendo la interfaz de consultar contacto
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

            //Aqui llamo al metodo que inserta un contacto (theContact)
            answer = prueba.AddContact(theContact);
        }
    }
}
