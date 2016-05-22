using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.M8;
using DominioTangerine;
using System;

namespace PruebasUnitarias.M8
{
    class PruebasLogica
    {

        #region Atributos

        private LogicaM8 Logica;
        public Facturacion theInvoice;
        public Facturacion theInvoice2;
        public Facturacion theInvoice3;
        private List<Facturacion> facturas;
        public double monto;
        public bool answer;
        public DateTime fecha = new DateTime(2015, 2, 10);

        #endregion

        #region SetUp and TearDown


        [SetUp]
        public void init()
        {
            Logica = new LogicaM8();
            theInvoice = new Facturacion(DateTime.Now, DateTime.Now, 100, 50, "Bolivares", "Hola", 0, 1, 1);
            theInvoice2 = new Facturacion(1, DateTime.Now, DateTime.Now, 100, 50, "Bolivares", "PruebaModificacion", 0, 1, 1);

        }

        [TearDown]
        public void clean()
        {
            theInvoice = null;
        }

        #endregion

        #region Test

        /// <summary>
        /// Prueba que permite verificar el insertar de una Factura en la base de datos
        /// </summary>
        [Test]
        public void TestAddNewFactura()
        {
            answer = Logica.AddNewFactura(theInvoice);

            //answer obtiene true si se inserta la Factura, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar el modificar de una Factura en la base de datos
        /// </summary>        
        [Test]
        public void TestChangeExistingFactura()
        {
             answer = Logica.ChangeExistingFactura(theInvoice2);

             //answer obtiene true si se modifica la Factura, si no, deberia agarrar un excepcion
             Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar el anular de una Factura en la base de datos
        /// </summary>
        [Test]
        public void TestAnnularInvoice()
        {
            theInvoice3 = new Facturacion(1, DateTime.Now, DateTime.Now, 100, 50, "Bolivares", "PruebaAnulacion", 0, 1, 1);
            answer = Logica.AnnularFactura(theInvoice3);

            //answer obtiene true si se anula la Factura, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar si existe la Factura con id 1  en la base de datos
        /// </summary>
        [Test]
        public void TestSearchFactura()
        {
            theInvoice = Logica.SearchFactura(1);

            //answer obtiene true si se encuentra la factura en la BD, si no, deberia agarrar un excepcion
            Assert.IsTrue(1 == theInvoice.idFactura);


        }

        /// <summary>
        /// Prueba que permite verificar el metodo para obtener todas las facturas en la base de datos
        /// </summary>
        [Test]
        public void TestgetFacturas()
        {
            facturas = Logica.getFacturas();

            //answer obtiene true si se encuentra las facturas en la BD, si no, deberia agarrar un excepcion
            for (int i = 0; i < facturas.Count(); i++)
            {

                Assert.IsTrue(i + 1 == facturas[i].idFactura);
            }

        }

        // <summary>
        /// Prueba que permite verificar el metodo para obtener una compañia en especifico en la base de datos
        /// </summary>
        [Test]
        public void TestSearchCompaniaFactura()
        {
            Compania theCompany = new Compania();
            theCompany = Logica.SearchCompaniaFactura(1);

            Assert.IsTrue(1 == theCompany.IdCompania);


        }

        /// <summary>
        /// Prueba que permite verificar el metodo para buscar todas las facturas asociadas a una compañia en la base de datos
        /// </summary>
        [Test]
        public void TestSearchProyectoFactura()
        {
            Proyecto theProject = new Proyecto();
            theProject = Logica.SearchProyectoFactura(1);

            Assert.IsNotNull(theProject);



        }

        /// <summary>
        /// Prueba que permite verificar el metodo para obtener un Proyecto específico que pertenecen a la base de datos
        /// </summary>    
        [Test]
        public void TestSearchFacturasCompania()
        {
            facturas = Logica.SearchFacturasCompania(1);

            Assert.AreEqual(6, facturas.Count());

        }

        /// <summary>
        /// Prueba que permite verificar el metodo para obtener un Proyecto específico que pertenecen a la base de datos
        /// </summary>
        [Test]
        public void TestContactMontoRestanteFactura()
        {
            monto = Logica.SearchMontoRestanteFactura(1);

            Assert.NotNull(monto);

        }
                
        #endregion

    }
}
