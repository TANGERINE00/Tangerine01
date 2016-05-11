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
        private BDEmpleadoProyecto _Emp;
        private BDProyectoContanto _Cont;
        private List<Empleado> Empleados;
        private List<Contacto> Contactos;
        public bool answer;
        public DateTime fechainicio = new DateTime(2015,2,10);
        public DateTime fechaestimadafin = new DateTime(2015, 2, 10);
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            theProyect2 = new BDProyecto();
            _Emp = new BDEmpleadoProyecto();
            _Cont = new BDProyectoContanto();
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

            
            Empleados = new List<Empleado>();
            for (int i = 0; i < 6; i++) {
                Empleado a = new Empleado();
                a.emp_num_ficha = i;
                Empleados.Add(a);
                
            }

            theProyect.set_empleados(Empleados);

            Contactos = new List<Contacto>();
            for ( int i = 0 ; i < 6 ; i++ )
            {
                Contacto a = new Contacto();
                a.IdContacto = i;
                Contactos.Add(a);

            }

            theProyect.set_contactos(Contactos);
            


        }

        [TearDown]
        public void clean()
        {
            theProyect = null;
            theProyect2 = null;
            Contactos = null;
            Empleados = null
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

        /// <summary>
        /// Prueba el metodo de insertar en la N:M Proyecto-Empleado
        /// </summary>
        [Test]
        public void TestAddProyectoEmpleado()
        {
            //obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(_Emp.AddProyectoEmpleado(theProyect));
        }

        /// <summary>
        /// Prueba el metodo de insertar en la N:M Proyecto-Contacto
        /// </summary>
        [Test]
        public void TestAddProyectoContato()
        {
            //obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(_Cont.AddProyectoContacto(theProyect));
        }

        /// <summary>
        /// Prueba el metodo de eliminar en la N:M Proyecto-Empleado
        /// </summary>
        [Test]
        public void TestDeleteProyectoEmpleado()
        {
            //obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(_Emp.DeleteProyectoEmpleado(theProyect));
        }

        /// <summary>
        /// Prueba el metodo de eliminar en la N:M Proyecto-Contacto
        /// </summary>
        [Test]
        public void TestDeleteProyectoContato()
        {
            //obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
            Assert.IsTrue(_Cont.DeleteProyectoContacto(theProyect));
        }

    /// <summary>
    /// Prueba el metodo que recupera los empleados de  un proyecto
    /// </summary>
     [Test]
     public void TestContactProyectoEmpleado()
     {
         theProyect.set_empleados(null);
         _Emp.ContactProyectoEmpleado(theProyect);
         Assert.Equals(0, theProyect.get_empleados()[0].emp_num_ficha);
         Assert.Equals(2, theProyect.get_empleados()[1].emp_num_ficha);
         Assert.Equals(3, theProyect.get_empleados()[2].emp_num_ficha);
         Assert.Equals(4, theProyect.get_empleados()[3].emp_num_ficha);


     }
     /// <summary>
     /// Prueba el metodo que recupera los Contactos de  un proyecto
     /// </summary>
     [Test]
     public void TestContactProyectoContatos()
     {
         theProyect.set_contactos(null);
         _Cont.ContactProyectoContacto(theProyect);
         Assert.Equals(0, theProyect.get__contactos()[0].IdContacto);
         Assert.Equals(1, theProyect.get__contactos()[1].IdContacto);
         Assert.Equals(2, theProyect.get__contactos()[2].IdContacto);
         Assert.Equals(3, theProyect.get__contactos()[3].IdContacto);


     }

        
    }
}
