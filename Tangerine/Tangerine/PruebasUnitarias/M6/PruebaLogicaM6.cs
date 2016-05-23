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
        private Boolean agregoPropuesta, borroPropuesta, modifico;
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




            laPropuesta2.CodigoP = "123";
            laPropuesta2.Nombre = "Nombre prueba";
            laPropuesta2.Descripcion = "Desc prueba2";
            laPropuesta2.TipoDuracion = "Meses";
            laPropuesta2.CantDuracion = "2";
            laPropuesta2.Acuerdopago = "acuerdo";
            laPropuesta2.Estatus = "Pendiente prueba";
            laPropuesta2.Moneda = "Dolar";
            laPropuesta2.Entrega = 1;
            Date1 = new DateTime(2016, 6, 4);
            Date2 = new DateTime(2016, 7, 4);
            laPropuesta2.Feincio = Date1;
            laPropuesta2.Feincio = Date2;
            laPropuesta2.Costo = 100;
            laPropuesta2.IdCompañia = "1";


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
           //Agrego primera propuesta de prueba
           agregoPropuesta = logicaM6.agregar(laPropuesta);

           if (agregoPropuesta == true)
           {               
               listaPropuestas=logicaM6.ConsultarTodasPropuestas();
               tamañoLista1=listaPropuestas.Count;

               //Elimino la propuesta de prueba
               borroPropuesta = logicaM6.BorrarPropuesta("Nombre prueba");               
               
               listaPropuestas=logicaM6.ConsultarTodasPropuestas();
               tamañoLista2 = listaPropuestas.Count;               
               Assert.Greater(tamañoLista1,tamañoLista2);               
           }
       }

        
       // <summary>
       //Prueba que modifica una propuesta
       // </summary>
       [Test]
       public void TestModificar_Propuesta() 
       {              
           //Agrego una propuesta de prueba
           agregoPropuesta = logicaM6.agregar(laPropuesta);

           if (agregoPropuesta == true)
           {
               
               modifico=logicaM6.ModificarPropuesta(laPropuesta2);
               Assert.IsTrue(modifico);

               listaPropuestas = logicaM6.ConsultarTodasPropuestas();
               
               //Recorro toda la lista y para validar que esta la propuesta con descripcion= desc prueba2
               //que acabo de cambiar
               foreach (Propuesta valor in listaPropuestas)
               {

                   if (valor.Descripcion == "Desc prueba2")
                  
                       modifico = true;
                   
                   else
                       modifico = false;

               };

               //Si modifico es falso es porque no existe y por ende no hubo modificacion
               Assert.IsTrue(modifico);
               

               //Elimino la propuesta de prueba
               borroPropuesta = logicaM6.BorrarPropuesta("Nombre prueba");    
               
              
               
           }

       }
        
        
    }


    }

