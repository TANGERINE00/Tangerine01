using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioTangerine;
using DatosTangerine.M3;

namespace PruebasUnitarias.M3
{
    [TestFixture]
    class PruebaClientePotencial
    {
        #region Atributos
        public ClientePotencial clientePot1;
        public ClientePotencial clientePot2;
        public bool answer;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            clientePot1 = new ClientePotencial("HP", "J-1221212", "info@hp.com", 12000,0,0,0);

            
        }

        [TearDown]
        public void clean()
        {
            BDClientePotencial.BorrarClientePotencial(clientePot1);
            clientePot1 = null;
            clientePot2 = null;

        }

        #endregion
        [Test]
        public void TestAddClientePotencial()
        {
            //Declaro test de tipo BDContacto para poder invocar el "AddContact(Contacto theContact)"
            answer = BDClientePotencial.AgregarClientePotencial(clientePot1);
            //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }

        [Test]
        public void TestDeleteClientePotencial()
        {
            //Declaro test de tipo BDContacto para poder invocar el "AddContact(Contacto theContact)"
            answer = BDClientePotencial.BorrarClientePotencial(clientePot1);
            //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }

        [Test]
        public void TestConsultClientePotencial()
        {
            //Declaro test de tipo BDContacto para poder invocar el "AddContact(Contacto theContact)"
    
            Assert.IsNotNull(BDClientePotencial.ConsultarClientePotencial(clientePot1.IdClientePotencial));
        }
        [Test]
        public void TestModificarClientePotencial()
        {
            //Declaro test de tipo BDContacto para poder invocar el "AddContact(Contacto theContact)"
       
            
            answer = BDClientePotencial.ModificarClientePotencial(clientePot1);

            Assert.IsTrue(answer);
        }


    }
}
