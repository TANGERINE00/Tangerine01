using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO.M7;
using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using NUnit.Framework;
using DominioTangerine.Entidades.M7;

namespace PruebasUnitarias.M7
{
    [TestFixture]
    class PruebaDAOProyecto
    {
        #region
        public Entidad _theProject, _checkTheProject, _checkTheProject2, _laPropuesta;
        private List<Entidad> _proyectos;
        public bool _answer;
        public DateTime _fechaInicio;
        public DateTime _fechaFin;
        DatosTangerine.InterfazDAO.M7.IDaoProyecto _daoProyecto;
        int _contador;
        int _cantidad;
        int _ultimoId;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            _fechaInicio = new DateTime(2016, 6, 4);
            _fechaFin = new DateTime(2016, 7, 4);
            _daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
            _theProject = DominioTangerine.Fabrica.FabricaEntidades.CrearProyecto("El proyecto nuevo",
                                   "el-pr1234", _fechaInicio, _fechaFin, 100000, "este es un proyecto de prueba",
                                   "20", "En desarrollo", "Razon de cambio", "Mensual", 1, 1, 1);
            

        }
        [TearDown]
        public void Clean()
        {
            _theProject = null;
            _checkTheProject = null;
            _checkTheProject2 = null;
            _daoProyecto = null;
            _laPropuesta = null;
        }


        #endregion


