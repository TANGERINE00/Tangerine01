using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.M4;
using DominioTangerine.Fabrica;
using DominioTangerine.Entidades.M4;
using DominioTangerine;
using DatosTangerine.M4;
using LogicaTangerine.Fabrica;
using LogicaTangerine;

namespace PruebasUnitarias.M4
{
    [TestFixture]
    public class PruebaLogica
    {
        #region Atributos
        public Entidad theCompany;
        public Entidad theCompany1;
        public Entidad theCompany2;
        public bool answer;
        public bool answer1;
        LogicaM4 Logica = new LogicaM4();
        #endregion

        #region Setup&TearDown

        [SetUp]
        public void setup()
        {
            theCompany = FabricaEntidades.CrearEntidadCompaniaM4Llena(5,"CompaniaPrueba3", "J-111111113", "asd@asdddd.com", "3434234", "ASS", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            theCompany1 = FabricaEntidades.CrearEntidadCompaniaM4Llena(1,"CompaniaPrueba4", "J-111111114", "asdd@asddddd.com", "34342344", "AAS", new DateTime(2015, 2, 10), 1, 100, 30, 1);

        }

        [TearDown]
        public void clean()
        {
            theCompany = null;
            theCompany1 = null;
        }
        #endregion

        #region Tests

        /// <summary>
        /// Prueba que permite verificar el agregar una compañía a la base de datos.
        /// </summary>
        [Test]
        public void TestAddNewCompany()
        {
            Comando<bool> Comand = FabricaComandos.CrearAgregarCompania(theCompany);
            Assert.IsTrue(Comand.Ejecutar());
            Comando<Entidad> Comand2 = FabricaComandos.CrearConsultarCompania(theCompany);
            theCompany2 = Comand2.Ejecutar();
            Assert.IsTrue(theCompany2.Id == 5);
          
        }

        /// <summary>
        /// Prueba que permite la búsqueda de una compañía a la base de datos
        /// </summary>
        [Test]
        public void TestGet()
        {
           
            Comando<Entidad> Comand2 = FabricaComandos.CrearConsultarCompania(theCompany1);
            theCompany2 = Comand2.Ejecutar();
            Assert.IsTrue(theCompany2.Id == 1);
            
        }

        /// <summary>
        /// Prueba que permite verificar el consultar de todas las companías en la base de datos.
        /// </summary>
        [Test]
        public void TestGetAll()
        {
            Comando<List<Entidad>> Comand2 = FabricaComandos.CrearConsultarTodasCompania();
            List<Entidad> Companias = Comand2.Ejecutar();
            for (int i = 0; i < Companias.Count(); i++)
            {

                Assert.IsTrue(Companias[i].Id != 0);
            }
            
        }

       

        /// <summary>
        /// Prueba que permite la búsqueda de una compañía a la base de datos.
        /// </summary>
        [Test]
        public void TestEnableCompany()
        {
            
        }

        /// <summary>
        /// Prueba que permite la búsqueda de una compañía a la base de datos.
        /// </summary>
        [Test]
        public void TestDisableCompany()
        {
            
        }
        #endregion

        /// <summary>
        /// Prueba que permite verificar el consultar de lugares en la base de datos.
        /// </summary>
        [Test]
        public void TestConsultPlaces()
        {
           
        }
        /// <summary>
        /// Prueba que permite verificar la busqueda de un Id por un nombre de Lugar en la base de datos.
        /// </summary>
        [Test]
        public void TestMatchIdLugar()
        {
            //Verifico que el método devuelva el id=5 si se consulta por "Caracas". Caracas siempre estará en la base de datos con id 5.
            Assert.AreEqual(5, Logica.MatchIdLugar("Caracas"));
        }

        /// <summary>
        /// Prueba que permite verificar la busqueda de un nombre de lugar por su id de Lugar en la base de datos.
        /// </summary>
        [Test]
        public void TestMatchNombreLugar()
        {
            //Verifico que el método devuelva el id=5 si se consulta por "Caracas". Caracas siempre estará en la base de datos con id 5.
            Assert.AreEqual("Caracas", Logica.MatchNombreLugar(5));
        }
    }
}
