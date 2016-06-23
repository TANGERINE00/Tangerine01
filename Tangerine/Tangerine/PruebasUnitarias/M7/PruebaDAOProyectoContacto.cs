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
    class PruebaDAOProyectoContacto
    {
        #region
        public Entidad _theProject, _checkTheProject, _checkTheProject2, _laPropuesta;
        private List<Entidad> _empleados;
        private List<Entidad> _contactos;
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
    }
}