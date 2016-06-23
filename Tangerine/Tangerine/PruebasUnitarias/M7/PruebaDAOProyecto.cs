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
        public Entidad _theProject;
        public Entidad _checkTheProject;
        private List<Entidad> _empleados;
        private List<Entidad> _contactos;
        private List<Entidad> _proyectos;
        public bool _answer;
        public DateTime _fechaInicio;
        public DateTime _fechaFin;
        DatosTangerine.InterfazDAO.M7.IDaoProyecto _daoProyecto;
        int _contador;
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
        }


        #endregion


        /// <summary>
        /// Prueba que permite verificar el insertar de un proyecto en la base de datos
        /// </summary>
        [Test]
        public void testAgregarProyecto()
        {
            _contador = _daoProyecto.ConsultarNumeroProyectos();

            IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
          

            Assert.IsTrue(daoProyecto.Agregar(_theProject));
            Assert.AreEqual(_daoProyecto.ConsultarNumeroProyectos(), _contador + 1);


            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Nombre == "El proyecto nuevo");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Codigo == "el-pr1234");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Fechainicio == _fechaInicio);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Fechaestimadafin == _fechaFin);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Costo == 100000);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Descripcion == "este es un proyecto de prueba");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Realizacion == "20");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Estatus== "En desarrollo");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Razon == "Razon de cambio");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Acuerdopago == "Mensual");
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Idpropuesta == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Idresponsable == 1);
            Assert.IsTrue(((DominioTangerine.Entidades.M7.Proyecto)_theProject).Idgerente == 1);


            int ultimoID = _daoProyecto.ContactMaxIdProyecto();
            _answer = _daoProyecto.BorrarProyecto(ultimoID);

        }

    }
}
