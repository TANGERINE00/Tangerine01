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
        public DateTime fecha = new DateTime(2015, 2, 10);
        public bool answer;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            theInvoice = new Facturacion();
            theInvoice.idFactura = 1;
            theInvoice.fechaFactura = fecha;
            theInvoice.montoFactura = 9000;
            theInvoice.montoRestanteFactura = 3000;

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
            //Declaro test de tipo BDFactura para poder invocar el "AddContact(Facturacion theInvoice)"
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
            answer = BDFactura.ChangeFactura(theInvoice);

            //answer obtiene true si se modifica la Factura, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar el eliminar de una Factura en la base de datos
        /// </summary>
        [Test]
        public void TestDeleteInvoice()
        {
            //Declaro test de tipo BDFactura para poder invocar el "DeleteInvoice(Facturacion theInvoice)"
            answer = BDFactura.DeleteFactura(theInvoice);

            //answer obtiene true si se elimina la Factura, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }
    }
}
