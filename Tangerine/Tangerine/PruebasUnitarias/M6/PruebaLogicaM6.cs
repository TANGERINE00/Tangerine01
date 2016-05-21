using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.M6;
using DominioTangerine;


namespace PruebasUnitarias.M6
{
    
        
    [TestFixture]

    class PruebaLogicaM6
    {

        #region Atributos

        private Propuesta laPropuesta, laPropuesta2;
        private DateTime Date1,Date2;
        private LogicaPropuesta logicaM6;
        private Boolean agregoPropuesta, borroPropuesta;
        
        #endregion


        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            laPropuesta = new Propuesta();
            laPropuesta2 = new Propuesta();
            laPropuesta.CodigoP = "123";
            laPropuesta.Nombre = "Nombre prueba";
            laPropuesta.Descripcion = "Desc prueba";
            laPropuesta.TipoDuracion = "Meses";
            laPropuesta.CantDuracion = "2";
            laPropuesta.Acuerdopago = "acuerdo";
            laPropuesta.Estatus = "Pendiente";
            laPropuesta.Moneda = "Dolar";
            laPropuesta.Entrega=1;
            Date1 = new DateTime(2016, 6, 4);
            Date2 = new DateTime(2016, 7, 4);            
            laPropuesta.Feincio = Date1;
            laPropuesta.Feincio = Date2;
            laPropuesta.Costo = 100;
            laPropuesta.IdCompañia = "1";

            logicaM6 = new LogicaPropuesta();
            
        }

    
        #endregion


        [Test]
        public void AgregarPropuesta()
        {
            //Agregar una prueba

            Assert.IsTrue(logicaM6.agregar(laPropuesta));

            //Elimino la propuesta de prueba

            borroPropuesta=logicaM6.BorrarPropuesta("Nombre prueba");
                    
        }

       [Test]
        public void TraerPropuesta()
        {
            //Agrego una propuesta de prueba
            
            agregoPropuesta=logicaM6.agregar(laPropuesta);

            if (agregoPropuesta == true)
            {
                //Traer propuesta que acabo de agregar
                laPropuesta2 = new Propuesta();
                laPropuesta2 = logicaM6.TraerPropuesta("Nombre prueba");

                Assert.AreEqual(laPropuesta2.Nombre, "Nombre prueba");
 
            }
        }




    }
}
