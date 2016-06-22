using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.M7;
using DominioTangerine;
using DatosTangerine.DAO.M7;
using DatosTangerine.InterfazDAO.M7;

namespace PruebasUnitarias.M7
{

     [TestFixture]
    class PruebasDatos
    {
        
        #region Atributos
        public Entidad theProyect;
        public BDProyecto theProyect2;
        private BDEmpleadoProyecto _Emp;
        private BDProyectoContanto _Cont;
        private List<Entidad> empleados;
        private List<Entidad> contactos;
        private List<Entidad> proyectos;
        public bool answer;
        public DateTime fechainicio = new DateTime(2015,2,10);
        public DateTime fechaestimadafin = new DateTime(2015, 2, 10);
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            theProyect = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
            theProyect2 = new BDProyecto();
            _Emp = new BDEmpleadoProyecto();
            _Cont = new BDProyectoContanto();
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Id = 1;
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Nombre = "El proyecto nuevo";
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Codigo = "elpr1234";
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Fechainicio = fechainicio;
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Fechaestimadafin = fechaestimadafin;
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Costo = 100000;
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Descripcion = "este es un proyecto de prueba";
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Realizacion = "20";
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Estatus = "En desarrollo";
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Razon = "";
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Acuerdopago = "Mensual";
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Idpropuesta = 1;
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Idresponsable = 1;
            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).Idgerente = 1;

            
            empleados = new List<Entidad>();
            for (int i = 4; i <= 5; i++) {
                Entidad a = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEmpleado();
                ((DominioTangerine.Entidades.M7.Empleado)a).emp_num_ficha = i;
                empleados.Add(a);
                
            }

            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).set_empleados(empleados);

            contactos = new List<Entidad>();
            for ( int i = 4 ; i <= 5 ; i++ )
            {
                Entidad a = DominioTangerine.Fabrica.FabricaEntidades.ObtenerContacto();
                ((DominioTangerine.Entidades.M7.Contacto)a).Id = i;
                ((DominioTangerine.Entidades.M7.Contacto)a).Nombre = "Istvan";
                ((DominioTangerine.Entidades.M7.Contacto)a).Apellido = "Bokor";
                ((DominioTangerine.Entidades.M7.Contacto)a).Cargo = "Gerente";
                ((DominioTangerine.Entidades.M7.Contacto)a).Correo = "asd@asd.com";
                ((DominioTangerine.Entidades.M7.Contacto)a).Telefono = "7654321";
                ((DominioTangerine.Entidades.M7.Contacto)a).TipoCompañia = 1;
                ((DominioTangerine.Entidades.M7.Contacto)a).IdCompañia = 1;

                contactos.Add(a);
            }

            ((DominioTangerine.Entidades.M7.Proyecto)theProyect).set_contactos(contactos);
            


        }

        [TearDown]
        public void clean()
        {
            theProyect = null;
            theProyect2 = null;
            contactos = null;
            empleados = null;
        }
        #endregion

        /// <summary>
        /// Prueba que permite verificar el insertar de un proyecto en la base de datos
        /// </summary>
        [Test]
        public void TestAddProyecto()
        {
            IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
            bool answer = daoProyecto.Agregar(theProyect);
            Assert.IsTrue(answer);
        }


        /// <summary>
        /// Prueba que permite verificar el modificar el proyecto en la base de datos
        /// </summary>
        //[Test]
        //public void TestChangeProyecto()
        //{
        //    IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
        //    bool answer = daoProyecto.Agregar(theProyect);
        //    Assert.IsTrue(answer);

        //    answer = theProyect2.ChangeProyecto(theProyect);

        //    //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
        //    Assert.IsTrue(answer);
        //}


        /// <summary>
        /// Prueba que permite verificar el consultar de un proyecto en la base de datos
        /// </summary>
        //[Test]
        //public void TestContactProyecto()
        //{

        //    theProyect = theProyect2.ContactProyecto(1);

        //    //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
        //    Assert.IsTrue(1 == theProyect.Idproyecto);
        //}



        /// <summary>
        /// Prueba que permite verificar el consultar de todos los proyectos en la base de datos
        /// </summary>

    //    [Test]
    //    public void TestContactProyectos()
    //    {
    //        proyectos = theProyect2.ContactProyectos();

    //        //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
    //        for (int i = 0; i < proyectos.Count(); i++)
    //        {

    //            Assert.IsTrue(i+1 == proyectos[i].Idproyecto);
    //        }
                
    //    }



    //    /// <summary>
    //    /// Prueba el metodo de insertar en la N:M Proyecto-Empleado
    //    /// </summary>
    //    [Test]
    //    public void TestAddProyectoEmpleado()
    //    {
    //        //obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
    //        theProyect.Idproyecto = theProyect2.ContacMaxIdProyecto();
    //        Assert.IsTrue(_Emp.AddProyectoEmpleado(theProyect));
    //    }

    //    /// <summary>
    //    /// Prueba el metodo de insertar en la N:M Proyecto-Contacto
    //    /// </summary>
    //    [Test]
    //    public void TestAddProyectoContato()
    //    {
    //        //obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
    //        theProyect.Idproyecto = theProyect2.ContacMaxIdProyecto();
    //        Assert.IsTrue(_Cont.AddProyectoContacto(theProyect));
    //    }

    //    /// <summary>
    //    /// Prueba el metodo de eliminar en la N:M Proyecto-Empleado
    //    /// </summary>
    //    [Test]
    //    public void TestDeleteProyectoEmpleado()
    //    {
    //        //obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
    //        theProyect.Idproyecto = theProyect2.ContacMaxIdProyecto();
    //        Assert.IsTrue(_Emp.DeleteProyectoEmpleado(theProyect));
    //    }

    //    /// <summary>
    //    /// Prueba el metodo de eliminar en la N:M Proyecto-Contacto
    //    /// </summary>
    //    [Test]
    //    public void TestDeleteProyectoContato()
    //    {
    //        //obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion
    //        theProyect.Idproyecto = theProyect2.ContacMaxIdProyecto();
    //        Assert.IsTrue(_Cont.DeleteProyectoContacto(theProyect));
    //    }

    ///// <summary>
    ///// Prueba el metodo que recupera los empleados de  un proyecto
    ///// </summary>
    // [Test]
    // public void TestContactProyectoEmpleado()
    // {
    //     theProyect.set_empleados(null);
    //     theProyect.Idproyecto = theProyect2.ContacMaxIdProyecto();
    //     _Emp.ContactProyectoEmpleado(theProyect);
    //     Assert.IsTrue(4 == theProyect.get_empleados()[0].emp_num_ficha);
    //     Assert.IsTrue(5 == theProyect.get_empleados()[1].emp_num_ficha);

    // }
    // /// <summary>
    // /// Prueba el metodo que recupera los Contactos de  un proyecto
    // /// </summary>
    // [Test]
    // public void TestContactProyectoContatos()
    // {
    //     theProyect.set_contactos(null);
    //     theProyect.Idproyecto = theProyect2.ContacMaxIdProyecto();
    //     _Cont.ContactProyectoContacto(theProyect);
    //     Assert.IsTrue( 4 == theProyect.get__contactos()[0].IdContacto );
    //     Assert.IsTrue( 5 == theProyect.get__contactos()[1].IdContacto );

    // }


    // /// <summary>
    // /// Prueba el metodo que trae todos los proyectos de acuerdo mensual que tengan que ser cancelados el dia de hoy
    // /// </summary>

    // [Test]
    // public void TestContactProyectosXAcuerdoPago()
    // {

    //     proyectos = theProyect2.ContactProyectosxAcuerdoPago();

    //     //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion

    //     for (int i = 0; i < proyectos.Count(); i++)
    //     {

    //         Assert.IsNotEmpty(proyectos[i].Nombre);
    //     }

      
      
    // }

    // /// <summary>
    // /// Prueba el metodo que recupera el nombre de una propuesta dada su id
    // /// </summary>

    // [Test]
    // public void TestContactNombrePropuestaID()
    // {
 
    //     string nombre = theProyect2.ContactNombrePropuestaID(1);

    //     //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion

    //     Assert.IsTrue(nombre == "Modulo de gestion de empleados");
         

    // }

    // /// <summary>
    // /// Prueba el metodo que recupera el id mayor de todos los proyectos de la base de datos
    // /// </summary>
    // [Test]
    // public void TestContacMaxIdProyecto()
    // {


    //     Assert.IsTrue(5 == theProyect2.ContacMaxIdProyecto());


    // }

        
    }
}
