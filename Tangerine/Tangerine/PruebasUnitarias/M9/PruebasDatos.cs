using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M9;
using DominioTangerine;

namespace PruebasUnitarias.M9
{
    class PruebasDatos
    {
        #region Atributos

        public Pago pago;
        public double monto;
        public bool answer;
        public DateTime fecha = new DateTime(2015, 2, 10);

        #endregion

        #region SetUp and TearDown

        [SetUp]
        public void init()
        {


            pago = new Pago(1, 100, "Euros", "Transferencia", 1234567890, DateTime.Now, 1);

        }

        [TearDown]
        public void clean()
        {
            pago = null;
        }

        #endregion

        #region Test

        /// <summary>
        /// Prueba que permite verificar el insertar de un pago en la base de datos
        /// </summary>
        [Test]
        public void TestAddInvoice()
        {
            answer = BDPagos.CargarPago(pago);

            //answer obtiene true si se inserta el pago, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar el modificar de una Factura en la base de datos
        /// </summary>
 
        #endregion


    }
}