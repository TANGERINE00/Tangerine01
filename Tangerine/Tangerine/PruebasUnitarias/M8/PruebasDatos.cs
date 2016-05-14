using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M8;
using DominioTangerine;

namespace PruebasUnitarias.M8
{
    class PruebasDatos
    {

        #region Atributos
        public Facturacion theInvoice;
        public Facturacion theInvoice2;
        public Facturacion theInvoice3;
        public bool answer;
        public DateTime fecha = new DateTime(2015, 2, 10);
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            theInvoice = new Facturacion(DateTime.Now, 100, 50,"Hola",0,1,1);
            theInvoice2 = new Facturacion(1, DateTime.Now, 100, 50, "PruebaModificacion", 0, 1, 1);


        }

        [TearDown]
        public void clean()
        {
            theInvoice = null;
        }
        #endregion

        /// <summary>
        /// Prueba que permite verificar el insertar de una Factura en la base de datos
        /// </summary>
        [Test]
        public void TestAddInvoice()
        {
            //Declaro test de tipo BDFactura para poder invocar el "AddInvoice(Facturacion theInvoice)"
            answer = BDFactura.AddFactura(theInvoice);

            //answer obtiene true si se inserta la Factura, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar el modificar de una Factura en la base de datos
        /// </summary>
        [Test]
        public void TestChangeInvoice()
        {
            //Declaro test de tipo BDFactura para poder invocar el "ChangeContact(Facturacion theInvoice)"
            
            answer = BDFactura.ChangeFactura(theInvoice2);

            //answer obtiene true si se modifica la Factura, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar el anular de una Factura en la base de datos
        /// </summary>
        [Test]
        public void TestAnnularInvoice()
        {

            theInvoice3 = new Facturacion(1, DateTime.Now, 100, 50, "PruebaAnulacion", 0, 1, 1);
            //Declaro test de tipo BDFactura para poder invocar el "AnnularInvoice(Facturacion theInvoice)"
            answer = BDFactura.AnnularFactura(theInvoice3);

            //answer obtiene true si se anula la Factura, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }
    }
}
