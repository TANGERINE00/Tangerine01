using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DatosTangerine.M6;
using DatosTangerine.M7;
using DominioTangerine;

namespace PruebasUnitarias.M6
{

    [TestFixture]


    class Pruebas
    {
        #region Atributos

        private BDPropuesta baseDeDatosPropuesta;
        

        #endregion


        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            baseDeDatosPropuesta = new BDPropuesta();

        }

        //[TearDown]
        //public void clean()
        //{
        //    propuesta = null;
        //}

        #endregion


        [Test]

        public void TestListaPropuestaProyecto()
        {

            Assert.IsTrue(baseDeDatosPropuesta.PropuestaProyecto().Count>0);

        }














    }
}
