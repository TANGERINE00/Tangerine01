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
            //Declaro test de tipo BDFactura para poder invocar el "AddInvoice(Facturacion theInvoice)"
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
                    //Declaro test de tipo BDFactura para poder invocar el "ChangeContact(Facturacion theInvoice)"

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
                    //Declaro test de tipo BDFactura para poder invocar el "AnnularInvoice(Facturacion theInvoice)"
                    answer = Logica.AnnularFactura(theInvoice3);

                    //answer obtiene true si se anula la Factura, si no, deberia agarrar un excepcion
                    Assert.IsTrue(answer);
                }
        

                [Test]
                public void TestSearchFactura()
                {
                    //Declaro test de tipo BDFactura para poder invocar el "AddInvoice(Facturacion theInvoice)"
                    theInvoice = Logica.SearchFactura(1);

                    //answer obtiene true si se encuentra la factura en la BD, si no, deberia agarrar un excepcion
                    Assert.IsTrue(1 == theInvoice.idFactura);


                }
        
                [Test]
                public void TestgetFacturas()
                {
                    //Declaro test de tipo BDContacto para poder invocar el "AddContact(Contacto theContact)"
                    facturas = Logica.getFacturas();

                    //answer obtiene true si se encuentra las facturas en la BD, si no, deberia agarrar un excepcion
                    for (int i = 0; i < facturas.Count(); i++)
                    {

                        Assert.IsTrue(i + 1 == facturas[i].idFactura);
                    }

                }

        



                [Test]
                public void TestSearchCompaniaFactura()
                {
                    Compania theCompany = new Compania();
                    //Declaro test de tipo BDFactura para poder invocar el "AddInvoice(Facturacion theInvoice)"
                    theCompany = Logica.SearchCompaniaFactura(1);

                    //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
                    Assert.IsTrue(1 == theCompany.IdCompania);


                }
        
                [Test]
                public void TestSearchProyectoFactura()
                {
                    Proyecto theProject = new Proyecto();
                    //Declaro test de tipo BDFactura para poder invocar el "ContactProyectoFactura"
                    theProject = Logica.SearchProyectoFactura(1);

                    //Verifico si el proyecto existe
                    //Assert.IsTrue(1 == theProject.Idproyecto);
                    Assert.IsNotNull(theProject);



                }
        
                [Test]
                public void TestSearchFacturasCompania()
                {
                    //Declaro test de tipo BDFactura para poder invocar el "ContactFacturasCompania(int idCompania)"
                    facturas = Logica.SearchFacturasCompania(1);

                    //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
                    Assert.AreEqual(6, facturas.Count());

                }
                
        #endregion

    }
}
