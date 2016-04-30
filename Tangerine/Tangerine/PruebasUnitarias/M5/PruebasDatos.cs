using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine;
using DominioTangerine;

namespace PruebasUnitarias.M5
{
    [TestFixture]
    public class PruebasDatos
    {
        #region Atributos
        public Contacto theContact;
        public Contacto theContact2;
        public bool answer;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            theContact = new Contacto();
            theContact.IdContacto = 1;
            theContact.Nombre = "Las";
            theContact.Apellido = "Bol";
            theContact.Departamento = "as";
            theContact.Cargo = "Gerente";
            theContact.Correo = "asd@asd.com";
            theContact.Telefono = "7654321";
            theContact.TipoCompañia = 1;
            theContact.IdCompañia = 1;


        }

        [TearDown]
        public void clean()
        {
            theContact = null;
        }
        #endregion

        [Test]
        public void UTAddContact()
        {
            DatosTangerine.M5.BDContacto prueba = new DatosTangerine.M5.BDContacto();
            answer = prueba.AddContact(theContact);
            Assert.IsTrue(answer);
        }
    }
}
