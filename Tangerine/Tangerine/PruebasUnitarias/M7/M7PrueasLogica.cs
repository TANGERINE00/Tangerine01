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
    class M7PrueasLogica
    {
         private Proyecto _proyecto;
        private LogicaProyecto _Logi;
        private List<Proyecto> _proyectos;
        int id;
        int IdGerente;
        int IdEmpleado;
        public DateTime fechainicio = new DateTime(2015, 2, 10);
        public DateTime fechaestimadafin = new DateTime(2015, 2, 10);
        public List<Contacto> Contactos;
        public List<Empleado> Empleados;

        [SetUp]
        public void setup() {

            _proyecto = new Proyecto();
            _proyecto.Idproyecto = 1;
            _proyecto.Nombre = "El proyecto nuevo";
            _proyecto.Codigo = "elpr1234";
            _proyecto.Fechainicio = fechainicio;
            _proyecto.Fechaestimadafin = fechaestimadafin;
            _proyecto.Costo = 100000;
            _proyecto.Descripcion = "este es un proyecto de prueba";
            _proyecto.Realizacion = "20%";
            _proyecto.Estatus = "En Curso";
            _proyecto.Razon = "";
            _proyecto.Acuerdopago = "Mensual";
            _proyecto.Idpropuesta = 1;
            _proyecto.Idresponsable = 1;
            _proyecto.Idgerente = 1;

            id = 1;
            IdGerente = 1;
            IdEmpleado = 1;

            Empleados = new List<Empleado>();
            for (int i = 0; i < 6; i++)
            {
                Empleado a = new Empleado();
                a.emp_num_ficha = i;
                Empleados.Add(a);

            }

            _proyecto.set_empleados(Empleados);

            Contactos = new List<Contacto>();
            for (int i = 1; i < 7; i++)
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
    }
}
