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

        public Propuesta propuesta;
        public Propuesta propuesta1;
        public Proyecto proyprop;
        List<Propuesta> lapropuesta = new List<Propuesta>();
        public List<Propuesta> prueba;
        public List<Propuesta> prueba1;
        public bool answer;

        #endregion


        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            

        }

        [TearDown]
        public void clean()
        {
            propuesta = null;
        }

        #endregion


        [Test]

        public void TestListaPropuestaProyecto()
        {
           // answer = BDPropuesta.agregarPropuesta();

        }














    }
}
