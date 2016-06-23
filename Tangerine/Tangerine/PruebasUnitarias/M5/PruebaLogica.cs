using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M5;
using DominioTangerine;
using DominioTangerine.Entidades.M5;
using DominioTangerine.Fabrica;
using ExcepcionesTangerine.M5;
using LogicaTangerine;
using LogicaTangerine.Fabrica;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.M5
{
    [TestFixture]
    public class PruebaLogica
    {
        #region Atributos
        private Entidad _contacto;
        private List<Entidad> _listaContactos;
        private Comando<Entidad> _comandoEntidad;
        private Comando<bool> _comandoBool;
        private Comando<List<Entidad>> _comandoLista;
        private IDAOContacto _daoContacto;
        private int _contadorContactos;
        private bool _respuesta;
        #endregion

        #region SetUp and TearDown
        /// <summary>
        /// Método para inicializar atributos
        /// </summary>
        [SetUp]
        public void init()
        {
            _contacto = FabricaEntidades.crearContactoSinId( "logicaNombre", "logicaApellido",
                                                             "logicaDepartamento", "logicaCargo",
                                                             "logicaTelefono", "logicaCorreo", 2, 1 );
            _listaContactos = new List<Entidad>();

            _daoContacto = FabricaDAOSqlServer.crearDAOContacto();

            _respuesta = false;

            _contadorContactos = 0;
        }

        /// <summary>
        /// Método para reiniciar atributos
        /// </summary>
        [TearDown]
        public void clean()
        {
            _contacto = null;
        }
        #endregion

        #region Pruebas Unitarias
        /// <summary>
        ///  Método para probar el comando ComandoAgregarContacto de Comandos.M5
        /// </summary>
        [Test]
        public void PruebaComandoAgregarContacto() 
        {
            _comandoBool = FabricaComandos.CrearComandoAgregarContacto( _contacto );
            _respuesta = _comandoBool.Ejecutar();
            Assert.True( _respuesta );

            _listaContactos = _daoContacto.ConsultarTodos();
            _contadorContactos = _listaContactos.Count;
            Assert.AreEqual( _contadorContactos, 6 );
        }

        /// <summary>
        /// Método para probar el comando ComandoEliminarContacto de Comandos.M5
        /// </summary>
        [Test]
        public void PruebaComandoEliminarContacto() 
        {
            _contacto.Id = 6;

            _comandoBool = FabricaComandos.CrearComandoEliminarContacto( _contacto );
            _respuesta = _comandoBool.Ejecutar();
            Assert.True( _respuesta );

            _listaContactos = _daoContacto.ConsultarTodos();
            _contadorContactos = _listaContactos.Count;
            Assert.AreEqual( _contadorContactos, 5 );
        }

        /// <summary>
        /// Método para probar el comando ComandoModificarContacto de Comandos.M5
        /// </summary>
        [Test]
        public void PruebaComandoModificarContacto() 
        {
            Entidad _contactoModificar;

            _contactoModificar = FabricaEntidades.crearContactoConId( 5 ,"nombre modificado", "igual",
                                                                      "igual", "igual",
                                                                      "igual", "igual", 1, 1 );

            _comandoEntidad = FabricaComandos.CrearComandoConsultarContacto( _contactoModificar );
            Entidad contactoConsulta = _comandoEntidad.Ejecutar();
            ContactoM5 nuevo = ( ContactoM5 ) contactoConsulta;
            Assert.AreEqual( nuevo.Nombre, "Pedro" );

            _comandoBool = FabricaComandos.CrearComandoModificarContacto( _contactoModificar );
            _respuesta = _comandoBool.Ejecutar();
            Assert.True( _respuesta );

            _comandoEntidad = FabricaComandos.CrearComandoConsultarContacto( _contactoModificar );
            contactoConsulta = _comandoEntidad.Ejecutar();
            nuevo = ( ContactoM5 ) contactoConsulta;
            Assert.AreEqual( nuevo.Nombre, "nombre modificado" );
        }

        /// <summary>
        /// Método para probar el comando ComandoConsultarContacto de Comandos.M5
        /// </summary>
        [Test]
        public void PruebaComandoConsultarContacto() 
        {
            Entidad contacto = FabricaEntidades.crearContactoVacio();
            contacto.Id = 4;

            _comandoEntidad = FabricaComandos.CrearComandoConsultarContacto( contacto );
            contacto = _comandoEntidad.Ejecutar();
            ContactoM5 nuevo = ( ContactoM5 ) contacto;
            Assert.AreEqual( nuevo.Nombre, "Ramon" );
        }

        /// <summary>
        /// Método para probar el comando ComandoConsultarContactosPorCompania de Comandos.M5
        /// </summary>
        [Test]
        public void PruebaComandoConsultarContactosPorCompania() 
        {
            Entidad compania = FabricaEntidades.crearCompaniaVacia();
            compania.Id = 1;
            _comandoLista = FabricaComandos.CrearComandoConsultarContactosPorCompania( compania, 1 );
            _listaContactos = _comandoLista.Ejecutar();
            _contadorContactos = _listaContactos.Count;

            Assert.AreEqual( _contadorContactos, 5 );
        }

        /// <summary>
        /// Método para probar el comando ComandoAgregarContactoAProyecto de Comandos.M5
        /// </summary>
        [Test]
        public void PruebaComandoAgregarContactoAProyecto()
        {
            Entidad proyecto = FabricaEntidades.ObtenerProyecto();
            proyecto.Id = 1;
            _contacto.Id = 5;

            _comandoBool = FabricaComandos.CrearComandoAgregarContactoAProyecto( _contacto, proyecto );
            _respuesta = _comandoBool.Ejecutar();
            Assert.True( _respuesta );

            _comandoLista = FabricaComandos.CrearComandoConsultarContactosPorProyecto( proyecto );
            _listaContactos = _comandoLista.Ejecutar();
            _contadorContactos = _listaContactos.Count;

            Assert.AreEqual( _contadorContactos, 1 );
        }

        /// <summary>
        /// Método para probar el comando ComandoConsultarContactosPorProyecto de Comandos.M5
        /// </summary>
        [Test]
        public void PruebaComandoConsultarContactosPorProyecto()
        {
            Entidad proyecto = FabricaEntidades.ObtenerProyecto();
            proyecto.Id = 1;

            _comandoLista = FabricaComandos.CrearComandoConsultarContactosPorProyecto( proyecto );
            _listaContactos = _comandoLista.Ejecutar();
            _contadorContactos = _listaContactos.Count;

            Assert.AreEqual( _contadorContactos, 1 );
        }

        /// <summary>
        /// Método para probar el comando ComandoEliminarContactoDeProyecto de Comandos.M5
        /// </summary>
        [Test]
        public void PruebaComandoEliminarContactoDeProyecto()
        {
            Entidad proyecto = FabricaEntidades.ObtenerProyecto();
            proyecto.Id = 1;
            _contacto.Id = 5;

            _comandoBool = FabricaComandos.CrearComandoEliminarContactoDeProyecto( _contacto, proyecto );
            _respuesta = _comandoBool.Ejecutar();
            Assert.True( _respuesta );

            _comandoLista = FabricaComandos.CrearComandoConsultarContactosPorProyecto( proyecto );
            _listaContactos = _comandoLista.Ejecutar();
            _contadorContactos = _listaContactos.Count;

            Assert.AreEqual( _contadorContactos, 0 );
        }

        /// <summary>
        /// Método para probar el comando ComandoConsultarContactosNoPertenecenAProyecto de Comandos.M5
        /// </summary>
        [Test]
        public void PruebaComandoConsultarContactosNoPertenecenAProyecto()
        {
            Entidad proyecto = FabricaEntidades.ObtenerProyecto();
            proyecto.Id = 1;

            _comandoLista = FabricaComandos.CrearComandoConsultarContactosNoPertenecenAProyecto( proyecto );
            _listaContactos = _comandoLista.Ejecutar();
            _contadorContactos = _listaContactos.Count;

            Assert.AreEqual( _contadorContactos, 4 );
        }

        //////////////////////pruebas excepciones

        /// <summary>
        ///  Método para probar Excepciones en el comando ComandoAgregarContacto de Comandos.M5
        /// </summary>
        [Test]
        [ExpectedException(typeof(AgregarContactoException))]
        public void PruebaComandoAgregarContactoEx()
        {
            Entidad _contactoAgregar = null;
            _comandoBool = FabricaComandos.CrearComandoAgregarContacto(_contactoAgregar);
            _respuesta = _comandoBool.Ejecutar();

        }
        /// <summary>
        /// Método para probar Excepciones en el comando ComandoEliminarContacto de Comandos.M5
        /// </summary>
        [Test]
        [ExpectedException(typeof(EliminarContactoException))]
        public void PruebaComandoEliminarContactoEx()
        {
            Entidad _contactoEliminar = null; 
            _comandoBool = FabricaComandos.CrearComandoEliminarContacto(_contactoEliminar);
            _respuesta = _comandoBool.Ejecutar();

        }

        /// <summary>
        /// Método para probar Excepciones en el comando ComandoModificarContacto de Comandos.M5
        /// </summary>
        [Test]
        [ExpectedException(typeof(ModificarContactoException))]
        public void PruebaComandoModificarContactoEx()
        {
            Entidad _contactoModificar;
            _contactoModificar = null;
            _comandoBool = FabricaComandos.CrearComandoModificarContacto(_contactoModificar);
            _respuesta = _comandoBool.Ejecutar();


        }

        /// <summary>
        /// Método para probar Excepciones en el comando ComandoConsultarContacto de Comandos.M5
        /// </summary>
        [Test]
        [ExpectedException(typeof(ConsultarContactoException))]
        public void PruebaComandoConsultarContactoEx()
        {
            Entidad contacto = null;
            _comandoEntidad = FabricaComandos.CrearComandoConsultarContacto(contacto);
            contacto = _comandoEntidad.Ejecutar();

        }



        /// <summary>
        /// Método para probar Excepciones en el comando ComandoAgregarContactoAProyecto de Comandos.M5
        /// </summary>
        [Test]
        [ExpectedException(typeof(AgregarContactoException))]
        public void PruebaComandoAgregarContactoAProyectoEx()
        {
            _contacto = null;
            Entidad proyecto = FabricaEntidades.ObtenerProyecto();
            proyecto.Id = 1;

            _comandoBool = FabricaComandos.CrearComandoAgregarContactoAProyecto(_contacto, proyecto);
            _respuesta = _comandoBool.Ejecutar();

        }

        /// <summary>
        /// Método para probar Excepciones en el comando ComandoConsultarContactosPorProyecto de Comandos.M5
        /// </summary>
        [Test]
        [ExpectedException(typeof(ConsultarContactoException))]
        public void PruebaComandoConsultarContactosPorProyectoEx()
        {
            Entidad proyecto = null;
            _comandoLista = FabricaComandos.CrearComandoConsultarContactosPorProyecto(proyecto);
            _listaContactos = _comandoLista.Ejecutar();

        }

        /// <summary>
        /// Método para probar Excepciones en el comando ComandoEliminarContactoDeProyecto de Comandos.M5
        /// </summary>
        [Test]
        [ExpectedException(typeof(EliminarContactoException))]
        public void PruebaComandoEliminarContactoDeProyectoEx()
        {
            Entidad proyecto = null;
            _contacto.Id = 5;

            _comandoBool = FabricaComandos.CrearComandoEliminarContactoDeProyecto(_contacto, proyecto);
            _respuesta = _comandoBool.Ejecutar();

        }

        /// <summary>
        /// Método para probar Excepciones en el comando ComandoConsultarContactosNoPertenecenAProyecto de Comandos.M5
        /// </summary>
        [Test]
        [ExpectedException(typeof(ConsultarContactoException))]
        public void PruebaComandoConsultarContactosNoPertenecenAProyectoEx()
        {
            Entidad proyecto = null;
            _comandoLista = FabricaComandos.CrearComandoConsultarContactosNoPertenecenAProyecto(proyecto);
            _listaContactos = _comandoLista.Ejecutar();

        }

        #endregion
    }
}
