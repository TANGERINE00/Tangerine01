using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DominioTangerine;
using LogicaTangerine.M3;
using DatosTangerine.M3;


namespace PruebasUnitarias.M3
{
    [TestFixture]
    class PruebaClientePotencialLogica
    {
        #region Atributos
        public ClientePotencial clientePot3;
        public LogicaM3 logicaM3;
        public bool answer;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            clientePot3 = new ClientePotencial("HP", "J-1221212", "info@hp.com", 12000, 0, 0, 3);
            logicaM3 = new LogicaM3();

        }

        [TearDown]
        public void clean()
        {
            clientePot3 = null;
            logicaM3 = null;
        }
        #endregion

        [Test]

        public void TestAgregarClientePotencialLogica()
        {
            //Declaro test de tipo Logico para poder invocar el "agregar de logica"
            answer = logicaM3.AgregarNuevoclientePotencial(clientePot3);
            //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }


        [Test]
        public void TestBorrarClientePotencialLogica()
        {

            answer = logicaM3.BorrarNuevoclientePotencial(clientePot3);
            //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);

        }

        [Test]
        public void TestConsultarClientePotencialLogica()
        {
            //Declaro test de tipo BDContacto para poder invocar el "AddContact(Contacto theContact)"

            Assert.IsNotNull(logicaM3.BuscarClientePotencial(clientePot3.IdClientePotencial));
        }


        [Test]
        public void TestModificarClientePotencialLogica()
        {
            //Declaro test de tipo BDContacto para poder invocar el "AddContact(Contacto theContact)"


            answer = logicaM3.ModificarNuevoclientePotencial(clientePot3);

            Assert.IsTrue(answer);
        }

        [Test]
        public void TestActivarClientePotencialLogica()
        {
            answer = logicaM3.ActivarclientePotencial(clientePot3);

            Assert.IsTrue(answer);

        }


    }
}



