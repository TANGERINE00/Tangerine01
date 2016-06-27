using DominioTangerine;
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
        public Entidad _theProject, _checkTheProject, _checkTheProject2, _laPropuesta;
        private List<Entidad> _proyectos;
        public bool _answer;
        public DateTime _fechaInicio;
        public DateTime _fechaFin;
        DatosTangerine.InterfazDAO.M7.IDaoProyecto _daoProyecto;
        int _contador;
        int _cantidad;
        int _ultimoId;
        private Comando<Entidad> _comandoEntidad;
        private Comando<bool> _comandoBool;
        private Comando<List<Entidad>> _comandoLista;
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
        #endregion


    }
}
