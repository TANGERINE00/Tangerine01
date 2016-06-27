using DominioTangerine;
using DominioTangerine.Fabrica;
using ExcepcionesTangerine.M7;
using LogicaTangerine;
using LogicaTangerine.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.M7
{
    [TestFixture]
    class PruebaLogicaM7
    {

        #region Atributos
        private Entidad _theProject, _checkTheProject, _laPropuesta;
        private List<Entidad> _listaEntidad, _empleados, _contactos;
        private bool _answer;
        private DateTime _fechaInicio;
        private DateTime _fechaFin;
        private DatosTangerine.InterfazDAO.M7.IDaoProyecto _daoProyecto;
        DatosTangerine.InterfazDAO.M5.IDAOContacto _daoContacto;
        private int _contador;
        private int _cantidad;
        private int _ultimoId;
        private Comando<Entidad> _comandoEntidad;
        private Comando<bool> _comandoBool;
        private Comando<String> _comandoString;
        private Comando<Double> _comandoDouble;
        private Comando<List<Entidad>> _comandoLista;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            _empleados = new List<Entidad>();
            _contactos = new List<Entidad>();
            _fechaInicio = new DateTime();
            _fechaFin = new DateTime();
            _fechaInicio = DateTime.ParseExact("06/04/2016", "MM/dd/yyyy", null);
            _fechaFin = DateTime.ParseExact("08/05/2016", "MM/dd/yyyy", null);
            _daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
            _daoContacto = DatosTangerine.Fabrica.FabricaDAOSqlServer.crearDAOContacto();
            _theProject = DominioTangerine.Fabrica.FabricaEntidades.CrearProyecto("El proyecto nuevo",
                                   "el-pr1234", _fechaInicio, _fechaFin, 100000, "este es un proyecto de prueba",
                                   "20", "En desarrollo", "Razon de cambio", "Mensual", 1, 1, 1);


            for (int i = 4; i <= 5; i++)
            {
                Entidad a = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEmpleado();
                ((DominioTangerine.Entidades.M7.Empleado)a).emp_num_ficha = i;
                _empleados.Add(a);

            }

            for (int i = 4; i <= 5; i++)
            {
                Entidad a = DominioTangerine.Fabrica.FabricaEntidades.crearContactoConId(i, "Istvan", "Bokor",
                    "Departamento", "Gerente", "7654321", "asd@as.com", 1, 1);
                _contactos.Add(a);
            }

        }
        [TearDown]
        public void Clean()
        {
            _theProject = null;
            _checkTheProject = null;
            _daoProyecto = null;
            _laPropuesta = null;
            _contador = 0;
            _cantidad = 0;
        }


        #endregion

        #region Pruebas Unitarias M7
        /// <summary>
        /// Prueba Unitaria para la agregación de un proyecto en la BD.
        /// </summary>
        [Test]
        public void testComandoAgregarProyecto()
        {
            _contador = _daoProyecto.ConsultarTodos().Count;

            _comandoBool = FabricaComandos.ObtenerComandoAgregarProyecto(_theProject);
            Assert.True(_comandoBool.Ejecutar());
            Assert.AreEqual(_daoProyecto.ConsultarTodos().Count, _contador + 1);

            _ultimoId = _daoProyecto.ContactMaxIdProyecto();
            _theProject.Id = _ultimoId;
            _checkTheProject = _daoProyecto.ConsultarXId(_theProject);

            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Nombre == "El proyecto nuevo");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Codigo == "el-pr1234");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Fechainicio == _fechaInicio);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Fechaestimadafin == _fechaFin);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Costo == 100000);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Descripcion == "este es un proyecto de prueba");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Realizacion == "20");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Estatus == "En desarrollo");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Razon == "Razon de cambio");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Acuerdopago == "Mensual");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Idpropuesta == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Idresponsable == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Idgerente == 1);

            //Se elimina el proyecto utilizado en la prueba.
            _answer = _daoProyecto.BorrarProyecto(_ultimoId);

        }

        [Test]
        public void testComandoConsultarTodosProyectos()
        {

            _comandoLista = FabricaComandos.ObtenerComandoConsultarTodosProyectos();
            _listaEntidad = _comandoLista.Ejecutar();
            _cantidad = _listaEntidad.Count;

            Assert.IsNotEmpty(_listaEntidad);

            foreach (Entidad pruebaProy in _listaEntidad)
            {
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Nombre);
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Codigo);
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Fechainicio);
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Fechaestimadafin);
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Costo);
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Descripcion);
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Realizacion);
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Estatus);
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Razon);
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Acuerdopago);
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Idpropuesta);
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Idresponsable);
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)pruebaProy).Idgerente);
                _contador++;
            }
            Assert.AreEqual(_contador,5);
        }

        [Test]
        public void testComandoConsultarXIdProyecto()
        {
            _theProject = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
            _theProject.Id = 1;

            _comandoEntidad = FabricaComandos.ObtenerComandoConsultarXIdProyecto(_theProject);
            _checkTheProject = _comandoEntidad.Ejecutar();

            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Id == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Nombre == "ProyectoDS");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Codigo == "CodigoPDS");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Fechainicio == DateTime.ParseExact("10/03/2016","MM/dd/yyyy",null));
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Fechaestimadafin == DateTime.ParseExact("10/08/2016", "MM/dd/yyyy", null));
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Costo == 10000.000);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Descripcion == "Se tratara de un modulo de gestion de empleados");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Realizacion == "60");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Estatus == "En desarrollo");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Razon == "");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Acuerdopago == "Mensual");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Idpropuesta == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Idresponsable == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Idgerente == 1);

        }

        [Test]
        public void TestComandoGenerarCodigoProyecto()
        {

            DateTime Date1 = new DateTime(2016, 6, 4);
            DateTime Date2 = new DateTime(2016, 7, 4);
            _laPropuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta("NombrePropuestaPrueba",
            "DescripcionProPuestaPrueba", "Meses", "2", "acuerdo", "PendientePrueba", "Dolar", 1, Date1, Date2, 100, "1");

            _comandoString = FabricaComandos.ObtenerComandoGenerarCodigoProyecto(_laPropuesta);
            String _codigo = _comandoString.Ejecutar();

            Assert.IsTrue(_codigo == "Proy-Nombre4-2016");
        }


        [Test]
        public void testComandoConsultarAcuerdoPagoMensual()
        {
            _comandoLista = FabricaComandos.ObtenerComandoConsultarAcuerdoPagoMensual();
            _listaEntidad = _comandoLista.Ejecutar();


            for (int i = 0; i < _listaEntidad.Count(); i++)
            {
                Assert.IsNotNull(((DominioTangerine.Entidades.M7.Proyecto)_listaEntidad[i]).Nombre);
                Assert.AreEqual(((DominioTangerine.Entidades.M7.Proyecto)_listaEntidad[i]).Acuerdopago, "Mensual");
            }
        }

        [Test]
        public void testComandoConsultarContactoNombrePropuestaId()
        {
            _theProject.Id = 1;
            _comandoEntidad = FabricaComandos.ObtenerComandoContactNombrePropuestaId(_theProject);
            _laPropuesta = _comandoEntidad.Ejecutar();

            Assert.AreEqual(((DominioTangerine.Entidades.M7.Propuesta)_laPropuesta).Nombre, "GNFRNCO160622044206");
        }


        [Test]
        public void testComandoConsultarTodosGerentes()
        {
            
            _comandoLista = FabricaComandos.ObtenerComandoConsultarTodosGerentes();
            _listaEntidad = _comandoLista.Ejecutar();
            
            foreach(Entidad Empleado in _listaEntidad)
            {
                Entidad ent = (((DominioTangerine.Entidades.M7.Empleado)Empleado).Job);
                DominioTangerine.Entidades.M7.Cargo cargo = (DominioTangerine.Entidades.M7.Cargo)ent;
                Assert.AreEqual(cargo.Nombre,"Gerente");
            }
        }

        [Test]
        public void testComandoConsultarTodosProgramadores()
        {

            _comandoLista = FabricaComandos.ObtenerComandoConsultarTodosProgramadores();
            _listaEntidad = _comandoLista.Ejecutar();

            foreach (Entidad Empleado in _listaEntidad)
            {
                Entidad ent = (((DominioTangerine.Entidades.M7.Empleado)Empleado).Job);
                DominioTangerine.Entidades.M7.Cargo cargo = (DominioTangerine.Entidades.M7.Cargo)ent;
                Assert.AreEqual(cargo.Nombre, "Programador");
            }
        }

        [Test]
        public void TestComandoCalcularPagoMensual()
        {
            _comandoDouble = FabricaComandos.ObtenerComandoCalcularPagoMesual(_theProject);
            Double monto = _comandoDouble.Ejecutar();

            Assert.AreEqual(Math.Truncate(monto), 48387);
        }

        [Test]
        public void testComandoAgregarContactos()
        {
            _comandoBool = FabricaComandos.ObtenerComandoAgregarProyecto(_theProject);
            Assert.True(_comandoBool.Ejecutar());

            _ultimoId = _daoProyecto.ContactMaxIdProyecto();
            _theProject.Id = _ultimoId;

            _comandoLista = FabricaComandos.ObtenerComandoConsultarContactosXIdProyecto(_theProject);
            _listaEntidad = _comandoLista.Ejecutar();

            Assert.IsEmpty(_listaEntidad);

            //Se le asocia una lista de contactos al proyecto
            ((DominioTangerine.Entidades.M7.Proyecto)_theProject).set_contactos(_contactos);


            _comandoBool = FabricaComandos.ObtenerComandoAgregarContactos(_theProject);
            Assert.IsTrue(_comandoBool.Ejecutar());

            _comandoLista = FabricaComandos.ObtenerComandoConsultarContactosXIdProyecto(_theProject);
            _listaEntidad = _comandoLista.Ejecutar();

            Assert.IsNotEmpty(_listaEntidad);

            foreach (Entidad contacto in _contactos)
            {
                _daoContacto.EliminarContactoDeProyecto(contacto, _theProject);
            }
            _answer = _daoProyecto.BorrarProyecto(_ultimoId);

        }
        #endregion

        [Test]
        [ExpectedException(typeof(ExceptionM7Tangerine))]
        public void PruebaComandoAgregarProyectoException()
        {
            _theProject = null;
            _comandoBool = FabricaComandos.ObtenerComandoAgregarProyecto(_theProject);
            _answer = _comandoBool.Ejecutar();

        }

    }
}
