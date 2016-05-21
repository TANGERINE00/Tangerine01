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
            clientePot3 = new ClientePotencial();
            logicaM3 = new LogicaM3();
            clientePot3.NombreClientePotencial = "HP";
            clientePot3.RifClientePotencial = "J-1221212";
            clientePot3.EmailClientePotencial = "info@hp.com";
            clientePot3.PresupuestoAnual_inversion = 12000;
            clientePot3.NumeroLlamadas = 0;
            clientePot3.NumeroVisitas = 0;
            clientePot3.IdClientePotencial = 1;

        }

        [TearDown]
        public void clean()
        {
            clientePot3 = null;
            logicaM3 = null;
        }
        #endregion

        [Test]

        public void TestAgregarClientePotencial()
        {
            //Declaro test de tipo Logico para poder invocar el "agregar de logica"
            answer = logicaM3.AgregarNuevoclientePotencial(clientePot3);
            //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }


        [Test]
        public void TestBorrarClientePotencial()
        {

            answer = logicaM3.BorrarNuevoclientePotencial(clientePot3);
            //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);

        }

        [Test]
        public void TestConsultarClientePotencial()
        {
            //Declaro test de tipo BDContacto para poder invocar el "AddContact(Contacto theContact)"

            Assert.IsNotNull(logicaM3.BuscarClientePotencial(clientePot3.IdClientePotencial));
        }


        [Test]
        public void TestModificarClientePotencial()
        {
            //Declaro test de tipo BDContacto para poder invocar el "AddContact(Contacto theContact)"


            answer = logicaM3.ModificarNuevoclientePotencial(clientePot3);

            Assert.IsTrue(answer);
        }




    }
}



