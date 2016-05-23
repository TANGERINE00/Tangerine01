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
        private Boolean agregoPropuesta, agregoRequerimiento, agregoRequerimiento2, borroPropuesta, esAprobado, modifico;
        private List<Propuesta> listaPropuestas;
        private List<Requerimiento> listaRequerimientos;
        private int tamañoLista1, tamañoLista2;
        private Requerimiento elRequerimiento, elRequerimiento2, elRequerimiento3;
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
            elRequerimiento3 = new Requerimiento();
            elRequerimiento.Descripcion = "desc prueba";
            elRequerimiento.CodigoRequerimiento = "codigo123";
            elRequerimiento.CodigoPropuesta = "Nombre prueba";

            elRequerimiento2.Descripcion = "desc prueba";
            elRequerimiento2.CodigoRequerimiento = "codigo123";
            elRequerimiento2.CodigoPropuesta = "Nombre prueba";

            elRequerimiento3.Descripcion = "desc prueba3";
            elRequerimiento3.CodigoRequerimiento = "codigo1234";
            elRequerimiento3.CodigoPropuesta = "Nombre prueba";
            
            logicaM6 = new LogicaPropuesta();
            datosM6 = new BDPropuesta();

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
        }

    
        #endregion


        // <summary>
        //Prueba que pueda agrega una propuesta
        // </summary>
        [Test]
        public void TestDatosAgregarPropuesta()
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
        public void TestDatosConsultarPropuesta()
        {
            //Agrego una propuesta de prueba
            
            agregoPropuesta= BDPropuesta.agregarPropuesta(laPropuesta);

            if (agregoPropuesta == true)
            {
                //Consultar propuesta que acabo de agregar
                laPropuesta2 = new Propuesta();
                
                laPropuesta2 = BDPropuesta.ConsultarPropuestaporNombre("Nombre prueba");                
               
                //Confirmo que la propuesta es la que tiene status pendiente prueba
                Assert.AreEqual("Pendiente prueba", laPropuesta2.Estatus);
                
                //Elimino la propuesta de prueba
                borroPropuesta = logicaM6.BorrarPropuesta("Nombre prueba");
            
            }
        }

        // <summary>
       //Prueba que se listen las propuestas, insertando una propuesta y comprobando que la lista no este vacia
       // </summary>
       [Test]
        public void TesDatostListarLasPropuestas() 
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
       public void TestDatosPropuestaProyecto()
       {
           //Agrego una propuesta de prueba
           agregoPropuesta = BDPropuesta.agregarPropuesta(laPropuesta);

           if (agregoPropuesta == true)
           {
               listaPropuestas = datosM6.PropuestaProyecto();
               Assert.IsNotEmpty(listaPropuestas);

               //Recorro toda la lista y para validar que todos sus estatos son aprobados
               foreach(Propuesta valor in listaPropuestas)
               {
                  
                   if (valor.Estatus == "Aprobado")
                       esAprobado = true;
                   else
                       esAprobado = false;

               };

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
       public void TestDatosAgregarRequerimiento()
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
       public void TestDatosConsultarRequerimientosPorPropuesta()
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
       public void TestDatosBorrarPropuestas()
       {
           //Agrego primera propuesta de prueba
           agregoPropuesta = logicaM6.agregar(laPropuesta);

           if (agregoPropuesta == true)
           {
               listaPropuestas = logicaM6.ConsultarTodasPropuestas();
               tamañoLista1 = listaPropuestas.Count;

               //Elimino la propuesta de prueba
               borroPropuesta = BDPropuesta.BorrarPropuesta("Nombre prueba"); 
               listaPropuestas = logicaM6.ConsultarTodasPropuestas();
               tamañoLista2 = listaPropuestas.Count;
               Assert.Greater(tamañoLista1, tamañoLista2);

           }

       }


       // <summary>
       //Prueba que modifica una propuesta
       // </summary>
       [Test]
       public void TestDatosModificar_Propuesta()
       {
           //Agrego una propuesta de prueba
           agregoPropuesta = logicaM6.agregar(laPropuesta);

           if (agregoPropuesta == true)
           {

               modifico = BDPropuesta.Modificar_Propuesta(laPropuesta2);
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



       // <summary>
       //Prueba que modifica una Requerimiento
       // </summary>
        [Test]
       public void TestDatosModificarRequerimiento()
       {

           //Agrego una propuesta de prueba
           agregoPropuesta = BDPropuesta.agregarPropuesta(laPropuesta);

           //Agrego dos requerimientos a la propuesta
           agregoRequerimiento = BDPropuesta.agregarRequerimiento(elRequerimiento);
           agregoRequerimiento2 = BDPropuesta.agregarRequerimiento(elRequerimiento3);


           if (agregoPropuesta == true && agregoRequerimiento == true && agregoRequerimiento2 == true)
           {

               listaRequerimientos = BDPropuesta.ConsultarRequerimientosPorPropuesta("Nombre prueba");

               modifico=BDPropuesta.Modificar_Requerimiento(elRequerimiento2);

               Assert.IsTrue(modifico);

               //Recorro toda la lista y para buscar el requerimiento que acabo de modificar
               foreach (Requerimiento valor in listaRequerimientos)
               {

                   if (valor.Descripcion == "desc prueba3")
                   {
                       esAprobado = true;
                       break;
                   }

                   else
                       esAprobado = false;

               };

               //Si esAprobado es falso es porque no encontró el nuevo requerimiento que acaba de modificar
               Assert.IsTrue(esAprobado);

               //Elimino la propuesta de prueba y sus requerimientos asociados
               borroPropuesta = logicaM6.BorrarPropuesta("Nombre prueba");

           }

       }


    }
    }

