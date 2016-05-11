using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M7;
using DominioTangerine;

namespace PruebasUnitarias.M7
{

     [TestFixture]
    class PruebasDatos
    {
        
        #region Atributos
        public Proyecto theProyect;
        public BDProyecto theProyect2;
        public bool answer;
        public DateTime fechainicio = new DateTime(2015,2,10);
        public DateTime fechaestimadafin = new DateTime(2015, 2, 10);
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            theProyect = new Proyecto();
            theProyect.Idproyecto = 8;
            theProyect.Nombre = "El proyecto";
            theProyect.Codigo = "elpr1234";
            theProyect.Fechainicio = fechainicio;
            theProyect.Fechaestimadafin = fechaestimadafin;
            theProyect.Costo = 100000;
            theProyect.Descripcion = "este es un proyecto de prueba";
            theProyect.Realizacion = "20%";
            theProyect.Estatus = "En Curso";
            theProyect.Razon = "";
            theProyect.Idpropuesta = 1;
            theProyect.Idresponsable = 1;
            theProyect.Idgerente = 1;

            theProyect2 = new BDProyecto();
        }

        [TearDown]
        public void clean()
        {
            theProyect = null;
            theProyect2 = null;
        }
        #endregion

        /// <summary>
        /// Prueba que permite verificar el insertar de un proyecto en la base de datos
        /// </summary>
        [Test]
        public void TestAddProyecto()
        {
            //Declaro test de tipo BDContacto para poder invocar el "AddContact(Contacto theContact)"
            answer = theProyect2.AddProyecto(theProyect);

            //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(answer);
        }
        
    }
}
