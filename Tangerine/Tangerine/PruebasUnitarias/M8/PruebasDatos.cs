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
        public double monto;
        private List<Facturacion> facturas;
        public bool answer;
        public DateTime fecha = new DateTime(2015, 10, 11);

        #endregion

        #region SetUp and TearDown

        [SetUp]
        public void init()
        {
            theInvoice = new Facturacion(DateTime.Now,DateTime.Now,100,100,"Dolares","Proyecto de diseño",0,1,1);
            theInvoice2 = new Facturacion(1, DateTime.Now, DateTime.Now, 100,100,"Dolares","Prueba Modificacion",0,1,1);

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
        public void TestAddInvoice()
        {
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
            theInvoice3 = new Facturacion(1, DateTime.Now, DateTime.Now, 100, 50, "Bolivares", "PruebaAnulacion", 0, 1, 1);
            answer = BDFactura.AnnularFactura(theInvoice3);

            //answer obtiene true si se anula la Factura, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }

        /// <summary>
        /// Prueba que permite verificar si existe la Factura con id 1  en la base de datos
        /// </summary>
        [Test]
        public void TestContactInvoice()
        {
            theInvoice = BDFactura.ContactFactura(1);

            //answer obtiene true si se encuentra la factura en la BD, si no, deberia agarrar un excepcion
            Assert.IsTrue(1 == theInvoice.idFactura);

            
        }


        /// <summary>
        /// Prueba que permite verificar el metodo para obtener todas las facturas en la base de datos
        /// </summary>
        [Test]
        public void TestContactFacturas()
        {
            facturas = BDFactura.ContactFacturas();

            //answer obtiene true si se encuentra las facturas en la BD, si no, deberia agarrar un excepcion
            for (int i = 0; i < facturas.Count(); i++)
            {
                Assert.IsTrue(i + 1 == facturas[i].idFactura);
            }

        }




        /// <summary>
        /// Prueba que permite verificar el metodo para obtener una compañia en especifico en la base de datos
        /// </summary>
        [Test]
        public void TestContactCompany()
        {
            Compania theCompany = new Compania();
            theCompany = BDFactura.ConsultCompany(1);

            Assert.IsTrue(1 == theCompany.IdCompania);


        }

        /// <summary>
        /// Prueba que permite verificar el metodo para buscar todas las facturas asociadas a una compañia en la base de datos
        /// </summary>
        [Test]
        public void TestContactProyectoFactura()
        {
            Proyecto theProject = new Proyecto();
            theProject = BDFactura.ContactProyectoFactura(1);

            Assert.IsNotNull(theProject);
            


        }

        /// <summary>
        /// Prueba que permite verificar el metodo para obtener un Proyecto específico que pertenecen a la base de datos
        /// </summary>
        [Test]
        public void TestContactFacturaCompania()
        {
            facturas = BDFactura.ContactFacturasCompania(1);

            Assert.AreEqual( 3 , facturas.Count() );

        }

        

    

        /// <summary>
        /// Prueba que permite verificar el metodo para obtener un Proyecto específico que pertenecen a la base de datos
        /// </summary>
        [Test]
        public void TestContactMontoRestanteFactura()
        {
            monto = BDFactura.ContactMontoRestanteFactura(1);

            Assert.NotNull(monto);

        }

        /// <summary>
        /// Prueba que permite verificar el metodo para saber si ya existe la factura especifica en la base de datos
        /// </summary>
        [Test]
        public void TestCheckExistingInvoice()
        {
            answer = BDFactura.CheckExistingInvoice(fecha,1,2);

            Assert.IsTrue(answer);

        }
        #endregion

    }
}
