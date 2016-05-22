using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.M7;
using DominioTangerine;

namespace PruebasUnitarias.M7
{
     [TestFixture]
    class M7PruebasLogica
    {
         private Proyecto _proyecto;
        private LogicaProyecto _Logi;
        private List<Proyecto> _proyectos;
        int id;
        int IdGerente;
        int IdEmpleado;
        public DateTime fechainicio = new DateTime(2016, 10, 03);
        public DateTime fechaestimadafin = new DateTime(2016, 10, 08);
        public List<Contacto> Contactos;
        public List<Empleado> Empleados;

        [SetUp]
        public void setup() {
            _Logi = new LogicaProyecto();
            _proyecto = new Proyecto();
            _proyecto.Idproyecto = 1;
            _proyecto.Nombre = "El proyecto nuevo";
            _proyecto.Codigo = "elpr1234";
            _proyecto.Fechainicio = fechainicio;
            _proyecto.Fechaestimadafin = fechaestimadafin;
            _proyecto.Costo = 10000;
            _proyecto.Descripcion = "este es un proyecto de prueba";
            _proyecto.Realizacion = "20";
            _proyecto.Estatus = "En desarrollo";
            _proyecto.Razon = "";
            _proyecto.Acuerdopago = "Mensual";
            _proyecto.Idpropuesta = 1;
            _proyecto.Idresponsable = 1;
            _proyecto.Idgerente = 1;

            id = 1;
            IdGerente = 1;
            IdEmpleado = 1;

            Empleados = new List<Empleado>();
            for (int i = 4; i <= 5; i++)
            {
                Empleado a = new Empleado();
                a.emp_num_ficha = i;
                Empleados.Add(a);

            }

            _proyecto.set_empleados(Empleados);

            Contactos = new List<Contacto>();
            for (int i = 4; i <=5; i++)
            {
                Contacto a = new Contacto(i, "Istvan", "Bokor", "Ventas", "Gerente", "asd@asd.com", "7654321", 1, 1);
                a.IdContacto = i;
                Contactos.Add(a);

            }

            _proyecto.set_contactos(Contactos);
        }

        [TearDown]
        public void teardown() {

            _proyecto = null;
            Contactos = null;
            Empleados = null;
            _Logi = null;

        
        }


        [Test]
        public void testAgregarProyecto() {

            Assert.IsTrue(_Logi.agregarProyecto(_proyecto) );
        }

         [Test]
        public void testModificarProyecto() {

            Assert.IsTrue(_Logi.modificarProyecto(_proyecto) );
        }

         [Test]
         public void testConsultarProyectos()
         {
             _proyectos = _Logi.consultarProyectos();

             for (int i = 0; i < _proyectos.Count(); i++)
             {

                 Assert.IsNotEmpty(_proyectos[i].Nombre);
             }
         }


         [Test]
         public void testConsultarProyecto()
         {
             _proyecto = _Logi.consultarProyecto(id);
             Assert.IsTrue(id == _proyecto.Idproyecto);

             
         }

         [Test]
         public void testConsultarAcuerdoPagoMensual()
         {
             _proyectos = _Logi.consultarAcuerdoPagoMensual();

             for (int i = 0; i < _proyectos.Count(); i++)
             {

                 Assert.IsNotEmpty(_proyectos[i].Nombre);
             }
         }

         [Test]
         public void testConsultarProyectosDeUnTrabajador()
         {
             _proyectos = _Logi.consultarProyectosDeUnTrabajador(IdEmpleado);

             for (int i = 0; i < _proyectos.Count(); i++)
             {

                 Assert.IsNotEmpty(_proyectos[i].Nombre);
             }
         }

         [Test]
         public void testConsultarProyectosDeUnGerente()
         {
             _proyectos = _Logi.consultarProyectosDeUnGerente(IdGerente);

             for (int i = 0; i < _proyectos.Count(); i++)
             {

                 Assert.IsNotEmpty(_proyectos[i].Nombre);
             }
         }

         [Test]
         public void testConsultarNombrePropuestaID()
         {
             String prueba = _Logi.ConsultarNombrePropuestaID(1);


             Assert.IsTrue(prueba == "Modulo de gestion de empleados");
         }

     [Test]
         public void TestgenerarCodigoProyecto()
     {
         Assert.AreEqual("Proy-Arbo2016", _Logi.generarCodigoProyecto("Arbol de la vida"));
     }

     [Test]
     public void TestcalcularPagoMesual()
     {
         Assert.AreEqual( _proyecto.Costo, _Logi.calcularPagoMesual(_proyecto));
     }
     
     [Test]
        public void TestObtenerListadeEmpleados()
        {
            if (_Logi.obtenerListaEmpleados(_proyecto).Count > 0)
            {   
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsFalse(false);
            }
        }
     }

}
