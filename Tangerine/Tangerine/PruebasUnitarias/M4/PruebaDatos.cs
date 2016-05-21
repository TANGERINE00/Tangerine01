using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M4;
using DominioTangerine;

namespace PruebasUnitarias.M4
{
    [TestFixture]
    public class PruebasDatos
    {
        #region Atributos
        public Compania theCompany;
        public Compania theCompany1;
        public bool answer;
        public bool answer1;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            theCompany = new Compania("Touch", "J-111111111", "asd@asd.com", "3434234", "ASD", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            theCompany1 = new Compania("CompaniaPrueba2", "J-111111112", "asdd@asdd.com", "34342344", "ADD", new DateTime(2015, 2, 10), 1, 100, 30, 1);
            
        }

        [TearDown]
        public void clean()
        {
            theCompany.IdCompania = BDCompania.ConsultLastCompanyId();
            answer1 = BDCompania.DeleteCompany(theCompany);
            theCompany = null;
        }
        #endregion

        /// <summary>
        /// Prueba que permite verificar el insertar de una compañía en la base de datos.
        /// </summary>
        [Test]
        public void TestAddCompany()
        {
            //Inserto una compañía.
            answer = BDCompania.AddCompany(theCompany);
            //Compruebo que el método de modificación finalizó correctamente.
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar el modificar de una compañía en la base de datos.
        /// </summary>
        [Test]
        public void TestChangeCompany()
        {
            //Inserto una compañía para posteriormente modificarla.
            answer1 = BDCompania.AddCompany(theCompany);
            //Aplico el método para modificar una compañía.
            answer = BDCompania.ChangeCompany(theCompany);
            //Compruebo que el método de modificación finalizó correctamente.
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite consultar compañía por su id en la base de datos.
        /// </summary>
        [Test]
        public void TestConsultCompany()
        {
            //Inserto la compañía para poder probar la consulta.
            answer1 = BDCompania.AddCompany(theCompany);
            //Aplico el metodo para consultar la companía agregada anteriormente.
            theCompany1 = BDCompania.ConsultCompany(BDCompania.ConsultLastCompanyId());
            //Comparo que el id de la companía creada coincide con el id de la compañía consultada.
            Assert.AreEqual(BDCompania.ConsultLastCompanyId(), theCompany1.IdCompania);
        }

        /// <summary>
        /// Prueba que permite verificar el consultar del último id de una companía en la base de datos.
        /// </summary>
        [Test]
        public void TestConsultLastCompanyId()
        {
            //Inserto una compañía
            answer1 = BDCompania.AddCompany(theCompany);
            //Consulto el ultimo id y lo almaceno.
            int ultimoId = BDCompania.ConsultLastCompanyId();
            //Inserto otra compañía.
            answer1 = BDCompania.AddCompany(theCompany1);
            //Compruebo que el id aumentó en 1.
            Assert.AreEqual(BDCompania.ConsultLastCompanyId(), ultimoId + 1);
        }

        /// <summary>
        /// Prueba que permite verificar el consultar de todas las compañías en la base de datos.
        /// </summary>
        [Test]
        public void TestConsultCompanies()
        {
            //Inserto una compañía por si la base de datos está vacía.
            answer1 = BDCompania.AddCompany(theCompany);
            //Consulto todas las compañías en la base de datos.
            List<Compania> companias = BDCompania.ConsultCompanies();
            //Recorro las compañías y verifico que su id no es nulo para corroborar que está extrayendo correctamente.
            foreach(Compania compania in companias){
                Assert.IsNotNull(compania.IdCompania);
            }
        }

        /// <summary>
        /// Prueba que permite verificar el inhabilitar de una companía en la base de datos.
        /// </summary>
        [Test]
        public void TestDisableCompany()
        {
            //Inserto la compañia para poder probar la deshabilitación.
            answer1 = BDCompania.AddCompany(theCompany);
            //Aplico el método sobre la compañía creada.
            answer = BDCompania.DisableCompany(theCompany);
            //Compruebo que el metodo de inhabilitación finalizó correctamente.
            Assert.IsTrue(answer);
        }
        /// <summary>
        /// Prueba que permite verificar el habilitar de una companía en la base de datos.
        /// </summary>
        [Test]
        public void TestEnableCompany()
        {
            //Inserto la compañía para poder probar la habilitación.
            answer1 = BDCompania.AddCompany(theCompany);
            //Aplico el método sobre la compañía creada.
            answer = BDCompania.EnableCompany(theCompany);
            //Compruebo que el metodo de habilitación finalizó correctamente.
            Assert.IsTrue(answer);
        }
    }
}

