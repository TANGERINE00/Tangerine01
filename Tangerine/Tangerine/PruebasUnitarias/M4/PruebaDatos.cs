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
            theCompany = new Compania("Touch", "J-111111111", "asd@asd.com", "3434234", "ASD", new DateTime(2015, 2, 10), 1, 1);
        }

        [TearDown]
        public void clean()
        {
            answer1 = BDCompania.DeleteCompany(theCompany);
            theCompany = null;
        }
        #endregion

        /// <summary>
        /// Prueba que permite verificar el insertar de una compañía en la base de datos
        /// </summary>
        [Test]
        public void TestAddCompany()
        {
            //Declaro test de tipo BDCompania para poder invocar el "AddCompania(Company theCompany)"
            answer = BDCompania.AddCompany(theCompany);

            //answer obtiene true si se inserta la compania, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar el modificar de una compania en la base de datos
        /// </summary>
        [Test]
        public void TestChangeCompany()
        {
            //Inserto la compañia para poder probar el cambio
            answer1 = BDCompania.AddCompany(theCompany);
            //Declaro test de tipo BDCompany para poder invocar el "ChangeCompany(Company theCompany)"
            answer = BDCompania.ChangeCompany(theCompany);

            //answer obtiene true si se modifica la compania, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite consultar compania por su id en la base de datos
        /// </summary>
        [Test]
        public void TestConsultCompany()
        {
            //Inserto la compañia para poder probar la consulta
            answer1 = BDCompania.AddCompany(theCompany);
            //Declaro test de tipo BDCompany para poder invocar el "ChangeCompany(Company theCompany)"
            theCompany1 = BDCompania.ConsultCompany(theCompany.IdCompania);
            //answer obtiene true si se modifica la compania, si no, deberia agarrar un excepcion
            Assert.AreEqual(theCompany1, theCompany);
        }

        /// <summary>
        /// Prueba que permite verificar el inhabilitar de una compania en la base de datos
        /// </summary>


        [Test]
        public void TestDisableCompany()
        {
            //Inserto la compañia para poder probar la deshabilitacion
            answer1 = BDCompania.AddCompany(theCompany);
            //Declaro test de tipo BDContacto para poder invocar el "DisableCompany(Company theCompany)"
            answer = BDCompania.DisableCompany(theCompany);
            //answer obtiene true si se deshabilita la compania, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }
        /// <summary>
        /// Prueba que permite verificar el habilitar de una compania en la base de datos
        /// </summary>
        [Test]
        public void TestEnableCompany()
        {
            //Inserto la compañia para poder probar la habilitacion
            answer1 = BDCompania.AddCompany(theCompany);
            //Declaro test de tipo BDContacto para poder invocar el "EnableCompany(Company theCompany)"
            answer = BDCompania.EnableCompany(theCompany);
            //answer obtiene true si se deshabilita la compania, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }
    }
}

