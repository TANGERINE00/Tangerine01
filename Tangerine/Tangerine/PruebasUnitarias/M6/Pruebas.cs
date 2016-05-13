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

        #endregion


        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            propuesta = new Propuesta();
            proyprop = new Proyecto();
            propuesta.CodigoP = "3";
            propuesta.Nombre = "SGC propuesta Sistema Gestión de cuentas";
            proyprop.Idpropuesta = 0;

        }

        [TearDown]
        public void clean()
        {
            propuesta = null;
        }
        #endregion















    }
}
