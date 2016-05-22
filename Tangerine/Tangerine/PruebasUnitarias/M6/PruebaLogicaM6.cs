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
        private List<Propuesta> listaPropuestas;
        private int tamañoLista1, tamañoLista2;
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
            laPropuesta.Estatus = "Pendiente prueba";
            laPropuesta.Moneda = "Dolar";
            laPropuesta.Entrega=1;
            Date1 = new DateTime(2016, 6, 4);
            Date2 = new DateTime(2016, 7, 4);            
            laPropuesta.Feincio = Date1;
            laPropuesta.Feincio = Date2;
            laPropuesta.Costo = 100;
            laPropuesta.IdCompañia = "1";
            tamañoLista1 = 0;
            tamañoLista2=0;

            logicaM6 = new LogicaPropuesta();
            
        }

    
        #endregion


        // <summary>
        //Prueba que pueda agrega una propuesta
        // </summary>
        [Test]
        public void TestAgregarPropuesta()
        {
            //Agregar una prueba

            Assert.IsTrue(logicaM6.agregar(laPropuesta));

            //Elimino la propuesta de prueba

            borroPropuesta=logicaM6.BorrarPropuesta("Nombre prueba");
                    
        }

        // <summary>
        //Prueba que efectivamente traigo una propuesta
        // </summary>
        [Test]
        public void TestTraerPropuesta()
        {
            //Agrego una propuesta de prueba
            
            agregoPropuesta=logicaM6.agregar(laPropuesta);

            if (agregoPropuesta == true)
            {
                //Traer propuesta que acabo de agregar
                laPropuesta2 = new Propuesta();
                laPropuesta2 = logicaM6.TraerPropuesta("Nombre prueba");                
                Assert.AreEqual("Pendiente prueba", laPropuesta2.Estatus);
                
                //Elimino la propuesta de prueba
                borroPropuesta = logicaM6.BorrarPropuesta("Nombre prueba");
            
            }
        }

        // <summary>
       //Prueba que la lista no este vacia
       // </summary>
       [Test]
       public void TestConsultarTodasPropuestas() 
       {
           //Agrego una propuesta de prueba
           agregoPropuesta = logicaM6.agregar(laPropuesta);

           if (agregoPropuesta == true)
           {
               listaPropuestas=logicaM6.ConsultarTodasPropuestas();               
               Assert.IsNotEmpty(listaPropuestas);
               //Elimino la propuesta de prueba
               borroPropuesta = logicaM6.BorrarPropuesta("Nombre prueba");
           }

       }
       
       // <summary>
       //Prueba que borra una propuesta
       // </summary>
       [Test]
       public void TestBorrarPropuestas() 
       {

           listaPropuestas = logicaM6.ConsultarTodasPropuestas();
           tamañoLista1 = listaPropuestas.Capacity;

           Console.WriteLine("tam3: " + tamañoLista1);
           
           listaPropuestas = null;
           tamañoLista1 = 0;
           
           //Agrego primera propuesta de prueba
           agregoPropuesta = logicaM6.agregar(laPropuesta);

           if (agregoPropuesta == true)
           {               
               listaPropuestas=logicaM6.ConsultarTodasPropuestas();
               tamañoLista1=listaPropuestas.Capacity;

               Console.WriteLine("tam1: " + tamañoLista1);
               //Elimino la propuesta de prueba
               borroPropuesta = logicaM6.BorrarPropuesta("Nombre prueba");               
               
               listaPropuestas=logicaM6.ConsultarTodasPropuestas();
               tamañoLista2=listaPropuestas.Capacity;
               Console.WriteLine("tam2: " + tamañoLista2);
               Assert.Greater(tamañoLista1,tamañoLista2);
               
           }

       }


    }


    }