        /// <summary>
        /// Prueba Unitaria para la agregación de un proyecto en la BD.
        /// </summary>
        [Test]
        public void testAgregarProyecto()
        {
            _contador = _daoProyecto.ConsultarNumeroProyectos();

            IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
          

            Assert.IsTrue(_daoProyecto.Agregar(_theProject));
            Assert.AreEqual(_daoProyecto.ConsultarNumeroProyectos(), _contador + 1);

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


        // <summary>
        //Prueba Unitaria para la eliminación de un proyecto en la BD.
        // <summary>
        [Test]
        public void TestEliminarProyecto()
        {
            //Cantidad de proyectos en la BD.
            _contador = _daoProyecto.ConsultarNumeroProyectos();
            
            Assert.IsTrue(_daoProyecto.Agregar(_theProject));

            //La cantidad de proyectos en la BD aumenta en 1
            Assert.AreEqual(_daoProyecto.ConsultarNumeroProyectos(), _contador+1);
            _ultimoId = _daoProyecto.ContactMaxIdProyecto();
            _theProject.Id = _ultimoId;

            //Eliminación del proyecto
            Assert.IsTrue(_daoProyecto.BorrarProyecto(_ultimoId));
           
            //La cantidad de poyectos en la BD disminuye en 1
            Assert.AreEqual(_daoProyecto.ConsultarNumeroProyectos(), _contador);


            try
            {
                //Se intenta consultar el proyecto eliminado.
                _checkTheProject = _daoProyecto.ConsultarXId(_theProject);
            }
            //No puede ser encontrado.
            catch (ExcepcionesTangerine.M7.ExceptionM7Tangerine e)
            {
                Assert.IsTrue(true);
            }
        }


        // <summary>
        //Prueba unitaria para la modificación de un proyecto
        // <summary>
        [Test]
        public void TestModificarProyecto()
        {
            Assert.IsTrue(_daoProyecto.Agregar(_theProject));
            _ultimoId = _daoProyecto.ContactMaxIdProyecto();
            _theProject.Id = _ultimoId;
            //Se modifica la propuesta
            _checkTheProject = DominioTangerine.Fabrica.FabricaEntidades.CrearProyecto("El proyecto nuevoCAMBIO",
                                   "el-pr1234CAMBIO", _fechaInicio, _fechaFin, 200002, "este es un proyecto de pruebaCAMBIO",
                                   "20CAMBIO", "En desarrolloCAMBIO", "Razon de cambioCAMBIO", "MensualCAMBIO", 1, 1, 1);
            _checkTheProject.Id = _ultimoId;
            Assert.IsTrue(_daoProyecto.Modificar(_checkTheProject));
            _checkTheProject2 = _daoProyecto.ConsultarXId(_theProject);
            //Comparo y confirmo la modificacion
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Nombre == "El proyecto nuevoCAMBIO");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Codigo == "el-pr1234CAMBIO");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Fechainicio == _fechaInicio);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Fechaestimadafin == _fechaFin);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Costo == 200002);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Descripcion == "este es un proyecto de pruebaCAMBIO");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Realizacion == "20CAMBIO");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Estatus == "En desarrolloCAMBIO");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Razon == "Razon de cambioCAMBIO");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Acuerdopago == "MensualCAMBIO");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Idpropuesta == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Idresponsable == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject2).Idgerente == 1);

            //Se elimina el proyecto utilizado en la prueba.
            _answer = _daoProyecto.BorrarProyecto(_ultimoId);
        }

        /// <summary>
        /// Prueba unitaria para la consulta en la BD de un proyecto por ID.
        /// </summary>
        [Test]
        public void TestConsultarProyectotXId()
        {
            //Se inserta la propuesta
            _answer = _daoProyecto.Agregar(_theProject);
            _ultimoId = _daoProyecto.ContactMaxIdProyecto();
            _theProject.Id = _ultimoId;

            _checkTheProject = _daoProyecto.ConsultarXId(_theProject);

            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Nombre == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Nombre);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Codigo == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Codigo);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Fechainicio == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Fechainicio);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Fechaestimadafin == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Fechaestimadafin);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Costo == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Costo);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Descripcion == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Descripcion);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Realizacion == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Realizacion);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Estatus == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Estatus);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Razon == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Razon);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Acuerdopago == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Acuerdopago);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Idpropuesta == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Idpropuesta);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Idresponsable == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Idresponsable);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Idgerente == ((DominioTangerine.Entidades.M7.Proyecto)_checkTheProject).Idgerente);


            //Se elimina el proyecto utilizado en la prueba.
            _answer = _daoProyecto.BorrarProyecto(_ultimoId);
        }

        /// <summary>
        /// Prueba unitaria para la consultar todos los proyectos
        ///  insertados en la BD.
        /// </summary>
        [Test]
        public void TestConsultarTodos()
        {
            //Se consulta la cantidad de proyectos en la BD
            _cantidad = _daoProyecto.ConsultarNumeroProyectos();

            //Se obtiene la lista de todos los proyectos
            _proyectos = _daoProyecto.ConsultarTodos();

            for (int i = 0; i < _proyectos.Count(); i++)
           {
                //Se verifica que ningun proyecto es nulo
               Assert.NotNull(_proyectos[i]);
           }
            //La cantidad de proyectos contados son los mismos que los de la lista
            Assert.IsTrue(_cantidad == _proyectos.Count());

        }

        /// <summary>
        /// Prueba unitaria para generar el codigo de un proyecto
        /// según una propuesta.
        /// </summary>
        [Test]
        public void TestGenerarCodigoProyecto()
        {

            DateTime Date1 = new DateTime(2016, 6, 4);
            DateTime Date2 = new DateTime(2016, 7, 4);
            _laPropuesta =  DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta("NombrePropuestaPrueba",
            "DescripcionProPuestaPrueba", "Meses", "2", "acuerdo", "PendientePrueba", "Dolar", 1, Date1, Date2, 100, "1");

            String codigo = _daoProyecto.GenerarCodigoProyecto(_laPropuesta);

            Assert.IsTrue(codigo=="Proy-Nombre4-2016");
         }

        // /// <summary>
        // /// Prueba el metodo que recupera el nombre de una propuesta dada su id
        // /// </summary>

         [Test]
         public void TestContactNombrePropuestaID()
         {
             _laPropuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
             _laPropuesta.Id = 1;
             Entidad propuesta = _daoProyecto.ContactNombrePropuestaId(_laPropuesta);

             //answer obtiene true si se inserta el contacto, si no, deberia agarrar un excepcion

             Assert.IsTrue(((DominioTangerine.Entidades.M7.Propuesta)propuesta).Nombre == "GNFRNCO160622044206");
          }

  
    }
}
