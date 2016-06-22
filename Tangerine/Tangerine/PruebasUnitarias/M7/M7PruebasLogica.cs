using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.M7;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.Fabrica;

namespace PruebasUnitarias.M7
{
     [TestFixture]
    class M7PruebasLogica
    {
        Entidad _proyecto;
        private LogicaProyecto _Logi;
        //private List<Entidad> _proyectos;
        int id;
        int IdGerente;
        int IdEmpleado;
        public DateTime fechainicio = new DateTime(2016, 10, 03);
        public DateTime fechaestimadafin = new DateTime(2016, 10, 08);
        public List<Entidad> contactos;
        public List<Entidad> empleados;

        [SetUp]
        public void setup() {
            _Logi = new LogicaProyecto();
            _proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();

            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Id = 1;
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Nombre = "El proyecto nuevo";
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Codigo = "elpr1234";
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Fechainicio = fechainicio;
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Fechaestimadafin = fechaestimadafin;
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Costo = 10000;
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Descripcion = "este es un proyecto de prueba";
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Realizacion = "20";
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Estatus = "En desarrollo";
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Razon = "";
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Acuerdopago = "Mensual";
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Idpropuesta = 1;
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Idresponsable = 1;
            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Idgerente = 1;

            id = 1;
            IdGerente = 1;
            IdEmpleado = 1;

            List<Entidad> empleados = new List<Entidad>();
            for (int i = 4; i <= 5; i++)
            {
                Entidad a = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEmpleado();
                ((DominioTangerine.Entidades.M7.Empleado)a).emp_num_ficha = i;
                empleados.Add(a);
            }

            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).set_empleados(empleados);

            List<Entidad> contactos = new List<Entidad>();
            for (int i = 4; i <=5; i++)
            {
                Entidad a = DominioTangerine.Fabrica.FabricaEntidades.ObtenerContacto();
                ((DominioTangerine.Entidades.M7.Contacto)a).Id = i; 
                ((DominioTangerine.Entidades.M7.Contacto)a).Nombre = "Istvan"; 
                ((DominioTangerine.Entidades.M7.Contacto)a).Apellido = "Bokor"; 
                ((DominioTangerine.Entidades.M7.Contacto)a).Departamento = "Ventas"; 
                ((DominioTangerine.Entidades.M7.Contacto)a).Correo = "asd@asd.com"; 
                ((DominioTangerine.Entidades.M7.Contacto)a).Telefono = "7654321"; 
                ((DominioTangerine.Entidades.M7.Contacto)a).IdCompañia = 1; 
                ((DominioTangerine.Entidades.M7.Contacto)a).TipoCompañia = 1; 
                contactos.Add(a);

            }

            ((DominioTangerine.Entidades.M7.Proyecto)_proyecto).set_contactos(contactos);
        }

        [TearDown]
        public void teardown() {

            _proyecto = null;
            contactos = null;
            empleados = null;
            _Logi = null;

        
        }


        [Test]
        public void testAgregarProyecto() {

            Comando<bool> comandoProyecto = FabricaComandos.ObtenerComandoAgregarProyecto(_proyecto);
            bool resultado = comandoProyecto.Ejecutar();
            Assert.IsTrue(resultado);
        }

        // [Test]
        //public void testModificarProyecto() {
        //    Comando<bool> comandoProyecto = FabricaComandos.ObtenerComandoModificarProyecto(_proyecto);
        //    bool resultado = comandoProyecto.Ejecutar();
        //    Assert.IsTrue(_Logi.modificarProyecto(_proyecto) );
        //}

         [Test]
         public void testConsultarProyectos()
         {
             List<Entidad> _proyectos = new List<Entidad>();
             Comando<List<Entidad>> comandoProyecto = FabricaComandos.ObtenerComandoConsultarTodosProyectos();
             List<Entidad> resultado = comandoProyecto.Ejecutar();
             foreach (Entidad _proyecto in _proyectos)
             {
                 Assert.IsNotEmpty(((DominioTangerine.Entidades.M7.Proyecto)_proyecto).Nombre);
             }
         }


         [Test]
         public void testConsultarProyecto()
         {
             Entidad proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
             ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id = id;

             Comando<Entidad> comandoProyecto = FabricaComandos.ObtenerComandoConsultarXIdproyecto(proyecto);
             Entidad resultado = comandoProyecto.Ejecutar();
             Assert.IsTrue(id == ((DominioTangerine.Entidades.M7.Proyecto)resultado).Id);
         }

         //[Test]
         //public void testConsultarAcuerdoPagoMensual()
         //{

         //    _proyectos = _Logi.consultarAcuerdoPagoMensual();

         //    for (int i = 0; i < _proyectos.Count(); i++)
         //    {

         //        Assert.IsNotEmpty(_proyectos[i].Nombre);
         //    }
         //}

         //[Test]
         //public void testConsultarProyectosDeUnTrabajador()
         //{
         //    _proyectos = _Logi.consultarProyectosDeUnTrabajador(IdEmpleado);

         //    for (int i = 0; i < _proyectos.Count(); i++)
         //    {

         //        Assert.IsNotEmpty(_proyectos[i].Nombre);
         //    }
         //}

         //[Test]
         //public void testConsultarProyectosDeUnGerente()
         //{
         //    _proyectos = _Logi.consultarProyectosDeUnGerente(IdGerente);

         //    for (int i = 0; i < _proyectos.Count(); i++)
         //    {

         //        Assert.IsNotEmpty(_proyectos[i].Nombre);
         //    }
         //}

         //[Test]
         //public void testConsultarNombrePropuestaID()
         //{
         //    String prueba = _Logi.ConsultarNombrePropuestaID(1);


         //    Assert.IsTrue(prueba == "Modulo de gestion de empleados");
         //}

     //[Test]
     //    public void TestgenerarCodigoProyecto()
     //{
     //    Assert.AreEqual("Proy-Arbo2016", _Logi.generarCodigoProyecto("Arbol de la vida"));
     //}

     //[Test]
     //public void TestcalcularPagoMesual()
     //{
     //    Assert.AreEqual( _proyecto.Costo, _Logi.calcularPagoMesual(_proyecto));
     //}


     //[Test]
     //public void TestcalcularPago()
     //{

     //    Assert.AreEqual(50000, _Logi.calcularPago(10, 60, 100000));
     //}

     //[Test]
     //public void TestobtenerIDContactosyEmpleados()
     //{
     //    Assert.IsTrue(_Logi.obtenerIDContactosyEmpleados(_proyecto));
     //}
     }

}
