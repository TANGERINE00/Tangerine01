using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.M4;
using DominioTangerine;
using DatosTangerine.M4;

namespace PruebasUnitarias.M4
{
    [TestFixture]
    public class PruebaLogica
    {
        #region Atributos
        public Compania theCompany;
        public Compania theCompany1;
        public bool answer;
        public bool answer1;
        LogicaM4 Logica = new LogicaM4();
        #endregion

        #region Setup&TearDown

        [SetUp]
        public void setup()
        {
            theCompany = new Compania("CompaniaPrueba3", "J-111111113", "asd@asdddd.com", "3434234", "ASS", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            theCompany1 = new Compania("CompaniaPrueba4", "J-111111114", "asdd@asddddd.com", "34342344", "AAS", new DateTime(2015, 2, 10), 1, 100, 30, 1);

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
        /// Prueba que permite verificar el consultar de todas las companías en la base de datos.
        /// </summary>
        [Test]
        public void TestGetCompanies()
        {
            //Inserto una compañía por si la base de datos está vacía.
            answer1 = Logica.AddNewCompany(theCompany);
            //Consulto todas las compañías en la base de datos.
            List<Compania> companias = Logica.getCompanies();
            //Recorro las compañías y verifico que su id no es nulo para corroborar que está extrayendo correctamente.
            foreach (Compania compania in companias)
            {
                Assert.IsNotNull(compania.IdCompania);
            }
        }

        /// <summary>
        /// Prueba que permite verificar el agregar una compañía a la base de datos.
        /// </summary>
        [Test]
        public void TestAddNewCompany()
        {
            //Inserto una compañía.
            answer = Logica.AddNewCompany(theCompany);
            //Compruebo que el método de modificación finalizó correctamente.
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite la búsqueda de una compañía a la base de datos.
        /// </summary>
        [Test]
        public void TestChangeCompany()
        {
            //Inserto una compañía para posteriormente modificarla.
            answer1 = Logica.AddNewCompany(theCompany);
            theCompany.IdCompania = BDCompania.ConsultLastCompanyId();
            theCompany.NombreCompania = "Nombremodificado";
            //Aplico el método para modificar una compañía.
            answer = Logica.ChangeCompany(theCompany);
            //Compruebo que el método de modificación finalizó correctamente.
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite la búsqueda de una compañía a la base de datos.
        /// </summary>
        [Test]
        public void TestSearchCompany()
        {
            //Inserto la compañía para poder probar la consulta.
            answer1 = Logica.AddNewCompany(theCompany);
            //Aplico el metodo para consultar la companía agregada anteriormente.
            theCompany1 = Logica.SearchCompany(BDCompania.ConsultLastCompanyId());
            //Comparo que el id de la companía creada coincide con el id de la compañía consultada.
            Assert.AreEqual(BDCompania.ConsultLastCompanyId(), theCompany1.IdCompania);
        }

        /// <summary>
        /// Prueba que permite la búsqueda de una compañía a la base de datos.
        /// </summary>
        [Test]
        public void TestEnableCompany()
        {
            //Inserto la compañía para poder probar la habilitación.
            answer1 = Logica.AddNewCompany(theCompany);
            //Aplico el método sobre la compañía creada.
            answer = Logica.EnableCompany(theCompany);
            //Compruebo que el metodo de habilitación finalizó correctamente.
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite la búsqueda de una compañía a la base de datos.
        /// </summary>
        [Test]
        public void TestDisableCompany()
        {
            //Inserto la compañia para poder probar la deshabilitación.
            answer1 = Logica.AddNewCompany(theCompany);
            //Aplico el método sobre la compañía creada.
            answer = Logica.DisableCompany(theCompany);
            //Compruebo que el metodo de inhabilitación finalizó correctamente.
            Assert.IsTrue(answer);
        }
        #endregion

        /// <summary>
        /// Prueba que permite verificar el consultar de lugares en la base de datos.
        /// </summary>
        [Test]
        public void TestConsultPlaces()
        {
            //Consulto los lugares que son Ciudad que se hallan en la base de datos.
            List<LugarDireccion> lugares = Logica.getPlaces();
            //Recorro los lugares y verifico que su id no es nulo para corroborar que está extrayendo correctamente.
            foreach (LugarDireccion lugar in lugares)
            {
                Assert.IsNotNull(lugar.LugId);
            }
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
