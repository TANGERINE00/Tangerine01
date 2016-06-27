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
        #region Atributos
        public Entidad _theProject, _checkTheProject, _checkTheProject2, _laPropuesta;
        private List<Entidad> _empleados;
        private List<Entidad> _contactos;
        public bool _answer;
        public DateTime _fechaInicio;
        public DateTime _fechaFin;
        DatosTangerine.InterfazDAO.M7.IDaoProyecto _daoProyecto;
        DatosTangerine.InterfazDAO.M7.IDaoProyectoContacto _daoProyectoContacto;
        DatosTangerine.InterfazDAO.M5.IDAOContacto _daoContacto;
        int _ultimoId;
        #endregion

        #region SetUp and TearDown
        [SetUp]
        public void init()
        {
            _empleados = new List<Entidad>();
            _contactos = new List<Entidad>();
            _fechaInicio = new DateTime(2016, 6, 4);
            _fechaFin = new DateTime(2016, 7, 4);
            _daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
            _daoProyectoContacto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyectoContacto();
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
                Entidad a = DominioTangerine.Fabrica.FabricaEntidades.crearContactoConId(i,"Istvan", "Bokor",
                    "Departamento", "Gerente", "7654321", "asd@as.com", 1, 1);
                _contactos.Add(a);
            }


            

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
        [Test]
        public void testAgregarContactosProyecto()
        {

            //Se inserta un proyecto en la BD SIN contactos.
            Assert.IsTrue(_daoProyecto.Agregar(_theProject));
            _ultimoId = _daoProyecto.ContactMaxIdProyecto();
            _theProject.Id = _ultimoId;

            //Se verifica que dicho proyecto no tiene contactos asociados.
            Assert.AreEqual((_daoProyectoContacto.ObtenerListaContactos(_theProject)).Count,0);

            //Se le asocia una lista de contactos al proyecto
            ((DominioTangerine.Entidades.M7.Proyecto)_theProject).set_contactos(_contactos);

            //Se agrega en la BD Los contactos de dicho proyecto.
            Assert.IsTrue(_daoProyectoContacto.Agregar(_theProject));

            //Se verifica que se asociaron 2 contactos al proyecto en la BD.
            Assert.AreEqual((_daoProyectoContacto.ObtenerListaContactos(_theProject)).Count, 2);


            //Se elimina el proyecto y contactos utilizado en la prueba.
            foreach (Entidad contacto in _contactos){
             _daoContacto.EliminarContactoDeProyecto(contacto, _theProject);
            }
            _answer = _daoProyecto.BorrarProyecto(_ultimoId);

        }
        #endregion
    }
}