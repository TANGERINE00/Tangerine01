using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M6;
using LogicaTangerine.M6;
using DominioTangerine;

namespace PruebasUnitarias.M6
{
    class PruebalogicaM6
    {
        #region Atributos

        private Propuesta laPropuesta, laPropuesta2;
        private DateTime Date1,Date2;
        private LogicaPropuesta logicaM6;
        private BDPropuesta datosM6;
        private Boolean agregoPropuesta, agregoRequerimiento,agregoRequerimiento2, borroPropuesta, esAprobado;
        private List<Propuesta> listaPropuestas;
        private List<Requerimiento> listaRequerimientos;
        private int tamañoLista1, tamañoLista2;
        private Requerimiento elRequerimiento, elRequerimiento2;
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
            
            elRequerimiento = new Requerimiento();
            elRequerimiento2 = new Requerimiento();
            elRequerimiento.Descripcion = "desc prueba";
            elRequerimiento.CodigoRequerimiento = "codigo prueba";
            elRequerimiento.CodigoPropuesta = "Nombre prueba";

            elRequerimiento2.Descripcion = "desc prueba";
            elRequerimiento2.CodigoRequerimiento = "codigo prueba2";
            elRequerimiento2.CodigoPropuesta = "Nombre prueba";
            
            logicaM6 = new LogicaPropuesta();
            datosM6 = new BDPropuesta();
        }

    
        #endregion


        // <summary>
        //Prueba que pueda agrega una propuesta
        // </summary>
        [Test]
        public void TestAgregarPropuesta()
        {
            //Agregar una prueba
          
            Assert.IsTrue(BDPropuesta.agregarPropuesta(laPropuesta));
                        
            //Elimino la propuesta de prueba

            borroPropuesta=logicaM6.BorrarPropuesta("Nombre prueba");
                    
        }

        // <summary>
        //Prueba que efectivamente consulte una propuesta
        // </summary>
        [Test]
        public void TestConsultarPropuesta()
        {
            //Agrego una propuesta de prueba
            
            agregoPropuesta= BDPropuesta.agregarPropuesta(laPropuesta);

            if (agregoPropuesta == true)
            {
                //Consultar propuesta que acabo de agregar
                laPropuesta2 = new Propuesta();
                
                laPropuesta2 = BDPropuesta.ConsultarPropuestaporNombre("Nombre prueba");                
                Assert.AreEqual("Pendiente prueba", laPropuesta2.Estatus);
                
                //Elimino la propuesta de prueba
                borroPropuesta = logicaM6.BorrarPropuesta("Nombre prueba");
            
            }
        }

        // <summary>
       //Prueba que se listen las propuestas, insertando una propuesta y comprobando que la lista no este vacia
       // </summary>
       [Test]
       public void TestListarLasPropuestas() 
       {
           //Agrego una propuesta de prueba
           agregoPropuesta = BDPropuesta.agregarPropuesta(laPropuesta);

           if (agregoPropuesta == true)
           {
               listaPropuestas = BDPropuesta.ListarLasPropuestas();               
               Assert.IsNotEmpty(listaPropuestas);
               //Elimino la propuesta de prueba
               borroPropuesta = logicaM6.BorrarPropuesta("Nombre prueba");
           }

       }

       // <summary>
       //Prueba que el metodo no devuelva una lista vacia, y que todas las propuestas tienen estatus Aprobado
       // </summary>
       [Test]
       public void TestPropuestaProyecto()
       {
           //Agrego una propuesta de prueba
           agregoPropuesta = BDPropuesta.agregarPropuesta(laPropuesta);

           if (agregoPropuesta == true)
           {
               listaPropuestas = datosM6.PropuestaProyecto();
               Assert.IsNotEmpty(listaPropuestas);

               //Recorro toda la lista y para validar que todos sus estatos son aprobados
               listaPropuestas.ForEach(delegate(Propuesta valor)
               {
                   if (valor.Estatus == "Aprobado")
                       esAprobado = true;
                   else
                       esAprobado = false;

               });

               //Si esAprobado es falso es porque existe al menos un estatus que no es Aprobado
               Assert.IsTrue(esAprobado);
               
               //Elimino la propuesta de prueba
               borroPropuesta = logicaM6.BorrarPropuesta("Nombre prueba");
           }

       }


       // <summary>
       //Prueba que se agrega un requerimiento
       // </summary>
       [Test]
        public void TestAgregarRequerimiento()
       {
           //Agrego una propuesta de prueba
           agregoPropuesta = BDPropuesta.agregarPropuesta(laPropuesta);
           //Assert.IsTrue(agregoPropuesta);
           //Agregar un Requerimiento y pruebo que se agregó
           Assert.IsTrue(BDPropuesta.agregarRequerimiento(elRequerimiento));

           //Pruebo que el requerimieto pertenece a la propuesta que acabo de agregar
           listaRequerimientos = BDPropuesta.ConsultarRequerimientosPorPropuesta("Nombre prueba");

           Assert.AreEqual(listaRequerimientos.ElementAt(0).Descripcion,"desc prueba");
                     
           //Elimino la propuesta de prueba y el requerimiento asociado

           borroPropuesta = logicaM6.BorrarPropuesta("Nombre prueba");

       }


       // <summary>
       //Prueba que verifica que la lista de requerimientos no venga vacia y que los requerimientos 
       //de la lista pertenecen a la propuesta solicitada
       // </summary>
       [Test]
        public void TestConsultarRequerimientosPorPropuesta()
       {
         
           //Agrego una propuesta de prueba
           agregoPropuesta = BDPropuesta.agregarPropuesta(laPropuesta);

           //Agrego dos requerimientos a la propuesta
           agregoRequerimiento= BDPropuesta.agregarRequerimiento(elRequerimiento);
           agregoRequerimiento2 = BDPropuesta.agregarRequerimiento(elRequerimiento2);


           if (agregoPropuesta == true && agregoRequerimiento == true && agregoRequerimiento2 == true)
           {
               
               listaRequerimientos=BDPropuesta.ConsultarRequerimientosPorPropuesta("Nombre prueba");
               //Prueba que la lista no esta vacia               
               Assert.IsNotEmpty(listaRequerimientos);

              
               //Recorro toda la lista y para validar que los requerimientos pertenecen a La misma Propuesta
               foreach( Requerimiento valor in listaRequerimientos)
               {
                 

                   if (valor.Descripcion == "desc prueba")                                        
                       
                       esAprobado = true;
                   
                   else
                       esAprobado = false;

               };

               //Si esAprobado es falso es porque existe al menos un requerimiento que no pertenece a esa propuesta
               Assert.IsTrue(esAprobado);

               //Elimino la propuesta de prueba y sus requerimientos
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

