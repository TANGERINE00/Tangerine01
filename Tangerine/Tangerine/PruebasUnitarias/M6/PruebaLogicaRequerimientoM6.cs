using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.M6;
using DominioTangerine;
using DatosTangerine.M6;


namespace PruebasUnitarias.M6
{
    
        
    [TestFixture]

    class PruebaLogicaRequerimientoM6
    {

        #region Atributos

        private Propuesta laPropuestaR, laPropuestaR2;
        private DateTime DateR1,DateR2;
        private LogicaRequerimiento logicaM6R;
        private LogicaPropuesta logicaM6P;
        private Boolean agregoPropuestaR, borroPropuestaR, modificoR, agregoRequerimientoR, agregoRequerimiento2R, esAprobadoR;
        private Requerimiento elRequerimientoR, elRequerimiento2R, elRequerimiento3R;
        private List<Requerimiento> listaRequerimientosR;
        //private int tamañoLista1, tamañoLista2;
        #endregion


        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            laPropuestaR = new Propuesta();
            laPropuestaR2 = new Propuesta();
            laPropuestaR.CodigoP = "123";
            laPropuestaR.Nombre = "Nombre prueba";
            laPropuestaR.Descripcion = "Desc prueba";
            laPropuestaR.TipoDuracion = "Meses";
            laPropuestaR.CantDuracion = "2";
            laPropuestaR.Acuerdopago = "acuerdo";
            laPropuestaR.Estatus = "Pendiente prueba";
            laPropuestaR.Moneda = "Dolar";
            laPropuestaR.Entrega = 1;
            DateR1 = new DateTime(2016, 6, 4);
            DateR2 = new DateTime(2016, 7, 4);
            laPropuestaR.Feincio = DateR1;
            laPropuestaR.Feincio = DateR2;
            laPropuestaR.Costo = 100;
            laPropuestaR.IdCompañia = "1";
           //  tamañoLista1 = 0;
           // tamañoLista2=0;

            laPropuestaR2.CodigoP = "123";
            laPropuestaR2.Nombre = "Nombre prueba";
            laPropuestaR2.Descripcion = "Desc prueba2";
            laPropuestaR2.TipoDuracion = "Meses";
            laPropuestaR2.CantDuracion = "2";
            laPropuestaR2.Acuerdopago = "acuerdo";
            laPropuestaR2.Estatus = "Pendiente prueba";
            laPropuestaR2.Moneda = "Dolar";
            laPropuestaR2.Entrega = 1;
            DateR1 = new DateTime(2016, 6, 4);
            DateR2 = new DateTime(2016, 7, 4);
            laPropuestaR2.Feincio = DateR1;
            laPropuestaR2.Feincio = DateR2;
            laPropuestaR2.Costo = 100;
            laPropuestaR2.IdCompañia = "1";

            elRequerimientoR = new Requerimiento();
            elRequerimiento2R = new Requerimiento();
            elRequerimiento3R = new Requerimiento();
            elRequerimientoR.Descripcion = "desc prueba";
            elRequerimientoR.CodigoRequerimiento = "codigo123";
            elRequerimientoR.CodigoPropuesta = "Nombre prueba";

            elRequerimiento2R.Descripcion = "desc prueba3";
            elRequerimiento2R.CodigoRequerimiento = "codigo123";
            elRequerimiento2R.CodigoPropuesta = "Nombre prueba";

            elRequerimiento3R.Descripcion = "desc prueba3";
            elRequerimiento3R.CodigoRequerimiento = "codigo1234";
            elRequerimiento3R.CodigoPropuesta = "Nombre prueba";
            
            
            
            logicaM6R = new LogicaRequerimiento();
            logicaM6P = new LogicaPropuesta();
            
        }
    
        #endregion


        // <summary>
        //Prueba que se agrega un requerimiento desde la logica
        // </summary>
        [Test]
        public void TestLogicaAgregarRequerimiento()
        {
            //Agrego una propuesta de prueba
            agregoPropuestaR = logicaM6P.agregar(laPropuestaR);
            

            //Agregar un Requerimiento y pruebo que se agregó
            Assert.IsTrue(logicaM6R.agregar(elRequerimientoR));

            //Pruebo que el requerimieto pertenece a la propuesta que acabo de agregar
            listaRequerimientosR = BDPropuesta.ConsultarRequerimientosPorPropuesta("Nombre prueba");

            Assert.AreEqual(listaRequerimientosR.ElementAt(0).Descripcion, "desc prueba");

            //Elimino la propuesta de prueba y el requerimiento asociado

            borroPropuestaR = logicaM6P.BorrarPropuesta("Nombre prueba");

        }
        

        // <summary>
        //Prueba que efectivamente traigo una propuesta desde la logica
        // </summary>
        [Test]
        public void TestLogicaTraerRequerimientoPropuesta()
        {
             //Agrego una propuesta de prueba
            agregoPropuestaR = logicaM6P.agregar(laPropuestaR);
            
            //Agregar un Requerimiento y pruebo que se agregó
            agregoRequerimientoR=logicaM6R.agregar(elRequerimientoR);

            if(agregoPropuestaR==true && agregoRequerimientoR==true)

            listaRequerimientosR= logicaM6R.TraerRequerimientoPropuesta("Nombre prueba");
            
            foreach(Requerimiento valor in listaRequerimientosR)
            {
                if (valor.Descripcion == ("desc prueba"))
                                    
                    agregoRequerimientoR = true;
                
                else
                    agregoRequerimientoR = false;

            }

            Assert.IsTrue(agregoRequerimientoR);

            //Elimino la propuesta de prueba y el requerimiento asociado
            borroPropuestaR = logicaM6P.BorrarPropuesta("Nombre prueba");    
            
            }
        // <summary>
        //Prueba que modifica una Requerimiento desde la logica
        // </summary>
        [Test]
        public void TestLogicaModificarRequerimiento()
        {

            //Agrego una propuesta de prueba
            agregoPropuestaR = logicaM6P.agregar(laPropuestaR);

            //Agregar un Requerimiento y pruebo que se agregó
            agregoRequerimientoR = logicaM6R.agregar(elRequerimientoR);

            //Agrego dos requerimientos a la propuesta
            agregoRequerimientoR = logicaM6R.agregar(elRequerimientoR);
            agregoRequerimiento2R = logicaM6R.agregar(elRequerimiento2R);


            if (agregoPropuestaR == true && agregoRequerimientoR == true && agregoRequerimiento2R == true)
            {

                listaRequerimientosR = BDPropuesta.ConsultarRequerimientosPorPropuesta("Nombre prueba");

                modificoR = logicaM6R.ModRequerimiento(elRequerimiento2R);

                Assert.IsTrue(modificoR);

                //Recorro toda la lista y para buscar el requerimiento que acabo de modificar
                foreach (Requerimiento valor in listaRequerimientosR)
                {

                    if (valor.Descripcion == "desc prueba3")
                    {                        
                        esAprobadoR = true;
                        break;
                    }

                    else
                        esAprobadoR = false;

                };

                //Si esAprobadoR es falso es porque no encontró el nuevo requerimiento que acaba de modificar
                Assert.IsTrue(esAprobadoR);
                //Elimino la propuesta de prueba y el requerimiento asociado
                borroPropuestaR = logicaM6P.BorrarPropuesta("Nombre prueba");    
            
                
            }

        }
    }


    }

